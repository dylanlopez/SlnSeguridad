using Domain_Layer.Converters;
using Domain_Layer.Dtos;
using Domain_Layer.Queries.Sistemas;
using Entity_Layer.Entities;
using NHibernate;
using System;
using System.Collections.Generic;

namespace Domain_Layer.Queries
{
    public partial class DQuery : IDModuloQuery
    {
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