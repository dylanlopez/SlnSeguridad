using Domain_Layer.Dtos.Sistemas;
using System.Collections.Generic;

namespace Business_Layer.Logics.Sistemas
{
    public interface IBOpcionLogic
    {
        int Actualizar(DOpcionDto dto);
        DOpcionDto Buscar(DOpcionDto dto);
        int Eliminar(DOpcionDto dto);
        int Insertar(DOpcionDto dto);
        List<DOpcionDto> Listar(DOpcionDto dto);
    }
}