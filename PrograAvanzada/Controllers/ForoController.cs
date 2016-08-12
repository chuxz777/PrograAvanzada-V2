using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrograAvanzada.Controllers
{
    public class ForoController : Controller
    {
        // GET: Foro
        public ActionResult Index()
        {
            return View();
        }
    }
}