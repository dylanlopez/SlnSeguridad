using Domain_Layer.Queries.Personas;
using Domain_Layer.Queries.Sistemas;
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

        private IDTipoDocumentoPersonaQuery _tipoDocumentoPersonaQuery;
        private IDPersonaQuery _personaQuery;
        private IDUsuarioQuery _usuarioQuery;
        private IDRolQuery _rolQuery;
        private IDUsuarioRolQuery _usuarioRolQuery;
        private IDMenuRolQuery _menuRolQuery;
        private Loggin _logger;
    }
}