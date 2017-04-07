using Domain_Layer.Dtos.Personas;
using System.Collections.Generic;

namespace Business_Layer.Logics.Personas
{
    public interface IBPermisoLogic
    {
        int Actualizar(DPermisoDto dto);
        int Eliminar(DPermisoDto dto);
        int Insertar(DPermisoDto dto);
        List<DPermisoDto> Listar(DPermisoDto dto);
    }
}