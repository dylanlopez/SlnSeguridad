using Domain_Layer.Converters.Personas;
using Domain_Layer.Dtos.Personas;
using Domain_Layer.Queries.Personas;
using Entity_Layer.Entities.Personas;
using Logging_Layer;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;

namespace Domain_Layer.Queries
{
    public partial class DQuery : IDUsuarioQuery
    {
        public int Actualizar(DUsuarioDto dto)
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
                        var entity = DUsuarioConverter.ToEntity(dto);
                        _sessionMidis.Update(entity);
                        //_sessionMidis.Update(DUsuarioConverter.ToEntity(dto));
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
        public int ActualizarContrasena(DUsuarioDto dto)
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
                        IQuery query = _sessionMidis.CreateQuery("UPDATE EUsuario " +
                                                                 "SET Contrasena = :p_Contrasena, " +
                                                                 "FechaUltimoCambio = :p_FechaUltimoCambio, " +
                                                                 "PrimeraVez = 'N' " +
                                                                 "WHERE Usuario = :p_Usuario ");
                        query.SetParameter("p_Usuario", dto.Usuario);
                        query.SetParameter("p_Contrasena", dto.Contrasena);
                        //query.SetParameter("p_FechaUltimoCambio", dto.FechaUltimoCambio);
                        query.SetParameter("p_FechaUltimoCambio", DateTime.ParseExact(dto.FechaUltimoCambio, "dd/MM/yyyy", CultureInfo.InvariantCulture));
                        int result = query.ExecuteUpdate();
                        _transactionMidis.Commit();
                        return result;
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
        public int ActualizarEstado(DUsuarioDto dto)
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
                        //IQuery query = _sessionMidis.CreateQuery("UPDATE EUsuario " +
                        //                                         "SET HaIngresado = :p_HaIngresado " +
                        //                                         "WHERE Usuario = :p_Usuario " +
                        //                                         "AND Contrasena = :p_Contrasena ");
                        IQuery query = _sessionMidis.CreateQuery("UPDATE EUsuario " +
                                                                 "SET HaIngresado = :p_HaIngresado " +
                                                                 "WHERE Usuario = :p_Usuario ");
                        query.SetParameter("p_Usuario", dto.Usuario);
                        //query.SetParameter("p_Contrasena", dto.Contrasena);
                        query.SetParameter("p_HaIngresado", dto.HaIngresado);
                        int result = query.ExecuteUpdate();
                        _transactionMidis.Commit();
                        return result;
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
        public DUsuarioDto Buscar(DUsuarioDto dto)
        {
            DUsuarioDto item = null;
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
                        IQuery query = _sessionMidis.CreateQuery("FROM EUsuario x " +
                                                                 "WHERE x.Id = :p_Id " +
                                                                 "OR (x.Usuario = :p_Usuario " +
                                                                 " AND x.Contrasena = :p_Contrasena) ");
                        query.SetParameter("p_Id", dto.Id);
                        query.SetParameter("p_Usuario", dto.Usuario);
                        query.SetParameter("p_Contrasena", dto.Contrasena);
                        var result = query.List<EUsuario>();
                        if (result != null)
                        {
                            if (result.Count > 0)
                            {
                                item = DUsuarioConverter.ToDto(result[0]);
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
        public DUsuarioDto BuscarPorUsuario(DUsuarioDto dto)
        {
            DUsuarioDto item = null;
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
                        IQuery query = _sessionMidis.CreateQuery("FROM EUsuario x " +
                                                                 "WHERE x.Usuario = :p_Usuario ");
                        query.SetParameter("p_Usuario", dto.Usuario);
                        var result = query.List<EUsuario>();
                        if (result != null)
                        {
                            if (result.Count > 0)
                            {
                                item = DUsuarioConverter.ToDto(result[0]);
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
        public int Eliminar(DUsuarioDto dto)
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
                        _sessionMidis.Delete(DUsuarioConverter.ToEntity(dto));
                        _transactionMidis.Commit();
                        return dto.Id;
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
        public int Insertar(DUsuarioDto dto)
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
                        var entity = DUsuarioConverter.ToEntity(dto);
                        _sessionMidis.Save(entity);
                        //_sessionMidis.Save(DUsuarioConverter.ToEntity(dto));
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
        public List<DUsuarioDto> Listar(DUsuarioDto dto)
        {
            List<DUsuarioDto> list = null;
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
                        IQuery query = _sessionMidis.CreateQuery("FROM EUsuario x " +
                                                                 "WHERE x.ApellidoPaterno LIKE CONCAT('%', :p_ApellidoPaterno, '%') " +
                                                                 "AND x.ApellidoMaterno LIKE CONCAT('%', :p_ApellidoMaterno, '%') " +
                                                                 "AND x.Nombres LIKE CONCAT('%', :p_Nombres, '%') " +
                                                                 "AND x.Institucion.Id = COALESCE(:p_IdInstitucion, x.Institucion.Id) " +
                                                                 "AND x.Institucion.TipoInstitucion.Id = COALESCE(:p_IdTipoInstitucion, x.Institucion.TipoInstitucion.Id) " + 
                                                                 "ORDER BY x.ApellidoPaterno, x.ApellidoMaterno, x.Nombres ");
                        if (!dto.ApellidoPaterno.Equals(String.Empty))
                        {
                            query.SetParameter("p_ApellidoPaterno", dto.ApellidoPaterno.ToUpper());
                        }
                        else
                        {
                            query.SetParameter("p_ApellidoPaterno", null, NHibernateUtil.String);
                        }
                        if (!dto.ApellidoMaterno.Equals(String.Empty))
                        {
                            query.SetParameter("p_ApellidoMaterno", dto.ApellidoMaterno.ToUpper());
                        }
                        else
                        {
                            query.SetParameter("p_ApellidoMaterno", null, NHibernateUtil.String);
                        }
                        if (!dto.Nombres.Equals(String.Empty))
                        {
                            query.SetParameter("p_Nombres", dto.Nombres.ToUpper());
                        }
                        else
                        {
                            query.SetParameter("p_Nombres", null, NHibernateUtil.String);
                        }
                        if (dto.Institucion.Id != 0)
                        {
                            query.SetParameter("p_IdInstitucion", dto.Institucion.Id);
                        }
                        else
                        {
                            query.SetParameter("p_IdInstitucion", null, NHibernateUtil.Int32);
                        }
                        if (dto.Institucion.TipoInstitucion.Id != 0)
                        {
                            query.SetParameter("p_IdTipoInstitucion", dto.Institucion.TipoInstitucion.Id);
                        }
                        else
                        {
                            query.SetParameter("p_IdTipoInstitucion", null, NHibernateUtil.Int32);
                        }
                        var result = query.List<EUsuario>();
                        if (result != null)
                        {
                            list = DUsuarioConverter.ToDtos(result);
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