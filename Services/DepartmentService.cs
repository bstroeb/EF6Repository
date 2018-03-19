using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using EF6Repository.Entities;

namespace EF6Repository.Services
{
    public class DepartmentService : Service<Department>
    {
        public override IEnumerable<Department> FindAll()
        {
            return Repository.FindAll(includes).OrderBy(x => x.name).ToList();
        }

        public override Department FindById(object id)
        {
            return Repository.FindById(id);
        }

        public override Department FindOne(Expression<Func<Department, bool>> predicate)
        {
            return Repository.FindOne(predicate, includes);
        }

        public override IEnumerable<Department> FindMany(Expression<Func<Department, bool>> predicate)
        {
            return Repository.FindMany(predicate, includes);
        }

        public override Department Insert(Department data)
        {
            Repository.Insert(data);
            Repository.Save();
            return data;
        }

        public override Department Update(Department data)
        {
            Repository.Update(data);
            Repository.Save();
            return data;
        }

        public override void Delete(Department data)
        {
            Repository.Delete(data);
            Repository.Save();
        }

        public override void DeleteById(object id)
        {
            Repository.Delete(FindById((long)id));
            Repository.Save();
        }
    }
}

