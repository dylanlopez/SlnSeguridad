using Domain_Layer.Dtos;
using System.Collections.Generic;

namespace Business_Layer.Logics.Sistemas
{
    public interface IBSistemaLogic
    {
        List<DSistemaDto> Listar(DSistemaDto dto);
    }
}