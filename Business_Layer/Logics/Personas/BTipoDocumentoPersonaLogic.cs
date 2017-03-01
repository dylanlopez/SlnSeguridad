using Business_Layer.Logics.Personas;
using Domain_Layer.Dtos.Personas;
using Domain_Layer.Queries;
using System;
using System.Collections.Generic;

namespace Business_Layer.Logics
{
    public partial class BLogic : IBTipoDocumentoPersonaLogic
    {
        public DTipoDocumentoPersonaDto Buscar(DTipoDocumentoPersonaDto dto)
        {
            try
            {
                _tipoDocumentoPersonaQuery = new DQuery();
                return _tipoDocumentoPersonaQuery.Buscar(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<DTipoDocumentoPersonaDto> Listar(DTipoDocumentoPersonaDto dto)
        {
            try
            {
                _tipoDocumentoPersonaQuery = new DQuery();
                return _tipoDocumentoPersonaQuery.Listar(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}