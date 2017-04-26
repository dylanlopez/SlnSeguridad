using Domain_Layer.Converters.Personas;
using Domain_Layer.Dtos.Personas;
using Domain_Layer.Queries.Personas;
using Entity_Layer.Entities.Personas;
using NHibernate;
using System;
using System.Collections.Generic;

namespace Domain_Layer.Queries
{
    public partial class DQuery : IDPermisoQuery
    {
        public int Actualizar(DPermisoDto dto)
        {
            try
            {
                using (_sessionMidis = _sessionFactoryMidis.OpenSession())
                {
                    using (_transactionMidis = _sessionMidis.BeginTransaction())
                    {
                        _sessionMidis.Update(DPermisoConverter.ToEntity(dto));
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
        public DPermisoDto Buscar(DPermisoDto dto)
        {
            DPermisoDto item = null;
            try
            {
                using (_sessionMidis = _sessionFactoryMidis.OpenSession())
                {
                    using (_transactionMidis = _sessionMidis.BeginTransaction())
                    {
                        IQuery query = _sessionMidis.CreateQuery("FROM EPermiso x " +
                                                                 "WHERE x.Id = :p_Id ");
                        query.SetParameter("p_Id", dto.Id);
                        var result = query.List<EPermiso>();
                        if (result != null)
                        {
                            if (result.Count > 0)
                            {
                                item = DPermisoConverter.ToDto(result[0]);
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
        public int Eliminar(DPermisoDto dto)
        {
            try
            {
                using (_sessionMidis = _sessionFactoryMidis.OpenSession())
                {
                    using (_transactionMidis = _sessionMidis.BeginTransaction())
                    {
                        _sessionMidis.Delete(DPermisoConverter.ToEntity(dto));
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
        public int Insertar(DPermisoDto dto)
        {
            try
            {
                using (_sessionMidis = _sessionFactoryMidis.OpenSession())
                {
                    using (_transactionMidis = _sessionMidis.BeginTransaction())
                    {
                        _sessionMidis.Save(DPermisoConverter.ToEntity(dto));
                        _sessionMidis.Flush();
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
        public List<DPermisoDto> Listar(DPermisoDto dto)
        {
            List<DPermisoDto> list = null;
            try
            {
                using (_sessionMidis = _sessionFactoryMidis.OpenSession())
                {
                    using (_transactionMidis = _sessionMidis.BeginTransaction())
                    {
                        IQuery query = _sessionMidis.CreateQuery("FROM EPermiso x " +
                                                                 "WHERE x.PerfilUsuarioRol.Perfil.Id = :p_IdPerfil " +
                                                                 "AND x.PerfilUsuarioRol.Usuario.Id = :p_IdUsuario " +
                                                                 "AND x.PerfilUsuarioRol.Rol.Id = :p_IdRol " +
                                                                 "AND x.PerfilUsuarioRol.Activo = 'S' " +
                                                                 "AND x.MenuOpcion.Menu.Modulo.Sistema.Id = COALESCE(:p_IdSistema, x.MenuOpcion.Menu.Modulo.Sistema.Id) " +
                                                                 "AND x.MenuOpcion.Menu.Modulo.Id = COALESCE(:p_IdModulo, x.MenuOpcion.Menu.Modulo.Id) " +
                                                                 "AND x.MenuOpcion.Menu.Id = COALESCE(:p_IdMenu, x.MenuOpcion.Menu.Id) " +
                                                                 "AND x.MenuOpcion.Activo = 'S' " +
                                                                 "AND x.Activo = COALESCE(:p_Activo, x.Activo) ");
                        query.SetParameter("p_IdPerfil", dto.PerfilUsuarioRol.Perfil.Id);
                        query.SetParameter("p_IdUsuario", dto.PerfilUsuarioRol.Usuario.Id);
                        query.SetParameter("p_IdRol", dto.PerfilUsuarioRol.Rol.Id);
                        if (dto.MenuOpcion.Menu.Modulo.Sistema.Id != 0)
                        {
                            query.SetParameter("p_IdSistema", dto.MenuOpcion.Menu.Modulo.Sistema.Id);
                        }
                        else
                        {
                            query.SetParameter("p_IdSistema", null, NHibernateUtil.Int32);
                        }
                        if (dto.MenuOpcion.Menu.Modulo.Id != 0)
                        {
                            query.SetParameter("p_IdModulo", dto.MenuOpcion.Menu.Modulo.Id);
                        }
                        else
                        {
                            query.SetParameter("p_IdModulo", null, NHibernateUtil.Int32);
                        }
                        if (dto.MenuOpcion.Menu.Id != 0)
                        {
                            query.SetParameter("p_IdMenu", dto.MenuOpcion.Menu.Id);
                        }
                        else
                        {
                            query.SetParameter("p_IdMenu", null, NHibernateUtil.Int32);
                        }
                        if (dto.Activo != '\0')
                        {
                            query.SetParameter("p_Activo", dto.Activo);
                        }
                        else
                        {
                            query.SetParameter("p_Activo", null, NHibernateUtil.Character);
                        }
                        var result = query.List<EPermiso>();
                        if (result != null)
                        {
                            list = DPermisoConverter.ToDtos(result);
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