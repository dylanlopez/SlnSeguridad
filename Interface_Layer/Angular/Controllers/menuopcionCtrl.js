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
                "Sistema": $scope.mymenu.Sistema
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
    };

    $scope.buscarMenu = function () {
        if (angular.isUndefined($scope.mymenu.Sistema) && angular.isUndefined($scope.mymenu.Modulo)) {
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
                "Modulo": $scope.mymenu.Modulo
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

    $scope.nuevo = function () {
        $scope.estaEditable = !$scope.estaEditable;
        $scope.myopcion.Id = "";
        if ($scope.estaEditable == false) {
            $scope.mymenu.Sistema = null;
            $scope.mymenu.Modulo = null;
            $scope.mymenu.Menu = null;
            $scope.mymenu.Opciones = null;
            $scope.mymenu.Estado = "";
            $scope.mymenu.EstaActivo = false;
            $scope.mymenu.Visible = "";
            $scope.mymenu.EstaVisible = false;
        }
        $scope.menuesopciones = [];
        $scope.tieneError = false;
        $scope.error = "";
    };
});