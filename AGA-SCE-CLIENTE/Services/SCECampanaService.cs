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
    public class SCECampanaService : ISCECampana
    {
        Database objDBSCE = DatabaseFactory.CreateDatabase("AGA-SCE");
        String EsquemaSCE = ConfigurationManager.AppSettings.Get("Esquema").ToString();

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public bool Exist(int Id)
        {
            throw new NotImplementedException();
        }

        public ICollection<SCECampana> Get()
        {
            List<SCECampana> campanas = new List<SCECampana>();
            try
            {
                DbCommand cmd;
                cmd = objDBSCE.GetStoredProcCommand(EsquemaSCE + ".[PR_SCE_CAMPAÑA_QRY]");
                foreach (DataRow dr in objDBSCE.ExecuteDataSet(cmd).Tables[0].Rows)
                {
                    SCECampana pr = new SCECampana();
                    pr.IdCampana = dr[0].ToString();
                    pr.Descripcion = dr[1].ToString();
                    pr.IdCultivo = dr[2].ToString();
                    campanas.Add(pr);
                }
            }
            catch (Exception ex)
            {
                throw ex; 
            }
            return campanas;
        }

        public SCECampana GetById(string Id)
        {
            SCECampana pr = new SCECampana();
            try
            {
                DbCommand cmd;
                cmd = objDBSCE.GetStoredProcCommand(EsquemaSCE + ".[PR_SCE_CAMPAÑA_SEL]");
                objDBSCE.AddInParameter(cmd, "@IdCampaña", DbType.String, Id);

                using (System.Data.IDataReader dataReader = objDBSCE.ExecuteReader(cmd))
                {
                    if (dataReader.Read())
                    {
                        pr.IdCampana = dataReader["IdCampaña"].ToString();
                        pr.Descripcion = dataReader["DESCRIPCION"].ToString();
                        pr.IdCultivo = dataReader["IDCULTIVO"].ToString();
                    }
                    return pr;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SCECampana GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public SCECampana Save(SCECampana entidad)
        {
            throw new NotImplementedException();
        }

        public SCECampana Update(SCECampana entidad)
        {
            throw new NotImplementedException();
        }
    }
}