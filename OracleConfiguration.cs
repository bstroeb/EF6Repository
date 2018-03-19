using Oracle.ManagedDataAccess.EntityFramework;
using System.Data.Entity;

namespace EF6Repository
{
    public class OracleConfiguration : DbConfiguration
    {
        public OracleConfiguration()
        {
            SetProviderServices("Oracle.ManagedDataAccess.Client", EFOracleProviderServices.Instance);
        }
    }
}
