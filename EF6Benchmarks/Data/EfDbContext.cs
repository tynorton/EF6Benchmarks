using System.Configuration;
using System.Data.Entity;

namespace EF6Benchmarks.Data
{
    /// <summary>
    /// Getting data using Entity Framework 6.
    /// </summary>
    public sealed class EfDbContext : DbContext
    {
        public DbSet<SysObject> SysObjects { get; set; }

        public EfDbContext() : base("DefaultConnection") { }
    }
}
