using AGA_SCE_CLIENTE.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AGA_SCE_CLIENTE.Controllers
{
    public class SCEArchivoController : Controller
    {
        // GET: SCEArchivo
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetById(int IdArchivo)
        {
            SCEArchivoService serv = new SCEArchivoService();
            var obj = serv.GetById(IdArchivo);
            return Json(obj, JsonRequestBehavior.AllowGet);
        }
    }
}