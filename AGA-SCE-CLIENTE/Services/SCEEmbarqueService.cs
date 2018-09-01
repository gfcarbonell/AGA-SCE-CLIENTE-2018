using AGA_SCE_CLIENTE.Interfaces;
using AGA_SCE_CLIENTE.Models;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace AGA_SCE_CLIENTE.Services
{
    public class SCEEmbarqueService : ISCEEmbarque
    {
        string EsquemaDBO = ConfigurationManager.AppSettings.Get("EsquemaDBO").ToString();
        string EsquemaSCE = ConfigurationManager.AppSettings.Get("EsquemaSCE").ToString();
        Database objDBSCE = DatabaseFactory.CreateDatabase("AGA-SCE");
        Database objDBDOC = DatabaseFactory.CreateDatabase("AGA-DOC");

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public bool Exist(int Id)
        {
            throw new NotImplementedException();
        }
        public ICollection<SCEEmbarque> Get()
        {
            throw new NotImplementedException();
        }

        public ICollection<SCEEmbarque> Get(

           DateTime FechaInicio, DateTime FechaFinal,
           string IdCampana, string IdSucursal, string Cliente, string NroPackingList)
        {
            List<SCEEmbarque> embarques = new List<SCEEmbarque>();
            try
            {
                DbCommand cmd;
                cmd = objDBSCE.GetStoredProcCommand(EsquemaSCE + ".[PR_SCE_INSTRUCCION_QRY_ParaDocumento]");
                objDBSCE.AddInParameter(cmd, "@FechaInicio", DbType.Date, FechaInicio);
                objDBSCE.AddInParameter(cmd, "@FechaFin", DbType.Date, FechaFinal);
                objDBSCE.AddInParameter(cmd, "@IdCampaña", DbType.String, IdCampana);
                objDBSCE.AddInParameter(cmd, "@IdSucursal", DbType.String, IdSucursal);
                objDBSCE.AddInParameter(cmd, "@Cliente", DbType.String, Cliente);
                objDBSCE.AddInParameter(cmd, "@NroPackingList", DbType.String, NroPackingList);

                foreach (DataRow dr in objDBSCE.ExecuteDataSet(cmd).Tables[0].Rows)
                {
                    SCEEmbarque pr = new SCEEmbarque();
                    pr.NroPackingList = dr[0].ToString();
                    pr.IdInstruccion = int.Parse(dr[1].ToString());
                    pr.Instruccion = dr[2].ToString();
                    pr.Embarque = dr[3].ToString();
                    pr.FechaEmbarque = DateTime.Parse(dr[4].ToString());
                    pr.FechaArribo = DateTime.Parse(dr[5].ToString());
                    pr.Cantidad = decimal.Parse(dr[6].ToString());
                    embarques.Add(pr);
                }
            }
            catch (Exception ex)
            {
               throw ex;
            }
            return embarques;
        }

        public SCEEmbarque GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public SCEEmbarque Save(SCEEmbarque entidad)
        {
            throw new NotImplementedException();
        }

        public SCEEmbarque Update(SCEEmbarque entidad)
        {
            throw new NotImplementedException();
        }
    }
}