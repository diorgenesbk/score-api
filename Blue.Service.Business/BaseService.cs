using Blue.Domain.Entities;
using Blue.Domain.Interfaces;
using Blue.Infrastructure.Context;
using Blue.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blue.Service.Business
{
    public class BaseService<T> : IService<T> where T : BaseEntity
    {
        public BaseRepository<T> Repository;

        public BaseService(BlueContext options)
        {
            this.Repository = new BaseRepository<T>(options);
        }

        public T Post<V>(T obj)
        {
            this.Repository.Insert(obj);
            return obj;
        }

        public T Put<V>(T obj)
        {
            this.Repository.Update(obj);
            return obj;
        }

        public void Delete(int id)
        {
            if (id == 0)
                throw new ArgumentException("Não foi possível deletar o registro de id: {id}");

            this.Repository.Remove(id);
        }

        public IList<T> Get() => this.Repository.SelectAll();

        public T Get(int id)
        {
            if (id == 0)
                throw new ArgumentException($"Não foi possível encontrar o registro de id: {id}");

            return this.Repository.Select(id);
        }
    }
}
