/*----------------------------------------------------------------
 * 版权所有 (c) 2025 HaiTangYunchi  保留所有权利
 * CLR版本：4.0.30319.42000
 * 公司名称：
 * 命名空间：Mihoyo_Tools
 * 唯一标识：383d6d76-d07a-40dd-8cb8-9cf7d81c7ed4
 * 文件名：JsonHelper
 * 
 * 创建者：海棠云螭
 * 电子邮箱：haitangyunchi@126.com
 * 创建时间：2025/3/31 16:57:02
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
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Reflection;
using static Mihoyo_Tools.lib.JsonHelper;
using System.Text.Json.Nodes;
using Json.Path;
using Newtonsoft.Json.Linq;

namespace Mihoyo_Tools.lib
{
    class JsonHelper
    {

        public class AppConfig
        {
            public string UsmKey { get; set; }
            public string GICutscennts_path { get; set; }
            public string FFmpeg_path { get; set; }
            public string Output_path { get; set; }
            public string Games_path { get; set; }
            public string USM_path { get; set; }
            public int Language { get; set; }

            public static implicit operator JToken(AppConfig v)
            {
                throw new NotImplementedException();
            }
        }
        public class SoftInfo
        {
            public string author { get; set; }
            public string mandatoryUpdate { get; set; }
            public string softwareMd5 { get; set; }
            public string softwareName { get; set; }
            public string notice { get; set; }
            public string usmkeyInfo { get; set; } 
            public string softwareId { get; set; }
            public string downloadLink { get; set; }
            public string versionInformation { get; set; }
            public string versionNumber { get; set; }
            public string numberOfVisits { get; set; }
            public string miniVersion { get; set; }
            public string timeStamp { get; set; }
            public string networkVerificationId { get; set; }
            public string isItEffective { get; set; }
            public string numberOfDays { get; set; }
            public string networkVerificationRemarks { get; set; }
            public string expirationDate { get; set; }
            public string bilibiliLink { get; set; }

            public static implicit operator JToken(SoftInfo v)
            {
                throw new NotImplementedException();
            }
        }
        #region JSON 文件读写
        // JSON 序列化选项（格式化输出）
        private static readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            WriteIndented = true, // 格式化输出
            PropertyNameCaseInsensitive = true // 不区分大小写
        };

        /// <summary>
        /// 读取 JSON 文件并反序列化为对象
        /// </summary>
        /// <typeparam name="T">返回的数据类型</typeparam>
        /// <param name="filePath">JSON 文件路径</param>
        /// <param name="defaultValue">如果文件不存在，返回的默认值</param>
        /// <returns>反序列化后的对象</returns>
        public static T ReadJson<T>(string filePath, T defaultValue = default)
        {
            try
            {
                if (!File.Exists(filePath))
                    return defaultValue;

                string json = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<T>(json, _jsonOptions);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"读取 JSON 文件失败: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// 写入 JSON 文件（覆盖或创建）
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="filePath">文件路径</param>
        /// <param name="data">要写入的数据</param>
        public static void WriteJson<T>(string filePath, T data)
        {
            try
            {
                string directory = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(directory))
                    Directory.CreateDirectory(directory);

                string json = JsonSerializer.Serialize(data, _jsonOptions);
                File.WriteAllText(filePath, json);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"写入 JSON 文件失败: {ex.Message}", ex);
            }
        }
        

        /// <summary>
        /// 合并 JSON 数据（更新或新增字段）
        /// </summary>
        /// <param name="filePath">JSON 文件路径</param>
        /// <param name="newData">要合并的新数据（匿名对象或字典）</param>
        public static void MergeJson(string filePath, object newData)
        {
            try
            {
                // 读取现有 JSON，如果不存在则创建新对象
                JsonNode root = File.Exists(filePath)
                    ? JsonNode.Parse(File.ReadAllText(filePath))
                    : new JsonObject();

                // 将新数据转换为 JsonNode 并合并
                JsonNode newNode = JsonSerializer.SerializeToNode(newData);
                MergeJsonNodes(root, newNode);

                // 写回文件
                File.WriteAllText(filePath, root.ToJsonString(_jsonOptions));
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"合并 JSON 失败: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// 递归合并两个 JsonNode
        /// </summary>
        private static void MergeJsonNodes(JsonNode target, JsonNode source)
        {
            if (source is JsonObject sourceObj && target is JsonObject targetObj)
            {
                // 合并对象
                foreach (var property in sourceObj)
                {
                    if (targetObj.ContainsKey(property.Key))
                    {
                        MergeJsonNodes(targetObj[property.Key], property.Value);
                    }
                    else
                    {
                        targetObj[property.Key] = property.Value.DeepClone();
                    }
                }
            }
            else if (source is JsonArray sourceArray && target is JsonArray targetArray)
            {
                // 合并数组（这里选择追加）
                foreach (var item in sourceArray)
                {
                    targetArray.Add(item.DeepClone());
                }
            }
            else
            {
                // 非对象/数组类型（如 string, number, bool），直接替换
                if (target.Parent is JsonObject parentObj)
                {
                    string propertyName = target.GetPropertyName();
                    if (propertyName != null)
                    {
                        parentObj[propertyName] = source.DeepClone();
                    }
                }
                else if (target.Parent is JsonArray parentArray)
                {
                    int index = parentArray.IndexOf(target);
                    if (index >= 0)
                    {
                        parentArray[index] = source.DeepClone();
                    }
                }
                else
                {
                    // 如果是根节点，直接替换整个 JSON
                    target = source.DeepClone();
                }
            }
        }

        /// <summary>
        /// 向 JSON 数组追加数据
        /// </summary>
        /// <typeparam name="T">数组元素类型</typeparam>
        /// <param name="filePath">JSON 文件路径</param>
        /// <param name="item">要追加的元素</param>
        public static void AppendToJsonArray<T>(string filePath, T item)
        {
            try
            {
                List<T> list;

                // 如果文件不存在，创建新列表
                if (!File.Exists(filePath))
                {
                    list = new List<T>();
                }
                else
                {
                    // 读取现有列表
                    string json = File.ReadAllText(filePath);
                    list = JsonSerializer.Deserialize<List<T>>(json);
                }

                // 追加新元素并写回
                list.Add(item);
                File.WriteAllText(filePath, JsonSerializer.Serialize(list, _jsonOptions));
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"追加 JSON 数组失败: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// 使用 JSON Path 修改指定字段
        /// </summary>
        /// <param name="filePath">JSON 文件路径</param>
        /// <param name="jsonPath">JSON Path 表达式（如 `$.user.name`）</param>
        /// <param name="newValue">新值</param>
        public static void UpdateByJsonPath(string filePath, string jsonPath, object newValue)
        {
            try
            {
                // 读取 JSON
                string json = File.Exists(filePath) ? File.ReadAllText(filePath) : "{}";
                JsonNode root = JsonNode.Parse(json);

                // 解析 JSON Path 并更新
                var path = JsonPath.Parse(jsonPath);
                var results = path.Evaluate(root);
                foreach (var match in results.Matches)
                {
                    match.Value.ReplaceWith(JsonSerializer.SerializeToNode(newValue));
                }

                // 写回文件
                File.WriteAllText(filePath, root.ToJsonString(_jsonOptions));
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"JSON Path 更新失败: {ex.Message}", ex);
            }
        }
        #endregion

    }
}

