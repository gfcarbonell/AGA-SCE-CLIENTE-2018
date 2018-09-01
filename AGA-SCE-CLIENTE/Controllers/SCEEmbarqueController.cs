using AGA_SCE_CLIENTE.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AGA_SCE_CLIENTE.Controllers
{
    public class SCEEmbarqueController : Controller
    {
        [HttpGet]
        public JsonResult Index(DateTime FechaInicio, DateTime FechaFinal, string IdCampana, string IdSucursal, string Cliente, string NroPackingList)
        {
            SCEEmbarqueService serv = new SCEEmbarqueService();
            var obj = serv.Get(FechaInicio, FechaFinal, IdCampana, IdSucursal, Cliente, NroPackingList);
            return Json(obj, JsonRequestBehavior.AllowGet);
        }
    }
}