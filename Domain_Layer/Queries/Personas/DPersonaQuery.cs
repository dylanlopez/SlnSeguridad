﻿//using Domain_Layer.Connections;
//using Domain_Layer.Converters.Personas;
using Domain_Layer.Dtos.Personas;
using Domain_Layer.Queries.Personas;
using Entity_Layer.Entities.Personas;
using Logging_Layer;
//using NHibernate;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Reflection;

namespace Domain_Layer.Queries
{
    public partial class DQuery : IDPersonaQuery
    {
        public DPersonaDto Buscar(DPersonaDto dto)
        {
            //DPersonaDto item = null;
            //try
            //{
            //    using (_sessionMidis = _sessionFactoryMidis.OpenSession())
            //    {
            //        using (_transactionMidis = _sessionMidis.BeginTransaction())
            //        {
            //            string error = "";
            //            List<EPersona> resultado = new List<EPersona>();
            //            //IQuery query = _sessionMidis.GetNamedQuery("ES_SEGURIDAD.CZSP_GET_PERSONA_DATOS");
            //            IQuery query = _sessionMidis.CreateSQLQuery("CALL ES_SEGURIDAD.CZSP_GET_PERSONA_DATOS(:P_IN_DOC_NACIMIENTO, :P_NU_DOC_NACIMIENTO, :P_ERROR, :P_CUR_MENSAJE)");
            //            //IQuery query = _sessionMidis.CreateSQLQuery("CALL ES_SEGURIDAD.CZSP_GET_PERSONA_DATOS(:P_IN_DOC_NACIMIENTO, :P_NU_DOC_NACIMIENTO)");
            //            //IQuery query = _sessionMidis.CreateQuery("FROM EPersona x " +
            //            //                                         "WHERE x.NumeroDocumento = :p_NumeroDocumento");
            //            query.SetParameter("P_IN_DOC_NACIMIENTO", dto.TipoDocumento);
            //            query.SetParameter("P_NU_DOC_NACIMIENTO", dto.NumeroDocumento);
            //            query.SetParameter("P_ERROR", error);
            //            query.SetParameter("P_CUR_MENSAJE", resultado);
            //            var result = query.List<EPersona>();
            //            if (result != null)
            //            {
            //                if (result.Count > 0)
            //                {
            //                    item = DPersonaConverter.ToDto(result[0]);
            //                }
            //            }
            //            return item;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            OracleConnection oraConn = null;
            DPersonaDto item = null;
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
                oraConn.ConnectionString = _connection;
                string error = "";
                List<EPersona> resultado = new List<EPersona>();
                OracleDataAdapter da = new OracleDataAdapter();
                OracleCommand cmd = new OracleCommand();
                oraConn.Open();
                cmd.Connection = oraConn;
                //cmd.InitialLONGFetchSize = 1000;
                cmd.CommandText = "CZAVALETA.CZSP_GET_PERSONA_DATOS";
                //cmd.CommandText = "ES_SEGURIDAD.CZSP_GET_PERSONA_DATOS";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("P_IN_DOC_NACIMIENTO", OracleDbType.Varchar2).Value = dto.TipoDocumento;
                cmd.Parameters.Add("P_NU_DOC_NACIMIENTO", OracleDbType.Varchar2).Value = dto.NumeroDocumento;
                cmd.Parameters.Add("P_ERROR", OracleDbType.Varchar2).Direction = ParameterDirection.Output;
                cmd.Parameters["P_ERROR"].Size = 10;
                cmd.Parameters.Add("P_CUR_MENSAJE", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                //OracleDataReader reader = cmd.ExecuteReader();
                //OracleDataReader myReader = default(OracleDataReader);
                //while (reader.Read())
                //{
                //    var a = reader.GetString(0);
                //    var b = reader.GetString(1);
                //}
                error = cmd.Parameters["P_ERROR"].Value.ToString();
                OracleDataReader myReader;
                myReader = ((OracleRefCursor)cmd.Parameters["P_CUR_MENSAJE"].Value).GetDataReader();
                while (myReader.Read())
                {
                    item = new DPersonaDto();
                    item.Numero = Convert.ToInt32(myReader["NU_PERSONA"]);
                    item.TipoDocumento = myReader["IN_DOC_NACIMIENTO"].ToString();
                    item.NumeroDocumento = myReader["NU_DOC_NACIMIENTO"].ToString();
                    //item.ApellidoPaterno = myReader["NO_APELLIDO_PATERNO"].ToString();
                    item.ApellidoPaterno = myReader["AP_PRIMER"].ToString();
                    //item.ApellidoMaterno = myReader["NO_APELLIDO_MATERNO"].ToString();
                    item.ApellidoMaterno = myReader["AP_SEGUNDO"].ToString();
                    //item.Nombres = myReader["NO_NOMBRE"].ToString();
                    item.Nombres = myReader["PRENOM_INSCRITO"].ToString();
                }

                //da.SelectCommand = cmd;
                //DataTable dt = new DataTable();
                //item = new DPersonaDto();
                //da.Fill(dt);

                //foreach (DataRow dr in dt.Rows)
                //{

                //}
                //oraConn.Close();
                return item;
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