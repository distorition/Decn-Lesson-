using Part_2_Lesson_8.CPU.DBcpu;
using Part_2_Lesson_8.CPU.DTO;
using Part_2_Lesson_8.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Part_2_Lesson_8.CPU.Repositry
{
    public class Repositroy<T> : IRepository<T> where T:ClassID
    {
        public CreatDb _cpuDb;
        public Repositroy(CreatDb cpu)
        {
            _cpuDb = cpu;
        }
        public async Task AddSync(T entity)
        {
           await _cpuDb.Set<T>().AddAsync(entity);
            await _cpuDb.SaveChangesAsync();
        }

        public async Task Delte(T entity)
        {
            await Task.Run(() => _cpuDb.Set<T>().Remove(entity));
            await _cpuDb.SaveChangesAsync();
        }

        public IQueryable<T> GetAll()
        {
            return _cpuDb.Set<T>().AsQueryable();
        }

        public async Task Update(T entita)
        {
            await Task.Run(() => _cpuDb.Set<T>().Update(entita));
            await _cpuDb.SaveChangesAsync();
        }
    }
}
