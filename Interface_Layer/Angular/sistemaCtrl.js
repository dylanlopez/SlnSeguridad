myApp.controller("SistemaCtrl", function ($scope, $http) {
    $scope.sistemas = [];
    //$scope.operation = '';
    $scope.estaCargando = true;
    $scope.estaEditable = false;
    $scope.mysistema = [];

    $http({
        method: 'POST',
        url: '../api/Sistema/ListarSistemas',
    }).then(function successCallback(result) {
        //console.log(result.data);
        $scope.sistemas = result.data;
        $scope.estaCargando = false;
    }, function errorCallback(result) {
        console.error(result);
        $scope.estaCargando = false;
    });

    $scope.nuevo = function () {
        $scope.estaEditable = !$scope.estaEditable;
        $scope.mysistema.Id = "";
        if ($scope.estaEditable == false)
        {
            $scope.mysistema.Codigo = "";
            $scope.mysistema.Nombre = "";
            $scope.mysistema.Abreviatura = "";
            $scope.mysistema.Descripcion = "";
            $scope.mysistema.Estado = "";
        }
    };

    $scope.modificar = function (sistema) {
        //alert(p1);
        //console.log(sistema);
        $scope.estaEditable = !$scope.estaEditable;
        //alert($scope.addMode);
        if ($scope.estaEditable == true) {
            //alert(sistema.Codigo);
            //alert($scope.mysistema);
            $scope.mysistema.Id = sistema.Id;
            $scope.mysistema.Codigo = sistema.Codigo;
            //$scope.mysistema = sistema;
            $scope.mysistema.Nombre = sistema.Nombre;
            $scope.mysistema.Abreviatura = sistema.Abreviatura;
            $scope.mysistema.Descripcion = sistema.Descripcion;
            $scope.mysistema.Estado = sistema.Estado;
            //alert($scope.mysistema.Id);
        }
    };

    $scope.guardar = function () {
        $scope.estaCargando = true;
        //var system = sistema;
        var system =
            {
                "Id": $scope.mysistema.Id,
                "Codigo": $scope.mysistema.Codigo,
                "Nombre": $scope.mysistema.Nombre,
                "Abreviatura": $scope.mysistema.Abreviatura,
                "Descripcion": $scope.mysistema.Descripcion,
                "Estado": $scope.mysistema.Estado,
            };


        if (system.Id == "")
        {
            //alert("nuevo");

            $http({
                method: 'POST',
                url: '../api/Sistema/InsertarSistema',
                data: system,
            }).then(function successCallback(result) {
                $scope.nuevo();

                $http({
                    method: 'POST',
                    url: '../api/Sistema/ListarSistemas',
                }).then(function successCallback(result) {
                    $scope.sistemas = result.data;
                }, function errorCallback(result) {
                    console.error(result);
                });

                $scope.estaCargando = false;
            }, function errorCallback(result) {
                console.error(result);
                $scope.estaCargando = false;
            });
        }
        else
        {
            //alert("modificar");
            //alert(system);
            //alert(system.Id);
            //alert(system.Nombre);
            //alert(system.Abreviatura);

            $http({
                method: 'PUT', 
                url: '../api/Sistema/ActualizarSistema/' + system.Id, 
                data: system,
            }).then(function successCallback(result) {
                $scope.nuevo();

                $http({
                    method: 'POST',
                    url: '../api/Sistema/ListarSistemas',
                }).then(function successCallback(result) {
                    $scope.sistemas = result.data;
                }, function errorCallback(result) {
                    console.error(result);
                });

                $scope.estaCargando = false;
            }, function errorCallback(result) {
                console.error(result);
                $scope.estaCargando = false;
            });
        }
    };
});