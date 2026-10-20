## PCL 2.13.1.1 NoUpdate（第三方修改版）

PCL 2.99.0.0 因政策与合规原因下架了 MC 下载功能。本版本基于 **PCL 2.13.1.1 正式版**，保留 MC 下载能力，并禁用启动器自动更新，作为政策调整后的替代版本。

> 非官方版本，不代表 PCL 官方或原作者龙腾猫跃的立场。

### 下载

- `PCL-2.13.1.1-NoUpdate.exe` — 直接下载后重命名为 `Plain Craft Launcher 2.exe`，覆盖原文件即可。
- `PCL-2.13.1.1-NoUpdate.zip` — 包含 exe、说明和许可证，解压后覆盖。

### 安装

1. 完全退出 PCL，确认任务管理器中没有 PCL 进程。
2. 把 exe 重命名为 `Plain Craft Launcher 2.exe`。
3. 拖入原 PCL 文件夹，选择“替换目标中的文件”。
4. 启动。原配置、账号和游戏目录会继续使用。

### 本版本改动

- 保留 MC 下载、安装，以及 Mod、整合包、资源包等下载功能。
- `UpdateStart`、`UpdateRestart`、`UpdateReplace` 置空，启动器无法下载或替换自身。
- “检查更新”只显示固定版本提示，不联网、不下载。
- 未修改界面、主题、下载源、账号登录或游戏启动逻辑。

### 校验

```text
SHA256  46815B33B11DCC46738115DCEE5560BB8682F553D196DB2A322434C8D67DC24B
```

### 原作者与许可

PCL 由 **龙腾猫跃（LTCat）** 开发。本项目遵循 PCL 的《PCL 分发使用指南》，为第三方修改版本，保留原作者署名与赞助入口，并公开补丁源码。

- PCL 官网：<https://meloong.com/pcl>
- PCL 源码：<https://github.com/Meloong-Git/PCL>
- 爱发电：<https://meloong.com/afd/a/LTCat>
