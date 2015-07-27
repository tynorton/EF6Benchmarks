using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using EF6Benchmarks.Data;

namespace EF6Benchmarks.Controllers
{
    [RoutePrefix("dapper")]
    public sealed class DapperController : Controller
    {
        private readonly DapperDbContext db;

        public DapperController()
        {
            this.db = new DapperDbContext();
        }

        [Route("sysobjects")]
        [HttpGet]
        public ActionResult SysObjects()
        {
            return Json(this.db.GetSysObjects(), JsonRequestBehavior.AllowGet);
        }
    }
}
