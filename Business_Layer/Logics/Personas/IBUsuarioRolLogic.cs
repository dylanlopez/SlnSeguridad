using Domain_Layer.Dtos.Personas;
using System.Collections.Generic;

namespace Business_Layer.Logics.Personas
{
    public interface IBUsuarioRolLogic
    {

        int Eliminar(DUsuarioRolDto dto);

        
        int Insertar(DUsuarioRolDto dto);

        
        List<DUsuarioRolDto> Listar(DUsuarioRolDto dto);
    }
}