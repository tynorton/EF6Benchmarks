using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace EF6Benchmarks.Data
{
    /// <summary>
    /// Getting data using dapper.net.
    /// </summary>
    public sealed class DapperDbContext
    {
        public List<SysObject> GetSysObjects()
        {
            const string sqlText = "select name as Name, object_id as ObjectId, type as Type, type_desc as TypeDescription from sys.objects";
            var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            return (connection.Query<SysObject>(sqlText)).ToList();
        }
    }
}
