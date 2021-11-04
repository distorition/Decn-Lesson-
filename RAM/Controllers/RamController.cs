using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Part_2_Lesson_8.Interfaces;
using Part_2_Lesson_8.RAM.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Part_2_Lesson_8.RAM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RamController : ControllerBase
    {
        public readonly IRepository<RamDto> repository;
        public RamController(IRepository<RamDto> rep)
        {
            repository = rep;
        }
        [HttpGet]
        public Task<List<RamDto>> GetAll()
        {
            return repository.GetAll().ToListAsync();
        }

        [HttpPut]
        public Task Update(RamDto ram)
        {
            return repository.Update(ram);
        }
        [HttpPost]
        public Task Add(RamDto ram)
        {
            return repository.AddSync(ram);
        }
    }
}
