using Domain_Layer.Dtos.Personas;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Service_Layer.Services.Sistemas
{
    [ServiceContract]
    public interface ISPersonasService
    {
        #region TipoDocumentoPersona
        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "BuscarTipoDocumentoPersona/")]
        DTipoDocumentoPersonaDto BuscarTipoDocumentoPersona(DTipoDocumentoPersonaDto dto);

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "ListarTipoDocumentoPersona/")]
        List<DTipoDocumentoPersonaDto> ListarTipoDocumentoPersona(DTipoDocumentoPersonaDto dto);
        #endregion

        #region Persona
        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "ActualizarPersona/")]
        int ActualizarPersona(DPersonaDto dto);

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "BuscarPersona/")]
        DPersonaDto BuscarPersona(DPersonaDto dto);

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "EliminarPersona/")]
        int EliminarPersona(DPersonaDto dto);

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "InsertarPersona/")]
        int InsertarPersona(DPersonaDto dto);

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "ListarPersonas/")]
        List<DPersonaDto> ListarPersonas(DPersonaDto dto);
        #endregion

        #region Usuario
        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "ActualizarUsuario/")]
        int ActualizarUsuario(DUsuarioDto dto);

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "BuscarUsuario/")]
        DUsuarioDto BuscarUsuario(DUsuarioDto dto);

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "EliminarUsuario/")]
        int EliminarUsuario(DUsuarioDto dto);

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "InsertarUsuario/")]
        int InsertarUsuario(DUsuarioDto dto);

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "ListarUsuarios/")]
        List<DUsuarioDto> ListarUsuarios(DUsuarioDto dto);
        #endregion

        #region Rol
        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "ActualizarRol/")]
        int ActualizarRol(DRolDto dto);

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "BuscarRol/")]
        DRolDto BuscarRol(DRolDto dto);

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "EliminarRol/")]
        int EliminarRol(DRolDto dto);

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "InsertarRol/")]
        int InsertarRol(DRolDto dto);

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "ListarRoles/")]
        List<DRolDto> ListarRoles(DRolDto dto);
        #endregion

        #region UsuarioRol
        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "EliminarUsuarioRol/")]
        int EliminarUsuarioRol(DUsuarioRolDto dto);

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "InsertarUsuarioRol/")]
        int InsertarUsuarioRol(DUsuarioRolDto dto);

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "ListarUsuariosRoles/")]
        List<DUsuarioRolDto> ListarUsuariosRoles(DUsuarioRolDto dto);
        #endregion

        #region MenuRol
        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "EliminarMenuRol/")]
        int EliminarMenuRol(DMenuRolDto dto);

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "InsertarMenuRol/")]
        int InsertarMenuRol(DMenuRolDto dto);

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "ListarMenusRoles/")]
        List<DMenuRolDto> ListarMenusRoles(DMenuRolDto dto);
        #endregion
    }
}