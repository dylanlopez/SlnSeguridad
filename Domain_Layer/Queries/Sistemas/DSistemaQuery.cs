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
    public partial class DQuery : IDSistemaQuery
    {
        public int Actualizar(DSistemaDto dto)
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
                        var entity = DSistemaConverter.ToEntity(dto);
                        _sessionMidis.Update(entity);
                        //_sessionMidis.Update(DSistemaConverter.ToEntity(dto));
                        _transactionMidis.Commit();
                        //return dto.Id;
                        return entity.Id;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.WriteErrorLog(ex);
                if (_transactionMidis != null)
                {
                    if (_transactionMidis.IsActive)
                    {
                        if (!_transactionMidis.WasCommitted)
                        {
                            _transactionMidis.Rollback();
                        }
                    }
                }
                throw ex;
            }
            finally
            {
                _logger = null;
                if (_sessionMidis != null)
                {
                    if (_sessionMidis.IsOpen)
                    {
                        _sessionMidis.Close();
                    }
                }
            }
        }
        public DSistemaDto Buscar(DSistemaDto dto)
        {
            DSistemaDto item = null;
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
                        IQuery query = _sessionMidis.CreateQuery("FROM ESistema x " +
                                                                 "WHERE x.Id = :p_Id " +
                                                                 "OR x.Codigo = :p_Codigo");
                        query.SetParameter("p_Id", dto.Id);
                        query.SetParameter("p_Codigo", dto.Codigo);
                        var result = query.List<ESistema>();
                        if (result != null)
                        {
                            if (result.Count > 0)
                            {
                                item = DSistemaConverter.ToDto(result[0]);
                            }
                        }
                        return item;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.WriteErrorLog(ex);
                if (_transactionMidis != null)
                {
                    if (_transactionMidis.IsActive)
                    {
                        if (!_transactionMidis.WasCommitted)
                        {
                            _transactionMidis.Rollback();
                        }
                    }
                }
                throw ex;
            }
            finally
            {
                _logger = null;
                if (_sessionMidis != null)
                {
                    if (_sessionMidis.IsOpen)
                    {
                        _sessionMidis.Close();
                    }
                }
            }
        }
        public int Insertar(DSistemaDto dto)
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
                        var entity = DSistemaConverter.ToEntity(dto);
                        _sessionMidis.Save(entity);
                        //_sessionMidis.Save(DSistemaConverter.ToEntity(dto));
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
                if (_transactionMidis != null)
                {
                    if (_transactionMidis.IsActive)
                    {
                        if (!_transactionMidis.WasCommitted)
                        {
                            _transactionMidis.Rollback();
                        }
                    }
                }
                throw ex;
            }
            finally
            {
                _logger = null;
                if (_sessionMidis != null)
                {
                    if (_sessionMidis.IsOpen)
                    {
                        _sessionMidis.Close();
                    }
                }
            }
        }
        public List<DSistemaDto> Listar(DSistemaDto dto)
        {
            List<DSistemaDto> list = null;
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
                        IQuery query = _sessionMidis.CreateQuery("FROM ESistema x " +
                                                                 "WHERE x.Nombre LIKE CONCAT('%', :p_Nombre, '%') " +
                                                                 "AND x.Activo = COALESCE(:p_Activo, x.Activo) " +
                                                                 "ORDER BY x.Nombre");
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
                        var result = query.List<ESistema>();
                        if (result != null)
                        {
                            list = DSistemaConverter.ToDtos(result);
                        }
                        return list;
                    }
                }
            }
            catch(Exception ex)
            {
                _logger.WriteErrorLog(ex);
                if (_transactionMidis != null)
                {
                    if (_transactionMidis.IsActive)
                    {
                        if (!_transactionMidis.WasCommitted)
                        {
                            _transactionMidis.Rollback();
                        }
                    }
                }
                throw ex;
            }
            finally
            {
                _logger = null;
                if (_sessionMidis != null)
                {
                    if (_sessionMidis.IsOpen)
                    {
                        _sessionMidis.Close();
                    }
                }
            }
        }
    }
}