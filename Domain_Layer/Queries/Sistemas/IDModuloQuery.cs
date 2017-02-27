using Domain_Layer.Dtos.Sistemas;
using System.Collections.Generic;

namespace Domain_Layer.Queries.Sistemas
{
    public interface IDModuloQuery
    {
        int Actualizar(DModuloDto dto);
        DModuloDto Buscar(DModuloDto dto);
        int Insertar(DModuloDto dto);
        List<DModuloDto> Listar(DModuloDto dto);
    }
}