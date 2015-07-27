using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace EF6Benchmarks.Data
{
    /// <summary>
    /// Getting things manually, writing plain ADO.NET code by hand.
    /// </summary>
    public sealed class ManualDbContext
    {
        public List<SysObject> GetSysObjects()
        {
            const string sqlText = "select name as Name, object_id as ObjectId, type as Type, type_desc as TypeDescription from sys.objects";
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            using (var command = new SqlCommand(cmdText: sqlText, connection: connection))
            {
                connection.Open();

                var result = new List<SysObject>();

                using (var reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        var item = new SysObject
                        {
                            Name = reader.GetString(0),
                            ObjectId = reader.GetInt32(1),
                            Type = reader.GetString(2),
                            TypeDescription = reader.GetString(3)
                        };

                        result.Add(item);
                    }

                    return result;
                }
            }
        }
    }
}
