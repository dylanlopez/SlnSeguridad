using Domain_Layer.Dtos.Personas;
using System.Collections.Generic;

namespace Business_Layer.Logics.Personas
{
    public interface IBPersonaLogic
    {
        DPersonaDto Buscar(DPersonaDto dto);
    }
}