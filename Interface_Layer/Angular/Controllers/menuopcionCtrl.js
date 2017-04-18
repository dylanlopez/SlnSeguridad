myApp.controller("MenuOpcionCtrl", function ($scope, $http, webAPIControllers) {
    $scope.sistemas = [];
    $scope.modulos = [];
    $scope.menus = [];
    $scope.opciones = [];
    $scope.menuesopciones = [];
    $scope.estaCargando = true;
    $scope.estaEditable = false;
    $scope.tieneError = false;
    $scope.mymenuopcion = [];

    $http({
        method: 'POST',
        url: webAPIControllers + '/api/Sistema/ListarSistemas',
    }).then(function successCallback(result) {
        $scope.sistemas = result.data;
        $scope.tieneError = false;
        $scope.error = "";
        $scope.estaCargando = false;
    }, function errorCallback(result) {
        $scope.tieneError = true;
        $scope.error = "Ha ocurrido un error al listar: " + result;
        $scope.estaCargando = false;
    });

    var option =
        {
            "Id": '',
            "Nombre": '',
            "NombreControlAsociado": '',
            "Descripcion": ''
        };

    $http({
        method: 'POST',
        url: webAPIControllers + '/api/Opcion/ListarOpciones',
        headers: {
            'Content-Type': 'application/json'
        },
        data: option
    }).then(function successCallback(result) {
        $scope.opciones = result.data;
        $scope.tieneError = false;
        $scope.error = "";
        $scope.estaCargando = false;
    }, function errorCallback(result) {
        $scope.tieneError = true;
        $scope.error = "Ha ocurrido un error al listar: " + result;
        $scope.estaCargando = false;
    });

    $scope.buscarModulo = function () {
        if (angular.isUndefined($scope.mymenuopcion.Sistema)) {
            $scope.tieneError = true;
            $scope.error = "Debe ingresar un sistema para poder ver sus módulos";
        }
        else {
            $scope.tieneError = false;
            $scope.error = "";

            var module =
                {
                    "Id": '',
                    "Codigo": '',
                    "Nombre": '',
                    "Abreviatura": '',
                    "Descripcion": '',
                    "Estado": '',
                    "Sistema": $scope.mymenuopcion.Sistema
                };

            $http({
                method: 'POST',
                url: webAPIControllers + '/api/Modulo/ListarModulos',
                headers: {
                    'Content-Type': 'application/json'
                },
                data: module,
            }).then(function successCallback(result) {
                $scope.modulos = result.data;
                $scope.estaCargando = false;
            }, function errorCallback(result) {
                $scope.tieneError = true;
                $scope.error = "Ha ocurrido un error al listar: " + result;
                $scope.estaCargando = false;
            });
        }
    };

    $scope.buscarMenu = function () {
        if (angular.isUndefined($scope.mymenuopcion.Sistema) && angular.isUndefined($scope.mymenuopcion.Modulo)) {
            $scope.tieneError = true;
            $scope.error = "Debe ingresar un sistema y módulo para poder ver sus menús";
        }
        else {
            $scope.tieneError = false;
            $scope.error = "";

            var menu =
            {
                "Id": '',
                "Codigo": '',
                "Nombre": '',
                "Ruta": '',
                "Descripcion": '',
                "Estado": '',
                "Modulo": $scope.mymenuopcion.Modulo
            };

            $http({
                method: 'POST',
                url: webAPIControllers + '/api/Menu/ListarMenus',
                headers: {
                    'Content-Type': 'application/json'
                },
                data: menu,
            }).then(function successCallback(result) {
                $scope.menus = result.data;
                $scope.estaCargando = false;
            }, function errorCallback(result) {
                $scope.tieneError = true;
                $scope.error = "Ha ocurrido un error al listar: " + result;
                $scope.estaCargando = false;
            });
        }
    };

    $scope.buscar = function () {
        if (angular.isUndefined($scope.mymenuopcion.Sistema) ||
            angular.isUndefined($scope.mymenuopcion.Modulo) ||
            angular.isUndefined($scope.mymenuopcion.Menu)) {
            $scope.tieneError = true;
            $scope.error = "Debe ingresar un sistema, módulo y menú para poder ver sus opciones";
        }
        else {
            $scope.tieneError = false;
            $scope.error = "";

            var menuopcion =
            {
                "Id": '',
                "Estado": '',
                "Visible": '',
                "Menu": $scope.mymenuopcion.Menu,
                "Opcion": ''
            };

            $http({
                method: 'POST',
                url: webAPIControllers + '/api/MenuOpcion/ListarMenuOpciones',
                headers: {
                    'Content-Type': 'application/json'
                },
                data: menuopcion,
            }).then(function successCallback(result) {
                $scope.menuesopciones = result.data;
                $scope.estaCargando = false;
            }, function errorCallback(result) {
                $scope.tieneError = true;
                $scope.error = "Ha ocurrido un error al listar: " + result;
                $scope.estaCargando = false;
            });
        }
    };

    $scope.nuevo = function () {
        $scope.estaEditable = !$scope.estaEditable;
        $scope.mymenuopcion.Id = "";
        if ($scope.estaEditable == false) {
            $scope.mymenuopcion.Estado = "";
            $scope.mymenuopcion.EstaActivo = false;
            $scope.mymenuopcion.Visible = "";
            $scope.mymenuopcion.EstaVisible = false;
            $scope.mymenuopcion.Sistema = null;
            $scope.mymenuopcion.Modulo = null;
            $scope.mymenuopcion.Menu = null;
            $scope.mymenuopcion.Opcion = null;
        }
        $scope.menuesopciones = [];
        $scope.tieneError = false;
        $scope.error = "";
    };

    $scope.modificar = function (menuopcion) {
        $scope.estaEditable = !$scope.estaEditable;
        if ($scope.estaEditable == true) {
            $scope.mymenuopcion.Id = menuopcion.Id;
            $scope.mymenuopcion.Estado = menuopcion.Estado;
            if (menuopcion.Estado == 'S') {
                $scope.mymenuopcion.EstaActivo = true;
            }
            else if (menuopcion.Estado == 'N') {
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
            $scope.mymenuopcion.Estado = "S";
        }
        else {
            $scope.mymenuopcion.Estado = "N";
        }
        if ($scope.mymenuopcion.EstaVisible) {
            $scope.mymenuopcion.Visible = "S";
        }
        else {
            $scope.mymenuopcion.Visible = "N";
        }
        var menuopcion =
            {
                "Id": $scope.mymenuopcion.Id,
                "Estado": $scope.mymenuopcion.Estado,
                "Visible": $scope.mymenuopcion.Visible,
                "Menu": $scope.mymenuopcion.Menu,
                "Opcion": $scope.mymenuopcion.Opcion
            };

        if (menuopcion.Id == "") //nuevo (insert)
        {
            $http({
                method: 'POST',
                url: webAPIControllers + '/api/MenuOpcion/InsertarMenuOpcion',
                headers: {
                    'Content-Type': 'application/json'
                },
                data: menuopcion,
            }).then(function successCallback(result) {
                $scope.nuevo();
                $scope.menuesopciones = [];
                $scope.tieneError = false;
                $scope.error = "";
                $scope.estaCargando = false;
            }, function errorCallback(result) {
                $scope.tieneError = true;
                $scope.error = "Ha ocurrido un error al insertar: " + result;
                $scope.estaCargando = false;
            });
        }
        else //actualizar (update)
        {
            $http({
                method: 'PUT',
                url: webAPIControllers + '/api/MenuOpcion/ActualizarMenuOpcion/' + menuopcion.Id,
                headers: {
                    'Content-Type': 'application/json'
                },
                data: menuopcion,
            }).then(function successCallback(result) {
                $scope.nuevo();
                $scope.menuesopciones = [];
                $scope.tieneError = false;
                $scope.error = "";
                $scope.estaCargando = false;
            }, function errorCallback(result) {
                $scope.tieneError = true;
                $scope.error = "Ha ocurrido un error al actualizar: " + result;
                $scope.estaCargando = false;
            });
        }
    };

    $scope.eliminar = function (menuopcion) {
        var menuopcion =
            {
                "Id": menuopcion.Id,
                "Estado": menuopcion.Estado,
                "Visible": menuopcion.Visible,
                "Menu": menuopcion.Menu,
                "Opcion": menuopcion.Opcion
            };

        $http({
            method: 'DELETE',
            url: webAPIControllers + '/api/MenuOpcion/EliminarMenuOpcion/' + menuopcion.Id,
            headers: {
                'Content-Type': 'application/json'
            },
            data: menuopcion
        }).then(function successCallback(result) {
            //$scope.nuevo();
            $scope.menuesopciones = [];
            $scope.tieneError = false;
            $scope.error = "";
            $scope.estaCargando = false;
        }, function errorCallback(result) {
            $scope.tieneError = true;
            $scope.error = "Ha ocurrido un error al listar: " + result;
            $scope.estaCargando = false;
        });
    };
});