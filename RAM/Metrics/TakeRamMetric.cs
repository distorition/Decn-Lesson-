using Part_2_Lesson_8.Interfaces;
using Part_2_Lesson_8.RAM.DTO;
using Quartz;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Part_2_Lesson_8.RAM.Metrics
{
    public class TakeRamMetric:IJob
    {
        private IRepository<RamDto> repositroy;
        private PerformanceCounter counter;
        public TakeRamMetric(IRepository<RamDto> dto)
        {
            repositroy = dto;
            counter = new PerformanceCounter("Memory", "Available MBytes");
        }
        public Task Execute(IJobExecutionContext context)
        {
            var convert = Convert.ToInt32(counter.NextValue());
            var time = TimeSpan.FromSeconds(DateTimeOffset.UtcNow.ToUnixTimeSeconds());
            repositroy.AddSync(new RamDto { time = time, value = convert });
            return Task.CompletedTask;
        }

       
    }
}
