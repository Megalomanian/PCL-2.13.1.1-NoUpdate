# PCL NoUpdate Patcher

用于给官方 PCL 2.13.1.1 打“禁用启动器自更新”补丁的 dnlib 小程序。

## 前置条件

- .NET SDK 9.0 或更高版本
- 官方 PCL 2.13.1.1 `Plain Craft Launcher 2.exe`

## 使用

```powershell
dotnet run --project . -- "C:\path\to\Plain Craft Launcher 2.exe" "C:\path\to\Plain Craft Launcher 2.patched.exe" --patch --hint
```

参数：

- `--patch`：必须，执行补丁
- `--hint`：把“检查更新”按钮改为显示固定版本提示
- `--bypass-singleton`：仅用于测试，绕过 PCL 单实例互斥锁（正式版不要使用）

## 补丁内容

- `PCL.ModSecret.UpdateStart` → `ret`
- `PCL.ModSecret.UpdateRestart` → `ret`
- `PCL.ModSecret.UpdateReplace` → `ret`
- `PCL.ModSecret.UpdateCheckByButton` → 显示提示后返回

补丁只修改 IL 方法体，不修改资源、界面或下载相关代码。
