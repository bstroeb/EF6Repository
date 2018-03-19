using EF6Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity;
using System.Web;
using System.Linq.Expressions;
using EF6Repository.Repository;

namespace EF6Repository.Services
{ 
    public abstract class Service<T> : IDisposable where T : class
    {
        public Repository<T> Repository { get; set; }

        public string[] includes { get; set; }
        
        public Service(GenericRepository<T> repo)
        {
            Repository = repo;
        }

        public Service()
        {
            Repository = new GenericRepository<T>();
        }

        public abstract IEnumerable<T> FindAll();

        public abstract T FindById(object id);

        public abstract T FindOne(Expression<Func<T, bool>> predicate);

        public abstract IEnumerable<T> FindMany(Expression<Func<T, bool>> predicate);
        
        public abstract T Insert(T data);

        public abstract T Update(T data);

        public abstract void Delete(T data);

        public abstract void DeleteById(object id);

        public virtual void Dispose()
        {

        }
    }
}
