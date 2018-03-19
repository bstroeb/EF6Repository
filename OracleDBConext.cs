using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6Repository
{
    public class OracleDBConext : DbContext
    {
        public OracleDBConext(string conn_string_name) : base(conn_string_name)
        {

        }

        public OracleDBConext Create(string conn_string_name)
        {
            return new OracleDBConext(conn_string_name);
        }
    }
}
