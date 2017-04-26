myApp.factory('PerfilUsuarioRolFctr', function ($http, webAPIControllers) {
    var perfilusuariorol = {};
    var urlListarPerfilesUsuariosRoles = webAPIControllers + '/api/PerfilUsuarioRol/ListarPerfilesUsuariosRoles';
    var urlInsertarPerfilUsuarioRol = webAPIControllers + '/api/PerfilUsuarioRol/InsertarPerfilUsuarioRol';
    var urlActualizarPerfilUsuarioRol = webAPIControllers + '/api/PerfilUsuarioRol/ActualizarPerfilUsuarioRol/';
    var header = {
        'Content-Type': 'application/json'
    }

    perfilusuariorol.ListarPerfilesUsuariosRoles = function (profileuserrole) {
        return $http.post(urlListarPerfilesUsuariosRoles, profileuserrole, header).then(function (response) {
            return response.data;
        });
    }

    perfilusuariorol.InsertarPerfilUsuarioRol = function (profileuserrole) {
        return $http.post(urlInsertarPerfilUsuarioRol, profileuserrole, header).then(function (response) {
            return response.data;
        });
    }

    perfilusuariorol.ActualizarPerfilUsuarioRol = function (profileuserrole) {
        return $http.put(urlActualizarPerfilUsuarioRol + profileuserrole.Id, profileuserrole, header).then(function (response) {
            return response.data;
        });
    }

    perfilusuariorol.CleanPerfilUsuarioRol = function (profileuserrole) {
        profileuserrole.Id = null;
        profileuserrole.Estado = null;
        profileuserrole.Perfil.Id = null;
        profileuserrole.Perfil.Nombre = null;
        profileuserrole.Perfil.Descripcion = null;
        profileuserrole.Usuario.Id = null;
        profileuserrole.Usuario.Usuario = null;
        profileuserrole.Usuario.Contrasena = null;
        profileuserrole.Usuario.ApellidoPaterno = null;
        profileuserrole.Usuario.ApellidoMaterno = null;
        profileuserrole.Usuario.Nombres = null;
        profileuserrole.Usuario.Caduca = null;
        profileuserrole.Usuario.PeriodoCaducidad = null;
        profileuserrole.Usuario.FechaUltimoCambio = null;
        profileuserrole.Usuario.Ubigeo = null;
        profileuserrole.Usuario.CodigoVersion = null;
        profileuserrole.Usuario.UnicoIngreso = null;
        profileuserrole.Usuario.HaIngresado = null;
        profileuserrole.Usuario.OtrosLogeos = null;
        profileuserrole.Usuario.Tipo = null;
        profileuserrole.Usuario.Activo = null;
        profileuserrole.Usuario.Email = null;
        profileuserrole.Rol.Id = null;
        profileuserrole.Rol.Nombre = null;
        profileuserrole.Rol.Descripcion = null;
    }

    return perfilusuariorol;
});