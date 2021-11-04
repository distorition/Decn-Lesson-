using Part_2_Lesson_8.CPU.DBcpu;
using Part_2_Lesson_8.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Part_2_Lesson_8.RAM.Repository
{
    public class RamRepository<T> : IRepository<T> where T : ClassID
    {
        public CreatDb createDb;
        public RamRepository(CreatDb creat)
        {
            createDb = creat;
        }
        public async Task AddSync(T entity)
        {
            await createDb.Set<T>().AddAsync(entity);
            await createDb.SaveChangesAsync();
        }

        public  async Task Delte(T entity)
        {
            await Task.Run(() => createDb.Set<T>().Remove(entity));
            await createDb.SaveChangesAsync();
        }

        public IQueryable<T> GetAll()
        {
            return createDb.Set<T>().AsQueryable();
        }

        public async Task Update(T entita)
        {
            await Task.Run(() => createDb.Set<T>().Update(entita));
            await createDb.SaveChangesAsync();
        }
    }
}
