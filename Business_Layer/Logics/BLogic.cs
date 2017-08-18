using Domain_Layer.Queries.Personas;
using Domain_Layer.Queries.Sistemas;
using Domain_Layer.Queries.Vistas;
using Logging_Layer;

namespace Business_Layer.Logics
{
    public partial class BLogic
    {
        private IDSistemaQuery _sistemaQuery;
        private IDModuloQuery _moduloQuery;
        private IDMenuQuery _menuQuery;
        private IDOpcionQuery _opcionQuery;
        private IDMenuOpcionQuery _menuOpcionQuery;

        private IDTipoInstitucionQuery _tipoInstitucionQuery;
        private IDInstitucionQuery _intitucionQuery;
        private IDPersonaQuery _personaQuery;
        private IDUsuarioQuery _usuarioQuery;
        private IDPerfilQuery _perfilQuery;
        private IDSistemaPerfilQuery _sistemaPerfilQuery;
        private IDRolQuery _rolQuery;
        private IDPerfilUsuarioRolQuery _perfilUsuarioRolQuery;
        private IDPermisoQuery _permisoQuery;

        private IDVistaPermisoQuery _vistaPermisoQuery;

        private Loggin _logger;
    }
}