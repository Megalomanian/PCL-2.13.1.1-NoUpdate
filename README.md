# PCL 2.13.1.1 NoUpdate（第三方修改版）

> **非官方版本。** 本项目不是 PCL 官方发布，也不代表原作者龙腾猫跃的立场。

## 下载

- **[下载 PCL 2.13.1.1 NoUpdate（zip，推荐）](https://github.com/Megalomanian/PCL-2.13.1.1-NoUpdate/releases/latest/download/PCL-2.13.1.1-NoUpdate.zip)**
- [直接下载 exe](https://github.com/Megalomanian/PCL-2.13.1.1-NoUpdate/releases/latest/download/Plain.Craft.Launcher.2.exe)

下载后解压到独立文件夹，不要覆盖官方 PCL 2.99 的文件。

## 背景

PCL 2.99.0.0 因政策与合规原因下架了 MC 下载功能。本版本基于此前的 **PCL 2.13.1.1 正式版**，保留 MC 下载能力，并禁用启动器自动更新，作为仍需要下载功能的用户的替代版本。

## 本版本改动

- 保留 PCL 2.13.1.1 的 MC 下载、安装，以及 Mod、整合包、资源包等下载功能。
- 禁用启动器自动更新：`UpdateStart`、`UpdateRestart`、`UpdateReplace` 均置空，无法下载或替换启动器自身。
- 手动点击“检查更新”时只显示固定版本提示，不联网检查、不下载更新包。
- 未修改界面、主题、下载源、账号登录或游戏启动逻辑。

## 文件与校验

- `Plain Craft Launcher 2.exe`（PCL 2.13.1.1，第三方修改版）
- SHA256：`46815B33B11DCC46738115DCEE5560BB8682F553D196DB2A322434C8D67DC24B`
- 原始版本：PCL 2.13.1.1 正式版（2026-08-06，2.99.0.0 之前的最后一个稳定版）

## 使用方法

1. 将压缩包解压到一个独立文件夹，**不要覆盖官方 PCL 2.99 的文件**。
2. 先退出正在运行的 PCL（PCL 使用单实例互斥锁，同时运行会提示“另一个 PCL 实例正在运行”）。
3. 双击 `Plain Craft Launcher 2.exe` 启动。
4. 首次启动后可在“设置”中把游戏目录、Java、账号等配置为常用值，或直接复用原有 `.minecraft` 目录。

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
