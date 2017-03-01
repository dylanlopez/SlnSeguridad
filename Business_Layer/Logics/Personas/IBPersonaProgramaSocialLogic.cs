using Domain_Layer.Dtos.Personas;
using System.Collections.Generic;

namespace Business_Layer.Logics.Personas
{
    public interface IBPersonaProgramaSocialLogic
    {

        int Eliminar(DPersonaProgramaSocialDto dto);

        
        int Insertar(DPersonaProgramaSocialDto dto);

        
        List<DPersonaProgramaSocialDto> Listar(DPersonaProgramaSocialDto dto);
    }
}