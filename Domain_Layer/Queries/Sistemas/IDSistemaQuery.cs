using Domain_Layer.Dtos;
using System.Collections.Generic;

namespace Domain_Layer.Queries.Sistemas
{
    public interface IDSistemaQuery
    {
        List<DSistemaDto> Listar(DSistemaDto dto);
    }
}