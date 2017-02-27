using Domain_Layer.Dtos.Sistemas;
using System.Collections.Generic;

namespace Business_Layer.Logics.Sistemas
{
    public interface IBMenuLogic
    {
        int Actualizar(DMenuDto dto);
        DMenuDto Buscar(DMenuDto dto);
        int Eliminar(DMenuDto dto);
        int Insertar(DMenuDto dto);
        List<DMenuDto> Listar(DMenuDto dto);
    }
}