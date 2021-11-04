using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Part_2_Lesson_8.CPU.DTO;
using Part_2_Lesson_8.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Part_2_Lesson_8.CPU.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CpuController : ControllerBase//берем ЦРУ из базы данных
    {
        private readonly IRepository<CpuDto> _repositroy;
        public CpuController(IRepository<CpuDto> rep)
        {
            _repositroy = rep;
        }
        [HttpGet]
        public Task<List<CpuDto>> GetAll()
        {
            return _repositroy.GetAll().ToListAsync();
        }

        [HttpPut]
        public Task Update(CpuDto cpu)
        {
            return _repositroy.Update(cpu);
        }
        [HttpPost]
        public Task Add(CpuDto cpu)
        {
            return _repositroy.AddSync(cpu);
        }

    }
}
