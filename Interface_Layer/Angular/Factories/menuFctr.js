myApp.factory('MenuFctr', function ($http, webAPIControllers) {
    var menue = {};
    var urlListarMenus = webAPIControllers + '/api/Menu/ListarMenus';
    var urlInsertarMenu = webAPIControllers + '/api/Menu/InsertarMenu';
    var urlActualizarMenu = webAPIControllers + '/api/Menu/ActualizarMenu/';
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
        return $http.put(urlActualizarMenu + menu.Id, menu, header).then(function (response) {
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
        menu.Modulo = null;
    }

    return menue;
});