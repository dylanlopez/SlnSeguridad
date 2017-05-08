myApp.factory('RolFctr', function ($http, webAPIControllers) {
    var rol = {};
    var urlListarRoles = webAPIControllers + 'api/Rol/ListarRoles';
    var urlInsertarRol = webAPIControllers + 'api/Rol/InsertarRol';
    var urlActualizarRol = webAPIControllers + 'api/Rol/ActualizarRol/';
    var header = {
        'Content-Type': 'application/json'
    }

    rol.ListarRoles = function (role) {
        return $http.post(urlListarRoles, role, header).then(function (response) {
            return response.data;
        });
    }

    rol.InsertarRol = function (role) {
        return $http.post(urlInsertarRol, role, header).then(function (response) {
            return response.data;
        });
    }

    rol.ActualizarRol = function (role) {
        return $http.put(urlActualizarRol + role.Id, role, header).then(function (response) {
            return response.data;
        });
    }

    rol.CleanRol = function (role) {
        role.Id = null;
        role.Nombre = null;
        role.Descripcion = null;
    }

    return rol;
});