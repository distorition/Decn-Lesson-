using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Part_2_Lesson_8.CPU.Request;
using Part_2_Lesson_8.MetricsAgentsClients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Part_2_Lesson_8.CPU.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TakeMetricCpuHttpController : ControllerBase//обращаеся за нашими метриками при помощи Http
    {
        private readonly TakeMetricsFromHttp take;
        private readonly ILogger _logger;
        public TakeMetricCpuHttpController(TakeMetricsFromHttp fromHttp, ILogger logger)
        {
            take = fromHttp;
            _logger = logger;
        }

        [HttpGet("agentid/{agentId}/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetric([FromRoute] int agentid, [FromRoute] TimeSpan toTime, [FromRoute] TimeSpan fromTime)
        {
            _logger.LogInformation("start request");
            var message = take.takeMetricsCpu(new CpuRequest { fromTime = fromTime, toTime = toTime });
            return Ok(message);
        }
    }
}
