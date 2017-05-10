myApp.factory('PermisoFctr', function ($http, webAPIControllers) {
    var permiso = {};
    var urlListarPermisos = webAPIControllers + 'api/Permiso/ListarPermisos';
    var urlInsertarPermiso = webAPIControllers + 'api/Permiso/InsertarPermiso';
    var urlActualizarPermiso = webAPIControllers + 'api/Permiso/ActualizarPermiso';
    var header = {
        'Content-Type': 'application/json'
    }

    permiso.ListarPermisos = function (permission) {
        return $http.post(urlListarPermisos, permission, header).then(function (response) {
            return response.data;
        });
    }

    permiso.InsertarPermiso = function (permission) {
        return $http.post(urlInsertarPermiso, permission, header).then(function (response) {
            return response.data;
        });
    }

    permiso.ActualizarPermiso = function (permission) {
        return $http.post(urlActualizarPermiso, permission, header).then(function (response) {
            return response.data;
        });
    }

    permiso.CleanPermiso = function (permission) {
        permission.Id = null;
        permission.FechaAlta = null;
        permission.Estado = null;
        permission.PerfilUsuarioRol = null;
        permission.MenuOpcion = null;
    }

    return permiso;
});