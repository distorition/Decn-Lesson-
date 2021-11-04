using AutoMapper;
using Part_2_Lesson_8.CPU.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Part_2_Lesson_8.Mapper
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<CpuDto, CpuMetricDto>();
        }

       
    }
}
