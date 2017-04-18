﻿using Domain_Layer.Converters.Personas;
using Domain_Layer.Dtos.Personas;
using Domain_Layer.Queries.Personas;
using Entity_Layer.Entities.Personas;
using NHibernate;
using System;
using System.Collections.Generic;

namespace Domain_Layer.Queries
{
    public partial class DQuery : IDPerfilUsuarioRolQuery
    {
        public int Actualizar(DPerfilUsuarioRolDto dto)
        {
            try
            {
                using (_sessionMidis = _sessionFactoryMidis.OpenSession())
                {
                    using (_transactionMidis = _sessionMidis.BeginTransaction())
                    {
                        _sessionMidis.Update(DPerfilUsuarioRolConverter.ToEntity(dto));
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
        public int Insertar(DPerfilUsuarioRolDto dto)
        {
            try
            {
                using (_sessionMidis = _sessionFactoryMidis.OpenSession())
                {
                    using (_transactionMidis = _sessionMidis.BeginTransaction())
                    {
                        _sessionMidis.Save(DPerfilUsuarioRolConverter.ToEntity(dto));
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
        public List<DPerfilUsuarioRolDto> Listar(DPerfilUsuarioRolDto dto)
        {
            List<DPerfilUsuarioRolDto> list = null;
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
                throw ex;
            }
        }
    }
}