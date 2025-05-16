/*----------------------------------------------------------------
 * 版权所有 (c) 2025 HaiTangYunchi  保留所有权利
 * CLR版本：4.0.30319.42000
 * 公司名称：
 * 命名空间：Mihoyo_Tools.Services
 * 唯一标识：e73da0c7-65fa-4a40-b4ba-22b95aafa4ec
 * 文件名：PresetService
 * 
 * 创建者：海棠云螭
 * 电子邮箱：haitangyunchi@126.com
 * 创建时间：2025/5/15 17:36:07
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
using Mihoyo_Tools.Models;
using Newtonsoft.Json;
using System.IO;
using Mihoyo_Tools.lib;

namespace Mihoyo_Tools.Services
{
    public class PresetService
    {
        private readonly string _presetsFilePath;

        public PresetService()
        {
            _presetsFilePath = $"{VarHelper.Var.StrPath}\\presets.json";
            Directory.CreateDirectory(Path.GetDirectoryName(_presetsFilePath));
        }

        /// <summary>
        /// 保存预设
        /// </summary>
        public void SavePresets(List<Preset> presets)
        {
            string json = JsonConvert.SerializeObject(presets, Formatting.Indented);
            File.WriteAllText(_presetsFilePath, json);
        }

        /// <summary>
        /// 加载预设
        /// </summary>
        public List<Preset> LoadPresets()
        {
            if (!File.Exists(_presetsFilePath))
                return new List<Preset>();

            string json = File.ReadAllText(_presetsFilePath);
            return JsonConvert.DeserializeObject<List<Preset>>(json) ?? new List<Preset>();
        }
    }
}

