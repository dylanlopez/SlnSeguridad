myApp.controller("PerfilCtrl", function ($scope, $http, webAPIControllers) {
    $scope.perfiles = [];
    $scope.estaCargando = true;
    $scope.estaEditable = false;
    $scope.tieneError = false;
    $scope.myperfil = [];

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

    $scope.nuevo = function () {
        $scope.estaEditable = !$scope.estaEditable;
        $scope.myperfil.Id = "";
        if ($scope.estaEditable == false) {
            $scope.myperfil.Nombre = "";
            $scope.myperfil.Descripcion = "";
        }
        $scope.tieneError = false;
        $scope.error = "";
    };

    $scope.modificar = function (perfil) {
        $scope.estaEditable = !$scope.estaEditable;
        if ($scope.estaEditable == true) {
            $scope.myperfil.Id = perfil.Id;
            $scope.myperfil.Nombre = perfil.Nombre;
            $scope.myperfil.Descripcion = perfil.Descripcion;
        }
    };

    $scope.guardar = function () {
        $scope.estaCargando = true;
        var perfil =
            {
                "Id": $scope.myperfil.Id,
                "Nombre": $scope.myperfil.Nombre,
                "Descripcion": $scope.myperfil.Descripcion
            };
        //console.debug(perfil);

        if (perfil.Id == "") //nuevo (insert)
        {
            $http({
                method: 'POST',
                url: webAPIControllers + '/api/Perfil/InsertarPerfil',
                headers: {
                    'Content-Type': 'application/json'
                },
                data: perfil,
            }).then(function successCallback(result) {
                $scope.nuevo();

                $http({
                    method: 'POST',
                    url: webAPIControllers + '/api/Perfil/ListarPerfiles',
                }).then(function successCallback(result) {
                    $scope.perfiles = result.data;
                });
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
                url: webAPIControllers + '/api/Perfil/ActualizarPerfil/' + perfil.Id,
                headers: {
                    'Content-Type': 'application/json'
                },
                data: perfil,
            }).then(function successCallback(result) {
                $scope.nuevo();

                $http({
                    method: 'POST',
                    url: webAPIControllers + '/api/Perfil/ListarPerfiles',
                }).then(function successCallback(result) {
                    $scope.perfiles = result.data;
                });
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