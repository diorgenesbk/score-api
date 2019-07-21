using Blue.Domain.Entities;
using Blue.Domain.Interfaces;
using Blue.Infrastructure.Context;
using System.Collections.Generic;
using System.Linq;

namespace Blue.Infrastructure.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        public BlueContext Context;

        public BaseRepository(BlueContext context)
        {
            this.Context = context;
        }

        public void Insert(T obj)
        {
            this.Context.Set<T>().Add(obj);
            this.Context.SaveChanges();
        }

        public void Update(T obj)
        {
            this.Context.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            this.Context.SaveChanges();
        }

        public void Remove(int id)
        {
            this.Context.Set<T>().Remove(Select(id));
            this.Context.SaveChanges();
        }

        public IList<T> SelectAll()
        {
            return this.Context.Set<T>().ToList();
        }

        public T Select(int id)
        {
            return this.Context.Set<T>().Find(id);
        }
    }
}
