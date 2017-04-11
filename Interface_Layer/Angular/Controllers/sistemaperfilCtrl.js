myApp.controller("SistemaPerfilCtrl", function ($scope, $http, webAPIControllers) {
    $scope.sistemasperfiles = [];
    $scope.sistemas = [];
    $scope.perfiles = [];
    $scope.estaCargando = true;
    $scope.estaEditable = false;
    $scope.tieneError = false;
    $scope.mysistemaperfil = [];

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

    $http({
        method: 'POST',
        url: webAPIControllers + '/api/Perfil/ListarPerfiles',
    }).then(function successCallback(result) {
        $scope.perfiles = result.data;
        $scope.tieneError = false;
        $scope.error = "";
        $scope.estaCargando = false;
    }, function errorCallback(result) {
        $scope.tieneError = true;
        $scope.error = "Ha ocuirrido un error al listar: " + result;
        $scope.estaCargando = false;
    });

    $scope.buscar = function () {
        if (angular.isUndefined($scope.mysistemaperfil.Sistema)) {
            $scope.tieneError = true;
            $scope.error = "Debe ingresar un sistema para poder ver sus perfiles";
        }
        else {
            $scope.tieneError = false;
            $scope.error = "";

            var sistemaperfil =
            {
                "Id": '',
                "Estado": '',
                "Sistema": $scope.mysistemaperfil.Sistema,
                "Perfil": ''
            };

            $http({
                method: 'POST',
                url: webAPIControllers + '/api/SistemaPerfil/ListarSistemasPerfiles',
                headers: {
                    'Content-Type': 'application/json'
                },
                data: sistemaperfil,
            }).then(function successCallback(result) {
                $scope.sistemasperfiles = result.data;
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
        $scope.mysistemaperfil.Id = "";
        if ($scope.estaEditable == false) {
            $scope.mysistemaperfil.Estado = "";
            $scope.mysistemaperfil.EstaActivo = false;
            $scope.mysistemaperfil.Sistema = null;
            $scope.mysistemaperfil.Perfil = null;
        }
        $scope.tieneError = false;
        $scope.error = "";
    };

    $scope.modificar = function (sistemaperfil) {
        $scope.estaEditable = !$scope.estaEditable;
        if ($scope.estaEditable == true) {
            $scope.mysistemaperfil.Id = sistemaperfil.Id;
            $scope.mysistemaperfil.Estado = sistemaperfil.Estado;
            $scope.mysistemaperfil.Sistema = sistemaperfil.Sistema;
            $scope.mysistemaperfil.Perfil = sistemaperfil.Perfil;
            if (modulo.Estado == 'S') {
                $scope.mysistemaperfil.EstaActivo = true;
            }
            else if (modulo.Estado == 'N') {
                $scope.mysistemaperfil.EstaActivo = false;
            }
        }
    };

    $scope.guardar = function () {
        $scope.estaCargando = true;
        var sistemaperfil =
            {
                "Id": $scope.mysistemaperfil.Id,
                "Estado": $scope.mysistemaperfil.Estado,
                "Sistema": $scope.mysistemaperfil.Sistema,
                "Perfil": $scope.mysistemaperfil.Perfil
            };
        //console.debug(perfil);

        if (sistemaperfil.Id == "") //nuevo (insert)
        {
            $http({
                method: 'POST',
                url: webAPIControllers + '/api/SistemaPerfil/InsertarSistemaPerfil',
                headers: {
                    'Content-Type': 'application/json'
                },
                data: sistemaperfil,
            }).then(function successCallback(result) {
                $scope.nuevo();
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
                url: webAPIControllers + '/api/SistemaPerfil/ActualizarSistemaPerfil/' + sistemaperfil.Id,
                headers: {
                    'Content-Type': 'application/json'
                },
                data: sistemaperfil,
            }).then(function successCallback(result) {
                $scope.nuevo();
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