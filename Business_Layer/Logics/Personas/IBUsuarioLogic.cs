using Domain_Layer.Dtos.Personas;
using System.Collections.Generic;

namespace Business_Layer.Logics.Personas
{
    public interface IBUsuarioLogic
    {

        int Actualizar(DUsuarioDto dto);

        int ActualizarContrasena(DUsuarioDto dto);

        DUsuarioDto Buscar(DUsuarioDto dto);

        DUsuarioDto BuscarPorUsuario(DUsuarioDto dto);

        int Eliminar(DUsuarioDto dto);
        
        int Insertar(DUsuarioDto dto);
        
        List<DUsuarioDto> Listar(DUsuarioDto dto);
    }
}