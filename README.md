# PCL 2.13.1.1 NoUpdate（第三方修改版）

> **非官方版本。** 本项目不是 PCL 官方发布，也不代表原作者龙腾猫跃的立场。

## 下载

🌐 **项目主页 / 下载页：<https://megalomanian.github.io/PCL-2.13.1.1-NoUpdate/>**

- **[下载 PCL 2.13.1.1 NoUpdate（zip，推荐）](https://github.com/Megalomanian/PCL-2.13.1.1-NoUpdate/releases/latest/download/PCL-2.13.1.1-NoUpdate.zip)**
- [直接下载 exe（文件名：`Plain Craft Launcher 2.exe`）](https://megalomanian.github.io/PCL-2.13.1.1-NoUpdate/downloads/Plain%20Craft%20Launcher%202.exe)

> GitHub Release 会自动把附件名中的空格替换成点，所以 Release 里的 exe 附件显示为 `Plain.Craft.Launcher.2.exe`。需要精确文件名时，请使用上面的下载页链接或 zip。

## 安装（直接覆盖官方 PCL）

1. **完全退出 PCL**：关闭 PCL 窗口，并确认任务管理器中没有 PCL 进程。
2. 下载 exe，文件名已经是 `Plain Craft Launcher 2.exe`，不需要改名。
3. 将文件拖入原 PCL 所在文件夹，选择“替换目标中的文件”。
4. 双击 `Plain Craft Launcher 2.exe` 启动。

覆盖后，原有的配置、账号、游戏目录和 `.minecraft` 都会继续使用，不需要重新设置。

如果替换时提示“文件正在使用”，说明 PCL 还没有完全退出，请在任务管理器中结束 PCL 进程后重试。

## 背景

PCL 2.99.0.0 因政策与合规原因下架了 MC 下载功能。本版本基于此前的 **PCL 2.13.1.1 正式版**，保留 MC 下载能力，并禁用启动器自动更新，作为仍需要下载功能的用户的替代版本。

## 本版本改动

- 保留 PCL 2.13.1.1 的 MC 下载、安装，以及 Mod、整合包、资源包等下载功能。
- 禁用启动器自动更新：`UpdateStart`、`UpdateRestart`、`UpdateReplace` 均置空，无法下载或替换启动器自身。
- 手动点击“检查更新”时只显示固定版本提示，不联网检查、不下载更新包。
- 未修改界面、主题、下载源、账号登录或游戏启动逻辑。

## 文件与校验

- 下载文件：`Plain Craft Launcher 2.exe`（直接下载或 zip 内文件，可直接覆盖）
- SHA256：`46815B33B11DCC46738115DCEE5560BB8682F553D196DB2A322434C8D67DC24B`
- 原始版本：PCL 2.13.1.1 正式版（2026-08-06，2.99.0.0 之前的最后一个稳定版）

## 补丁说明

本版本通过 dnlib 修改官方 PCL 2.13.1.1 程序集中的以下方法：

| 方法 | 修改 |
| --- | --- |
| `PCL.ModSecret.UpdateStart` | 直接返回，禁止下载/安装启动器更新 |
| `PCL.ModSecret.UpdateRestart` | 直接返回，禁止启动更新替换进程 |
| `PCL.ModSecret.UpdateReplace` | 直接返回，禁止替换启动器文件 |
| `PCL.ModSecret.UpdateCheckByButton` | 改为显示固定版本提示，不再联网检查 |

补丁工具源码位于 [`patcher/`](patcher/) 目录，可自行审阅或复现：

```powershell
dotnet run --project patcher -- <官方 PCL 2.13.1.1.exe> <输出.exe> --patch --hint
```

## 原作者与许可

PCL 由 **龙腾猫跃（LTCat）** 开发，本项目仅在其官方 2.13.1.1 正式版基础上做上述最小修改。

- PCL 官网 / 下载：<https://meloong.com/pcl>
- PCL 源代码：<https://github.com/Meloong-Git/PCL>
- 爱发电：<https://meloong.com/afd/a/LTCat>

本项目遵循 PCL 的《PCL 分发使用指南》（见 [LICENCE](LICENCE)），作为第三方修改版本：

- 名称以 **Plain Craft Launcher (PCL)** 开头并注明修改；
- 非官方产物，不代表官方提供；
- 保留原程序的作者署名与赞助入口，未移除或修改 About 页面中的相关链接；
- 公开本项目的修改内容与补丁源码；
- 不包含与 PCL 赞助解锁类似的功能，界面主色相保持蓝色。

如果条件允许，请支持原作者：<https://meloong.com/afd/a/LTCat>
