using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Part_2_Lesson_8.RAM.DTO
{
    public class RamDto:ClassID
    {
        public int value { get; set; }
        public TimeSpan time { get; set; }
    }
}
