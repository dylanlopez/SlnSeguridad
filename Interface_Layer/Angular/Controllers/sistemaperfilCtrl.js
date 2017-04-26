//myApp.controller("SistemaPerfilCtrl", function ($scope, $http, webAPIControllers) {
myApp.controller("SistemaPerfilCtrl", function ($scope, system, systemprofile, 
                                                SistemaFctr, PerfilFctr, SistemaPerfilFctr) {
    $scope.sistemasperfiles = [];
    $scope.sistemas = [];
    $scope.perfiles = [];
    $scope.estaCargando = true;
    $scope.estaEditable = false;
    $scope.tieneError = false;
    $scope.mysistemaperfil = [];

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
    //    $scope.error = "Ha ocuirrido un error al listar: " + result;
    //    $scope.estaCargando = false;
    //});

    system.Activo = 'S';
    SistemaFctr.ListarSistemas(system)
        .then(function successCallback(response) {
            $scope.sistemas = response;
            $scope.tieneError = false;
            $scope.error = "";
            $scope.estaCargando = false;
        }, function errorCallback(response) {
            $scope.tieneError = true;
            $scope.error = "Ha ocuirrido un error al listar: " + response;
            $scope.estaCargando = false;
        });

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

    PerfilFctr.ListarPerfiles()
        .then(function successCallback(response) {
            $scope.perfiles = response;
            $scope.tieneError = false;
            $scope.error = "";
            $scope.estaCargando = false;
        }, function errorCallback(response) {
            $scope.tieneError = true;
            $scope.error = "Ha ocuirrido un error al listar: " + response;
            $scope.estaCargando = false;
        });

    $scope.buscar = function () {
        if (angular.isUndefined($scope.mysistemaperfil.Sistema) && 
            angular.isUndefined($scope.mysistemaperfil.Perfil)) {
            $scope.tieneError = true;
            $scope.error = "Debe ingresar un sistema o perfiles";
        }
        else {
            $scope.tieneError = false;
            $scope.error = "";

            //var sistemaperfil =
            //{
            //    "Id": '',
            //    "Estado": '',
            //    "Sistema": $scope.mysistemaperfil.Sistema,
            //    "Perfil": ''
            //};

            systemprofile.Sistema = $scope.mysistemaperfil.Sistema;
            systemprofile.Perfil = $scope.mysistemaperfil.Perfil;
            SistemaPerfilFctr.ListarSistemasPerfiles(systemprofile)
                .then(function successCallback(response) {
                    $scope.sistemasperfiles = response;
                    $scope.tieneError = false;
                    $scope.error = "";
                    $scope.estaCargando = false;
                }, function errorCallback(response) {
                    $scope.tieneError = true;
                    $scope.error = "Ha ocuirrido un error al listar: " + response;
                    $scope.estaCargando = false;
                });

            //$http({
            //    method: 'POST',
            //    url: webAPIControllers + '/api/SistemaPerfil/ListarSistemasPerfiles',
            //    headers: {
            //        'Content-Type': 'application/json'
            //    },
            //    data: sistemaperfil,
            //}).then(function successCallback(result) {
            //    $scope.sistemasperfiles = result.data;
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
        $scope.mysistemaperfil.Id = "";
        if ($scope.estaEditable == false) {
            $scope.mysistemaperfil.Activo = "";
            $scope.mysistemaperfil.EstaActivo = false;
        }
        $scope.mysistemaperfil.Sistema = null;
        $scope.mysistemaperfil.Perfil = null;
        SistemaPerfilFctr.CleanSistemaPerfil(systemprofile);
        $scope.tieneError = false;
        $scope.error = "";
    };

    $scope.modificar = function (sistemaperfil) {
        $scope.estaEditable = !$scope.estaEditable;
        if ($scope.estaEditable == true) {
            $scope.mysistemaperfil.Id = sistemaperfil.Id;
            $scope.mysistemaperfil.Activo = sistemaperfil.Activo;
            $scope.mysistemaperfil.Sistema = sistemaperfil.Sistema;
            $scope.mysistemaperfil.Perfil = sistemaperfil.Perfil;
            if (sistemaperfil.Activo == 'S') {
                $scope.mysistemaperfil.EstaActivo = true;
            }
            else if (sistemaperfil.Activo == 'N') {
                $scope.mysistemaperfil.EstaActivo = false;
            }
        }
    };

    $scope.guardar = function () {
        $scope.tieneError = false;
        $scope.error = "";
        $scope.estaCargando = true;
        if ($scope.mysistemaperfil.EstaActivo) {
            $scope.mysistemaperfil.Activo = "S";
        }
        else {
            $scope.mysistemaperfil.Activo = "N";
        }
        //var sistemaperfil =
        //    {
        //        "Id": $scope.mysistemaperfil.Id,
        //        "Estado": $scope.mysistemaperfil.Estado,
        //        "Sistema": $scope.mysistemaperfil.Sistema,
        //        "Perfil": $scope.mysistemaperfil.Perfil
        //    };
        //console.debug(perfil);
        systemprofile.Id = $scope.mysistemaperfil.Id;
        systemprofile.Activo = $scope.mysistemaperfil.Activo;
        systemprofile.Sistema = $scope.mysistemaperfil.Sistema;
        systemprofile.Perfil = $scope.mysistemaperfil.Perfil;
        if (systemprofile.Id == "") //nuevo (insert)
        {
            SistemaPerfilFctr.InsertarSistemaPerfil(systemprofile)
                .then(function successCallback(response) {
                    $scope.nuevo();
                    $scope.sistemasperfiles = [];
                    $scope.estaCargando = false;
                }, function errorCallback(response) {
                    $scope.tieneError = true;
                    $scope.error = "Ha ocuirrido un error al insertar: " + error;
                    $scope.estaCargando = false;
                });

            //$http({
            //    method: 'POST',
            //    url: webAPIControllers + '/api/SistemaPerfil/InsertarSistemaPerfil',
            //    headers: {
            //        'Content-Type': 'application/json'
            //    },
            //    data: sistemaperfil,
            //}).then(function successCallback(result) {
            //    $scope.nuevo();
            //    $scope.sistemasperfiles = [];
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
            SistemaPerfilFctr.ActualizarSistemaPerfil(systemprofile)
                .then(function successCallback(response) {
                    $scope.nuevo();
                    $scope.sistemasperfiles = [];
                    $scope.estaCargando = false;
                }, function errorCallback(response) {
                    $scope.tieneError = true;
                    $scope.error = "Ha ocuirrido un error al actualizar: " + result;
                    $scope.estaCargando = false;
                    $scope.estaCargando = false;
                });

            //$http({
            //    method: 'PUT',
            //    url: webAPIControllers + '/api/SistemaPerfil/ActualizarSistemaPerfil/' + sistemaperfil.Id,
            //    headers: {
            //        'Content-Type': 'application/json'
            //    },
            //    data: sistemaperfil,
            //}).then(function successCallback(result) {
            //    $scope.nuevo();
            //    $scope.sistemasperfiles = [];
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