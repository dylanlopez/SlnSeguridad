using Domain_Layer.Dtos.Personas;
using System.Collections.Generic;

namespace Business_Layer.Logics.Personas
{
    public interface IBRolLogic
    {

        int Actualizar(DRolDto dto);

        
        DRolDto Buscar(DRolDto dto);

        
        int Eliminar(DRolDto dto);

        
        int Insertar(DRolDto dto);

        
        List<DRolDto> Listar(DRolDto dto);
    }
}