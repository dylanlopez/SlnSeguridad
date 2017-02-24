using Domain_Layer.Converters;
using Domain_Layer.Dtos;
using Domain_Layer.Queries.Sistemas;
using Entity_Layer.Entities;
using NHibernate;
using System;
using System.Collections.Generic;

namespace Domain_Layer.Queries
{
    public partial class DQuery : IDSistemaQuery
    {
        public List<DSistemaDto> Listar(DSistemaDto dto)
        {
            List<DSistemaDto> list = null;
            try
            {
                using (_sessionMidis = _sessionFactoryMidis.OpenSession())
                {
                    using (_transactionMidis = _sessionMidis.BeginTransaction())
                    {
                        IQuery query = _sessionMidis.CreateQuery("FROM ESistema x " +
                                                                 "WHERE x.Estado = COALESCE(:p_Estado, x.Estado) ");
                        if (dto.Estado != '\0')
                        {
                            query.SetParameter("p_Estado", dto.Estado);
                        }
                        else
                        {
                            query.SetParameter("p_Estado", null, NHibernateUtil.Character);
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
                throw ex;
            }
        }
    }
}