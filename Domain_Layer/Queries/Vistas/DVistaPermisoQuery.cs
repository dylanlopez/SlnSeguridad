//using Domain_Layer.Converters.Vistas;
//using Domain_Layer.Dtos.Vistas;
//using Domain_Layer.Queries.Vistas;
//using Entity_Layer.Entities.Vistas;
//using Logging_Layer;
//using NHibernate;
//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Reflection;
using Domain_Layer.Connections;
using Domain_Layer.Converters.Vistas;
using Domain_Layer.Dtos.Vistas;
using Domain_Layer.Queries.Vistas;
using Entity_Layer.Entities.Vistas;
using Logging_Layer;
using NHibernate;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Reflection;

namespace Domain_Layer.Queries
{
    public partial class DQuery : IDVistaPermisoQuery
    {
        //public List<DVistaPermisoDto> Listar(DVistaPermisoDto dto)
        //{
        //    if (_logger == null)
        //    {
        //        _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
        //    }
        //    List<DVistaPermisoDto> list = null;
        //    try
        //    {
        //        //_logger.WriteInfoLog("Step 0");
        //        using (_sessionMidis = _sessionFactoryMidis.OpenSession())
        //        {
        //            //_logger.WriteInfoLog("Step 1");
        //            using (_transactionMidis = _sessionMidis.BeginTransaction())
        //            {
        //                //_logger.WriteInfoLog("Step 2");
        //                _sessionMidis.Evict(new EVistaPermiso());
        //                IQuery query = _sessionMidis.CreateQuery("FROM EVistaPermiso x " +
        //                                                         "WHERE x.CodigoSistema LIKE :p_CodigoSistema " +
        //                                                         "AND x.Usuario LIKE :p_Usuario " +
        //                                                         "AND x.Contrasena LIKE :p_Contrasena ");
        //                //"ORDER BY x.NombreSistema, x.NombreModulo, x.NombreMenu ");
        //                //IQuery query = _sessionMidis.CreateQuery("FROM EVistaPermiso x ");
        //                //_logger.WriteInfoLog("Step 3");
        //                query.SetParameter("p_CodigoSistema", dto.CodigoSistema);
        //                query.SetParameter("p_Usuario", dto.Usuario);
        //                query.SetParameter("p_Contrasena", dto.Contrasena);
        //                //_logger.WriteInfoLog("Step 4");
        //                var result = query.List<EVistaPermiso>();
        //                //_logger.WriteInfoLog("Step 5");
        //                if (result != null)
        //                {
        //                    //_logger.WriteInfoLog("Step 6");
        //                    list = DVistaPermisoConverter.ToDtos(result);
        //                    //_logger.WriteInfoLog("Step 7");
        //                }
        //                return list;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.WriteErrorLog(ex);
        //        throw ex;
        //    }
        //    finally
        //    {
        //        _logger = null;
        //    }
        //}
        public List<DVistaPermisoDto> Listar(DVistaPermisoDto dto)
        {
            OracleConnection oraConn = null;
            List<DVistaPermisoDto> list = null;
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                //var cns = "Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = 10.10.40.22)(PORT = 1521))(CONNECT_DATA =(SERVER = DEDICATED)(SERVICE_NAME = dbsisfoh))); User Id=DESA01;Password=oracle";
                //var cns = "Data Source=(DESCRIPTION = (ADDRESS_LIST= (ADDRESS= (PROTOCOL=TCP)(HOST=192.168.64.159)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=XE)));User Id=ES_SEGURIDAD;Password=midis2017";
                //var cns = "Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = 10.10.40.22)(PORT = 1521))(CONNECT_DATA =(SERVER = DEDICATED)(SERVICE_NAME = dbsisfoh))); User Id=DESA01;Password=oracle";
                oraConn = new OracleConnection();
                //OracleConnection cn = new OracleConnection(_connection);
                //cn.ConnectionString = cns;
                oraConn.ConnectionString = ConfigurationManager.ConnectionStrings["DBMIDIS"].ConnectionString;
                string error = "";
                OracleDataAdapter da = new OracleDataAdapter();
                OracleCommand cmd = new OracleCommand();
                oraConn.Open();
                cmd.Connection = oraConn;
                //cmd.InitialLONGFetchSize = 1000;
                string schemaSeguridad = ConfigurationManager.AppSettings["Schema"].ToString();
                cmd.CommandText = schemaSeguridad + ".PKG_SEGURIDAD.SEGSP_ACREDITACION";
                //cmd.CommandText = "ES_SEGURIDAD.CZSP_GET_PERSONA_DATOS";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("I_US_USUARIO", OracleDbType.Varchar2).Value = dto.Usuario;
                cmd.Parameters.Add("I_US_CONTRASENA", OracleDbType.Varchar2).Value = dto.Contrasena;
                cmd.Parameters.Add("I_US_CONTRASENA", OracleDbType.Varchar2).Value = dto.CodigoSistema;
                cmd.Parameters.Add("P_CUR_RESULT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                //OracleDataReader reader = cmd.ExecuteReader();
                //OracleDataReader myReader = default(OracleDataReader);
                //while (reader.Read())
                //{
                //    var a = reader.GetString(0);
                //    var b = reader.GetString(1);
                //}
                OracleDataReader myReader;
                myReader = ((OracleRefCursor)cmd.Parameters["P_CUR_RESULT"].Value).GetDataReader();
                list = new List<DVistaPermisoDto>();
                while (myReader.Read())
                {
                    DVistaPermisoDto item = new DVistaPermisoDto();
                    item.IdTipoInstitucion = Convert.ToInt32(myReader["ID_INSTITUCION_TIPO"]);
                    item.TipoInstitucion = myReader["NO_INSTITUCION_TIPO"].ToString();
                    item.IdInstitucion = Convert.ToInt32(myReader["ID_INSTITUCION"]);
                    item.Institucion = myReader["NO_INSTITUCION"].ToString();
                    item.InstitucionCorto = myReader["NO_INSTITUCION_CORTA"].ToString();
                    item.IdPerfil = Convert.ToInt32(myReader["ID_PERFIL"]);
                    item.NombrePerfil = myReader["NO_PERFIL"].ToString();
                    item.Usuario = myReader["US_USUARIO"].ToString();
                    item.Contrasena = myReader["US_CONTRASENA"].ToString();
                    item.ApellidoPaterno = myReader["NO_APELLIDO_PATERNO"].ToString();
                    item.ApellidoMaterno = myReader["NO_APELLIDO_MATERNO"].ToString();
                    item.Nombres = myReader["NO_NOMBRE"].ToString();
                    item.Ubigeo = myReader["UBIGEO"].ToString();
                    item.CodigoVersion = Convert.ToInt32(myReader["CO_VERSION"]);
                    item.Email = myReader["NO_EMAIL"].ToString();
                    item.Caduca = Convert.ToChar(myReader["IN_CADUCA"]);
                    item.FechaUltimoCambio = Convert.ToDateTime(myReader["FE_ULTIMOCAMBIO"]);
                    item.PeriodoCaducidad = Convert.ToInt32(myReader["NU_PERIODO_CADUCIDAD"]);
                    item.PrimeraVez = Convert.ToChar(myReader["IN_PRIMERA_VEZ"]);
                    item.IdRol = Convert.ToInt32(myReader["ID_ROL"]);
                    item.NombreRol = myReader["NO_ROL"].ToString();
                    item.IdSistema = Convert.ToInt32(myReader["ID_SISTEMA"]);
                    item.CodigoSistema = myReader["CO_SISTEMA"].ToString();
                    item.AbreviaturaSistema = myReader["NO_ABREVIATURA"].ToString();
                    item.NombreSistema = myReader["NO_SISTEMA"].ToString();
                    item.RutaLogica = myReader["DE_RUTA_LOGICA"].ToString();
                    item.IdModulo = Convert.ToInt32(myReader["ID_MODULO"]);
                    item.CodigoModulo = myReader["CO_MODULO"].ToString();
                    item.NombreModulo = myReader["NO_MODULO"].ToString();
                    item.IdMenu = Convert.ToInt32(myReader["ID_MENU"]);
                    item.CodigoMenu = myReader["CO_MENU"].ToString();
                    item.NombreMenu = myReader["NO_MENU"].ToString();
                    item.MenuRuta = myReader["DE_RUTA"].ToString();
                    item.IdOpcion = Convert.ToInt32(myReader["ID_OPCION"]);
                    item.NombreOpcion = myReader["NO_OPCION"].ToString();
                    item.ControlAsociado = myReader["NO_CONTROL_ASOC"].ToString();
                    item.Visible = Convert.ToChar(myReader["IN_VISIBLE"]);
                    list.Add(item);
                }
                //oraConn.Close();
                return list;
            }
            catch (Exception ex)
            {
                _logger.WriteErrorLog(ex);
                throw ex;
            }
            finally
            {
                _logger = null;
                if (oraConn != null)
                {
                    if (oraConn.State == ConnectionState.Open)
                    {
                        oraConn.Close();
                    }
                }
            }
        }
    }
}