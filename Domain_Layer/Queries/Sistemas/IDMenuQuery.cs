using Domain_Layer.Dtos.Sistemas;
using System.Collections.Generic;

namespace Domain_Layer.Queries.Sistemas
{
    public interface IDMenuQuery
    {
        int Actualizar(DMenuDto dto);
        DMenuDto Buscar(DMenuDto dto);
        int Eliminar(DMenuDto dto);
        int Insertar(DMenuDto dto);
        List<DMenuDto> Listar(DMenuDto dto);
    }
}