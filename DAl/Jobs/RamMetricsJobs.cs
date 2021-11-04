
using Part_2_Lesson_8.Interfaces;
using Part_2_Lesson_8.RAM.DTO;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Part_2_Lesson_8.DAl.Jobs
{
    public class RamMetricsJobs : IJob
    {
        public IRepository<RamDto> ram;
        public IRecuestMetrics client;

        public RamMetricsJobs(IRepository<RamDto> repositories, IRecuestMetrics metric)
        {
            ram = repositories;
            client = metric;
        }

        public Task Execute(IJobExecutionContext context)
        {
            return Task.CompletedTask;
        }
    }
}
