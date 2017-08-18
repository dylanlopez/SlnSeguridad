using Domain_Layer.Converters.Personas;
using Domain_Layer.Dtos.Personas;
using Domain_Layer.Queries.Personas;
using Entity_Layer.Entities.Personas;
using Logging_Layer;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace Domain_Layer.Queries
{
    public partial class DQuery : IDInstitucionQuery
    {
        public int Actualizar(DInstitucionDto dto)
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
                        var entity = DInstitucionConverter.ToEntity(dto);
                        _sessionMidis.Update(entity);
                        _transactionMidis.Commit();
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
        public DInstitucionDto Buscar(DInstitucionDto dto)
        {
            DInstitucionDto item = null;
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
                        IQuery query = _sessionMidis.CreateQuery("FROM EInstitucion x " +
                                                                 "WHERE x.Id = :p_Id ");
                        query.SetParameter("p_Id", dto.Id);
                        var result = query.List<EInstitucion>();
                        if (result != null)
                        {
                            if (result.Count > 0)
                            {
                                item = DInstitucionConverter.ToDto(result[0]);
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
        public int Insertar(DInstitucionDto dto)
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
                        var entity = DInstitucionConverter.ToEntity(dto);
                        _sessionMidis.Save(entity);
                        _sessionMidis.Flush();
                        _transactionMidis.Commit();
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
        public List<DInstitucionDto> Listar(DInstitucionDto dto)
        {
            List<DInstitucionDto> list = null;
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
                        IQuery query = _sessionMidis.CreateQuery("FROM EInstitucion x " +
                                                                 "WHERE x.Nombre LIKE CONCAT('%', :p_Nombre, '%') " +
                                                                 "AND x.Activo = COALESCE(:p_Activo, x.Activo) " +
                                                                 "AND x.TipoInstitucion.Id = COALESCE(:p_IdTipoInstitucion, x.TipoInstitucion.Id) " +
                                                                 "ORDER BY x.TipoInstitucion.Nombre, x.Nombre");
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
                        if (dto.TipoInstitucion.Id != 0)
                        {
                            query.SetParameter("p_IdTipoInstitucion", dto.TipoInstitucion.Id);
                        }
                        else
                        {
                            query.SetParameter("p_IdTipoInstitucion", null, NHibernateUtil.Int32);
                        }
                        var result = query.List<EInstitucion>();
                        if (result != null)
                        {
                            list = DInstitucionConverter.ToDtos(result);
                        }
                        return list;
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
    }
}