using Domain_Layer.Dtos.Personas;
using System.Collections.Generic;

namespace Business_Layer.Logics.Personas
{
    public interface IBSistemaPerfilLogic
    {
        int Actualizar(DSistemaPerfilDto dto);
        int Insertar(DSistemaPerfilDto dto);
        List<DSistemaPerfilDto> Listar(DSistemaPerfilDto dto);
    }
}