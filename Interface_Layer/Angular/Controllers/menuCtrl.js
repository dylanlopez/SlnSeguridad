myApp.controller("MenuCtrl", function ($scope, $http, webAPIControllers) {
    $scope.sistemas = [];
    $scope.modulos = [];
    $scope.menus = [];
    $scope.estaCargando = true;
    $scope.estaEditable = false;
    $scope.tieneError = false;
    $scope.mymenu = [];

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
    
    $scope.buscarModulo = function () {
        if (angular.isUndefined($scope.mymenu.Sistema)) {
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
        }
    };
    
    $scope.buscar = function () {
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
        $scope.mymenu.Id = "";
        if ($scope.estaEditable == false) {
            $scope.mymenu.Codigo = "";
            $scope.mymenu.Nombre = "";
            $scope.mymenu.Ruta = "";
            $scope.mymenu.Descripcion = "";
            $scope.mymenu.Estado = "";
            $scope.mymenu.EstaActivo = false;
            $scope.mymenu.Sistema = null;
            $scope.mymenu.Modulo = null;
        }
        $scope.menus = [];
        $scope.tieneError = false;
        $scope.error = "";
    };

    $scope.modificar = function (menu) {
        $scope.estaEditable = !$scope.estaEditable;
        if ($scope.estaEditable == true) {
            $scope.mymenu.Id = menu.Id;
            $scope.mymenu.Codigo = menu.Codigo;
            $scope.mymenu.Nombre = menu.Nombre;
            $scope.mymenu.Ruta = menu.Ruta;
            $scope.mymenu.Descripcion = menu.Descripcion;
            $scope.mymenu.Estado = menu.Estado;
            if (menu.Estado == 'S') {
                $scope.mymenu.EstaActivo = true;
            }
            else if (menu.Estado == 'N') {
                $scope.mymenu.EstaActivo = false;
            }
            console.debug(menu.Modulo.Sistema);
            console.debug(menu.Modulo);
            $scope.mymenu.Sistema = menu.Modulo.Sistema;
            $scope.buscarModulo();
            $scope.mymenu.Modulo = menu.Modulo;
        }
    };

    $scope.guardar = function () {
        $scope.estaCargando = true;
        if ($scope.mymenu.EstaActivo) {
            $scope.mymenu.Estado = "S";
        }
        else {
            $scope.mymenu.Estado = "N";
        }
        var menu =
            {
                "Id": $scope.mymenu.Id,
                "Codigo": $scope.mymenu.Codigo,
                "Nombre": $scope.mymenu.Nombre,
                "Ruta": $scope.mymenu.Ruta,
                "Descripcion": $scope.mymenu.Descripcion,
                "Estado": $scope.mymenu.Estado,
                "Modulo": $scope.mymenu.Modulo
            };

        if (menu.Id == "") //nuevo (insert)
        {
            $http({
                method: 'POST',
                url: webAPIControllers + '/api/Menu/InsertarMenu',
                headers: {
                    'Content-Type': 'application/json'
                },
                data: menu,
            }).then(function successCallback(result) {
                $scope.nuevo();
                $scope.menus = [];
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
                url: webAPIControllers + '/api/Menu/ActualizarMenu/' + menu.Id,
                headers: {
                    'Content-Type': 'application/json'
                },
                data: menu,
            }).then(function successCallback(result) {
                $scope.nuevo();
                $scope.menus = [];
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

    $scope.eliminar = function (menu) {
        if (menu.Estado == 'I') {
            //console.debug(menu);
            var men =
            {
                "Id": menu.Id,
                "Codigo": menu.Codigo,
                "Nombre": menu.Nombre,
                "Ruta": menu.Ruta,
                "Descripcion": menu.Descripcion,
                "Estado": menu.Estado,
                "Modulo": menu.Modulo
            };
            //console.debug(men);
            $http({
                method: 'DELETE',
                url: webAPIControllers + '/api/Menu/EliminarMenu/' + men.Id,
                headers: {
                    'Content-Type': 'application/json'
                },
                data: men,
            }).then(function successCallback(result) {
                $scope.nuevo();
                $scope.menus = [];
                $scope.tieneError = false;
                $scope.error = "";
                $scope.estaCargando = false;
            }, function errorCallback(result) {
                $scope.tieneError = true;
                $scope.error = "Ha ocurrido un error al listar: " + result;
                $scope.estaCargando = false;
            });
        }
        else {
            $scope.tieneError = true;
            $scope.error = "No se puede eliminar un menú que se encuentra activo";
        }
    };
});