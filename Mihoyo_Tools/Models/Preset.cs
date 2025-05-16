/*----------------------------------------------------------------
 * 版权所有 (c) 2025 HaiTangYunchi  保留所有权利
 * CLR版本：4.0.30319.42000
 * 公司名称：
 * 命名空间：Mihoyo_Tools.Models
 * 唯一标识：ecfd421a-4415-4339-b705-c567bf3c3ad9
 * 文件名：Preset
 * 
 * 创建者：海棠云螭
 * 电子邮箱：haitangyunchi@126.com
 * 创建时间：2025/5/15 17:35:24
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

// Models/Preset.cs
namespace Mihoyo_Tools.Models
{
    /// <summary>
    /// 预设配置
    /// </summary>
    public class Preset
    {
        public string Name { get; set; }
        public string VideoCodec { get; set; } = "libx264";
        public string Resolution { get; set; } = "1920:1080";
        public string Bitrate { get; set; } = "18";
        public string fps { get; set; } = "30";
    }
}
