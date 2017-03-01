using Domain_Layer.Converters.Personas;
using Domain_Layer.Dtos.Personas;
using Domain_Layer.Queries.Personas;
using Entity_Layer.Entities.Personas;
using NHibernate;
using System;
using System.Collections.Generic;

namespace Domain_Layer.Queries
{
    public partial class DQuery : IDTipoDocumentoPersonaQuery
    {
        public DTipoDocumentoPersonaDto Buscar(DTipoDocumentoPersonaDto dto)
        {
            DTipoDocumentoPersonaDto item = null;
            try
            {
                using (_sessionMidis = _sessionFactoryMidis.OpenSession())
                {
                    using (_transactionMidis = _sessionMidis.BeginTransaction())
                    {
                        IQuery query = _sessionMidis.CreateQuery("FROM ETipoDocumentoPersona x " +
                                                                 "WHERE x.Id = :p_Id " +
                                                                 "OR x.Codigo = :p_Codigo");
                        query.SetParameter("p_Id", dto.Id);
                        query.SetParameter("p_Codigo", dto.Codigo);
                        var result = query.List<ETipoDocumentoPersona>();
                        if (result != null)
                        {
                            if (result.Count > 0)
                            {
                                item = DTipoDocumentoPersonaConverter.ToDto(result[0]);
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
        public List<DTipoDocumentoPersonaDto> Listar(DTipoDocumentoPersonaDto dto)
        {
            List<DTipoDocumentoPersonaDto> list = null;
            try
            {
                using (_sessionMidis = _sessionFactoryMidis.OpenSession())
                {
                    using (_transactionMidis = _sessionMidis.BeginTransaction())
                    {
                        IQuery query = _sessionMidis.CreateQuery("FROM ETipoDocumentoPersona x ");
                        var result = query.List<ETipoDocumentoPersona>();
                        if (result != null)
                        {
                            list = DTipoDocumentoPersonaConverter.ToDtos(result);
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