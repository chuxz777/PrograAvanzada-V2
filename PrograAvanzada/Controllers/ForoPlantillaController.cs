using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrograAvanzada.Controllers
{
    public class ForoPlantillaController : Controller
    {
        //index creado para mostrar vista pasando valores por medio de viewbag
        // GET: ForoPlantilla
        public ActionResult Index(int id)
        {
            ViewBag.IdValue = id;

            return View();
        }
    }
}