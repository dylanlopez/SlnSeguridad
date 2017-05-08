using Domain_Layer.Dtos.Vistas;
using System.Collections.Generic;

namespace Domain_Layer.Queries.Vistas
{
    public interface IDVistaPermisoQuery
    {
        List<DVistaPermisoDto> Listar(DVistaPermisoDto dto);
    }
}