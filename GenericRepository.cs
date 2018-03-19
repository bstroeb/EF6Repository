using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EF6Repository.Repository
{
    /// <summary>
    /// To be used as a repo for any Class Entity that wants to use just the standard CRUD operations for adding, updating, and deleting. If you need
    /// special operations or want to ovverride the operations in Rpository, implement your own class and inherit from Repository.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericRepository<T> : Repository<T>
             where T : class
    {
        public GenericRepository()
            : base(new SQLDbContext())
        {
            
        }
    }
}
//   