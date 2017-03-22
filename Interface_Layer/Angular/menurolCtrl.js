myApp.controller("MenuRolCtrl", function ($scope, $http) {
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
        url: '../api/Rol/ListarRoles',
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
        url: '../api/Sistema/ListarSistemas',
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
            url: '../api/Modulo/ListarModulos',
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
                url: '../api/Menu/ListarMenus',
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
            url: '../api/MenuRol/ListarMenusRoles',
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
        var menurol =
            {
                "Id": '0',
                "Menu": $scope.menuSeleccionada,
                "Rol": $scope.rolSeleccionado
            };
        console.debug(menurol);
        $scope.menusroles.push(menurol);

        //$scope.menusroles = [{ "Persona": personaSeleccionada.Nombre, "Rol": rolSeleccionado.Nombre }];
    };

    $scope.guardar = function () {
        $scope.estaCargando = true;
        //console.debug($scope.menusroles);
        //console.debug($scope.menusroles[0]);
        $http({
            method: 'DELETE',
            url: '../api/MenuRol/EliminarMenuRol/' + $scope.menusroles[0].Id,
            headers: {
                'Content-Type': 'application/json'
            },
            data: $scope.menusroles[0],
        }).then(function successCallback(result) {
            $http({
                method: 'POST',
                url: '../api/MenuRol/InsertarMenuRol',
                headers: {
                    'Content-Type': 'application/json'
                },
                data: $scope.menusroles,
            }).then(function successCallback(result) {
                $scope.tieneError = false;
                $scope.error = "";
                $scope.estaCargando = false;
            }, function errorCallback(result) {
                $scope.tieneError = true;
                $scope.error = "Ha ocurrido un error al insertar: " + result;
                $scope.estaCargando = false;
            });
            $scope.tieneError = false;
            $scope.error = "";
            $scope.estaCargando = false;
        }, function errorCallback(result) {
            $scope.tieneError = true;
            $scope.error = "Ha ocurrido un error al insertar: " + result;
            $scope.estaCargando = false;
        });
    };
});