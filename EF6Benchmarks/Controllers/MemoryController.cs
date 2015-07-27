using System.Web.Mvc;
using EF6Benchmarks.Data;

namespace EF6Benchmarks.Controllers
{
    [RoutePrefix("memory")]
    public sealed class MemoryController : Controller
    {
        private readonly MemoryDbContext db;

        public MemoryController()
        {
            this.db = new MemoryDbContext();
        }

        [Route("sysobjects")]
        [HttpGet]
        public ActionResult SysObjects()
        {
            var content = this.db.GetSysObjects();
            return this.Content(content, "application/json");
        }
    }
}
