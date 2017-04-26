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
        profileuserrole.Perfil = null;
        profileuserrole.Usuario = null;
        profileuserrole.Rol = null;
    }

    return perfilusuariorol;
});