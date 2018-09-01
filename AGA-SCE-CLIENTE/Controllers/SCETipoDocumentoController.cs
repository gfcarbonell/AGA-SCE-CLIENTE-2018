using AGA_SCE_CLIENTE.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AGA_SCE_CLIENTE.Controllers
{
    public class SCETipoDocumentoController : Controller
    {
        [HttpGet]
        public JsonResult Index()
        {
            SCETipoDocumentoService serv = new SCETipoDocumentoService();
            var obj = serv.Get();
            return Json(obj, JsonRequestBehavior.AllowGet);
        }
    }
}