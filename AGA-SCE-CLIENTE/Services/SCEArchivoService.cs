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
    public class SCEArchivoService : ISCEArchivo
    {
        Database objDBDOC = DatabaseFactory.CreateDatabase("AGA-DOC");
        string EsquemaDBO = ConfigurationManager.AppSettings.Get("EsquemaDBO").ToString();

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public bool Exist(int Id)
        {
            throw new NotImplementedException();
        }
        public SCEArchivo GetById(int IdArchivo)
        {
            SCEArchivo pr = new SCEArchivo();
            try
            {
                DbCommand cmd;
                cmd = objDBDOC.GetStoredProcCommand(EsquemaDBO + ".[PR_AGA_ARCHIVO_SEL]");
                objDBDOC.AddInParameter(cmd, "@IdArchivo", DbType.Int32, IdArchivo);
                using (IDataReader dataReader = objDBDOC.ExecuteReader(cmd))
                {
                    if (dataReader.Read())
                    {
                        pr.IdArchivo = int.Parse(dataReader["IdArchivo"].ToString());
                        pr.DocumentoData = (byte[])dataReader["DocumentoData"];
                        pr.Estado = byte.Parse(dataReader["Estado"].ToString());
                    }
                    return pr;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ICollection<SCEArchivo> Get()
        {
            throw new NotImplementedException();
        }

        public SCEArchivo Save(SCEArchivo entidad)
        {
            throw new NotImplementedException();
        }

        public SCEArchivo Update(SCEArchivo entidad)
        {
            throw new NotImplementedException();
        }
    }
}