using Service_Layer.Models.Personas;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Service_Layer.Services
{
    [ServiceContract]
    public interface ISPersonasService
    {
        #region Persona
        //[OperationContract]
        //[WebInvoke(Method = "POST",
        //ResponseFormat = WebMessageFormat.Json,
        //RequestFormat = WebMessageFormat.Json,
        //BodyStyle = WebMessageBodyStyle.Bare,
        //UriTemplate = "BuscarPersona/")]
        //PersonaModel BuscarPersona(PersonaModel dto);
        #endregion

        #region Usuario
        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "ActualizarUsuario/")]
        int ActualizarUsuario(UsuarioModel dto);

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "BuscarUsuario/")]
        UsuarioModel BuscarUsuario(UsuarioModel dto);

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "EliminarUsuario/")]
        int EliminarUsuario(UsuarioModel dto);

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "InsertarUsuario/")]
        int InsertarUsuario(UsuarioModel dto);

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "ListarUsuarios/")]
        List<UsuarioModel> ListarUsuarios(UsuarioModel dto);
        #endregion

        #region Perfil
        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "ActualizarPerfil/")]
        int ActualizarPerfil(PerfilModel dto);

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "InsertarPerfil/")]
        int InsertarPerfil(PerfilModel dto);

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "ListarPerfiles/")]
        List<PerfilModel> ListarPerfiles(PerfilModel dto);
        #endregion

        #region SistemaPerfil
        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "ActualizarSistemaPerfil/")]
        int ActualizarSistemaPerfil(SistemaPerfilModel dto);

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "InsertarSistemaPerfil/")]
        int InsertarSistemaPerfil(SistemaPerfilModel dto);

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "ListarSistemasPerfiles/")]
        List<SistemaPerfilModel> ListarSistemasPerfiles(SistemaPerfilModel dto);
        #endregion

        #region Rol
        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "ActualizarRol/")]
        int ActualizarRol(RolModel dto);

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "BuscarRol/")]
        RolModel BuscarRol(RolModel dto);

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "EliminarRol/")]
        int EliminarRol(RolModel dto);

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "InsertarRol/")]
        int InsertarRol(RolModel dto);

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "ListarRoles/")]
        List<RolModel> ListarRoles(RolModel dto);
        #endregion

        #region PerfilUsuarioRol
        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "ActualizarPerfilUsuarioRol/")]
        int ActualizarPerfilUsuarioRol(PerfilUsuarioRolModel dto);

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "InsertarPerfilUsuarioRol/")]
        int InsertarPerfilUsuarioRol(PerfilUsuarioRolModel dto);

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "ListarPerfilesUsuariosRoles/")]
        List<PerfilUsuarioRolModel> ListarPerfilesUsuariosRoles(PerfilUsuarioRolModel dto);
        #endregion

        #region Permiso
        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "ActualizarPermiso/")]
        int ActualizarPermiso(PermisoModel dto);

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "EliminarPermiso/")]
        int EliminarPermiso(PermisoModel dto);

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "InsertarPermiso/")]
        int InsertarPermiso(PermisoModel dto);

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "ListarPermisos/")]
        List<PermisoModel> ListarPermisos(PermisoModel dto);
        #endregion
    }
}