using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Part_2_Lesson_8.Interfaces
{
   public interface IRepository<T> where T:ClassID
    {
        IQueryable<T> GetAll();
        Task AddSync(T entity);
        Task Update(T entita);
        Task Delte(T entity);
    }
}
