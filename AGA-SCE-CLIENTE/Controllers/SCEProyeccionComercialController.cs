using AGA_SCE_CLIENTE.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AGA_SCE_CLIENTE.Controllers
{
    public class SCEProyeccionComercialController : Controller
    {
        // GET: SCEProyeccionComercial
        public JsonResult Index(string IdCampana, string IdCliente, int SemanaConsulta, string FlagColor)
        {
            SCEProyeccionComercialService serv = new SCEProyeccionComercialService();
            var obj = serv.GetProyeccionComercialDataTable(IdCampana, IdCliente, SemanaConsulta, FlagColor);
            List<Dictionary<string, object>> ok = serv.GetTableRows(obj);
            return Json(ok, JsonRequestBehavior.AllowGet);
        }
        
        public JsonResult GetEjecucionPackingList(string IdCampana, string IdCliente, int SemanaConsulta, string FlagColor)
        {
            SCEProyeccionComercialService serv = new SCEProyeccionComercialService();
            var obj = serv.GetEjecucionPackingListDataTable(IdCampana, IdCliente, SemanaConsulta, FlagColor);
            List<Dictionary<string, object>> ok = serv.GetTableRows(obj);
            return Json(ok, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetProyeccionCampo(string IdCampana, string IdCliente, int SemanaConsulta, string FlagColor)
        {
            SCEProyeccionComercialService serv = new SCEProyeccionComercialService();
            var obj = serv.GetProyeccionCampo(IdCampana, IdCliente, SemanaConsulta, FlagColor);
            List<Dictionary<string, object>> ok = serv.GetTableRows(obj);
            return Json(ok, JsonRequestBehavior.AllowGet);
        }

    }
}