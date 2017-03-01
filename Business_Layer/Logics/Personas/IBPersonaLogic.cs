using Domain_Layer.Dtos.Personas;
using System.Collections.Generic;

namespace Business_Layer.Logics.Personas
{
    public interface IBPersonaLogic
    {

        int Actualizar(DPersonaDto dto);

        
        DPersonaDto Buscar(DPersonaDto dto);

        
        int Eliminar(DPersonaDto dto);

        
        int Insertar(DPersonaDto dto);

        
        List<DPersonaDto> Listar(DPersonaDto dto);
    }
}