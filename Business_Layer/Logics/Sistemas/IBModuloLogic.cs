using Domain_Layer.Dtos;
using System.Collections.Generic;

namespace Business_Layer.Logics.Sistemas
{
    public interface IBModuloLogic
    {
        List<DModuloDto> Listar(DModuloDto dto);
    }
}