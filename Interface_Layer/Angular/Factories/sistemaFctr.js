myApp.factory('SistemaFctr', function ($http, webAPIControllers) {
    var sistema = {};
    var urlListarSistemas = webAPIControllers + '/api/Sistema/ListarSistemas';
    var urlInsertarSistema = webAPIControllers + '/api/Sistema/InsertarSistema';
    var urlActualizarSistema = webAPIControllers + '/api/Sistema/ActualizarSistema/';
    var header = {
        'Content-Type': 'application/json'
    }

    sistema.ListarSistemas = function (system) {
        return $http.post(urlListarSistemas, system, header).then(function (response) {
            return response.data;
        });
    }

    sistema.InsertarSistema = function (system) {
        return $http.post(urlInsertarSistema, system, header).then(function (response) {
            return response.data;
        });
    }

    sistema.ActualizarSistema = function (system) {
        return $http.put(urlActualizarSistema + system.Id, system, header).then(function (response) {
            return response.data;
        });
    }

    sistema.CleanSistema = function (system) {
        system.Id = null;
        system.Codigo = null;
        system.Nombre = null;
        system.Abreviatura = null;
        system.Activo = null;
        system.Descripcion = null;
        system.NombreServidor = null;
        system.IPServidor = null;
        system.RutaFisica = null;
        system.RutaLogica = null;
    }

    return sistema;
});