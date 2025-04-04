#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (c) 2025 HaiTangYunchi  保留所有权利
 * CLR版本：4.0.30319.42000
 * 公司名称：
 * 命名空间：Mihoyo_Tools
 * 唯一标识：03f5f629-6e9d-4011-88bc-d48eec3badaf
 * 文件名：VarHelper
 * 
 * 创建者：海棠云螭
 * 电子邮箱：haitangyunchi@126.com
 * 创建时间：2025/3/31 16:50:09
 * 版本：V1.0.0
 * 描述：
 *
 * ----------------------------------------------------------------
 * 修改人：
 * 时间：
 * 修改说明：
 *
 * 版本：V1.0.1
 *----------------------------------------------------------------*/
#endregion << 版 本 注 释 >>

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Mihoyo_Tools.lib
{

    class VarHelper
    {
        
        public class Var
        {
            //代码设计海棠云螭（B站）  小海棠（抖音）
            //2025-09-28 更新

            public static string tempFolderPath = Path.GetTempPath();
            /// <summary>
            /// <param name="StrPath">项目运行目录</param>
            /// </summary>
            public static string StrPath = System.Windows.Forms.Application.StartupPath;
            public static int Release = 1;//  0  Alpha 内测版      1  bate 公测版      2  Release 正式版
            public static string VersionNo = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            public static string SoftTitle = "米哈游工具箱";
            public static string USM_path = "";//自定义usm目录
            public static string line = "";
            public static int Outdir = 0; // 0 = 单文件导出  1 = 游戏目录导出  2 = 自定义 usm 目录导出
            public static string AuthorName = "海棠云螭";
            public static string Setting = StrPath + @"Setting.json";
            public static string GICutscents_path = StrPath + @"data\GICutscenes.exe";     // GICutscents 路径
            public static string Ffmpeg_path = StrPath + @"data\ffmpeg.exe";          // Ffmpeg 路径
            public static string Output_path = "";          // 输出目录
            public static string Games_path = "";           // 游戏目录
            public static string USM_Files = "";            // usm 名称
            public static string SelectedFolder;            // 原神 YuanShen.exe 所在目录
            public static string usmkey= "5.5.0";
            public static string VersionPath = StrPath+ @"data\versions.json";

            /// <summary>
            /// <param name="Out_Language">输出语言  0 == 中文 ， 1 == 英文 ， 2 == 日语 ， 3 == 韩文</param>
            /// </summary>
            public static int Language = 0;        // 输出语言
            public static string Video_Name = "";           // 输出视频名称
            public static string Command_Usm = "";          // 命令
            public static string Command_Mpeg = "";         // 命令
            public static string Command_Play = "";          // 命令
            public static string Command_Mpeg_Info = "";    // 命令
            public static string Command_cmd = "";          // 命令
            public static string Audio_Name = "";           // 音频名称
            public static string strOutput = "";

            public static string genshin = StrPath + @"\Mihoyo\Genshin.dat";
            public static string genshinCloud = StrPath + @"\Mihoyo\GenshinCloud.dat";
            public static string genshinOversea = StrPath + @"\Mihoyo\GenshinOversea .dat";
            public static string HonkaiImpact3 = StrPath + @"\Mihoyo\BH3.dat";
            public static string StarRail = StrPath + @"\Mihoyo\StarRail.dat";
            public static string StarRailOversea = StrPath + @"\Mihoyo\StarRailOversea.dat";
            public static string ZZZ = StrPath + @"\Mihoyo\ZZZ.dat";
            public static string ZZZOversea = StrPath + @"\Mihoyo\ZZZOversea.dat";

            #region 常量
            public const string KeyGenshin = "KeyHaiTangYunchiPK9SAUq0txQh1NV4WyJVZjz0g3YnHSPibmYWQqJn3i4kxtlZWYHCAowRwOobBLTPAnWTV99NJHE6AuZoyZ8ziefsblLbqEbSsmm0RRyuPdMhNdZQQ0qfQynP3aj9rpZD9fMToHyfytY16NtCIj5ykkgGSCHcPf6qcH9ho6TZKcV0ALsLNNhn3qaN0ujYD1iseo1TaeM0IsYs1b8elK4g6iEWyGwKsijqSyRZsmNrCx4VriLZ";
            public const string KeyGenshinCloud = "KeyHaiTangYunchiDCBBN48xLwexmD5r8IbCIAS10BowGHupz6A8QEmpi1eaptNPxuDueRTQIBFpWmhFUI25ShwzGLjik248hd5HZ3IjSy6hvo79h7hngbyeZT0M4RgORJnsydcViYImOEKJWHrRGjdFA8mcKCmON7K7fPV1MADKxdiyMB2vgWNcVhuKccRhaKmdNzDqnYwMQXOWqXOIpz1XB8c9JVaKjiXxciFCOE9Znl1jyY8LCF5O9ng2WJbI";
            public const string KeyGenshinOversea = "KeyHaiTangYunchi8HqUFiuCFRGNS0VUqW5ao2jADnk5uDa1rKGZ6APLHwhmf4uc1zjv0HQUeorrWaEZCl5VaysKb0NZLj88WnmGQzr7T6irCU9NtybDs3yv7kL5dN4B6Yd0LflBOueHBTpTxAU8ckXEcMsHaiTangYunchiNvbMUlMj1KNRj1ucwsGizYMxE9ZZD1X0hj1RzbpK3DOvtGuXWYFPD0YGSWupPsx3gRmj7weV7V7PSi7tE5Kfdh04";
            public const string KeyHonkaiImpact3 = "KeyHaiTangYunchiYToqUVqcdHaiTangYunchi9n5zZaRndQvPHWihOw2kdgVKC985T70oBaBxxGDU6bPOn21EjrJ18Aa5zTsZQGWFR2NWJyVwFTizTdQADdNDH0MWmJwmTO8rGViKVgI55dUD9lEMMbobnKHscJDmHPqNyUleqQdsEvbVZuTvsqWgViOgVKjJg88OBKQgF3GW2st8mZjRnioV8GAvL0Yf8KA6mrNBoySBz9gODi2TlMhVDpylPj";
            public const string KeyStarRail = "KeyHaiTangYunchiFkoJAKXESdMZtN1qQLyVJTbgJ1y56qXI18OEfoA4v1thmIs7msb0vG8ZurKAkHaiTangYunchiNVMdDrkAQPufeXUooCvL6AMKWh8ijFRDgW8gdCTOzU38MlE5Zw5kWTDDY6ersWt6BqOVd9BNBzEYwb2xjpvLUfxP8BY9m75lAsqDq6Id4jGMq5iOn0QtWS8u4KlivvhHj8YvJBXH4EiOX6QtT2SiWE7BC10j91CbmsXucW";
            public const string KeyStarRailOversea = "KeyHaiTangYunchiKotAX898cVFOiGNU2SyKwd3m4hXIUOaJAMtYzpaphQpdkQU5AQFTuWobzX18lNl3LsZ5y55IqBFsurfYxkTwA69awWkEuxYMNQwaH2N81BGACTyX0sizPwvxgc0Mxq1DJNHaiTangYunchiA191x9jOUqRxt5nal0dndw8P7jNWkgjFbFhwBNejCbaFaFSI17ATVX5i0JD5j0vXA5DOpLZ4eunf3fIdDLMhb8YTOAO1rlU7H";
            public const string KeyZZZ = "KeyHaiTangYunchiEpas9LP8KdXBEa0HlOvSh8kLB9suaI9XWRKUup5k4WVbDZ3okeCGsrenp2T7f9ava5tI5QeAOfHaiTangYunchiqcxAGWdlQWViCrPYKPRmKH7Vzkhq5wQ8iEr6QFBzptQp6PNMSCZ6iJziFbdQVZENmqfaNDohexP4nZtKwts5ushTfbTjqzCn516gvSwFJdm3u9ybK35AztR7RX4MeiJz4irn0syMgF3fcsZLEPAG3mmj8";
            public const string KeyZZZOversea = "KeyHaiTangYunchiQJO80NmZI44AD7mpaNrQWJyHr5Q5s3LJmEA9BK7iQGaXcuDZpb5HaiTangYunchikj758UVj13pyeGt9wGrf2A1qlZmUxsaA4PMwFe0WFtmobRHKMx4H9ug9efyyWfa2BHGP4QpTHFbw4F2Pe12FyVbhnjVNLF83Rd3flMc2712ZlpVn7rnsGRn1utiC1mSLYln3naSYo7yEkBT73lWv6om7GJ7xanPzFidzxLV4PKZns2Es";

            public const string Genshin_REG_PATH = @"Software\miHoYo\原神";
            public const string GenshinCloud_REG_PATH = @"Software\miHoYo\云·原神";
            public const string GenshinOversea_REG_PATH = @"Software\miHoYo\Genshin Impact";
            public const string HonkaiImpact3_REG_PATH = @"Software\miHoYo\崩坏3";
            public const string StarRail_REG_PATH = @"Software\miHoYo\崩坏：星穹铁道";
            public const string StarRailOversea_REG_PATH = @"Software\Cognosphere\Star Rail";
            public const string ZZZ_REG_PATH = @"Software\miHoYo\绝区零";
            public const string ZZZOversea_REG_PATH = @"Software\Cognosphere\ZZZ";
            #endregion
            public static string Control_Web = "http://space.bilibili.com/3493128132626725";
            //public static string id = "AE72DEEE2BDF489DACC17D39D8D2C65E";//测试的时候换这个 ID

            public static string id = "1B3BBA3F795047C5B4C278B2CE28A17B";//软件ID 不要修改
            public static string key = "C727432CEB7047B580131B53D5C7FD9F";
        }
    }
}
