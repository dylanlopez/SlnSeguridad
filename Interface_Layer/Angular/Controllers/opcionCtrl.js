myApp.controller("OpcionCtrl", function ($scope, $http, webAPIControllers) {
    $scope.opciones = [];
    $scope.estaCargando = true;
    $scope.estaEditable = false;
    $scope.tieneError = false;
    $scope.myopcion = [];

    $scope.buscar = function () {
        $scope.tieneError = false;
        $scope.error = "";

        var option =
        {
            "Id": '',
            "Nombre": $scope.myopcion.Nombre,
            "NombreControlAsociado": '',
            "Descripcion": ''
        };

        $http({
            method: 'POST',
            url: webAPIControllers + '/api/Opcion/ListarOpciones',
            headers: {
                'Content-Type': 'application/json'
            },
            data: option
        }).then(function successCallback(result) {
            $scope.opciones = result.data;
            $scope.tieneError = false;
            $scope.error = "";
            $scope.estaCargando = false;
        }, function errorCallback(result) {
            $scope.tieneError = true;
            $scope.error = "Ha ocurrido un error al listar: " + result;
            $scope.estaCargando = false;
        });
    };

    $scope.nuevo = function () {
        $scope.estaEditable = !$scope.estaEditable;
        $scope.myopcion.Id = "";
        if ($scope.estaEditable == false) {
            $scope.myopcion.Nombre = "";
            $scope.myopcion.NombreControlAsociado = "";
            $scope.myopcion.Descripcion = "";
        }
        $scope.opciones = [];
        $scope.tieneError = false;
        $scope.error = "";
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
        var option =
            {
                "Id": $scope.myopcion.Id,
                "Nombre": $scope.myopcion.Nombre,
                "NombreControlAsociado": $scope.myopcion.NombreControlAsociado,
                "Descripcion": $scope.myopcion.Descripcion
            };

        if (option.Id == "") //nuevo (insert)
        {
            $http({
                method: 'POST',
                url: webAPIControllers + '/api/Opcion/InsertarOpcion',
                headers: {
                    'Content-Type': 'application/json'
                },
                data: option,
            }).then(function successCallback(result) {
                $scope.nuevo();
                $scope.opciones = [];
                $scope.tieneError = false;
                $scope.error = "";
                $scope.estaCargando = false;
            }, function errorCallback(result) {
                $scope.tieneError = true;
                $scope.error = "Ha ocurrido un error al insertar: " + result;
                $scope.estaCargando = false;
            });
        }
        else //actualizar (update)
        {
            $http({
                method: 'PUT',
                url: webAPIControllers + '/api/Opcion/ActualizarOpcion/' + option.Id,
                headers: {
                    'Content-Type': 'application/json'
                },
                data: option
            }).then(function successCallback(result) {
                $scope.nuevo();
                $scope.opciones = [];
                $scope.tieneError = false;
                $scope.error = "";
                $scope.estaCargando = false;
            }, function errorCallback(result) {
                $scope.tieneError = true;
                $scope.error = "Ha ocurrido un error al actualizar: " + result;
                $scope.estaCargando = false;
            });
        }
    };
});