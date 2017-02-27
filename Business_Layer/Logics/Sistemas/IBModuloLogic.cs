using Domain_Layer.Dtos.Sistemas;
using System.Collections.Generic;

namespace Business_Layer.Logics.Sistemas
{
    public interface IBModuloLogic
    {
        int Actualizar(DModuloDto dto);
        DModuloDto Buscar(DModuloDto dto);
        int Insertar(DModuloDto dto);
        List<DModuloDto> Listar(DModuloDto dto);
    }
}