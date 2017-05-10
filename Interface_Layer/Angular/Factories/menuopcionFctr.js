myApp.factory('MenuOpcionFctr', function ($http, webAPIControllers) {
    var menuopcion = {};
    var urlListarMenuOpciones = webAPIControllers + 'api/MenuOpcion/ListarMenuOpciones';
    var urlInsertarMenuOpcion = webAPIControllers + 'api/MenuOpcion/InsertarMenuOpcion';
    var urlActualizarMenuOpcion = webAPIControllers + 'api/MenuOpcion/ActualizarMenuOpcion';
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
        return $http.post(urlActualizarMenu, menuoption, header).then(function (response) {
            return response.data;
        });
    }

    menuopcion.CleanMenuOpcion = function (menuoption) {
        menuoption.Id = null;
        menuoption.Estado = null;
        menuoption.Visible = null;
        menuoption.Menu.Id = null;
        menuoption.Menu.Codigo = null;
        menuoption.Menu.Nombre = null;
        menuoption.Menu.Ruta = null;
        menuoption.Menu.Descripcion = null;
        menuoption.Menu.Activo = null;
        menuoption.Menu.Modulo.Id = null;
        menuoption.Menu.Modulo.Codigo = null;
        menuoption.Menu.Modulo.Nombre = null;
        menuoption.Menu.Modulo.Abreviatura = null;
        menuoption.Menu.Modulo.Activo = null;
        menuoption.Menu.Modulo.Descripcion = null;
        menuoption.Menu.Modulo.Sistema.Id = null;
        menuoption.Menu.Modulo.Sistema.Codigo = null;
        menuoption.Menu.Modulo.Sistema.Nombre = null;
        menuoption.Menu.Modulo.Sistema.Abreviatura = null;
        menuoption.Menu.Modulo.Sistema.Activo = null;
        menuoption.Menu.Modulo.Sistema.Descripcion = null;
        menuoption.Menu.Modulo.Sistema.NombreServidor = null;
        menuoption.Menu.Modulo.Sistema.IPServidor = null;
        menuoption.Menu.Modulo.Sistema.RutaFisica = null;
        menuoption.Menu.Modulo.Sistema.RutaLogica = null;
        menuoption.Opcion.Id = null;
        menuoption.Opcion.Nombre = null;
        menuoption.Opcion.NombreControlAsociado = null;
        menuoption.Opcion.Descripcion = null;
    }

    return menuopcion;
});