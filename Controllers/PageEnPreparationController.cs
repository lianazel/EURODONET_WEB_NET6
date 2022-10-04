using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EURODONET_WEB_NET6.Controllers
{
    public class PageEnPreparationController : Controller
    {
        // GET: PageEnPreparationController1
        public ActionResult Index()
        {
            return View();
        }

        // GET: PageEnPreparationController1/Details/5
        [HttpGet]
        public ActionResult PageEnTravauxGet()
        {
            return View();
        }

    }
}
