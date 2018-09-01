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
    public class SCETipoDocumentoService
    {
        Database objDB = DatabaseFactory.CreateDatabase("AGA-SCE");
        String EsquemaSCE = ConfigurationManager.AppSettings.Get("EsquemaSCE").ToString();

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public bool Exist(int Id)
        {
            throw new NotImplementedException();
        }

        public ICollection<SCETipoDocumento> Get()
        {
            List<SCETipoDocumento> tiposDocumentos = new List<SCETipoDocumento>();
            try
            {
                DbCommand cmd;
                cmd = objDB.GetStoredProcCommand(EsquemaSCE + ".[PR_SCE_TIPO_DOCUMENTO_QRY]");
                foreach (DataRow dr in objDB.ExecuteDataSet(cmd).Tables[0].Rows)
                {
                    SCETipoDocumento pr = new SCETipoDocumento();
                    pr.IdTipoDocumento = dr[0].ToString();
                    pr.Descripcion = dr[1].ToString();
                    tiposDocumentos.Add(pr);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return tiposDocumentos;
        }

        public SCETipoDocumento Save(SCETipoDocumento entidad)
        {
            throw new NotImplementedException();
        }

        public SCETipoDocumento Update(SCETipoDocumento entidad)
        {
            throw new NotImplementedException();
        }
    }
}