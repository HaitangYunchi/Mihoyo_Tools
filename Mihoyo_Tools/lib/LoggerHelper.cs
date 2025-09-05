/*----------------------------------------------------------------
 * 版权所有 (c) 2025 HaiTangYunchi  保留所有权利
 * CLR版本：4.0.30319.42000
 * 公司名称：HaiTangYunchi
 * 命名空间：Mihoyo_Tools.lib
 * 唯一标识：c69a5371-62de-4523-a45f-bf1d1b6df8af
 * 文件名：LoggerHelper
 * 
 * 创建者：海棠云螭
 * 电子邮箱：haitangyunchi@126.com
 * 创建时间：2025/9/5 23:16:36
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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mihoyo_Tools.lib
{
    class LoggerHelper
    {
        private static readonly object _lock = new object();
        private static readonly string LogDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");

        public enum LogLevel
        {
            INFO,
            WARN,
            ERROR
        }

        public static void Log(string message, LogLevel level = LogLevel.INFO)
        {
            Task.Run(() => // 异步写入避免阻塞UI
            {
                lock (_lock)
                {
                    try
                    {
                        if (!Directory.Exists(LogDirectory))
                            Directory.CreateDirectory(LogDirectory);

                        string logFile = Path.Combine(LogDirectory, $"log_{DateTime.Now:yyyyMMdd}.log");
                        string logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{level}] {message}{Environment.NewLine}";

                        File.AppendAllText(logFile, logMessage);
                    }
                    catch (Exception ex)
                    {
                        // 日志记录失败处理（可选）
                        Console.WriteLine($"日志写入失败: {ex.Message}");
                    }
                }
            });
        }

    }
}
