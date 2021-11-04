using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Part_2_Lesson_8.CPU.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TakeHttpMetricsCpuController : ControllerBase//получаем ответы от сервиса при помощи HttpClient
    {
        private readonly IHttpClientFactory _httpContext;
        public TakeHttpMetricsCpuController(IHttpClientFactory httpClientactory)
        {
            _httpContext = httpClientactory;
        }
        [HttpGet("id/{agetnid}/fromTime/{fromTime}/toTime/{toTime}")]
        public IActionResult HttpCpuRequest([FromRoute] int id, [FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:5432/api/cpu/from/1/to/999999?var=val&var1=val1");
            request.Headers.Add("Accept", "application/vnd.github.v3+json");
            var clien = _httpContext.CreateClient();
            HttpResponseMessage message = clien.SendAsync(request).Result;
            if (message.IsSuccessStatusCode)
            {
                using var responseStream = message.Content.ReadAsStreamAsync().Result;
                var metricRespone = JsonSerializer.DeserializeAsync<CpuResponse>(responseStream, new JsonSerializerOptions(JsonSerializerDefaults.Web)).Result;
            }
            return Ok();

        }

    }
}
