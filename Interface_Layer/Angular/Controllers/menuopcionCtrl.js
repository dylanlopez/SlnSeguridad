//myApp.controller("MenuOpcionCtrl", function ($scope, $http, webAPIControllers) {
myApp.controller("MenuOpcionCtrl", function ($scope, system, module, menu, option, menuoption,
                                            SistemaFctr, ModuloFctr, MenuFctr, OpcionFctr, MenuOpcionFctr) {
    $scope.sistemas = [];
    $scope.modulos = [];
    $scope.menus = [];
    $scope.opciones = [];
    $scope.menuesopciones = [];
    $scope.estaCargando = false;
    $scope.estaEditable = false;
    $scope.tieneError = false;
    $scope.mymenuopcion = [];

    //$http({
    //    method: 'POST',
    //    url: webAPIControllers + '/api/Sistema/ListarSistemas',
    //}).then(function successCallback(result) {
    //    $scope.sistemas = result.data;
    //    $scope.tieneError = false;
    //    $scope.error = "";
    //    $scope.estaCargando = false;
    //}, function errorCallback(result) {
    //    $scope.tieneError = true;
    //    $scope.error = "Ha ocurrido un error al listar: " + result;
    //    $scope.estaCargando = false;
    //});

    system.Activo = 'S';
    $scope.listarSistemas = function () {
        $scope.tipoError = "";
        $scope.error = "";
        $scope.tieneError = false;
        SistemaFctr.ListarSistemas(system)
            .then(function successCallback(response) {
                $scope.sistemas = response;
                //$scope.estaCargando = false;
            }, function errorCallback(response) {
                $scope.tipoError = "alert alert-danger";
                $scope.error = "Ha ocurrido un error al listar: " + response;
                $scope.tieneError = true;
                //$scope.estaCargando = false;
            });
    };
    $scope.listarSistemas();

    //var option =
    //    {
    //        "Id": '',
    //        "Nombre": '',
    //        "NombreControlAsociado": '',
    //        "Descripcion": ''
    //    };

    //$http({
    //    method: 'POST',
    //    url: webAPIControllers + '/api/Opcion/ListarOpciones',
    //    headers: {
    //        'Content-Type': 'application/json'
    //    },
    //    data: option
    //}).then(function successCallback(result) {
    //    $scope.opciones = result.data;
    //    $scope.tieneError = false;
    //    $scope.error = "";
    //    $scope.estaCargando = false;
    //}, function errorCallback(result) {
    //    $scope.tieneError = true;
    //    $scope.error = "Ha ocurrido un error al listar: " + result;
    //    $scope.estaCargando = false;
    //});

    //option.Nombre = $scope.myopcion.Nombre;

    $scope.listarOpciones = function () {
        $scope.tipoError = "";
        $scope.error = "";
        $scope.tieneError = false;
        OpcionFctr.ListarOpciones(option)
            .then(function successCallback(response) {
                $scope.opciones = response;
                //$scope.estaCargando = false;
            }, function errorCallback(response) {
                $scope.tipoError = "alert alert-danger";
                $scope.error = "Ha ocurrido un error al listar: " + response;
                $scope.tieneError = true;
                //$scope.estaCargando = false;
            });
    };
    $scope.listarOpciones();

    $scope.buscarModulo = function () {
        if (angular.isUndefined($scope.mymenuopcion.Sistema)) {
            $scope.tipoError = "alert alert-warning";
            $scope.error = "Debe ingresar un sistema para poder ver sus módulos";
            $scope.tieneError = true;
        }
        else {
            //$scope.estaCargando = true;
            $scope.tipoError = "";
            $scope.error = "";
            $scope.tieneError = false;

            module.Activo = 'S';
            module.Sistema = $scope.mymenuopcion.Sistema;
            ModuloFctr.ListarModulos(module)
                .then(function successCallback(response) {
                    $scope.modulos = response;
                    //$scope.estaCargando = false;
                }, function errorCallback(response) {
                    //$scope.estaCargando = false;
                    $scope.tipoError = "alert alert-danger";
                    $scope.error = "Ha ocurrido un error al listar: " + response;
                    $scope.tieneError = true;
                });

            //var module =
            //    {
            //        "Id": '',
            //        "Codigo": '',
            //        "Nombre": '',
            //        "Abreviatura": '',
            //        "Descripcion": '',
            //        "Estado": '',
            //        "Sistema": $scope.mymenuopcion.Sistema
            //    };

            //$http({
            //    method: 'POST',
            //    url: webAPIControllers + '/api/Modulo/ListarModulos',
            //    headers: {
            //        'Content-Type': 'application/json'
            //    },
            //    data: module,
            //}).then(function successCallback(result) {
            //    $scope.modulos = result.data;
            //    $scope.estaCargando = false;
            //}, function errorCallback(result) {
            //    $scope.tieneError = true;
            //    $scope.error = "Ha ocurrido un error al listar: " + result;
            //    $scope.estaCargando = false;
            //});
        }
    };

    $scope.buscarMenu = function () {
        if (angular.isUndefined($scope.mymenuopcion.Sistema) && angular.isUndefined($scope.mymenuopcion.Modulo)) {
            $scope.tipoError = "alert alert-warning";
            $scope.error = "Debe ingresar un sistema y módulo para poder ver sus menús";
            $scope.tieneError = true;
        }
        else {
            //$scope.estaCargando = true;
            $scope.tieneError = false;
            $scope.error = "";
            $scope.estaCargando = true;

            menu.Modulo = $scope.mymenuopcion.Modulo;
            MenuFctr.ListarMenus(menu)
                .then(function successCallback(response) {
                    $scope.menus = response;
                    //$scope.estaCargando = false;
                }, function errorCallback(response) {
                    //$scope.estaCargando = false;
                    $scope.tipoError = "alert alert-danger";
                    $scope.error = "Ha ocurrido un error al listar: " + response;
                    $scope.tieneError = true;
                });

            //var menu =
            //{
            //    "Id": '',
            //    "Codigo": '',
            //    "Nombre": '',
            //    "Ruta": '',
            //    "Descripcion": '',
            //    "Estado": '',
            //    "Modulo": $scope.mymenuopcion.Modulo
            //};

            //$http({
            //    method: 'POST',
            //    url: webAPIControllers + '/api/Menu/ListarMenus',
            //    headers: {
            //        'Content-Type': 'application/json'
            //    },
            //    data: menu,
            //}).then(function successCallback(result) {
            //    $scope.menus = result.data;
            //    $scope.estaCargando = false;
            //}, function errorCallback(result) {
            //    $scope.tieneError = true;
            //    $scope.error = "Ha ocurrido un error al listar: " + result;
            //    $scope.estaCargando = false;
            //});
        }
    };

    $scope.buscar = function () {
        if ((angular.isUndefined($scope.mymenuopcion.Sistema) || $scope.mymenuopcion.Sistema == null) &&
            (angular.isUndefined($scope.mymenuopcion.Modulo) || $scope.mymenuopcion.Modulo == null) &&
            (angular.isUndefined($scope.mymenuopcion.Menu) || $scope.mymenuopcion.Menu == null)) {
            $scope.tipoError = "alert alert-warning";
            $scope.error = "Debe ingresar un sistema, módulo y menú para poder ver sus opciones";
            $scope.tieneError = true;
        }
        else {
            $scope.estaCargando = true;
            $scope.tipoError = "";
            $scope.error = "";
            $scope.tieneError = false;

            menuoption.Menu = $scope.mymenuopcion.Menu;
            MenuOpcionFctr.ListarMenuOpciones(menuoption)
                .then(function successCallback(response) {
                    $scope.menuesopciones = response;
                    $scope.estaCargando = false;
                }, function errorCallback(response) {
                    $scope.estaCargando = false;
                    $scope.tipoError = "alert alert-danger";
                    $scope.error = "Ha ocurrido un error al listar: " + response;
                    $scope.tieneError = true;
                });

            //var menuopcion =
            //{
            //    "Id": '',
            //    "Estado": '',
            //    "Visible": '',
            //    "Menu": $scope.mymenuopcion.Menu,
            //    "Opcion": ''
            //};

            //$http({
            //    method: 'POST',
            //    url: webAPIControllers + '/api/MenuOpcion/ListarMenuOpciones',
            //    headers: {
            //        'Content-Type': 'application/json'
            //    },
            //    data: menuopcion,
            //}).then(function successCallback(result) {
            //    $scope.menuesopciones = result.data;
            //    $scope.estaCargando = false;
            //}, function errorCallback(result) {
            //    $scope.tieneError = true;
            //    $scope.error = "Ha ocurrido un error al listar: " + result;
            //    $scope.estaCargando = false;
            //});
        }
    };

    $scope.nuevo = function () {
        $scope.estaEditable = !$scope.estaEditable;
        $scope.mymenuopcion.Id = "";
        if ($scope.estaEditable == false) {
            $scope.mymenuopcion.Activo = "";
            $scope.mymenuopcion.EstaActivo = false;
            $scope.mymenuopcion.Visible = "";
            $scope.mymenuopcion.EstaVisible = false;
        }
        $scope.mymenuopcion.Sistema = null;
        $scope.mymenuopcion.Modulo = null;
        $scope.mymenuopcion.Menu = null;
        $scope.mymenuopcion.Opcion = null;
        MenuOpcionFctr.CleanMenuOpcion(menuoption);
        //console.debug(profileuserrole);
        $scope.menuesopciones = [];
        $scope.tipoError = "";
        $scope.error = "";
        $scope.tieneError = false;
    };

    $scope.modificar = function (menuopcion) {
        $scope.estaEditable = !$scope.estaEditable;
        if ($scope.estaEditable == true) {
            $scope.mymenuopcion.Id = menuopcion.Id;
            $scope.mymenuopcion.Activo = menuopcion.Activo;
            if (menuopcion.Activo == 'S') {
                $scope.mymenuopcion.EstaActivo = true;
            }
            else if (menuopcion.Activo == 'N') {
                $scope.mymenuopcion.EstaActivo = false;
            }
            $scope.mymenuopcion.Visible = menuopcion.Visible;
            if (menuopcion.Visible == 'S') {
                $scope.mymenuopcion.EstaVisible = true;
            }
            else if (menuopcion.Visible == 'N') {
                $scope.mymenuopcion.EstaVisible = false;
            }
            $scope.mymenuopcion.Sistema = menuopcion.Menu.Modulo.Sistema;
            $scope.buscarModulo();
            $scope.mymenuopcion.Modulo = menuopcion.Menu.Modulo;
            $scope.buscarMenu();
            $scope.mymenuopcion.Menu = menuopcion.Menu;
            $scope.mymenuopcion.Opcion = menuopcion.Opcion;
        }
    };

    $scope.guardar = function () {
        $scope.estaCargando = true;
        if ($scope.mymenuopcion.EstaActivo) {
            $scope.mymenuopcion.Activo = "S";
        }
        else {
            $scope.mymenuopcion.Activo = "N";
        }
        if ($scope.mymenuopcion.EstaVisible) {
            $scope.mymenuopcion.Visible = "S";
        }
        else {
            $scope.mymenuopcion.Visible = "N";
        }
        $scope.tipoError = "";
        $scope.error = "";
        $scope.tieneError = false;
        //var menuopcion =
        //    {
        //        "Id": $scope.mymenuopcion.Id,
        //        "Activo": $scope.mymenuopcion.Activo,
        //        "Visible": $scope.mymenuopcion.Visible,
        //        "Menu": $scope.mymenuopcion.Menu,
        //        "Opcion": $scope.mymenuopcion.Opcion
        //    };

        menuoption.Id = $scope.mymenuopcion.Id;
        menuoption.Activo = $scope.mymenuopcion.Activo;
        menuoption.Visible = $scope.mymenuopcion.Visible;
        menuoption.Menu = $scope.mymenuopcion.Menu;
        menuoption.Opcion = $scope.mymenuopcion.Opcion;
        if (menuoption.Id == "") //nuevo (insert)
        {
            MenuOpcionFctr.InsertarMenuOpcion(menuoption)
                .then(function successCallback(response) {
                    $scope.nuevo();
                    //$scope.menuesopciones = [];
                    $scope.estaCargando = false;
                }, function errorCallback(response) {
                    $scope.estaCargando = false;
                    $scope.tipoError = "alert alert-danger";
                    $scope.error = "Ha ocurrido un error al insertar: " + response.data.Message;
                    $scope.tieneError = true;
                });

            //$http({
            //    method: 'POST',
            //    url: webAPIControllers + '/api/MenuOpcion/InsertarMenuOpcion',
            //    headers: {
            //        'Content-Type': 'application/json'
            //    },
            //    data: menuopcion,
            //}).then(function successCallback(result) {
            //    $scope.nuevo();
            //    $scope.menuesopciones = [];
            //    $scope.tieneError = false;
            //    $scope.error = "";
            //    $scope.estaCargando = false;
            //}, function errorCallback(result) {
            //    $scope.tieneError = true;
            //    $scope.error = "Ha ocurrido un error al insertar: " + result;
            //    $scope.estaCargando = false;
            //});
        }
        else //actualizar (update)
        {
            MenuOpcionFctr.ActualizarMenuOpcion(menuoption)
                .then(function successCallback(response) {
                    $scope.nuevo();
                    //$scope.menuesopciones = [];
                    $scope.estaCargando = false;
                }, function errorCallback(response) {
                    $scope.estaCargando = false;
                    $scope.tipoError = "alert alert-danger";
                    $scope.error = "Ha ocurrido un error al actualizar: " + response.data.Message;
                    $scope.tieneError = true;
                });

            //$http({
            //    method: 'PUT',
            //    url: webAPIControllers + '/api/MenuOpcion/ActualizarMenuOpcion/' + menuopcion.Id,
            //    headers: {
            //        'Content-Type': 'application/json'
            //    },
            //    data: menuopcion,
            //}).then(function successCallback(result) {
            //    $scope.nuevo();
            //    $scope.menuesopciones = [];
            //    $scope.tieneError = false;
            //    $scope.error = "";
            //    $scope.estaCargando = false;
            //}, function errorCallback(result) {
            //    $scope.tieneError = true;
            //    $scope.error = "Ha ocurrido un error al actualizar: " + result;
            //    $scope.estaCargando = false;
            //});
        }
    };

    //$scope.eliminar = function (menuopcion) {
    //    var menuopcion =
    //        {
    //            "Id": menuopcion.Id,
    //            "Activo": menuopcion.Activo,
    //            "Visible": menuopcion.Visible,
    //            "Menu": menuopcion.Menu,
    //            "Opcion": menuopcion.Opcion
    //        };

    //    $http({
    //        method: 'DELETE',
    //        url: webAPIControllers + '/api/MenuOpcion/EliminarMenuOpcion/' + menuopcion.Id,
    //        headers: {
    //            'Content-Type': 'application/json'
    //        },
    //        data: menuopcion
    //    }).then(function successCallback(result) {
    //        //$scope.nuevo();
    //        $scope.menuesopciones = [];
    //        $scope.tieneError = false;
    //        $scope.error = "";
    //        $scope.estaCargando = false;
    //    }, function errorCallback(result) {
    //        $scope.tieneError = true;
    //        $scope.error = "Ha ocurrido un error al listar: " + result;
    //        $scope.estaCargando = false;
    //    });
    //};
});