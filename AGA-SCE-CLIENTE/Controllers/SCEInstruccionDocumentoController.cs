using AGA_SCE_CLIENTE.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AGA_SCE_CLIENTE.Controllers
{
    public class SCEInstruccionDocumentoController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetByNroPackingList(string NroPackingList)
        {
            SCEInstruccionDocumentoService serv = new SCEInstruccionDocumentoService();
            var obj = serv.GetByNroPackingList(NroPackingList);
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

       
    }
}