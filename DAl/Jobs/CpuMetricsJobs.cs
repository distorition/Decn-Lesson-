
using Part_2_Lesson_8.CPU.DTO;
using Part_2_Lesson_8.Interfaces;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Part_2_Lesson_8.DAl.Jobs
{
    public class CpuMetricsJobs : IJob//тут мы записываем что то при помощи репозитория (добавляем в репозиторий)
    {
        private IRepository<CpuDto> _cpuRepository;
        private IRecuestMetrics metricAgent;
        public CpuMetricsJobs(IRepository<CpuDto> repositories, IRecuestMetrics agentClient)
        {
            metricAgent = agentClient;
            _cpuRepository = repositories;
        }
        public Task Execute(IJobExecutionContext context)
        {
            return Task.CompletedTask;
        }
    }
}
