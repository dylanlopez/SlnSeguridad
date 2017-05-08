using Domain_Layer.Converters.Vistas;
using Domain_Layer.Dtos.Vistas;
using Domain_Layer.Queries.Vistas;
using Entity_Layer.Entities.Vistas;
using Logging_Layer;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace Domain_Layer.Queries
{
    public partial class DQuery : IDVistaPermisoQuery
    {
        public List<DVistaPermisoDto> Listar(DVistaPermisoDto dto)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            List<DVistaPermisoDto> list = null;
            try
            {
                _logger.WriteInfoLog("Step 0");
                using (_sessionMidis = _sessionFactoryMidis.OpenSession())
                {
                    _logger.WriteInfoLog("Step 1");
                    using (_transactionMidis = _sessionMidis.BeginTransaction())
                    {
                        _logger.WriteInfoLog("Step 2");
                        IQuery query = _sessionMidis.CreateQuery("FROM EVistaPermiso x " +
                                                                 "WHERE x.CodigoSistema = :p_CodigoSistema " +
                                                                 "AND x.Usuario = :p_Usuario " +
                                                                 "AND x.Contrasena = :p_Contrasena " +
                                                                 "ORDER BY x.NombreSistema, x.NombreModulo, x.NombreMenu ");
                        _logger.WriteInfoLog("Step 3");
                        query.SetParameter("p_CodigoSistema", dto.CodigoSistema.ToUpper());
                        query.SetParameter("p_Usuario", dto.Usuario);
                        query.SetParameter("p_Contrasena", dto.Contrasena);
                        _logger.WriteInfoLog("Step 4");
                        var result = query.List<EVistaPermiso>();
                        _logger.WriteInfoLog("Step 5");
                        if (result != null)
                        {
                            _logger.WriteInfoLog("Step 6");
                            list = DVistaPermisoConverter.ToDtos(result);
                            _logger.WriteInfoLog("Step 7");
                        }
                        return list;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.WriteErrorLog(ex);
                throw ex;
            }
            finally
            {
                _logger = null;
            }
        }
    }
}