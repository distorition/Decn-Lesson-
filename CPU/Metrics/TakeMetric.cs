using Part_2_Lesson_8.CPU.DTO;
using Part_2_Lesson_8.Interfaces;
using Quartz;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Part_2_Lesson_8.CPU.Metrics
{
    public class TakeMetric : IJob//берем метрики из процессора 
    {
        private IRepository<CpuDto> _repositroy;
        private PerformanceCounter counter;
        public TakeMetric(IRepository<CpuDto> cpude)
        {
            _repositroy = cpude;
            counter = new PerformanceCounter("Processor", " % Processor Time", "_Total");
        }
        public Task Execute(IJobExecutionContext context)
        {
            var CpuConvert = Convert.ToInt32(counter.NextValue());
            var time = TimeSpan.FromSeconds(DateTimeOffset.UtcNow.ToUnixTimeSeconds());
            _repositroy.AddSync(new CpuDto { Time = time, value = CpuConvert });
            return Task.CompletedTask;
        }
    }
}
