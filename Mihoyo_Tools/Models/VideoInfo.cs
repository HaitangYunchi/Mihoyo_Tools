/*----------------------------------------------------------------
 * 版权所有 (c) 2025 HaiTangYunchi  保留所有权利
 * CLR版本：4.0.30319.42000
 * 公司名称：
 * 命名空间：Mihoyo_Tools.Models
 * 唯一标识：79f826ff-efb8-4b9c-a735-6979027e033c
 * 文件名：VideoInfo
 * 
 * 创建者：海棠云螭
 * 电子邮箱：haitangyunchi@126.com
 * 创建时间：2025/5/15 17:35:36
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// Models/VideoInfo.cs
namespace Mihoyo_Tools.Models
{
    /// <summary>
    /// 视频信息
    /// </summary>
    public class VideoInfo
    {
        public string FilePath { get; set; }
        public string Format { get; set; }
        public TimeSpan Duration { get; set; }
        public string Resolution { get; set; }
        public string VideoCodec { get; set; }
        public string AudioCodec { get; set; }
        public double FrameRate { get; set; }
        public string Bitrate { get; set; }
    }
}