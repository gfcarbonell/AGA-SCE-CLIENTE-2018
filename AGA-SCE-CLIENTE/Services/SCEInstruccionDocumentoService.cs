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
    public class SCEInstruccionDocumentoService : ISCEInstruccionDocumento
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

        public ICollection<SCEInstruccionDocumento> Get()
        {
            throw new NotImplementedException();
        }

        public SCEInstruccionDocumento GetById(int IdArchivo)
        {
            SCEInstruccionDocumento pr = new SCEInstruccionDocumento();
            try
            {
                DbCommand cmd;
                cmd = objDBSCE.GetStoredProcCommand(EsquemaSCE + ".[PR_SCE_INSTRUCCION_DOCUMENTO_SEL]");
                objDBSCE.AddInParameter(cmd, "@IdDocumento", DbType.Int32, IdArchivo);

                using (System.Data.IDataReader dataReader = objDBSCE.ExecuteReader(cmd))
                {
                    if (dataReader.Read())
                    {
                        pr.IdDocumento = int.Parse(dataReader["IdDocumento"].ToString());
                        pr.SCEInstruccion = new SCEInstruccion();
                        pr.SCEInstruccion.NroPackingList = dataReader["NroPackingList"].ToString();
                        pr.SCEArchivo = new SCEArchivo();
                        pr.SCEArchivo.IdArchivo = int.Parse(dataReader["IdArchivo"].ToString());
                        pr.SCETipoDocumento = new SCETipoDocumento();
                        pr.SCETipoDocumento.IdTipoDocumento = dataReader["IdTipo"].ToString();
                        pr.SCETipoDocumento.Descripcion = dataReader["Tipo"].ToString();
                        pr.NombreArchivo = dataReader["NombreArchivo"].ToString();
                        pr.Descripcion = dataReader["Descripcion"].ToString();
                        pr.Tamano = float.Parse(dataReader["Tamaño"].ToString());
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

        public ICollection<SCEInstruccionDocumento> GetByNroPackingList(string NroPackingList)
        {
            List<SCEInstruccionDocumento> instruccionesDocumentos = new List<SCEInstruccionDocumento>();
            try
            {
                DbCommand cmd;
                cmd = objDBSCE.GetStoredProcCommand(EsquemaSCE + ".[PR_SCE_INSTRUCCION_DOCUMENTO_QRY]");
                objDBSCE.AddInParameter(cmd, "@NroPackingList", DbType.String, NroPackingList);



                foreach (DataRow dr in objDBSCE.ExecuteDataSet(cmd).Tables[0].Rows)
                {
                    SCEInstruccionDocumento pr = new SCEInstruccionDocumento();
                    pr.IdDocumento = int.Parse(dr[0].ToString());
                    pr.SCEInstruccion = new SCEInstruccion();
                    pr.SCEInstruccion.NroPackingList = dr[1].ToString();
                    pr.SCEArchivo = new SCEArchivo();
                    pr.SCEArchivo.IdArchivo = int.Parse(dr[2].ToString());
                    pr.SCETipoDocumento = new SCETipoDocumento();
                    pr.SCETipoDocumento.IdTipoDocumento = dr[3].ToString();
                    pr.SCETipoDocumento.Descripcion = dr[4].ToString();
                    pr.NombreArchivo = dr[5].ToString();
                    pr.Descripcion = dr[6].ToString();
                    pr.Tamano = float.Parse(dr[7].ToString());
                    pr.Estado = byte.Parse(dr[8].ToString());
                    instruccionesDocumentos.Add(pr);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return instruccionesDocumentos;
        }

        public SCEInstruccionDocumento Save(SCEInstruccionDocumento entidad)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["AGA-DOC"].ConnectionString))
                {
                    cn.Open();

                    SqlCommand commandArchivo = new SqlCommand(EsquemaDBO + ".[PR_AGA_ARCHIVO_INS]", cn);
                    SqlParameter DocumentoData = commandArchivo.Parameters.Add("@DocumentoData", SqlDbType.VarBinary, entidad.SCEArchivo.DocumentoData.Length);
                    //OUTPUT
                    SqlParameter IdArchivo = new SqlParameter("@IdArchivo", SqlDbType.Int) { Direction = ParameterDirection.Output };
                    commandArchivo.Parameters.Add(IdArchivo);
                    SqlParameter Mensaje = new SqlParameter("@Mensaje", SqlDbType.VarChar, 200) { Direction = ParameterDirection.Output };
                    commandArchivo.Parameters.Add(Mensaje);
                    commandArchivo.CommandType = System.Data.CommandType.StoredProcedure;
                    DocumentoData.Value = entidad.SCEArchivo.DocumentoData;
                    commandArchivo.ExecuteNonQuery();

                    using (SqlConnection cn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["AGA-SCE"].ConnectionString))
                    {
                        cn1.Open();
                        SqlCommand commandDocumento = new SqlCommand(EsquemaSCE + ".[PR_SCE_INSTRUCCION_DOCUMENTO_INS]", cn1);
                        SqlParameter NroPackingList = commandDocumento.Parameters.Add("@NroPackingList", SqlDbType.VarChar);
                        SqlParameter IdArchivoDocumento = commandDocumento.Parameters.Add("@IdArchivo", SqlDbType.Int);
                        SqlParameter IdTipoDocumento = commandDocumento.Parameters.Add("@IdTipo", SqlDbType.VarChar);
                        SqlParameter Nombre = commandDocumento.Parameters.Add("@NombreArchivo", SqlDbType.VarChar);
                        SqlParameter Descripcion = commandDocumento.Parameters.Add("@Descripcion", SqlDbType.VarChar);
                        SqlParameter Tamano = commandDocumento.Parameters.Add("@Tamaño", SqlDbType.Float);

                        //OUTPUT
                        SqlParameter IdDocumento = new SqlParameter("@IdDocumento", SqlDbType.Int) { Direction = ParameterDirection.Output };
                        commandDocumento.Parameters.Add(IdDocumento);
                        SqlParameter MensajeDocumento = new SqlParameter("@Mensaje", SqlDbType.VarChar, 200) { Direction = ParameterDirection.Output };
                        commandDocumento.Parameters.Add(MensajeDocumento);
                        commandDocumento.CommandType = System.Data.CommandType.StoredProcedure;

                        NroPackingList.Value = entidad.SCEInstruccion.NroPackingList;
                        IdArchivoDocumento.Value = IdArchivo.Value;
                        IdTipoDocumento.Value = entidad.SCETipoDocumento.IdTipoDocumento;
                        Nombre.Value = entidad.NombreArchivo;
                        Descripcion.Value = entidad.Descripcion;
                        Tamano.Value = entidad.Tamano;
                        commandDocumento.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return entidad;
        }

        public SCEInstruccionDocumento Update(SCEInstruccionDocumento entidad)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["AGA-DOC"].ConnectionString))
                {
                    cn.Open();

                    SqlCommand commandArchivo = new SqlCommand(EsquemaDBO + ".[PR_AGA_ARCHIVO_UPD]", cn);
                    SqlParameter IdArchivo = commandArchivo.Parameters.Add("@IdArchivo", SqlDbType.Int, entidad.SCEArchivo.IdArchivo);
                    SqlParameter DocumentoData = commandArchivo.Parameters.Add("@DocumentoData", SqlDbType.VarBinary, entidad.SCEArchivo.DocumentoData.Length);

                    //OUTPUT
                    SqlParameter Mensaje = new SqlParameter("@Mensaje", SqlDbType.VarChar, 200) { Direction = ParameterDirection.Output };
                    commandArchivo.Parameters.Add(Mensaje);
                    commandArchivo.CommandType = System.Data.CommandType.StoredProcedure;
                    IdArchivo.Value = entidad.SCEArchivo.IdArchivo;
                    DocumentoData.Value = entidad.SCEArchivo.DocumentoData;

                    commandArchivo.ExecuteNonQuery();

                    using (SqlConnection cn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["AGA-SCE"].ConnectionString))
                    {
                        cn1.Open();
                        SqlCommand commandDocumento = new SqlCommand(EsquemaSCE + ".[PR_SCE_INSTRUCCION_DOCUMENTO_UPD]", cn1);
                        SqlParameter IdDocumento = commandDocumento.Parameters.Add("@IdDocumento", SqlDbType.Int);
                        SqlParameter NroPackingList = commandDocumento.Parameters.Add("@NroPackingList", SqlDbType.VarChar);
                        SqlParameter IdArchivoDocumento = commandDocumento.Parameters.Add("@IdArchivo", SqlDbType.Int);
                        SqlParameter IdTipoDocumento = commandDocumento.Parameters.Add("@IdTipo", SqlDbType.VarChar);
                        SqlParameter Nombre = commandDocumento.Parameters.Add("@NombreArchivo", SqlDbType.VarChar);
                        SqlParameter Descripcion = commandDocumento.Parameters.Add("@Descripcion", SqlDbType.VarChar);
                        SqlParameter Tamano = commandDocumento.Parameters.Add("@Tamaño", SqlDbType.Float);

                        //OUTPUT
                        SqlParameter MensajeDocumento = new SqlParameter("@Mensaje", SqlDbType.VarChar, 200) { Direction = ParameterDirection.Output };
                        commandDocumento.Parameters.Add(MensajeDocumento);
                        commandDocumento.CommandType = System.Data.CommandType.StoredProcedure;

                        IdDocumento.Value = entidad.IdDocumento;
                        NroPackingList.Value = entidad.SCEInstruccion.NroPackingList;
                        IdArchivoDocumento.Value = entidad.SCEArchivo.IdArchivo;
                        IdTipoDocumento.Value = entidad.SCETipoDocumento.IdTipoDocumento;
                        Nombre.Value = entidad.NombreArchivo;
                        Descripcion.Value = entidad.Descripcion;
                        Tamano.Value = entidad.Tamano;
                        commandDocumento.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return entidad;
        }
    }
}