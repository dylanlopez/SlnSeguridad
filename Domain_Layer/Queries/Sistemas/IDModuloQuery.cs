using Domain_Layer.Dtos;
using System.Collections.Generic;

namespace Domain_Layer.Queries.Sistemas
{
    public interface IDModuloQuery
    {
        List<DModuloDto> Listar(DModuloDto dto);
    }
}