using Domain_Layer.Converters.Personas;
using Domain_Layer.Dtos.Personas;
using Domain_Layer.Queries.Personas;
using Entity_Layer.Entities.Personas;
using NHibernate;
using System;
using System.Collections.Generic;

namespace Domain_Layer.Queries
{
    public partial class DQuery : IDUsuarioQuery
    {
        public int Actualizar(DUsuarioDto dto)
        {
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
                throw ex;
            }
        }
        public int ActualizarContrasena(DUsuarioDto dto)
        {
            try
            {
                using (_sessionMidis = _sessionFactoryMidis.OpenSession())
                {
                    using (_transactionMidis = _sessionMidis.BeginTransaction())
                    {
                        IQuery query = _sessionMidis.CreateQuery("UPDATE EUsuario " +
                                                                 "SET Contrasena = :p_Contrasena " +
                                                                 "WHERE Usuario = :p_Usuario ");
                        query.SetParameter("p_Usuario", dto.Usuario);
                        query.SetParameter("p_Contrasena", dto.Contrasena);
                        int result = query.ExecuteUpdate();
                        _transactionMidis.Commit();
                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DUsuarioDto Buscar(DUsuarioDto dto)
        {
            DUsuarioDto item = null;
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
                throw ex;
            }
        }
        public DUsuarioDto BuscarPorUsuario(DUsuarioDto dto)
        {
            DUsuarioDto item = null;
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
                throw ex;
            }
        }
        public int Eliminar(DUsuarioDto dto)
        {
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
                throw ex;
            }
        }
        public int Insertar(DUsuarioDto dto)
        {
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
                throw ex;
            }
        }
        public List<DUsuarioDto> Listar(DUsuarioDto dto)
        {
            List<DUsuarioDto> list = null;
            try
            {
                using (_sessionMidis = _sessionFactoryMidis.OpenSession())
                {
                    using (_transactionMidis = _sessionMidis.BeginTransaction())
                    {
                        IQuery query = _sessionMidis.CreateQuery("FROM EUsuario x " +
                                                                 "WHERE x.ApellidoPaterno LIKE CONCAT('%', :p_ApellidoPaterno, '%') " +
                                                                 "AND x.ApellidoMaterno LIKE CONCAT('%', :p_ApellidoMaterno, '%') " +
                                                                 "AND x.Nombres LIKE CONCAT('%', :p_Nombres, '%') ");
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
                throw ex;
            }
        }
    }
}