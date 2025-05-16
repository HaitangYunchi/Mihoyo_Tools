/*----------------------------------------------------------------
 * 版权所有 (c) 2025 HaiTangYunchi  保留所有权利
 * CLR版本：4.0.30319.42000
 * 公司名称：
 * 命名空间：Mihoyo_Tools.Models
 * 唯一标识：334b53e1-5cb4-4795-bf15-c513f45716d1
 * 文件名：FFmpegProcessResult
 * 
 * 创建者：海棠云螭
 * 电子邮箱：haitangyunchi@126.com
 * 创建时间：2025/5/15 17:33:13
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

namespace Mihoyo_Tools.Models
{
    /// <summary>
    /// FFmpeg处理结果
    /// </summary>
    public class FFmpegProcessResult
    {
        public bool Success { get; set; }
        public string Output { get; set; }
        public string Error { get; set; }
        public TimeSpan Duration { get; set; }
    }
}

