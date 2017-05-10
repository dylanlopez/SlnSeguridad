myApp.factory('MenuFctr', function ($http, webAPIControllers) {
    var menue = {};
    var urlListarMenus = webAPIControllers + 'api/Menu/ListarMenus';
    var urlInsertarMenu = webAPIControllers + 'api/Menu/InsertarMenu';
    var urlActualizarMenu = webAPIControllers + 'api/Menu/ActualizarMenu';
    var header = {
        'Content-Type': 'application/json'
    }

    menue.ListarMenus = function (menu) {
        return $http.post(urlListarMenus, menu, header).then(function (response) {
            return response.data;
        });
    }

    menue.InsertarMenu = function (menu) {
        return $http.post(urlInsertarMenu, menu, header).then(function (response) {
            return response.data;
        });
    }

    menue.ActualizarMenu = function (menu) {
        return $http.post(urlActualizarMenu, menu, header).then(function (response) {
            return response.data;
        });
    }

    menue.CleanMenu = function (menu) {
        menu.Id = null;
        menu.Codigo = null;
        menu.Nombre = null;
        menu.Ruta = null;
        menu.Descripcion = null;
        menu.Activo = null;
        menu.Modulo.Id = null;
        menu.Modulo.Codigo = null;
        menu.Modulo.Nombre = null;
        menu.Modulo.Abreviatura = null;
        menu.Modulo.Activo = null;
        menu.Modulo.Descripcion = null;
        menu.Modulo.Sistema.Id = null;
        menu.Modulo.Sistema.Codigo = null;
        menu.Modulo.Sistema.Nombre = null;
        menu.Modulo.Sistema.Abreviatura = null;
        menu.Modulo.Sistema.Activo = null;
        menu.Modulo.Sistema.Descripcion = null;
        menu.Modulo.Sistema.NombreServidor = null;
        menu.Modulo.Sistema.IPServidor = null;
        menu.Modulo.Sistema.RutaFisica = null;
        menu.Modulo.Sistema.RutaLogica = null;
    }

    return menue;
});