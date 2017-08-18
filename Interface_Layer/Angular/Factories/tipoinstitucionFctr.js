myApp.factory('TipoInstitucionFctr', function ($http, webAPIControllers) {
    var tipoinstitucion = {};
    var urlListarTipoInstitucion = webAPIControllers + 'api/TipoInstitucion/Listar';
    var urlInsertarTipoInstitucion = webAPIControllers + 'api/TipoInstitucion/Insertar';
    var urlActualizarTipoInstitucion = webAPIControllers + 'api/TipoInstitucion/Actualizar';
    var header = {
        'Content-Type': 'application/json'
    }

    tipoinstitucion.ListarTipoInstitucion = function (intitutiontype) {
        return $http.post(urlListarTipoInstitucion, intitutiontype, header, "unique: true").then(function (response) {
            return response.data;
        });
    }

    tipoinstitucion.InsertarTipoInstitucion = function (intitutiontype) {
        return $http.post(urlInsertarTipoInstitucion, intitutiontype, header).then(function (response) {
            return response.data;
        });
    }

    tipoinstitucion.ActualizarTipoInstitucion = function (intitutiontype) {
        return $http.post(urlActualizarTipoInstitucion, intitutiontype, header).then(function (response) {
            return response.data;
        });
    }

    tipoinstitucion.CleanTipoInstitucion = function (intitutiontype) {
        intitutiontype.Id = null;
        intitutiontype.Nombre = null;
        intitutiontype.Activo = null;
        intitutiontype.Descripcion = null;
    }

    return tipoinstitucion;
});