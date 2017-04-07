using Domain_Layer.Dtos.Personas;
using System.Collections.Generic;

namespace Business_Layer.Logics.Personas
{
    public interface IBPerfilLogic
    {
        int Actualizar(DPerfilDto dto);
        int Insertar(DPerfilDto dto);
        List<DPerfilDto> Listar(DPerfilDto dto);
    }
}