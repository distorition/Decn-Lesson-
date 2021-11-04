using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Part_2_Lesson_8.MetricsAgentsClients;
using Part_2_Lesson_8.RAM.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Part_2_Lesson_8.RAM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TakeRamtoHttp : ControllerBase
    {
        public TakeMetricsFromHttp takeMetrics;
        public ILogger ilogger;
        public TakeRamtoHttp(TakeMetricsFromHttp take,ILogger logger)
        {
            takeMetrics = take;
            ilogger = logger;
        }
        [HttpGet("agentid/{agentId}/from/{fromTime}/to/{toTime}")]
        public IActionResult TakeMetric([FromRoute] int agentid,[FromRoute] TimeSpan fromTime,[FromRoute] TimeSpan toTime)
        {
            ilogger.LogInformation("start ram request");
            var request = takeMetrics.takeMetricRam(new RamRequest { fromTime = fromTime, toTime = toTime });
            return Ok(request);
        }
    }
}
