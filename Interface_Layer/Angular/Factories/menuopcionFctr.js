myApp.factory('MenuOpcionFctr', function ($http, webAPIControllers) {
    var menuopcion = {};
    var urlListarMenuOpciones = webAPIControllers + '/api/MenuOpcion/ListarMenuOpciones';
    var urlInsertarMenuOpcion = webAPIControllers + '/api/MenuOpcion/InsertarMenuOpcion';
    var urlActualizarMenuOpcion = webAPIControllers + '/api/MenuOpcion/ActualizarMenuOpcion/';
    var header = {
        'Content-Type': 'application/json'
    }

    menuopcion.ListarMenuOpciones = function (menuoption) {
        return $http.post(urlListarMenuOpciones, menuoption, header).then(function (response) {
            return response.data;
        });
    }

    menuopcion.InsertarMenuOpcion = function (menuoption) {
        return $http.post(urlInsertarMenuOpcion, menuoption, header).then(function (response) {
            return response.data;
        });
    }

    menuopcion.ActualizarMenuOpcion = function (menuoption) {
        return $http.put(urlActualizarMenu + menuoption.Id, menuoption, header).then(function (response) {
            return response.data;
        });
    }

    menuopcion.CleanMenuOpcion = function (menuoption) {
        menuoption.Id = null;
        menuoption.Estado = null;
        menuoption.Visible = null;
        menuoption.Menu = null;
        menuoption.Opcion = null;
    }

    return menuopcion;
});