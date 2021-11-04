using Microsoft.Extensions.Logging;
using Part_2_Lesson_8.CPU;
using Part_2_Lesson_8.CPU.Request;
using Part_2_Lesson_8.Interfaces;
using Part_2_Lesson_8.RAM.Request;
using Part_2_Lesson_8.RAM.REsponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Part_2_Lesson_8.MetricsAgentsClients
{
    public class TakeMetricsFromHttp : IRecuestMetrics//берем метрици при помощи Http запросов
    {
        public readonly ILogger ilogger;
        public readonly HttpClient httpClient;
        public TakeMetricsFromHttp(HttpClient client,ILogger logger)
        {
            ilogger = logger;
            httpClient = client;
        }

        public RamResponse takeMetricRam(RamRequest ram)
        {
            var timeFrom = ram.fromTime.TotalSeconds;
            var timeTo = ram.toTime.TotalSeconds;
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"{ram.Id}/api/ram/from/{timeFrom}/to/{timeTo}");
            try
            {
                HttpResponseMessage response = httpClient.SendAsync(httpRequest).Result;
                using var responseStrea = response.Content.ReadAsStreamAsync().Result;
                return JsonSerializer.DeserializeAsync<RamResponse>(responseStrea, new JsonSerializerOptions(JsonSerializerDefaults.Web)).Result;
            }

            catch(Exception ex)
            {
                ilogger.LogError(ex.Message);
            }
            return null;
        }

        public CpuResponse takeMetricsCpu(CpuRequest cpu)
        {
            var fromTime = cpu.fromTime.TotalSeconds;
            var toTime = cpu.toTime.TotalSeconds;
            var httpReques = new HttpRequestMessage(HttpMethod.Get, $"{cpu.Id}/api/cpu/from/{fromTime}/to/{toTime}");
            try
            {
                HttpResponseMessage response = httpClient.SendAsync(httpReques).Result;
                using var responseStream = response.Content.ReadAsStreamAsync().Result;
                return JsonSerializer.DeserializeAsync<CpuResponse>(responseStream, new JsonSerializerOptions(JsonSerializerDefaults.Web)).Result;
            }
            catch (Exception ex)
            {
                ilogger.LogError(ex.Message);
            }
            return null;
        }
    }
}
