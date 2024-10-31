using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDVNAP_HSZF_2024251.Persistence.MsSql
{
    public abstract class GenericRepository<T> : IRepository<T> where T : class
    {
        protected AppDbContext context;

        public GenericRepository(AppDbContext ctx)
        {
            context = ctx;
        }
        public void Create(T item)
        {
            context.Set<T>().Add(item);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context.Set<T>().Remove(Read(id));
        }
        public IQueryable<T> ReadAll()
        {
            return context.Set<T>();
        }

        public abstract T Read(int id);
        public abstract void Update(T item);
    }
}
