myApp.controller("MenuRolCtrl", function ($scope, $http, webAPIControllers) {
    $scope.menusroles = [];
    $scope.sistemas = [];
    $scope.modulos = [];
    $scope.menus = [];
    $scope.roles = [];
    $scope.estaCargando = true;
    $scope.estaEditable = false;
    $scope.tieneError = false;
    //$scope.roles = [{ "Id": '1', "Nombre": 'Admin' },
    //                    { "Id": '2', "Nombre": 'Contable' }];

    var role =
            {
                "Id": '',
                "Nombre": '',
                "Descripcion": '',
                "Estado": 'A',
            };
    $http({
        method: 'POST',
        url: webAPIControllers + '/api/Rol/ListarRoles',
        headers: {
            'Content-Type': 'application/json'
        },
        data: role,
    }).then(function successCallback(result) {
        $scope.roles = result.data;
        $scope.tieneError = false;
        $scope.error = "";
        $scope.estaCargando = false;
    }, function errorCallback(result) {
        //console.error(result);
        $scope.tieneError = true;
        $scope.error = "Ha ocuirrido un error al listar: " + result;
        $scope.estaCargando = false;
    });
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
    $scope.selectedRol = 0;
    $scope.selectedMenu = 0;

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
                "Sistema": $scope.sistema,
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
        if (angular.isUndefined($scope.sistema) && angular.isUndefined($scope.modulo)) {
            $scope.tieneError = true;
            $scope.error = "Debe ingresar un sistema y módulo para poder ver sus menús";
        }
        else {
            $scope.tieneError = false;
            $scope.error = "";

            var men =
            {
                "Id": '',
                "Codigo": '',
                "Nombre": '',
                "Ruta": '',
                "Descripcion": '',
                "Estado": '',
                "Modulo": $scope.modulo
            };

            $http({
                method: 'POST',
                url: webAPIControllers + '/api/Menu/ListarMenus',
                headers: {
                    'Content-Type': 'application/json'
                },
                data: men,
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

    $scope.buscar = function (rol, index) {
        $scope.rolSeleccionado = rol;
        $scope.selectedRol = index;
        var menurol =
            {
                "Id": '',
                "Menu": { },
                "Rol": { }
            };
        menurol.Rol = rol;
        //console.debug(rol);
        $http({
            method: 'POST',
            url: webAPIControllers + '/api/MenuRol/ListarMenusRoles',
            headers: {
                'Content-Type': 'application/json'
            },
            data: menurol,
        }).then(function successCallback(result) {
            $scope.menusroles = result.data;
            $scope.tieneError = false;
            $scope.error = "";
            $scope.estaCargando = false;
        }, function errorCallback(result) {
            //console.error(result);
            $scope.tieneError = true;
            $scope.error = "Ha ocuirrido un error al listar: " + result;
            $scope.estaCargando = false;
        });
    };

    $scope.seleccionaRol = function (rol) {
        $scope.rolSeleccionado = rol;
    };

    $scope.seleccionaMenu = function (menu, index) {
        $scope.menuSeleccionada = menu;
        //console.debug(index);
        $scope.selectedMenu = index;
    };

    $scope.agregaMenu = function () {
        $scope.tieneError = false;
        $scope.error = "";
        var menurol =
            {
                "Id": '0',
                "Menu": $scope.menuSeleccionada,
                "Rol": $scope.rolSeleccionado
            };
        var repetido = false;
        angular.forEach($scope.menusroles, function (value) {
            //console.debug("MENU");
            //console.debug(value.Menu);
            //console.debug(menurol.Menu);
            //console.debug("ROL");
            //console.debug(value.Rol);
            //console.debug(menurol.Rol);
            if (value.Menu.Id == menurol.Menu.Id && value.Rol.Id == menurol.Rol.Id) {
                repetido = true;
            }
            //if (value.Menu.Id != menurol.Menu.Id && value.Rol.Id != menurol.Rol.Id) {
            //    $scope.menusroles.push(menurol);
            //    $scope.tieneError = false;
            //    $scope.error = "";
            //} else {
            //    $scope.tieneError = true;
            //    $scope.error = "Ha ocurrido un error, al agregar el menu al rol. Ya se encuentra ingresado";
            //}
        });
        if (!repetido) {
            $scope.menusroles.push(menurol);
            $scope.tieneError = false;
            $scope.error = "";
        } else {
            $scope.tieneError = true;
            $scope.error = "Ha ocurrido un error, al agregar el menu al rol. Ya se encuentra ingresado";
        }
    };

    $scope.eliminarMenu = function (menurol) {
        console.debug(menurol);
        for (var i = 0; i < $scope.menusroles.length; i++) {
            var obj = $scope.menusroles[i];
            if (obj.Id == menurol.Id) {
                $scope.menusroles.splice(i, 1);
            }
        }
    };

    $scope.guardar = function () {
        $scope.estaCargando = true;
        //console.debug($scope.menusroles);
        //console.debug($scope.menusroles[0]);
        $http({
            method: 'DELETE',
            url: webAPIControllers + '/api/MenuRol/EliminarMenuRol/' + $scope.menusroles[0].Id,
            headers: {
                'Content-Type': 'application/json'
            },
            data: $scope.menusroles[0],
        }).then(function successCallback(result) {
            $http({
                method: 'POST',
                url: webAPIControllers + '/api/MenuRol/InsertarMenuRol',
                headers: {
                    'Content-Type': 'application/json'
                },
                data: $scope.menusroles,
            }).then(function successCallback(result) {
                $scope.menusroles = [];
                $scope.rolSeleccionado = {};
                $scope.selectedRol = 0;
                $scope.menuSeleccionada = {};
                $scope.selectedMenu = 0;
                $scope.tieneError = false;
                $scope.error = "";
                $scope.estaCargando = false;
            }, function errorCallback(result) {
                $scope.tieneError = true;
                $scope.error = "Ha ocurrido un error al insertar: " + result;
                $scope.estaCargando = false;
            });
        }, function errorCallback(result) {
            $scope.tieneError = true;
            $scope.error = "Ha ocurrido un error al insertar: " + result;
            $scope.estaCargando = false;
        });
    };
});