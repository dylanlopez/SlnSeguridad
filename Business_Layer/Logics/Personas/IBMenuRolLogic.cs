using Domain_Layer.Dtos.Personas;
using System.Collections.Generic;

namespace Business_Layer.Logics.Personas
{
    public interface IBMenuRolLogic
    {

        int Eliminar(DMenuRolDto dto);

        
        int Insertar(DMenuRolDto dto);

        
        List<DMenuRolDto> Listar(DMenuRolDto dto);
    }
}