using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using EF6Benchmarks.Data;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EF6Benchmarks.Startup))]
namespace EF6Benchmarks
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {

                connection.Open();

                using (var command = new SqlCommand(cmdText: "IF Object_ID('dbo.SysObjectsView') IS NOT NULL DROP VIEW [dbo].[SysObjectsView]", connection: connection))
                {
                    command.ExecuteNonQuery();
                }

                using (var command = new SqlCommand(cmdText: "CREATE VIEW [dbo].[SysObjectsView] AS (SELECT * FROM sys.objects)", connection: connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
