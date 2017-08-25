//myApp.controller("MenuCtrl", function ($scope, $http, webAPIControllers) {
myApp.controller("MenuCtrl", function ($scope, system, module, menu, SistemaFctr, ModuloFctr, MenuFctr) {
    $scope.sistemas = [];
    $scope.modulos = [];
    $scope.menus = [];
    $scope.estaCargando = false;
    $scope.estaEditable = false;
    $scope.tieneError = false;
    $scope.mymenu = [];

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
        }, function errorCallback(response) {
            $scope.tipoError = "alert alert-danger";
            $scope.error = "Ha ocurrido un error al listar: " + response;
            $scope.tieneError = true;
        });
    };
    $scope.listarSistemas();
    
    $scope.listarModulos = function () {
        if (angular.isUndefined($scope.mymenu.Sistema)) {
            $scope.tipoError = "alert alert-warning";
            $scope.error = "Debe ingresar un sistema para poder ver sus módulos";
            $scope.tieneError = true;
        }
        else {
            $scope.tipoError = "";
            $scope.error = "";
            $scope.tieneError = false;
            //$scope.estaCargando = true;
            //var module =
            //    {
            //        "Id": '',
            //        "Codigo": '',
            //        "Nombre": '',
            //        "Abreviatura": '',
            //        "Descripcion": '',
            //        "Estado": '',
            //        "Sistema": $scope.mymenu.Sistema
            //    };
            module.Activo = 'S';
            module.Sistema = $scope.mymenu.Sistema;
            ModuloFctr.ListarModulos(module)
                .then(function successCallback(response) {
                    $scope.modulos = response;
                    //$scope.estaCargando = false;
                }, function errorCallback(response) {
                    $scope.tipoError = "alert alert-danger";
                    $scope.error = "Ha ocurrido un error al listar: " + response;
                    $scope.tieneError = true;
                    //$scope.estaCargando = false;
                });
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

    $scope.setearModulo = function () {
        if (!angular.isUndefined($scope.mymenu.Modulo) && $scope.mymenu.Modulo != null) {
            $scope.mymenu.Codigo = $scope.mymenu.Modulo.Codigo;
        }
    };
    
    $scope.buscar = function () {
        if (angular.isUndefined($scope.mymenu.Sistema) || $scope.mymenu.Sistema == null) {
            $scope.tipoError = "alert alert-warning";
            $scope.error = "Debe ingresar un sistema como mínimo para poder ver sus menús";
            $scope.tieneError = true;
        }
        else {
            $scope.estaCargando = true;
            $scope.tipoError = "";
            $scope.error = "";
            $scope.tieneError = false;

            //var menu =
            //{
            //    "Id": '',
            //    "Codigo": '',
            //    "Nombre": '',
            //    "Ruta": '',
            //    "Descripcion": '',
            //    "Estado": '',
            //    "Modulo": $scope.mymenu.Modulo
            //};
            //console.debug(menu);
            //console.debug(module);
            //console.debug($scope.mymenu.Modulo);
            //console.debug($scope.mymenu.Sistema);
            menu.Nombre = $scope.mymenu.Nombre;
            //menu.Modulo = $scope.mymenu.Modulo;
            menu.Modulo.Sistema = $scope.mymenu.Sistema;
            //console.debug($scope.mymenu.Modulo);
            //console.debug(menu);

            if (!angular.isUndefined($scope.mymenu.Modulo) && $scope.mymenu.Modulo != null) {
                //console.info("Entro A");
                menu.Modulo = $scope.mymenu.Modulo;
                //menu.Modulo = module;
            }
            ////console.debug($scope.mymenu.Sistema);
            //if (!angular.isUndefined($scope.mymenu.Sistema)) {
            //    //console.info("Entro B");
            //    menu.Modulo.Sistema = $scope.mymenu.Sistema;
            //    //menu.Modulo.Sistema = system;
            //}
            
            MenuFctr.ListarMenus(menu)
                .then(function successCallback(response) {
                    $scope.menus = response;
                    $scope.estaCargando = false;
                }, function errorCallback(response) {
                    $scope.estaCargando = false;
                    $scope.tipoError = "alert alert-warning";
                    $scope.error = "Ha ocurrido un error al listar: " + response;
                    $scope.tieneError = true;
                });

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

    $scope.nuevo = function () {
        $scope.estaEditable = !$scope.estaEditable;
        $scope.mymenu.Id = "";
        if ($scope.estaEditable == false) {
            $scope.mymenu.Codigo = "";
            $scope.mymenu.Ruta = "";
            $scope.mymenu.Descripcion = "";
            $scope.mymenu.Activo = "";
            $scope.mymenu.EstaActivo = false;
            //ModuloFctr.CleanModulo(module);
            //SistemaFctr.CleanSistema(system);
        }
        $scope.mymenu.Sistema = null;
        $scope.mymenu.Modulo = null;
        $scope.mymenu.Nombre = "";
        MenuFctr.CleanMenu(menu);
        //console.debug(menu);
        $scope.menus = [];
        $scope.tipoError = "";
        $scope.error = "";
        $scope.tieneError = false;
    };

    $scope.modificar = function (menu) {
        $scope.estaEditable = !$scope.estaEditable;
        if ($scope.estaEditable == true) {
            $scope.mymenu.Id = menu.Id;
            $scope.mymenu.Codigo = menu.Codigo;
            $scope.mymenu.Nombre = menu.Nombre;
            $scope.mymenu.Ruta = menu.Ruta;
            $scope.mymenu.Descripcion = menu.Descripcion;
            $scope.mymenu.Activo = menu.Activo;
            if (menu.Activo == 'S') {
                $scope.mymenu.EstaActivo = true;
            }
            else if (menu.Activo == 'N') {
                $scope.mymenu.EstaActivo = false;
            }
            //console.debug(menu.Modulo.Sistema);
            //console.debug(menu.Modulo);
            $scope.mymenu.Sistema = menu.Modulo.Sistema;
            $scope.listarModulos();
            $scope.mymenu.Modulo = menu.Modulo;
        }
    };

    $scope.guardar = function () {
        $scope.estaCargando = true;
        if ($scope.mymenu.EstaActivo) {
            $scope.mymenu.Activo = "S";
        }
        else {
            $scope.mymenu.Activo = "N";
        }
        //var menu =
        //    {
        //        "Id": $scope.mymenu.Id,
        //        "Codigo": $scope.mymenu.Codigo,
        //        "Nombre": $scope.mymenu.Nombre,
        //        "Ruta": $scope.mymenu.Ruta,
        //        "Descripcion": $scope.mymenu.Descripcion,
        //        "Estado": $scope.mymenu.Estado,
        //        "Modulo": $scope.mymenu.Modulo
        //    };

        $scope.tipoError = "";
        $scope.error = "";
        $scope.tieneError = false;

        menu.Id = $scope.mymenu.Id;
        menu.Codigo = $scope.mymenu.Codigo;
        menu.Nombre = $scope.mymenu.Nombre;
        menu.Ruta = $scope.mymenu.Ruta;
        menu.Descripcion = $scope.mymenu.Descripcion;
        menu.Activo = $scope.mymenu.Activo;
        menu.Modulo = $scope.mymenu.Modulo;
        if (menu.Id == "") //nuevo (insert)
        {
            MenuFctr.InsertarMenu(menu)
                .then(function successCallback(response) {
                    $scope.nuevo();
                    //$scope.menus = [];
                    //$scope.tipoError = "";
                    //$scope.error = "";
                    //$scope.tieneError = false;
                    $scope.estaCargando = false;
                }, function errorCallback(response) {
                    $scope.estaCargando = false;
                    $scope.tipoError = "alert alert-danger";
                    $scope.error = "Ha ocurrido un error al insertar: " + response.data.Message;
                    $scope.tieneError = true;
                });

            //$http({
            //    method: 'POST',
            //    url: webAPIControllers + '/api/Menu/InsertarMenu',
            //    headers: {
            //        'Content-Type': 'application/json'
            //    },
            //    data: menu,
            //}).then(function successCallback(result) {
            //    $scope.nuevo();
            //    $scope.menus = [];
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
            MenuFctr.ActualizarMenu(menu)
                .then(function successCallback(response) {
                    $scope.nuevo();
                    //$scope.menus = [];
                    //$scope.tipoError = "";
                    //$scope.error = "";
                    //$scope.tieneError = false;
                    $scope.estaCargando = false;
                }, function errorCallback(response) {
                    $scope.estaCargando = false;
                    $scope.tipoError = "alert alert-danger";
                    $scope.error = "Ha ocurrido un error al actualizar: " + response.data.Message;
                    $scope.tieneError = true;
                });

            //$http({
            //    method: 'PUT',
            //    url: webAPIControllers + '/api/Menu/ActualizarMenu/' + menu.Id,
            //    headers: {
            //        'Content-Type': 'application/json'
            //    },
            //    data: menu,
            //}).then(function successCallback(result) {
            //    $scope.nuevo();
            //    $scope.menus = [];
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

    //$scope.eliminar = function (menu) {
    //    if (menu.Estado == 'I') {
    //        //console.debug(menu);
    //        var men =
    //        {
    //            "Id": menu.Id,
    //            "Codigo": menu.Codigo,
    //            "Nombre": menu.Nombre,
    //            "Ruta": menu.Ruta,
    //            "Descripcion": menu.Descripcion,
    //            "Estado": menu.Estado,
    //            "Modulo": menu.Modulo
    //        };
    //        //console.debug(men);
    //        $http({
    //            method: 'DELETE',
    //            url: webAPIControllers + '/api/Menu/EliminarMenu/' + men.Id,
    //            headers: {
    //                'Content-Type': 'application/json'
    //            },
    //            data: men,
    //        }).then(function successCallback(result) {
    //            $scope.nuevo();
    //            $scope.menus = [];
    //            $scope.tieneError = false;
    //            $scope.error = "";
    //            $scope.estaCargando = false;
    //        }, function errorCallback(result) {
    //            $scope.tieneError = true;
    //            $scope.error = "Ha ocurrido un error al listar: " + result;
    //            $scope.estaCargando = false;
    //        });
    //    }
    //    else {
    //        $scope.tieneError = true;
    //        $scope.error = "No se puede eliminar un menú que se encuentra activo";
    //    }
    //};
});