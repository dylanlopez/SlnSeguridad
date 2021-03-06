﻿//myApp.controller("OpcionCtrl", function ($scope, $http, webAPIControllers) {
myApp.controller("OpcionCtrl", function ($scope, option, OpcionFctr) {
    $scope.opciones = [];
    $scope.estaCargando = false;
    $scope.estaEditable = false;
    $scope.tieneError = false;
    $scope.myopcion = [];

    $scope.buscar = function () {
        $scope.estaCargando = true;
        $scope.tipoError = "";
        $scope.error = "";
        $scope.tieneError = false;

        //var option =
        //{
        //    "Id": '',
        //    "Nombre": $scope.myopcion.Nombre,
        //    "NombreControlAsociado": '',
        //    "Descripcion": ''
        //};

        //$http({
        //    method: 'POST',
        //    url: webAPIControllers + '/api/Opcion/ListarOpciones',
        //    headers: {
        //        'Content-Type': 'application/json'
        //    },
        //    data: option
        //}).then(function successCallback(result) {
        //    $scope.opciones = result.data;
        //    $scope.tieneError = false;
        //    $scope.error = "";
        //    $scope.estaCargando = false;
        //}, function errorCallback(result) {
        //    $scope.tieneError = true;
        //    $scope.error = "Ha ocurrido un error al listar: " + result;
        //    $scope.estaCargando = false;
        //});

        option.Nombre = $scope.myopcion.Nombre;

        OpcionFctr.ListarOpciones(option)
            .then(function successCallback(response) {
                $scope.opciones = response;
                //$scope.tieneError = false;
                //$scope.error = "";
                $scope.estaCargando = false;
            }, function errorCallback(response) {
                $scope.estaCargando = false;
                $scope.tipoError = "alert alert-danger";
                $scope.error = "Ha ocurrido un error al listar: " + response;
                $scope.tieneError = true;
            });
    };

    $scope.nuevo = function () {
        $scope.estaEditable = !$scope.estaEditable;
        $scope.myopcion.Id = "";
        if ($scope.estaEditable == false) {
            $scope.myopcion.Nombre = "";
            $scope.myopcion.NombreControlAsociado = "";
            $scope.myopcion.Descripcion = "";
            OpcionFctr.CleanOpcion(option);
        }
        $scope.opciones = [];
        $scope.error = "";
        $scope.tipoError = "";
        $scope.tieneError = false;
    };

    $scope.modificar = function (option) {
        $scope.estaEditable = !$scope.estaEditable;
        if ($scope.estaEditable == true) {
            $scope.myopcion.Id = option.Id;
            $scope.myopcion.Nombre = option.Nombre;
            $scope.myopcion.NombreControlAsociado = option.NombreControlAsociado;
            $scope.myopcion.Descripcion = option.Descripcion;
        }
    };

    $scope.guardar = function () {
        $scope.estaCargando = true;
        //var option =
        //    {
        //        "Id": $scope.myopcion.Id,
        //        "Nombre": $scope.myopcion.Nombre,
        //        "NombreControlAsociado": $scope.myopcion.NombreControlAsociado,
        //        "Descripcion": $scope.myopcion.Descripcion
        //    };
        $scope.tipoError = "";
        $scope.error = "";
        $scope.tieneError = false;

        option.Id = $scope.myopcion.Id;
        option.Nombre = $scope.myopcion.Nombre;
        option.NombreControlAsociado = $scope.myopcion.NombreControlAsociado;
        option.Descripcion = $scope.myopcion.Descripcion;
        if (option.Id == "") //nuevo (insert)
        {
            OpcionFctr.InsertarOpcion(option)
                .then(function successCallback(response) {
                    $scope.nuevo();
                    //$scope.tieneError = false;
                    //$scope.error = "";
                    $scope.estaCargando = false;
                }, function errorCallback(response) {
                    $scope.estaCargando = false;
                    $scope.tipoError = "alert alert-danger";
                    $scope.error = "Ha ocurrido un error al insertar: " + response.data.Message;
                    $scope.tieneError = true;
                });
            //$http({
            //    method: 'POST',
            //    url: webAPIControllers + '/api/Opcion/InsertarOpcion',
            //    headers: {
            //        'Content-Type': 'application/json'
            //    },
            //    data: option,
            //}).then(function successCallback(result) {
            //    $scope.nuevo();
            //    $scope.opciones = [];
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
            OpcionFctr.ActualizarOpcion(option)
                .then(function successCallback(response) {
                    $scope.nuevo();
                    //$scope.tieneError = false;
                    //$scope.error = "";
                    $scope.estaCargando = false;
                }, function errorCallback(response) {
                    $scope.estaCargando = false;
                    $scope.tipoError = "alert alert-danger";
                    $scope.error = "Ha ocurrido un error al actualizar: " + response.data.Message;
                    $scope.tieneError = true;
                });
            //$http({
            //    method: 'PUT',
            //    url: webAPIControllers + '/api/Opcion/ActualizarOpcion/' + option.Id,
            //    headers: {
            //        'Content-Type': 'application/json'
            //    },
            //    data: option
            //}).then(function successCallback(result) {
            //    $scope.nuevo();
            //    $scope.opciones = [];
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
});