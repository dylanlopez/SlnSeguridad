using Domain_Layer.Converters.Personas;
using Domain_Layer.Dtos.Personas;
using Domain_Layer.Queries.Personas;
using Entity_Layer.Entities.Personas;
using NHibernate;
using System;
using System.Collections.Generic;

namespace Domain_Layer.Queries
{
    public partial class DQuery : IDPersonaQuery
    {
        public DPersonaDto Buscar(DPersonaDto dto)
        {
            DPersonaDto item = null;
            try
            {
                using (_sessionMidis = _sessionFactoryMidis.OpenSession())
                {
                    using (_transactionMidis = _sessionMidis.BeginTransaction())
                    {
                        IQuery query = _sessionMidis.CreateQuery("FROM EPersona x " +
                                                                 "WHERE x.NumeroDocumento = :p_NumeroDocumento");
                        query.SetParameter("p_NumeroDocumento", dto.NumeroDocumento);
                        var result = query.List<EPersona>();
                        if (result != null)
                        {
                            if (result.Count > 0)
                            {
                                item = DPersonaConverter.ToDto(result[0]);
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
    }
}