myApp.controller("ModuloCtrl", function ($scope, $http, webAPIControllers) {
    $scope.sistemas = [];
    $scope.modulos = [];
    $scope.estaCargando = true;
    $scope.estaEditable = false;
    $scope.tieneError = false;
    $scope.mymodulo = [];

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
        $scope.error = "Ha ocuirrido un error al listar: " + result;
        $scope.estaCargando = false;
    });

    $scope.buscar = function () {
        if (angular.isUndefined($scope.sistema)) {
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
                "Estado": '',
                "Descripcion": '',
                "Sistema": $scope.sistema,
            };
            console.debug(module);
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
                $scope.error = "Ha ocuirrido un error al listar: " + result;
                $scope.estaCargando = false;
            });
        }
    };

    $scope.nuevo = function () {
        $scope.estaEditable = !$scope.estaEditable;
        $scope.mymodulo.Id = "";
        if ($scope.estaEditable == false) {
            $scope.mymodulo.Codigo = "";
            $scope.mymodulo.Nombre = "";
            $scope.mymodulo.Abreviatura = "";
            $scope.mymodulo.Estado = "";
            $scope.mymodulo.EstaActivo = false;
            $scope.mymodulo.Descripcion = "";
            $scope.mymodulo.Sistema = null;
        }
        $scope.modulos = [];
        $scope.tieneError = false;
        $scope.error = "";
    };

    $scope.modificar = function (modulo) {
        $scope.estaEditable = !$scope.estaEditable;
        if ($scope.estaEditable == true) {
            $scope.mymodulo.Id = modulo.Id;
            $scope.mymodulo.Codigo = modulo.Codigo;
            $scope.mymodulo.Nombre = modulo.Nombre;
            $scope.mymodulo.Abreviatura = modulo.Abreviatura;
            $scope.mymodulo.Estado = modulo.Estado;
            if (modulo.Estado == 'S') {
                $scope.mymodulo.EstaActivo = true;
            }
            else if (modulo.Estado == 'N') {
                $scope.mymodulo.EstaActivo = false;
            }
            $scope.mymodulo.Descripcion = modulo.Descripcion;
            $scope.mymodulo.Sistema = modulo.Sistema;
        }
    };

    $scope.guardar = function () {
        $scope.estaCargando = true;
        if ($scope.mymodulo.EstaActivo) {
            $scope.mymodulo.Estado = "S";
        }
        else {
            $scope.mymodulo.Estado = "N";
        }
        var module =
            {
                "Id": $scope.mymodulo.Id,
                "Codigo": $scope.mymodulo.Codigo,
                "Nombre": $scope.mymodulo.Nombre,
                "Abreviatura": $scope.mymodulo.Abreviatura,
                "Estado": $scope.mymodulo.Estado,
                "Descripcion": $scope.mymodulo.Descripcion,
                "Sistema": $scope.mymodulo.Sistema
            };

        if (module.Id == "") //nuevo (insert)
        {
            $http({
                method: 'POST',
                url: webAPIControllers + '/api/Modulo/InsertarModulo',
                headers: {
                    'Content-Type': 'application/json'
                },
                data: module,
            }).then(function successCallback(result) {
                $scope.nuevo();
                $scope.modulos = [];
                $scope.tieneError = false;
                $scope.error = "";
                $scope.estaCargando = false;
            }, function errorCallback(result) {
                $scope.tieneError = true;
                $scope.error = "Ha ocuirrido un error al insertar: " + result;
                $scope.estaCargando = false;
            });
        }
        else //actualizar (update)
        {
            $http({
                method: 'PUT',
                url: webAPIControllers + '/api/Modulo/ActualizarModulo/' + module.Id,
                headers: {
                    'Content-Type': 'application/json'
                },
                data: module,
            }).then(function successCallback(result) {
                $scope.nuevo();
                $scope.modulos = [];
                $scope.tieneError = false;
                $scope.error = "";
                $scope.estaCargando = false;
            }, function errorCallback(result) {
                $scope.tieneError = true;
                $scope.error = "Ha ocuirrido un error al actualizar: " + result;
                $scope.estaCargando = false;
            });
        }
    };
});