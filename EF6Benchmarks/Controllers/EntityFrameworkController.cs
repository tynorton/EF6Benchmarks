using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using EF6Benchmarks.Data;

namespace EF6Benchmarks.Controllers
{
    [RoutePrefix("ef")]
    public sealed class EntityFrameworkController : Controller
    {
        private readonly EfDbContext db;

        public EntityFrameworkController()
        {
            this.db = new EfDbContext();
        }

        [Route("sysobjects")]
        [HttpGet]
        public ActionResult SysObjects()
        {
            var content = this.db.SysObjects.ToList();
            return Json(content, JsonRequestBehavior.AllowGet);
        }

        [Route("sysobjects/asnotracking")]
        [HttpGet]
        public ActionResult SysObjectAsNoTrackings()
        {
            // As per advice, swithch off tracking.
            // This should improve perormance for read operations.
            var content = this.db.SysObjects.AsNoTracking().ToList();
            return Json(content, JsonRequestBehavior.AllowGet);
        }
    }
}
