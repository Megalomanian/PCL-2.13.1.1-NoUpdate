using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using dnlib.DotNet.Writer;

internal static class Program
{
    private static int Main(string[] args)
    {
        if (args.Length < 1)
        {
            Console.WriteLine("usage: PclPatcher <input.exe> [output.exe] [--patch] [--hint] [--bypass-singleton]");
            return 1;
        }

        string input = Path.GetFullPath(args[0]);
        string output = args.Length > 1 && !args[1].StartsWith("--", StringComparison.Ordinal)
            ? Path.GetFullPath(args[1])
            : input + ".patched.exe";
        bool patch = args.Contains("--patch");
        bool hint = args.Contains("--hint");
        bool bypassSingleton = args.Contains("--bypass-singleton");

        using var module = ModuleDefMD.Load(input);
        Console.WriteLine($"Assembly: {module.Assembly?.FullName}");
        Console.WriteLine($"PublicKey: {(module.Assembly?.PublicKey?.Data?.Length ?? 0)} bytes");
        Console.WriteLine($"Runtime: {module.RuntimeVersion}");

        var type = module.GetTypes().FirstOrDefault(t => t.FullName == "PCL.ModSecret")
                   ?? throw new InvalidOperationException("PCL.ModSecret not found");

        if (!patch)
        {
            foreach (var method in type.Methods.Where(m => m.Name.String.Contains("Update", StringComparison.Ordinal) ||
                                                          m.Name.String.Contains("Server", StringComparison.Ordinal)))
            {
                Console.WriteLine($"METHOD {method.MDToken} {method.FullName} | params={method.Parameters.Count} | body={(method.HasBody ? method.Body.Instructions.Count : -1)}");
            }
            return 0;
        }

        PatchToReturn(type, "UpdateStart");
        PatchToReturn(type, "UpdateReplace");
        PatchToReturn(type, "UpdateRestart");

        if (hint)
        {
            PatchUpdateCheckHint(module, type);
        }

        if (bypassSingleton)
        {
            var appType = module.GetTypes().First(t => t.FullName == "PCL.Application");
            PatchToReturn(appType, "WaitingMutex");
        }

        var options = new ModuleWriterOptions(module)
        {
            MetadataOptions = { Flags = MetadataFlags.PreserveAll },
            Logger = DummyLogger.NoThrowInstance
        };
        module.Write(output, options);
        Console.WriteLine($"Patched: {output}");
        return 0;
    }

    private static void PatchToReturn(TypeDef type, string name)
    {
        var methods = type.Methods.Where(m => m.Name == name).ToList();
        if (methods.Count == 0)
        {
            throw new InvalidOperationException($"Method {name} not found in {type.FullName}");
        }

        foreach (var method in methods)
        {
            if (!method.HasBody)
            {
                throw new InvalidOperationException($"Method {method.FullName} has no body");
            }

            var body = method.Body;
            body.ExceptionHandlers.Clear();
            body.Variables.Clear();
            body.Instructions.Clear();
            body.Instructions.Add(OpCodes.Ret.ToInstruction());
            body.UpdateInstructionOffsets();
            body.OptimizeMacros();
            Console.WriteLine($"PATCHED {method.FullName} -> ret");
        }
    }

    private static void PatchUpdateCheckHint(ModuleDef module, TypeDef secretType)
    {
        var method = secretType.Methods.FirstOrDefault(m => m.Name == "UpdateCheckByButton")
                     ?? throw new InvalidOperationException("UpdateCheckByButton not found");
        var mainType = module.GetTypes().First(t => t.FullName == "PCL.ModMain");
        var hintMethod = mainType.Methods.FirstOrDefault(m => m.Name == "Hint" && m.MethodSig.Params.Count == 3)
                         ?? throw new InvalidOperationException("ModMain.Hint(string, HintType, bool) not found");

        var body = method.Body;
        body.ExceptionHandlers.Clear();
        body.Variables.Clear();
        body.Instructions.Clear();
        body.Instructions.Add(OpCodes.Ldstr.ToInstruction("此版本已固定，不会检查或安装启动器更新。"));
        body.Instructions.Add(OpCodes.Ldc_I4_0.ToInstruction());
        body.Instructions.Add(OpCodes.Ldc_I4_1.ToInstruction());
        body.Instructions.Add(OpCodes.Call.ToInstruction(hintMethod));
        body.Instructions.Add(OpCodes.Ret.ToInstruction());
        body.UpdateInstructionOffsets();
        body.OptimizeMacros();
        Console.WriteLine($"PATCHED {method.FullName} -> hint + ret");
    }
}
