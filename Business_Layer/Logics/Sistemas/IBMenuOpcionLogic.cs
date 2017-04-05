using Domain_Layer.Dtos.Sistemas;
using System.Collections.Generic;

namespace Business_Layer.Logics.Sistemas
{
    public interface IBMenuOpcionLogic
    {
        int Actualizar(DMenuOpcionDto dto);
        DMenuOpcionDto Buscar(DMenuOpcionDto dto);
        int Eliminar(DMenuOpcionDto dto);
        int Insertar(DMenuOpcionDto dto);
        List<DMenuOpcionDto> Listar(DMenuOpcionDto dto);
    }
}