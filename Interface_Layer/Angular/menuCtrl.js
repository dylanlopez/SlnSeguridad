myApp.controller("MenuCtrl", function ($scope, $http) {
    $scope.sistemas = [];
    $scope.sistemas2 = [];
    $scope.busquedaModulos = [];
    $scope.modulos = [];
    $scope.modulos2 = [];
    $scope.menus = [];
    $scope.estaCargando = true;
    $scope.estaEditable = false;
    $scope.tieneError = false;
    $scope.mymenu = [];

    $http({
        method: 'POST',
        url: '../api/Sistema/ListarSistemas',
    }).then(function successCallback(result) {
        $scope.sistemas = result.data;
        $scope.sistemas2 = result.data;
        $scope.tieneError = false;
        $scope.error = "";
        $scope.estaCargando = false;
    }, function errorCallback(result) {
        $scope.tieneError = true;
        $scope.error = "Ha ocurrido un error al listar: " + result;
        $scope.estaCargando = false;
    });

    //$scope.buscarModulo = function (sistema) {
    $scope.buscarBusquedaModulo = function () {
        $scope.tieneError = false;
        $scope.error = "";

        var system =
        {
            "Id": $scope.sistema.Id,
            "Codigo": $scope.sistema.Codigo,
            "Nombre": $scope.sistema.Nombre,
            "Abreviatura": $scope.sistema.Abreviatura,
            "Descripcion": $scope.sistema.Descripcion,
            "Estado": $scope.sistema.Estado,
        };

        //var system =
        //{
        //    "Id": sistema.Id,
        //    "Codigo": sistema.Codigo,
        //    "Nombre": sistema.Nombre,
        //    "Abreviatura": sistema.Abreviatura,
        //    "Descripcion": sistema.Descripcion,
        //    "Estado": sistema.Estado,
        //};

        $http({
            method: 'POST',
            url: '../api/Modulo/ListarModulos',
            headers: {
                'Content-Type': 'application/json'
            },
            data: system,
        }).then(function successCallback(result) {
            $scope.modulos = result.data;
            $scope.estaCargando = false;
        }, function errorCallback(result) {
            $scope.tieneError = true;
            $scope.error = "Ha ocurrido un error al listar: " + result;
            $scope.estaCargando = false;
        });
    };
    
    $scope.buscarModulo = function () {
        $scope.tieneError = false;
        $scope.error = "";
        //alert("holas");
        console.debug($scope.mymenu.Sistema);
        //console.debug($scope.mymenu.sistema2);
        //console.debug(mymenu.Modulo.Sistema);
        var system =
        {
            "Id": $scope.mymenu.Sistema.Id,
            "Codigo": $scope.mymenu.Sistema.Codigo,
            "Nombre": $scope.mymenu.Sistema.Nombre,
            "Abreviatura": $scope.mymenu.Sistema.Abreviatura,
            "Descripcion": $scope.mymenu.Sistema.Descripcion,
            "Estado": $scope.mymenu.Sistema.Estado,
        };

        $http({
            method: 'POST',
            url: '../api/Modulo/ListarModulos',
            headers: {
                'Content-Type': 'application/json'
            },
            data: system,
        }).then(function successCallback(result) {
            $scope.modulos2 = result.data;
            $scope.estaCargando = false;
        }, function errorCallback(result) {
            $scope.tieneError = true;
            $scope.error = "Ha ocurrido un error al listar: " + result;
            $scope.estaCargando = false;
        });
    };
    
    $scope.buscar = function () {
        if (angular.isUndefined($scope.sistema) && angular.isUndefined($scope.modulo)) {
            $scope.tieneError = true;
            $scope.error = "Debe ingresar un sistema y módulo para poder ver sus menús";
        }
        else {
            $scope.tieneError = false;
            $scope.error = "";

            var module =
            {
                "Id": $scope.modulo.Id,
                "Codigo": $scope.modulo.Codigo,
                "Nombre": $scope.modulo.Nombre,
                "Abreviatura": $scope.modulo.Abreviatura,
                "Descripcion": $scope.modulo.Descripcion,
                "Estado": $scope.modulo.Estado,
                "Sistema": $scope.modulo.Sistema,
            };
            $http({
                method: 'POST',
                url: '../api/Menu/ListarMenus',
                headers: {
                    'Content-Type': 'application/json'
                },
                data: module,
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
        $scope.tieneError = false;
        $scope.error = "";
    };

    $scope.modificar = function (menu) {
        $scope.estaEditable = !$scope.estaEditable;
        //console.debug(menu);
        if ($scope.estaEditable == true) {
            $scope.mymenu.Id = menu.Id;
            $scope.mymenu.Codigo = menu.Codigo;
            $scope.mymenu.Nombre = menu.Nombre;
            $scope.mymenu.Ruta = menu.Ruta;
            $scope.mymenu.Descripcion = menu.Descripcion;
            $scope.mymenu.Estado = menu.Estado;
            if (menu.Estado == 'A') {
                $scope.mymenu.EstaActivo = true;
            }
            else if (menu.Estado == 'I') {
                $scope.mymenu.EstaActivo = false;
            }
            console.debug(menu.Modulo.Sistema);
            console.debug(menu.Modulo);
            $scope.mymenu.Sistema = menu.Modulo.Sistema;
            $scope.buscarModulo();
            //$scope.mymenu.Sistema
            $scope.mymenu.Modulo = menu.Modulo;
            //$scope.mymenu.Modulo
        }
    };

    $scope.guardar = function () {
        $scope.estaCargando = true;
        if ($scope.mymenu.EstaActivo) {
            $scope.mymenu.Estado = "A";
        }
        else {
            $scope.mymenu.Estado = "I";
        }
        var men =
            {
                "Id": $scope.mymenu.Id,
                "Codigo": $scope.mymenu.Codigo,
                "Nombre": $scope.mymenu.Nombre,
                "Ruta": $scope.mymenu.Ruta,
                "Descripcion": $scope.mymenu.Descripcion,
                "Estado": $scope.mymenu.Estado,
                "Modulo": $scope.mymenu.Modulo
            };

        if (men.Id == "") //nuevo (insert)
        {
            $http({
                method: 'POST',
                url: '../api/Menu/InsertarMenu',
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
                $scope.error = "Ha ocurrido un error al insertar: " + result;
                $scope.estaCargando = false;
            });
        }
        else //actualizar (update)
        {
            $http({
                method: 'PUT',
                url: '../api/Menu/ActualizarMenu/' + men.Id,
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
                url: '../api/Menu/EliminarMenu/' + men.Id,
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