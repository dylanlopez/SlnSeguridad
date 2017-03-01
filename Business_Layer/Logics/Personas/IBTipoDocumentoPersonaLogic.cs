using Domain_Layer.Dtos.Personas;
using System.Collections.Generic;

namespace Business_Layer.Logics.Personas
{
    public interface IBTipoDocumentoPersonaLogic
    {
        DTipoDocumentoPersonaDto Buscar(DTipoDocumentoPersonaDto dto);

        
        List<DTipoDocumentoPersonaDto> Listar(DTipoDocumentoPersonaDto dto);
    }
}