using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Part_2_Lesson_8.RAM.REsponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Part_2_Lesson_8.RAM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TakeResponseHttp : ControllerBase
    {
        private readonly IHttpClientFactory httpClient;
        public TakeResponseHttp(IHttpClientFactory clientFactory)
        {
            httpClient = clientFactory;
        }
        [HttpGet("id/{agetnid}/fromTime/{fromTime}/toTime/{toTime}")]
        public IActionResult HtppRamRequest([FromRoute] int id,[FromRoute] TimeSpan fromTime,[FromRoute] TimeSpan toTime)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:5432/api/ram/from/1/to/999999?var=val&var1=val1");
            request.Headers.Add("Accept", "application/vnd.github.v3+json");
            var client=httpClient.CreateClient();
            HttpResponseMessage response = client.SendAsync(request).Result;
            if(response.IsSuccessStatusCode)
            {
                using var responseStream = response.Content.ReadAsStreamAsync().Result;
                var responseMetric = JsonSerializer.DeserializeAsync<RamResponse>(responseStream, new JsonSerializerOptions(JsonSerializerDefaults.Web)).Result;
            }
            return Ok();
        }

    }
}
