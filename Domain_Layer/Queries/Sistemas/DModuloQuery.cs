﻿using Domain_Layer.Converters.Sistemas;
using Domain_Layer.Dtos.Sistemas;
using Domain_Layer.Queries.Sistemas;
using Entity_Layer.Entities.Sistemas;
using NHibernate;
using System;
using System.Collections.Generic;

namespace Domain_Layer.Queries
{
    public partial class DQuery : IDModuloQuery
    {
        public int Actualizar(DModuloDto dto)
        {
            try
            {
                using (_sessionMidis = _sessionFactoryMidis.OpenSession())
                {
                    using (_transactionMidis = _sessionMidis.BeginTransaction())
                    {
                        _sessionMidis.Update(DModuloConverter.ToEntity(dto));
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
        public DModuloDto Buscar(DModuloDto dto)
        {
            DModuloDto item = null;
            try
            {
                using (_sessionMidis = _sessionFactoryMidis.OpenSession())
                {
                    using (_transactionMidis = _sessionMidis.BeginTransaction())
                    {
                        IQuery query = _sessionMidis.CreateQuery("FROM EModulo x " +
                                                                 "WHERE x.Id = :p_Id " +
                                                                 "OR x.Codigo = :p_Codigo");
                        query.SetParameter("p_Id", dto.Id);
                        query.SetParameter("p_Codigo", dto.Codigo);
                        var result = query.List<EModulo>();
                        if (result != null)
                        {
                            if (result.Count > 0)
                            {
                                item = DModuloConverter.ToDto(result[0]);
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
        public int Insertar(DModuloDto dto)
        {
            try
            {
                using (_sessionMidis = _sessionFactoryMidis.OpenSession())
                {
                    using (_transactionMidis = _sessionMidis.BeginTransaction())
                    {
                        _sessionMidis.Save(DModuloConverter.ToEntity(dto));
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
        public List<DModuloDto> Listar(DModuloDto dto)
        {
            List<DModuloDto> list = null;
            try
            {
                using (_sessionMidis = _sessionFactoryMidis.OpenSession())
                {
                    using (_transactionMidis = _sessionMidis.BeginTransaction())
                    {
                        IQuery query = _sessionMidis.CreateQuery("FROM EModulo x " +
                                                                 "WHERE x.Estado = COALESCE(:p_Estado, x.Estado) " +
                                                                 "AND x.Sistema.Id = COALESCE(:p_IdSistema, x.Sistema.Id)");
                        if (dto.Estado != '\0')
                        {
                            query.SetParameter("p_Estado", dto.Estado);
                        }
                        else
                        {
                            query.SetParameter("p_Estado", null, NHibernateUtil.Character);
                        }
                        if (dto.Sistema.Id != 0)
                        {
                            query.SetParameter("p_IdSistema", dto.Sistema.Id);
                        }
                        else
                        {
                            query.SetParameter("p_IdSistema", null, NHibernateUtil.Int32);
                        }
                        var result = query.List<EModulo>();
                        if (result != null)
                        {
                            list = DModuloConverter.ToDtos(result);
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