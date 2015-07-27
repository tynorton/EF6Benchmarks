using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using EF6Benchmarks.Data;

namespace EF6Benchmarks.Controllers
{
    [RoutePrefix("manual")]
    public sealed class ManualController : Controller
    {
        private readonly ManualDbContext db;

        public ManualController()
        {
            this.db = new ManualDbContext();
        }

        [Route("sysobjects")]
        [HttpGet]
        public ActionResult SysObjects()
        {
            var content = this.db.GetSysObjects();
            return Json(content, JsonRequestBehavior.AllowGet);
        }
    }
}
