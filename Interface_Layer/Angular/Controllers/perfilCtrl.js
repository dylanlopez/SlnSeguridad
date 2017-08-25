//myApp.controller("PerfilCtrl", function ($scope, $http, webAPIControllers) {
myApp.controller("PerfilCtrl", function ($scope, profile, PerfilFctr) {
    $scope.perfiles = [];
    $scope.estaCargando = false;
    $scope.estaEditable = false;
    $scope.tieneError = false;
    $scope.myperfil = [];

    $scope.listarPerfiles = function () {
        $scope.estaCargando = true;
        $scope.tipoError = "";
        $scope.error = "";
        $scope.tieneError = false;
        PerfilFctr.ListarPerfiles()
            .then(function successCallback(response) {
                $scope.perfiles = response;
                $scope.estaCargando = false;
                //$scope.tieneError = false;
                //$scope.error = "";
            }, function errorCallback(response) {
                $scope.estaCargando = false;
                $scope.tipoError = "alert alert-danger";
                $scope.error = "Ha ocurrido un error al listar: " + response;
                $scope.tieneError = true;
            });
    };
    $scope.listarPerfiles();

    //$http({
    //    method: 'POST',
    //    url: webAPIControllers + '/api/Perfil/ListarPerfiles',
    //}).then(function successCallback(result) {
    //    $scope.perfiles = result.data;
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
        $scope.myperfil.Id = "";
        if ($scope.estaEditable == false) {
            $scope.myperfil.Nombre = "";
            $scope.myperfil.Descripcion = "";
            PerfilFctr.CleanPerfil(profile);
        }
        $scope.tipoError = "";
        $scope.error = "";
        $scope.tieneError = false;
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
        //var perfil =
        //    {
        //        "Id": $scope.myperfil.Id,
        //        "Nombre": $scope.myperfil.Nombre,
        //        "Descripcion": $scope.myperfil.Descripcion
        //    };
        //console.debug(perfil);
        $scope.tipoError = "";
        $scope.error = "";
        $scope.tieneError = false;
        profile.Id = $scope.myperfil.Id;
        profile.Nombre = $scope.myperfil.Nombre;
        profile.Descripcion = $scope.myperfil.Descripcion;
        if (profile.Id == "") //nuevo (insert)
        {
            PerfilFctr.InsertarPerfil(profile)
                .then(function successCallback(response) {
                    $scope.nuevo();
                    //PerfilFctr.ListarPerfiles()
                    //    .then(function successCallback(response) {
                    //        $scope.perfiles = response;
                    //        //$scope.tieneError = false;
                    //        //$scope.error = "";
                    //        $scope.estaCargando = false;
                    //    }, function errorCallback(response) {
                    //        $scope.tieneError = true;
                    //        $scope.error = "Ha ocurrido un error al listar: " + response.data.Message;
                    //        $scope.estaCargando = false;
                    //    });
                    $scope.estaCargando = false;
                }, function errorCallback(response) {
                    $scope.estaCargando = false;
                    $scope.tipoError = "alert alert-danger";
                    $scope.error = "Ha ocurrido un error al insertar: " + response.data.Message;
                    $scope.tieneError = true;
                });

            //$http({
            //    method: 'POST',
            //    url: webAPIControllers + '/api/Perfil/InsertarPerfil',
            //    headers: {
            //        'Content-Type': 'application/json'
            //    },
            //    data: perfil,
            //}).then(function successCallback(result) {
            //    $scope.nuevo();

            //    $http({
            //        method: 'POST',
            //        url: webAPIControllers + '/api/Perfil/ListarPerfiles',
            //    }).then(function successCallback(result) {
            //        $scope.perfiles = result.data;
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
            PerfilFctr.ActualizarPerfil(profile)
                .then(function successCallback(response) {
                    $scope.nuevo();
                    //PerfilFctr.ListarPerfiles()
                    //    .then(function successCallback(response) {
                    //        $scope.perfiles = response;
                    //        $scope.tieneError = false;
                    //        $scope.error = "";
                    //        $scope.estaCargando = false;
                    //    }, function errorCallback(response) {
                    //        $scope.tieneError = true;
                    //        $scope.error = "Ha ocurrido un error al listar: " + response.data.Message;
                    //        $scope.estaCargando = false;
                    //    });
                    $scope.estaCargando = false;
                }, function errorCallback(response) {
                    $scope.estaCargando = false;
                    $scope.tipoError = "alert alert-danger";
                    $scope.error = "Ha ocurrido un error al actualizar: " + response.data.Message;
                    $scope.tieneError = true;
                });

            //$http({
            //    method: 'PUT',
            //    url: webAPIControllers + '/api/Perfil/ActualizarPerfil/' + perfil.Id,
            //    headers: {
            //        'Content-Type': 'application/json'
            //    },
            //    data: perfil,
            //}).then(function successCallback(result) {
            //    $scope.nuevo();

            //    $http({
            //        method: 'POST',
            //        url: webAPIControllers + '/api/Perfil/ListarPerfiles',
            //    }).then(function successCallback(result) {
            //        $scope.perfiles = result.data;
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