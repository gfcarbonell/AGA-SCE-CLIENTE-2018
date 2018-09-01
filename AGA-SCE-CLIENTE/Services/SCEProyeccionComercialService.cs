using AGA_SCE_CLIENTE.Interfaces;
using AGA_SCE_CLIENTE.Models;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AGA_SCE_CLIENTE.Services
{
    public class SCEProyeccionComercialService : ISCEProyeccionComercial
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

        public ICollection<SCEProyeccionComercial> Get()
        {
            throw new NotImplementedException();
        }

        //DataTable to List
        public List<Dictionary<string, object>> GetTableRows(DataTable dtData)
        {
            List<Dictionary<string, object>> lstRows = new List<Dictionary<string, object>>();
            Dictionary<string, object> dictRow = null;

            foreach (DataRow dr in dtData.Rows)
            {
                dictRow = new Dictionary<string, object>();
                foreach (DataColumn col in dtData.Columns)
                {
                    dictRow.Add(col.ColumnName, dr[col]);
                }
                lstRows.Add(dictRow);
            }
            return lstRows;
        }

        public DataTable GetProyeccionComercialDataTable
            (string IdCampana, string IdCliente, int SemanaConsulta, string FlagColor)
        {
            DataTable ProyeccionComercialTabla = new DataTable();
            try
            {
                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["AGA-SCE"].ConnectionString))
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand(EsquemaSCE + ".[PR_SCE_PROYECCION_COMERCIAL_QRY]", cn);
                    SqlParameter IdCampanaParameter = cmd.Parameters.Add("@IdCampaña", SqlDbType.VarChar);
                    SqlParameter IdClienteParameter = cmd.Parameters.Add("@IdCliente", SqlDbType.VarChar);
                    SqlParameter SemanaConsultaParameter = cmd.Parameters.Add("@SemanaConsulta", SqlDbType.Int);
                    SqlParameter FlagColorParameter = cmd.Parameters.Add("@FlagColor", SqlDbType.VarChar);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    IdCampanaParameter.Value = IdCampana;
                    IdClienteParameter.Value = IdCliente;
                    SemanaConsultaParameter.Value = SemanaConsulta;
                    FlagColorParameter.Value = FlagColor;

                    cmd.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    // this will query your database and return the result to your datatable
                    da.Fill(ProyeccionComercialTabla);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ProyeccionComercialTabla;
        }

        public DataTable GetEjecucionPackingListDataTable
            (string IdCampana, string IdCliente, int SemanaConsulta, string FlagColor)
        {
            DataTable ProyeccionComercialTabla = new DataTable();
            try
            {
                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["AGA-SCE"].ConnectionString))
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand(EsquemaSCE + ".[PR_NIS_EJECUCION_PL_QRY]", cn);
                    SqlParameter IdCampanaParameter = cmd.Parameters.Add("@IdCampaña", SqlDbType.VarChar);
                    SqlParameter IdClienteParameter = cmd.Parameters.Add("@IdCliente", SqlDbType.VarChar);
                    SqlParameter SemanaConsultaParameter = cmd.Parameters.Add("@SemanaConsulta", SqlDbType.Int);
                    SqlParameter FlagColorParameter = cmd.Parameters.Add("@FlagColor", SqlDbType.VarChar);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    IdCampanaParameter.Value = IdCampana;
                    IdClienteParameter.Value = IdCliente;
                    SemanaConsultaParameter.Value = SemanaConsulta;
                    FlagColorParameter.Value = FlagColor;

                    cmd.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    // this will query your database and return the result to your datatable
                    da.Fill(ProyeccionComercialTabla);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ProyeccionComercialTabla;
        }

        public DataTable GetProyeccionCampo(string IdCampana, string IdCliente, int SemanaConsulta, string FlagColor)
        {
            DataTable ProyeccionComercialTabla = new DataTable();
            try
            {
                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["AGA-SCE"].ConnectionString))
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand(EsquemaSCE + ".PR_PCC_PROYECCION_CAMPO_QRY_Nisira", cn);
                    SqlParameter IdCampanaParameter = cmd.Parameters.Add("@IdCampaña", SqlDbType.VarChar);
                    SqlParameter IdClienteParameter = cmd.Parameters.Add("@IdCliente", SqlDbType.VarChar);
                    SqlParameter SemanaConsultaParameter = cmd.Parameters.Add("@SemanaConsulta", SqlDbType.Int);
                    SqlParameter FlagColorParameter = cmd.Parameters.Add("@FlagColor", SqlDbType.VarChar);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    IdCampanaParameter.Value = IdCampana;
                    IdClienteParameter.Value = IdCliente;
                    SemanaConsultaParameter.Value = SemanaConsulta;
                    FlagColorParameter.Value = FlagColor;

                    cmd.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    // this will query your database and return the result to your datatable
                    da.Fill(ProyeccionComercialTabla);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ProyeccionComercialTabla;
        }


        public ICollection<SCEProyeccionComercial> GetProyeccionComercial
            (string IdCampana, string IdCliente, int SemanaConsulta, string FlagColor)
        {
            List<SCEProyeccionComercial> proyecciones = new List<SCEProyeccionComercial>();
            try
            {
                DbCommand cmd;
                cmd = objDBSCE.GetStoredProcCommand(EsquemaSCE + ".[PR_SCE_PROYECCION_COMERCIAL_QRY]");
                objDBSCE.AddInParameter(cmd, "@IdCampaña", DbType.String, IdCampana);
                objDBSCE.AddInParameter(cmd, "@IdCliente", DbType.String, IdCliente);
                objDBSCE.AddInParameter(cmd, "@SemanaConsulta", DbType.Int32, SemanaConsulta);
                objDBSCE.AddInParameter(cmd, "@FlagColor", DbType.String, FlagColor);
               
                foreach (DataRow dr in objDBSCE.ExecuteDataSet(cmd).Tables[0].Rows)
                {
                    SCEProyeccionComercial pr = new SCEProyeccionComercial();
                    pr.SCECampana = new SCECampana();
                    pr.SCECampana.IdCampana = dr[0].ToString();
                    pr.SCEClienteProveedor = new SCEClienteProveedor();
                    pr.SCEClienteProveedor.IdClienteProveedor = dr[1].ToString();
                    pr.SCEMercado = new SCEMercado();
                    pr.SCEMercado.IdMercado = dr[2].ToString();
                    pr.SCEEmbalaje = new SCEEmbalaje();
                    pr.SCEVariedad = new SCEVariedad();
                    pr.SCEVariedad.IdVariedad = dr[3].ToString();
                    pr.SCEEmbalaje.IdEmbalaje = dr[4].ToString();
                    pr.SCEClienteProveedor.RazonSocial = dr[5].ToString();
                    pr.SCEMercado.Descripcion = dr[6].ToString();
                    pr.SCEVariedad.Descripcion = dr[7].ToString();
                    pr.SCEEmbalaje.Descripcion = dr[8].ToString();
                    proyecciones.Add(pr);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return proyecciones;
        }


        public ICollection<SCEProyeccionComercial> GetEjecucionPackingList
           (string IdCampana, string IdCliente, int SemanaConsulta, string FlagColor)
        {
            List<SCEProyeccionComercial> proyecciones = new List<SCEProyeccionComercial>();
            try
            {
                DbCommand cmd;
                cmd = objDBSCE.GetStoredProcCommand(EsquemaSCE + ".[PR_NIS_EJECUCION_PL_QRY]");
                objDBSCE.AddInParameter(cmd, "@IdCampaña", DbType.String, IdCampana);
                objDBSCE.AddInParameter(cmd, "@IdCliente", DbType.String, IdCliente);
                objDBSCE.AddInParameter(cmd, "@SemanaConsulta", DbType.Int32, SemanaConsulta);
                objDBSCE.AddInParameter(cmd, "@FlagColor", DbType.String, FlagColor);
                
                foreach (DataRow dr in objDBSCE.ExecuteDataSet(cmd).Tables[0].Rows)
                {
                    SCEProyeccionComercial pr = new SCEProyeccionComercial();
                    pr.SCEClienteProveedor = new SCEClienteProveedor();
                    pr.SCEClienteProveedor.IdClienteProveedor = dr[0].ToString();
                    pr.SCEClienteProveedor.RazonSocial = dr[1].ToString();
                    pr.SCEMercado = new SCEMercado();
                    pr.SCEMercado.IdMercado = dr[2].ToString();
                    pr.SCEVariedad = new SCEVariedad();
                    pr.SCEVariedad.Descripcion = dr[3].ToString();
                    pr.SCEEmbalaje = new SCEEmbalaje();
                    pr.SCEEmbalaje.Descripcion = dr[4].ToString();
                   
                    proyecciones.Add(pr);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return proyecciones;
        }
        public SCEProyeccionComercial GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public SCEProyeccionComercial Save(SCEProyeccionComercial entidad)
        {
            throw new NotImplementedException();
        }

        public SCEProyeccionComercial Update(SCEProyeccionComercial entidad)
        {
            throw new NotImplementedException();
        }
    }
}