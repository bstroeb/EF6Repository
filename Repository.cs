
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EF6Repository.Repository
{

    public abstract class Repository<T> : IDisposable
        where T : class
    {

        #region Properties and Constructor

        private SQLDbContext _ctx;
        protected readonly DbSet<T> _table;

        protected SQLDbContext Ctx
        {
            get
            {
                return _ctx;
            }
        }

        public Repository(SQLDbContext ctx)
        {
            _ctx = ctx;
            _table = Ctx.Set<T>();
        }
        #endregion

        /// <summary>
        /// Returns all records.
        /// </summary>
        /// <param name="navigationProps">Optional - String array of navigation properties to include in the search.</param>
        /// <returns></returns>
        public virtual IEnumerable<T> FindAll(string[] navigationProps = null)
        {
            if (navigationProps != null)
            {
                var query = _ctx.Set<T>().AsQueryable();
                foreach (string navigationProp in navigationProps)
                {
                    query = query.Include(navigationProp);
                }
                return query.AsEnumerable<T>();
            }
            else
            {
                return _table.AsEnumerable<T>();
            }
        }

        /// <summary>
        /// Returns a single record by primary key.<para/>
        /// Result will not include navigation properties.
        /// </summary>
        /// <param name="id">Primary Key</param>
        /// <returns></returns>
        public virtual T FindById(object id)
        {
            return _table.Find(id);
        }
        
        /// <summary>
        /// Returns a single roecord in the search.
        /// </summary>
        /// <param name="predicate">Where clause to include in the search.</param>
        /// <param name="navigationProps">Optional - String array of navigation properties to include in the search.</param>
        /// <returns></returns>
        public T FindOne(Expression<Func<T, bool>> predicate, string[] navigationProps = null)
        {
            if (navigationProps != null)
            {
                var query = _ctx.Set<T>().AsQueryable();
                foreach (string navigationProp in navigationProps)
                {
                    query = query.Include(navigationProp);
                }
                return query.Where(predicate).FirstOrDefault();
            }
            else
            {
                return _table.FirstOrDefault(predicate);
            }
        }

        /// <summary>
        /// Returns a list of objects from the search.
        /// </summary>
        /// <param name="predicate">Where clause to include in the search.</param>
        /// <param name="navigationProps">Optional - String array of navigation properties to include in the search.</param>
        /// <returns></returns>
        public IEnumerable<T> FindMany(Expression<Func<T, bool>> predicate, string[] navigationProps = null)
        {
            if (navigationProps != null)
            {
                var query = _ctx.Set<T>().AsQueryable();
                foreach (string navigationProp in navigationProps)
                {
                    query = query.Include(navigationProp);
                }
                return query.Where(predicate).ToList();
            }
            else
            {
                return _table.Where(predicate).ToList();
            }
        }

        public virtual T Insert(T entity)
        {
            return _table.Add(entity);
        }

        public virtual void Update(T entity)
        {
            _table.Attach(entity);
            Ctx.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            _table.Remove(entity);
        }

        public void DeleteById(object id)
        {
            _table.Remove(this.FindById(id));
        }

        public virtual void Save()
        {
            Ctx.SaveChanges();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _ctx = null;
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~Repository() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion

    }
}
