//myApp.controller("RolCtrl", function ($scope, $http, webAPIControllers) {
myApp.controller("RolCtrl", function ($scope, role, RolFctr) {
    $scope.roles = [];
    $scope.estaCargando = true;
    $scope.estaEditable = false;
    $scope.tieneError = false;
    $scope.myrol = [];

    RolFctr.ListarRoles(role)
        .then(function successCallback(response) {
            $scope.roles = response;
            $scope.tieneError = false;
            $scope.error = "";
            $scope.estaCargando = false;
        }, function errorCallback(response) {
            $scope.tieneError = true;
            $scope.error = "Ha ocurrido un error al listar: " + response;
            $scope.estaCargando = false;
        });

    //var role =
    //        {
    //            "Id": '',
    //            "Nombre": '',
    //            "Descripcion": ''
    //        };
    //$http({
    //    method: 'POST',
    //    url: webAPIControllers + '/api/Rol/ListarRoles',
    //    headers: {
    //        'Content-Type': 'application/json'
    //    },
    //    data: role,
    //}).then(function successCallback(result) {
    //    $scope.roles = result.data;
    //    $scope.tieneError = false;
    //    $scope.error = "";
    //    $scope.estaCargando = false;
    //}, function errorCallback(result) {
    //    $scope.tieneError = true;
    //    $scope.error = "Ha ocuirrido un error al listar: " + result;
    //    $scope.estaCargando = false;
    //});

    $scope.nuevo = function () {
        $scope.estaEditable = !$scope.estaEditable;
        $scope.myrol.Id = "";
        if ($scope.estaEditable == false) {
            $scope.myrol.Nombre = "";
            $scope.myrol.Descripcion = "";
            RolFctr.CleanRol(role);
        }
        //$scope.roles = [];
        $scope.tieneError = false;
        $scope.error = "";
    };

    $scope.modificar = function (role) {
        $scope.estaEditable = !$scope.estaEditable;
        if ($scope.estaEditable == true) {
            $scope.myrol.Id = role.Id;
            $scope.myrol.Nombre = role.Nombre;
            $scope.myrol.Descripcion = role.Descripcion;
        }
    };

    $scope.guardar = function () {
        $scope.estaCargando = true;
        //var role =
        //    {
        //        "Id": $scope.myrol.Id,
        //        "Nombre": $scope.myrol.Nombre,
        //        "Descripcion": $scope.myrol.Descripcion
        //    };
        role.Id = $scope.myrol.Id;
        role.Nombre = $scope.myrol.Nombre;
        role.Descripcion = $scope.myrol.Descripcion;
        if (role.Id == "") //nuevo (insert)
        {
            RolFctr.InsertarRol(role)
                .then(function successCallback(response) {
                    $scope.nuevo();
                    RolFctr.ListarRoles(role)
                        .then(function successCallback(response) {
                            $scope.roles = response;
                            $scope.tieneError = false;
                            $scope.error = "";
                            $scope.estaCargando = false;
                        }, function errorCallback(response) {
                            $scope.tieneError = true;
                            $scope.error = "Ha ocurrido un error al listar: " + response.data.Message;
                            $scope.estaCargando = false;
                        });
                }, function errorCallback(response) {
                    $scope.tieneError = true;
                    $scope.error = "Ha ocurrido un error al insertar: " + response.data.Message;
                    $scope.estaCargando = false;
                });
            //$http({
            //    method: 'POST',
            //    url: webAPIControllers + '/api/Rol/InsertarRol',
            //    headers: {
            //        'Content-Type': 'application/json'
            //    },
            //    data: role,
            //}).then(function successCallback(result) {
            //    $scope.nuevo();
            //    $http({
            //        method: 'POST',
            //        url: webAPIControllers + '/api/Rol/ListarRoles',
            //    }).then(function successCallback(result) {
            //        $scope.roles = result.data;
            //    });
            //    $scope.tieneError = false;
            //    $scope.error = "";
            //    $scope.estaCargando = false;
            //}, function errorCallback(result) {
            //    $scope.tieneError = true;
            //    $scope.error = "Ha ocuirrido un error al insertar: " + result;
            //    $scope.estaCargando = false;
            //});
        }
        else //actualizar (update)
        {
            RolFctr.ActualizarRol(role)
                .then(function successCallback(response) {
                    $scope.nuevo();
                    RolFctr.ListarRoles(role)
                        .then(function successCallback(response) {
                            $scope.roles = response;
                            $scope.tieneError = false;
                            $scope.error = "";
                            $scope.estaCargando = false;
                        }, function errorCallback(response) {
                            $scope.tieneError = true;
                            $scope.error = "Ha ocurrido un error al listar: " + response.data.Message;
                            $scope.estaCargando = false;
                        });
                }, function errorCallback(response) {
                    $scope.tieneError = true;
                    $scope.error = "Ha ocurrido un error al actualizar: " + response.data.Message;
                    $scope.estaCargando = false;
                });
            //$http({
            //    method: 'PUT',
            //    url: webAPIControllers + '/api/Rol/ActualizarRol/' + role.Id,
            //    headers: {
            //        'Content-Type': 'application/json'
            //    },
            //    data: role,
            //}).then(function successCallback(result) {
            //    $scope.nuevo();
            //    $http({
            //        method: 'POST',
            //        url: webAPIControllers + '/api/Rol/ListarRoles',
            //    }).then(function successCallback(result) {
            //        $scope.roles = result.data;
            //    });
            //    $scope.tieneError = false;
            //    $scope.error = "";
            //    $scope.estaCargando = false;
            //}, function errorCallback(result) {
            //    $scope.tieneError = true;
            //    $scope.error = "Ha ocuirrido un error al actualizar: " + result;
            //    $scope.estaCargando = false;
            //});
        }
    };
});