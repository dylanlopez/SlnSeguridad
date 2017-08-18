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
    public partial class DQuery : IDPerfilUsuarioRolQuery
    {
        public int Actualizar(DPerfilUsuarioRolDto dto)
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
                        var entity = DPerfilUsuarioRolConverter.ToEntity(dto);
                        _sessionMidis.Update(entity);
                        //_sessionMidis.Update(DPerfilUsuarioRolConverter.ToEntity(dto));
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
        public int Insertar(DPerfilUsuarioRolDto dto)
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
                        var entity = DPerfilUsuarioRolConverter.ToEntity(dto);
                        _sessionMidis.Save(entity);
                        //_sessionMidis.Save(DPerfilUsuarioRolConverter.ToEntity(dto));
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
        public List<DPerfilUsuarioRolDto> Listar(DPerfilUsuarioRolDto dto)
        {
            List<DPerfilUsuarioRolDto> list = null;
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
                        IQuery query = _sessionMidis.CreateQuery("FROM EPerfilUsuarioRol x " +
                                                                 "WHERE x.Perfil.Id = COALESCE(:p_IdPerfil, x.Perfil.Id) " +
                                                                 "AND x.Usuario.Id = COALESCE(:p_IdUsuario, x.Usuario.Id) " +
                                                                 "AND x.Rol.Id = COALESCE(:p_IdRol, x.Rol.Id) ");
                        if (dto.Perfil.Id != 0)
                        {
                            query.SetParameter("p_IdPerfil", dto.Perfil.Id);
                        }
                        else
                        {
                            query.SetParameter("p_IdPerfil", null, NHibernateUtil.Int32);
                        }
                        if (dto.Usuario.Id != 0)
                        {
                            query.SetParameter("p_IdUsuario", dto.Usuario.Id);
                        }
                        else
                        {
                            query.SetParameter("p_IdUsuario", null, NHibernateUtil.Int32);
                        }
                        if (dto.Rol.Id != 0)
                        {
                            query.SetParameter("p_IdRol", dto.Rol.Id);
                        }
                        else
                        {
                            query.SetParameter("p_IdRol", null, NHibernateUtil.Int32);
                        }

                        var result = query.List<EPerfilUsuarioRol>();
                        if (result != null)
                        {
                            list = DPerfilUsuarioRolConverter.ToDtos(result);
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