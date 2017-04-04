myApp.controller("RolCtrl", function ($scope, $http, webAPIControllers) {
    $scope.roles = [];
    $scope.estaCargando = true;
    $scope.estaEditable = false;
    $scope.tieneError = false;
    $scope.myrol = [];

    var role =
            {
                "Id": '',
                "Nombre": '',
                "Descripcion": '',
                "Estado": '',
            };
    $http({
        method: 'POST',
        url: webAPIControllers + '/api/Rol/ListarRoles',
        headers: {
            'Content-Type': 'application/json'
        },
        data: role,
    }).then(function successCallback(result) {
        //console.log(result.data);
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

    $scope.nuevo = function () {
        $scope.estaEditable = !$scope.estaEditable;
        $scope.myrol.Id = "";
        if ($scope.estaEditable == false) {
            $scope.myrol.Nombre = "";
            $scope.myrol.Descripcion = "";
            $scope.myrol.EstaActivo = false;
        }
        $scope.roles = [];
        $scope.tieneError = false;
        $scope.error = "";
    };

    $scope.modificar = function (role) {
        $scope.estaEditable = !$scope.estaEditable;
        if ($scope.estaEditable == true) {
            $scope.myrol.Id = role.Id;
            $scope.myrol.Nombre = role.Nombre;
            $scope.myrol.Descripcion = role.Descripcion;
            if (role.Estado == 'A') {
                $scope.myrol.EstaActivo = true;
            }
            else if (sistema.Estado == 'I') {
                $scope.myrol.EstaActivo = false;
            }
        }
    };

    $scope.guardar = function () {
        $scope.estaCargando = true;
        var role =
            {
                "Id": $scope.myrol.Id,
                "Nombre": $scope.myrol.Nombre,
                "Descripcion": $scope.myrol.Descripcion,
                "Estado": '',
            };
        if ($scope.myrol.EstaActivo) {
            role.Estado = "A";
        }
        else {
            role.Estado = "I";
        }
        if (role.Id == "") //nuevo (insert)
        {
            $http({
                method: 'POST',
                url: webAPIControllers + '/api/Rol/InsertarRol',
                headers: {
                    'Content-Type': 'application/json'
                },
                data: role,
            }).then(function successCallback(result) {
                $scope.nuevo();
                $http({
                    method: 'POST',
                    url: webAPIControllers + '/api/Rol/ListarRoles',
                }).then(function successCallback(result) {
                    $scope.roles = result.data;
                });
                $scope.tieneError = false;
                $scope.error = "";
                $scope.estaCargando = false;
            }, function errorCallback(result) {
                //console.error(result);
                $scope.tieneError = true;
                $scope.error = "Ha ocuirrido un error al insertar: " + result;
                $scope.estaCargando = false;
            });
        }
        else //actualizar (update)
        {
            $http({
                method: 'PUT',
                url: webAPIControllers + '/api/Rol/ActualizarRol/' + role.Id,
                headers: {
                    'Content-Type': 'application/json'
                },
                data: role,
            }).then(function successCallback(result) {
                $scope.nuevo();
                $http({
                    method: 'POST',
                    url: webAPIControllers + '/api/Rol/ListarRoles',
                }).then(function successCallback(result) {
                    $scope.roles = result.data;
                });
                $scope.tieneError = false;
                $scope.error = "";
                $scope.estaCargando = false;
            }, function errorCallback(result) {
                //console.error(result);
                $scope.tieneError = true;
                $scope.error = "Ha ocuirrido un error al actualizar: " + result;
                $scope.estaCargando = false;
            });
        }
    };
});