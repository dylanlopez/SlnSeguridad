using Domain_Layer.Converters.Sistemas;
using Domain_Layer.Dtos.Sistemas;
using Domain_Layer.Queries.Sistemas;
using Entity_Layer.Entities.Sistemas;
using Logging_Layer;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace Domain_Layer.Queries
{
    public partial class DQuery : IDMenuQuery
    {
        public int Actualizar(DMenuDto dto)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                using (_sessionMidis = _sessionFactoryMidis.OpenSession())
                {
                    using (_transactionMidis = _sessionMidis.BeginTransaction())
                    {
                        _sessionMidis.Update(DMenuConverter.ToEntity(dto));
                        _transactionMidis.Commit();
                        return dto.Id;
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
        public DMenuDto Buscar(DMenuDto dto)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            DMenuDto item = null;
            try
            {
                using (_sessionMidis = _sessionFactoryMidis.OpenSession())
                {
                    using (_transactionMidis = _sessionMidis.BeginTransaction())
                    {
                        IQuery query = _sessionMidis.CreateQuery("FROM EMenu x " +
                                                                 "WHERE x.Id = :p_Id " +
                                                                 "OR x.Codigo = :p_Codigo");
                        query.SetParameter("p_Id", dto.Id);
                        query.SetParameter("p_Codigo", dto.Codigo);
                        var result = query.List<EMenu>();
                        if (result != null)
                        {
                            if (result.Count > 0)
                            {
                                item = DMenuConverter.ToDto(result[0]);
                            }
                        }
                        return item;
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
        public int Eliminar(DMenuDto dto)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                using (_sessionMidis = _sessionFactoryMidis.OpenSession())
                {
                    using (_transactionMidis = _sessionMidis.BeginTransaction())
                    {
                        _sessionMidis.Delete(DMenuConverter.ToEntity(dto));
                        _transactionMidis.Commit();
                        return dto.Id;
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
        public int Insertar(DMenuDto dto)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                using (_sessionMidis = _sessionFactoryMidis.OpenSession())
                {
                    using (_transactionMidis = _sessionMidis.BeginTransaction())
                    {
                        _sessionMidis.Save(DMenuConverter.ToEntity(dto));
                        _sessionMidis.Flush();
                        _transactionMidis.Commit();
                        return dto.Id;
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
        public List<DMenuDto> Listar(DMenuDto dto)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            List<DMenuDto> list = null;
            try
            {
                using (_sessionMidis = _sessionFactoryMidis.OpenSession())
                {
                    using (_transactionMidis = _sessionMidis.BeginTransaction())
                    {
                        IQuery query = _sessionMidis.CreateQuery("FROM EMenu x " +
                                                                 "WHERE x.Nombre LIKE CONCAT('%', :p_Nombre, '%') " +
                                                                 "AND x.Activo = COALESCE(:p_Activo, x.Activo) " +
                                                                 "AND x.Modulo.Sistema.Id = COALESCE(:p_IdSistema, x.Modulo.Sistema.Id) " +
                                                                 "AND x.Modulo.Id = COALESCE(:p_IdModulo, x.Modulo.Id) " +
                                                                 "ORDER BY x.Modulo.Sistema.Nombre, x.Modulo.Nombre, x.Nombre");
                        if (!dto.Nombre.Equals(String.Empty))
                        {
                            query.SetParameter("p_Nombre", dto.Nombre.ToUpper());
                        }
                        else
                        {
                            query.SetParameter("p_Nombre", null, NHibernateUtil.String);
                        }
                        if (dto.Activo != '\0')
                        {
                            query.SetParameter("p_Activo", dto.Activo);
                        }
                        else
                        {
                            query.SetParameter("p_Activo", null, NHibernateUtil.Character);
                        }
                        if (dto.Modulo.Sistema.Id != 0)
                        {
                            query.SetParameter("p_IdSistema", dto.Modulo.Sistema.Id);
                        }
                        else
                        {
                            query.SetParameter("p_IdSistema", null, NHibernateUtil.Int32);
                        }
                        if (dto.Modulo.Id != 0)
                        {
                            query.SetParameter("p_IdModulo", dto.Modulo.Id);
                        }
                        else
                        {
                            query.SetParameter("p_IdModulo", null, NHibernateUtil.Int32);
                        }
                        var result = query.List<EMenu>();
                        if (result != null)
                        {
                            list = DMenuConverter.ToDtos(result);
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