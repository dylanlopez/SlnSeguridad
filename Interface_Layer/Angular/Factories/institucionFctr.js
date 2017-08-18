myApp.factory('InstitucionFctr', function ($http, webAPIControllers) {
    var institucion = {};
    var urlListarInstitucion = webAPIControllers + 'api/Institucion/Listar';
    var urlInsertarInstitucion = webAPIControllers + 'api/Institucion/Insertar';
    var urlActualizarInstitucion = webAPIControllers + 'api/Institucion/Actualizar';
    var header = {
        'Content-Type': 'application/json'
    }

    institucion.ListarInstitucion = function (intitution) {
        return $http.post(urlListarInstitucion, intitution, header, "unique: true").then(function (response) {
            return response.data;
        });
    }

    institucion.InsertarInstitucion = function (intitution) {
        return $http.post(urlInsertarInstitucion, intitution, header).then(function (response) {
            return response.data;
        });
    }

    institucion.ActualizarInstitucion = function (intitution) {
        return $http.post(urlActualizarInstitucion, intitution, header).then(function (response) {
            return response.data;
        });
    }

    institucion.CleanInstitucion = function (intitution) {
        intitution.Id = null;
        intitution.Nombre = null;
        intitution.NombreCorto = null;
        intitution.Activo = null;
        intitution.Direccion = null;
        intitution.TipoInstitucion = null;
    }

    return institucion;
});