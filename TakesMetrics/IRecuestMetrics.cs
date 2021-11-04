using Part_2_Lesson_8.CPU;
using Part_2_Lesson_8.CPU.Request;
using Part_2_Lesson_8.RAM.Request;
using Part_2_Lesson_8.RAM.REsponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Part_2_Lesson_8.Interfaces
{
   public  interface IRecuestMetrics
    {
        CpuResponse takeMetricsCpu(CpuRequest cpu);
        RamResponse takeMetricRam(RamRequest ram);
    }
}
