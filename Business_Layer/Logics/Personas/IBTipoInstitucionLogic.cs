using Domain_Layer.Dtos.Personas;
using System.Collections.Generic;

namespace Business_Layer.Logics.Personas
{
    public interface IBTipoInstitucionLogic
    {
        int Actualizar(DTipoInstitucionDto dto);
        DTipoInstitucionDto Buscar(DTipoInstitucionDto dto);
        int Insertar(DTipoInstitucionDto dto);
        List<DTipoInstitucionDto> Listar(DTipoInstitucionDto dto);
    }
}