myApp.factory('OpcionFctr', function ($http, webAPIControllers) {
    var opcion = {};
    var urlListarOpciones = webAPIControllers + '/api/Opcion/ListarOpciones';
    var urlInsertarOpcion = webAPIControllers + '/api/Opcion/InsertarOpcion';
    var urlActualizarOpcion = webAPIControllers + '/api/Opcion/ActualizarOpcion/';
    var header = {
        'Content-Type': 'application/json'
    }

    opcion.ListarOpciones = function (option) {
        return $http.post(urlListarOpciones, option, header).then(function (response) {
            return response.data;
        });
    }

    opcion.InsertarOpcion = function (option) {
        return $http.post(urlInsertarOpcion, option, header).then(function (response) {
            return response.data;
        });
    }

    opcion.ActualizarOpcion = function (option) {
        return $http.put(urlActualizarOpcion + option.Id, option, header).then(function (response) {
            return response.data;
        });
    }

    opcion.CleanOpcion = function (option) {
        option.Id = null;
        option.Nombre = null;
        option.NombreControlAsociado = null;
        option.Descripcion = null;
    }

    return opcion;
});