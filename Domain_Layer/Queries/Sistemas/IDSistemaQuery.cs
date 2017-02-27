using Domain_Layer.Dtos.Sistemas;
using System.Collections.Generic;

namespace Domain_Layer.Queries.Sistemas
{
    public interface IDSistemaQuery
    {
        int Actualizar(DSistemaDto dto);
        DSistemaDto Buscar(DSistemaDto dto);
        int Insertar(DSistemaDto dto);
        List<DSistemaDto> Listar(DSistemaDto dto);
    }
}