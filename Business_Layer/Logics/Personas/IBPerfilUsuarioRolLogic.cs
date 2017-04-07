using Domain_Layer.Dtos.Personas;
using System.Collections.Generic;

namespace Business_Layer.Logics.Personas
{
    public interface IBPerfilUsuarioRolLogic
    {
        int Actualizar(DPerfilUsuarioRolDto dto);
        int Insertar(DPerfilUsuarioRolDto dto);
        List<DPerfilUsuarioRolDto> Listar(DPerfilUsuarioRolDto dto);
    }
}