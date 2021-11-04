using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Part_2_Lesson_8.CPU.Request
{
    public class CpuRequest:ClassID
    {
        public TimeSpan fromTime { get; set; }
        public TimeSpan toTime { get; set; }
    }
}
