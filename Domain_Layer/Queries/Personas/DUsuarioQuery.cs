﻿using Domain_Layer.Converters.Personas;
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
                        _sessionMidis.Update(DUsuarioConverter.ToEntity(dto));
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
                        _sessionMidis.Save(DUsuarioConverter.ToEntity(dto));
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
                                                                 "WHERE x.Tipo = COALESCE(:p_Tipo, x.Tipo) " +
                                                                 "AND x.Estado = COALESCE(:p_Estado, x.Estado) ");
                        if (dto.Tipo != '\0')
                        {
                            query.SetParameter("p_Tipo", dto.Tipo);
                        }
                        else
                        {
                            query.SetParameter("p_Tipo", null, NHibernateUtil.Character);
                        }
                        if (dto.Estado != '\0')
                        {
                            query.SetParameter("p_Estado", dto.Estado);
                        }
                        else
                        {
                            query.SetParameter("p_Estado", null, NHibernateUtil.Character);
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