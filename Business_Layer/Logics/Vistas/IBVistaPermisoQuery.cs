using Domain_Layer.Dtos.Vistas;
using System.Collections.Generic;

namespace Business_Layer.Logics.Vistas
{
    public interface IBVistaPermisoQuery
    {
        List<DVistaPermisoDto> Listar(DVistaPermisoDto dto);
    }
}