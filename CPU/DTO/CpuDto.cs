using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Part_2_Lesson_8.CPU.DTO
{
    public class CpuDto:ClassID
    {
       public int value { get; set; }
        public TimeSpan Time { get; set; }
    }
}
