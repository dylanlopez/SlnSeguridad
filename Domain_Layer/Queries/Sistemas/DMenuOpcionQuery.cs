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
    public partial class DQuery : IDMenuOpcionQuery
    {
        public int Actualizar(DMenuOpcionDto dto)
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
                        var entity = DMenuOpcionConverter.ToEntity(dto);
                        _sessionMidis.Update(entity);
                        //_sessionMidis.Update(DMenuOpcionConverter.ToEntity(dto));
                        _transactionMidis.Commit();
                        //return dto.Id;
                        return entity.Id;
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
        public DMenuOpcionDto Buscar(DMenuOpcionDto dto)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            DMenuOpcionDto item = null;
            try
            {
                using (_sessionMidis = _sessionFactoryMidis.OpenSession())
                {
                    using (_transactionMidis = _sessionMidis.BeginTransaction())
                    {
                        IQuery query = _sessionMidis.CreateQuery("FROM EMenuOpcion x " +
                                                                 "WHERE x.Id = :p_Id ");
                        query.SetParameter("p_Id", dto.Id);
                        var result = query.List<EMenuOpcion>();
                        if (result != null)
                        {
                            if (result.Count > 0)
                            {
                                item = DMenuOpcionConverter.ToDto(result[0]);
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
        public int Eliminar(DMenuOpcionDto dto)
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
                        _sessionMidis.Delete(DMenuOpcionConverter.ToEntity(dto));
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
        public int Insertar(DMenuOpcionDto dto)
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
                        var entity = DMenuOpcionConverter.ToEntity(dto);
                        _sessionMidis.Save(entity);
                        //_sessionMidis.Save(DMenuOpcionConverter.ToEntity(dto));
                        _sessionMidis.Flush();
                        _transactionMidis.Commit();
                        //return dto.Id;
                        return entity.Id;
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
        public List<DMenuOpcionDto> Listar(DMenuOpcionDto dto)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            List<DMenuOpcionDto> list = null;
            try
            {
                using (_sessionMidis = _sessionFactoryMidis.OpenSession())
                {
                    using (_transactionMidis = _sessionMidis.BeginTransaction())
                    {
                        IQuery query = _sessionMidis.CreateQuery("FROM EMenuOpcion x " +
                                                                 "WHERE x.Menu.Id = COALESCE(:p_IdMenu, x.Menu.Id) ");
                        if (dto.Menu.Id != 0)
                        {
                            query.SetParameter("p_IdMenu", dto.Menu.Id);
                        }
                        else
                        {
                            query.SetParameter("p_IdMenu", null, NHibernateUtil.Int32);
                        }
                        var result = query.List<EMenuOpcion>();
                        if (result != null)
                        {
                            list = DMenuOpcionConverter.ToDtos(result);
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