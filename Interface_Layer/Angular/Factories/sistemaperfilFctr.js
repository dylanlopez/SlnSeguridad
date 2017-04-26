myApp.factory('SistemaPerfilFctr', function ($http, webAPIControllers) {
    var sistemaperfil = {};
    var urlListarSistemasPerfiles = webAPIControllers + '/api/SistemaPerfil/ListarSistemasPerfiles';
    var urlInsertarSistemaPerfil = webAPIControllers + '/api/SistemaPerfil/InsertarSistemaPerfil';
    var urlActualizarSistemaPerfil = webAPIControllers + '/api/SistemaPerfil/ActualizarSistemaPerfil/';
    var header = {
        'Content-Type': 'application/json'
    }

    sistemaperfil.ListarSistemasPerfiles = function (systemprofile) {
        return $http.post(urlListarSistemasPerfiles, systemprofile, header).then(function (response) {
            return response.data;
        });
    }

    sistemaperfil.InsertarSistemaPerfil = function (systemprofile) {
        return $http.post(urlInsertarSistemaPerfil, systemprofile, header).then(function (response) {
            return response.data;
        });
    }

    sistemaperfil.ActualizarSistemaPerfil = function (systemprofile) {
        return $http.put(urlActualizarSistemaPerfil + systemprofile.Id, systemprofile, header).then(function (response) {
            return response.data;
        });
    }

    sistemaperfil.CleanSistemaPerfil = function (systemprofile) {
        systemprofile.Id = null;
        systemprofile.Estado = null;
        systemprofile.Sistema = null;
        systemprofile.Perfil = null;
    }

    return sistemaperfil;
});