using Domain_Layer.Dtos.Sistemas;
using System.Collections.Generic;

namespace Business_Layer.Logics.Sistemas
{
    public interface IBSistemaLogic
    {
        int Actualizar(DSistemaDto dto);
        DSistemaDto Buscar(DSistemaDto dto);
        int Insertar(DSistemaDto dto);
        List<DSistemaDto> Listar(DSistemaDto dto);
    }
}