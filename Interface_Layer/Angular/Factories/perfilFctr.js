myApp.factory('PerfilFctr', function ($http, webAPIControllers) {
    var perfil = {};
    var urlListarPerfiles = webAPIControllers + '/api/Perfil/ListarPerfiles';
    var urlInsertarPerfil = webAPIControllers + '/api/Perfil/InsertarPerfil';
    var urlActualizarPerfil = webAPIControllers + '/api/Perfil/ActualizarPerfil/';
    var header = {
        'Content-Type': 'application/json'
    }

    perfil.ListarPerfiles = function () {
        return $http.post(urlListarPerfiles, header).then(function (response) {
            return response.data;
        });
    }

    perfil.InsertarPerfil = function (profile) {
        return $http.post(urlInsertarPerfil, profile, header).then(function (response) {
            return response.data;
        });
    }

    perfil.ActualizarPerfil = function (profile) {
        return $http.put(urlActualizarPerfil + profile.Id, profile, header).then(function (response) {
            return response.data;
        });
    }

    perfil.CleanPerfil = function (profile) {
        profile.Id = null;
        profile.Nombre = null;
        profile.Descripcion = null;
    }

    return perfil;
});