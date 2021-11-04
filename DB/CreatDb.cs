using Microsoft.EntityFrameworkCore;
using Part_2_Lesson_8.CPU.DTO;
using Part_2_Lesson_8.RAM.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Part_2_Lesson_8.CPU.DBcpu
{
    public class CreatDb:DbContext
    {
        public CreatDb(DbContextOptions<CreatDb> options):base (options)
        {
            Database.EnsureCreated();
        }

        public DbSet<CpuDto> cpu { get; set; }
        public DbSet<RamDto> ram { get; set; }
    }
}
