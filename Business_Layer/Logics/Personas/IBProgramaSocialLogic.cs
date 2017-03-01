using Domain_Layer.Dtos.Personas;
using System.Collections.Generic;

namespace Business_Layer.Logics.Personas
{
    public interface IBProgramaSocialLogic
    {

        int Actualizar(DProgramaSocialDto dto);

        
        DProgramaSocialDto Buscar(DProgramaSocialDto dto);

        
        int Eliminar(DProgramaSocialDto dto);

        
        int Insertar(DProgramaSocialDto dto);

        
        List<DProgramaSocialDto> Listar(DProgramaSocialDto dto);
    }
}