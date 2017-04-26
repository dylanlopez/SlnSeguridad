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
        systemprofile.Sistema.Id = null;
        systemprofile.Sistema.Codigo = null;
        systemprofile.Sistema.Nombre = null;
        systemprofile.Sistema.Abreviatura = null;
        systemprofile.Sistema.Activo = null;
        systemprofile.Sistema.Descripcion = null;
        systemprofile.Sistema.NombreServidor = null;
        systemprofile.Sistema.IPServidor = null;
        systemprofile.Sistema.RutaFisica = null;
        systemprofile.Sistema.RutaLogica = null;
        systemprofile.Perfil.Id = null;
        systemprofile.Perfil.Nombre = null;
        systemprofile.Perfil.Descripcion = null;
    }

    return sistemaperfil;
});