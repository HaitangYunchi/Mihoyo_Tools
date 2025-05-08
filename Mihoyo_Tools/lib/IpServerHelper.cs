/*----------------------------------------------------------------
 * 版权所有 (c) 2025 HaiTangYunchi  保留所有权利
 * CLR版本：4.0.30319.42000
 * 公司名称：
 * 命名空间：Mihoyo_Tools.lib
 * 唯一标识：565969f9-0424-4306-ab60-d2089579dda2
 * 文件名：IpServerHelper
 * 
 * 创建者：海棠云螭
 * 电子邮箱：haitangyunchi@126.com
 * 创建时间：2025/4/4 21:07:11
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
using DevExpress.Data.Details;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace Mihoyo_Tools.lib
{
    /// <summary>
    /// 对应 https://ipapi.co/json/ 返回的数据结构
    /// </summary>
    public class IpApiResponse
    {
        [JsonPropertyName("ip")]
        public string Ip { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("region")]
        public string Region { get; set; }

        [JsonPropertyName("region_code")]
        public string RegionCode { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("country_name")]
        public string CountryName { get; set; }

        [JsonPropertyName("country_code")]
        public string CountryCode { get; set; }

        [JsonPropertyName("country_code_iso3")]
        public string CountryCodeIso3 { get; set; }

        [JsonPropertyName("country_capital")]
        public string CountryCapital { get; set; }

        [JsonPropertyName("country_tld")]
        public string CountryTld { get; set; }

        [JsonPropertyName("continent_code")]
        public string ContinentCode { get; set; }

        [JsonPropertyName("postal")]
        public string Postal { get; set; }

        [JsonPropertyName("latitude")]
        public double Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public double Longitude { get; set; }

        [JsonPropertyName("timezone")]
        public string Timezone { get; set; }

        [JsonPropertyName("utc_offset")]
        public string UtcOffset { get; set; }

        [JsonPropertyName("country_calling_code")]
        public string CountryCallingCode { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("currency_name")]
        public string CurrencyName { get; set; }

        [JsonPropertyName("languages")]
        public string Languages { get; set; }

        [JsonPropertyName("country_area")]
        public double CountryArea { get; set; }

        [JsonPropertyName("country_population")]
        public int CountryPopulation { get; set; }

        [JsonPropertyName("asn")]
        public string Asn { get; set; }

        [JsonPropertyName("org")]
        public string Org { get; set; }

        /// <summary>
        /// 格式化输出信息
        /// </summary>
        public override string ToString()
        {
            return $"来自[{City}]的用户使用了[米哈游工具箱]\n" +
                   $"IP: {Ip}, {Region} ({RegionCode}), {CountryName} ({CountryCode})";
            /*
            return $"来自[{City}]的用户使用了[米哈游工具箱]\n" +
                   $"IP: {Ip}\n" +
                   $"位置: {City}, {Region} ({RegionCode}), {CountryName} ({CountryCode})\n" +
                   $"经纬度: {Latitude}, {Longitude}\n" +
                   $"时区: {Timezone} (UTC {UtcOffset})\n" +
                   $"货币: {Currency} ({CurrencyName})\n" +
                   $"运营商: {Org} (ASN: {Asn})";
            */
        }
    }
    public class IpApiService
    {
        private readonly HttpClient _httpClient;
        private const string ApiEndpoint = "https://ipapi.co/json/";

        public IpApiService(HttpClient httpClient = null)
        {
            _httpClient = httpClient ?? new HttpClient();

            // 配置 HttpClient
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "IpApiService/1.0");
            _httpClient.Timeout = TimeSpan.FromSeconds(5);
        }

        /// <summary>
        /// 获取当前 IP 的完整信息
        /// </summary>
        public async Task<IpApiResponse> GetIpDetailsAsync()
        {
            try
            {
                var response = await _httpClient.GetStringAsync(ApiEndpoint);

                // 配置 JSON 反序列化选项
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    NumberHandling = System.Text.Json.Serialization.JsonNumberHandling.AllowReadingFromString
                };

                var result = JsonSerializer.Deserialize<IpApiResponse>(response, options);

                if (result == null)
                    throw new Exception("API 返回了空数据");

                return result;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"网络请求失败: {ex.Message}");
            }
            catch (JsonException ex)
            {
                throw new Exception($"数据解析失败: {ex.Message}");
            }
            catch (TaskCanceledException)
            {
                throw new Exception("请求超时");
            }
        }

        /// <summary>
        /// 获取指定 IP 的信息
        /// </summary>
        public async Task<IpApiResponse> GetIpDetailsAsync(string ipAddress)
        {
            if (!System.Net.IPAddress.TryParse(ipAddress, out _))
                throw new ArgumentException("无效的 IP 地址");

            try
            {
                var response = await _httpClient.GetStringAsync($"https://ipapi.co/{ipAddress}/json/");
                return JsonSerializer.Deserialize<IpApiResponse>(response);
            }
            catch (HttpRequestException ex) when (ex.StatusCode == System.Net.HttpStatusCode.TooManyRequests)
            {
                throw new Exception("请求过于频繁，请稍后再试");
            }
        }
    }
}
