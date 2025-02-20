using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
using System.IO;

namespace Mihoyo_Tools
{
   public static class GlobalVar
    {
        ///代码设计海棠云螭（B站）  小海棠（抖音）
        ///2024-09-28 更新
        ///
        ///
        /// 
        /// <summary>
        /// <param name="StrPath">项目运行目录</param>
        /// </summary>
        public static string tempFolderPath = Path.GetTempPath();
        public static string StrPath = System.Windows.Forms.Application.StartupPath;
        public static string VersionNo= Assembly.GetExecutingAssembly().GetName().Version.ToString();
        public static int    Release = 2;//  0  Alpha 内测版      1  bate 公测版      2  Release 正式版
        public static string Upgrade_ver = "";//升级版本号
        public static string VerContrast = Assembly.GetExecutingAssembly().GetName().Version.ToString();// 版本唯一码
        public static string New_Info = "";

        public static string SoftTitle = "  原神过场动画导出工具 UI";
        public static string USM_dir = "";
        public static string line = "";
        public static string Outdir = "0"; // 0 = 单文件导出  1 = 游戏目录导出  2 = 自定义 usm 目录导出


        public static string AuthorName = "海棠云螭";
        public static string IniName = StrPath + @"\Config.ini";
        public static string GICutscents_path = "";     // GICutscents 路径
        public static string Ffmpeg_path = "";          // Ffmpeg 路径
        public static string Output_path = "";          // 输出目录
        public static string Games_path = "";           // 游戏目录
        public static string USM_Files = "";            // usm 名称
        public static string SelectedFolder;            // 原神 YuanShen.exe 所在目录

        /// <summary>
        /// <param name="Out_Language">输出语言  0 == 中文 ， 1 == 英文 ， 2 == 日语 ， 3 == 韩文</param>
        /// </summary>
        public static string Out_Language = "0";        // 输出语言
        public static string Video_Name = "";           // 输出视频名称
        public static string Command_Usm = "";          // 命令
        public static string Command_Mpeg = "";         // 命令
        public static string Command_Play= "";          // 命令
        public static string Command_Mpeg_Info = "";    // 命令
        public static string Command_cmd = "";          // 命令
        public static string Audio_Name = "";           // 音频名称
        public static string strOutput = "";
        public static string _tempVideo_Name = "";      // 视频临时名字，可能用不到，先放这里吧，懒得删了

        public static bool   isNetworkAvailable;        // 判断网络是否链接 true = 已链接  flase = 未连接

    }
}
