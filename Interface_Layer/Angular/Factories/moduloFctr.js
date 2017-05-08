myApp.factory('ModuloFctr', function ($http, webAPIControllers) {
    var modulo = {};
    var urlListarModulos = webAPIControllers + 'api/Modulo/ListarModulos';
    var urlInsertarModulo = webAPIControllers + 'api/Modulo/InsertarModulo';
    var urlActualizarModulo = webAPIControllers + 'api/Modulo/ActualizarModulo/';
    var header = {
        'Content-Type': 'application/json'
    }

    modulo.ListarModulos = function (module) {
        return $http.post(urlListarModulos, module, header).then(function (response) {
            return response.data;
        });
    }

    modulo.InsertarModulo = function (module) {
        return $http.post(urlInsertarModulo, module, header).then(function (response) {
            return response.data;
        });
    }

    modulo.ActualizarModulo = function (module) {
        return $http.put(urlActualizarModulo + module.Id, module, header).then(function (response) {
            return response.data;
        });
    }

    modulo.CleanModulo = function (module) {
        module.Id = null;
        module.Codigo = null;
        module.Nombre = null;
        module.Abreviatura = null;
        module.Activo = null;
        module.Descripcion = null;
        module.Sistema.Id = null;
        module.Sistema.Codigo = null;
        module.Sistema.Nombre = null;
        module.Sistema.Abreviatura = null;
        module.Sistema.Activo = null;
        module.Sistema.Descripcion = null;
        module.Sistema.NombreServidor = null;
        module.Sistema.IPServidor = null;
        module.Sistema.RutaFisica = null;
        module.Sistema.RutaLogica = null;
    }

    return modulo;
});