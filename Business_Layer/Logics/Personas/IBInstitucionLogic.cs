using Domain_Layer.Dtos.Personas;
using System.Collections.Generic;

namespace Business_Layer.Logics.Personas
{
    public interface IBInstitucionLogic
    {
        int Actualizar(DInstitucionDto dto);
        DInstitucionDto Buscar(DInstitucionDto dto);
        int Insertar(DInstitucionDto dto);
        List<DInstitucionDto> Listar(DInstitucionDto dto);
    }
}