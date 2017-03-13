myApp.controller("SistemaCtrl", function ($scope, $http) {
    $scope.sistemas = [];
    $scope.estaCargando = true;
    $scope.estaEditable = false;
    $scope.tieneError = false;
    $scope.mysistema = [];

    $http({
        method: 'POST',
        url: '../api/Sistema/ListarSistemas',
    }).then(function successCallback(result) {
        //console.log(result.data);
        $scope.sistemas = result.data;
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
        $scope.mysistema.Id = "";
        if ($scope.estaEditable == false)
        {
            $scope.mysistema.Codigo = "";
            $scope.mysistema.Nombre = "";
            $scope.mysistema.Abreviatura = "";
            $scope.mysistema.Descripcion = "";
            $scope.mysistema.Estado = "";
            $scope.mysistema.EstaActivo = false;
            //$scope.mysistema.EstaInactivo = false;
        }
        $scope.tieneError = false;
        $scope.error = "";
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
            //alert($scope.mysistema.Estado);
            if (sistema.Estado == 'A')
            {
                $scope.mysistema.EstaActivo = true;
                //$scope.mysistema.EstaInactivo = false;
            }
            else if(sistema.Estado == 'I')
            {
                $scope.mysistema.EstaActivo = false;
                //$scope.mysistema.EstaInactivo = true;
            }
            //alert($scope.mysistema.EstaActivo);
            //alert($scope.mysistema.Id);
        }
    };

    $scope.guardar = function () {
        $scope.estaCargando = true;
        //var system = sistema;
        if ($scope.mysistema.EstaActivo)
        {
            $scope.mysistema.Estado = "A";
        }
        else
        {
            $scope.mysistema.Estado = "I";
        }
        //alert($scope.mysistema.Estado);
        var system =
            {
                "Id": $scope.mysistema.Id,
                "Codigo": $scope.mysistema.Codigo,
                "Nombre": $scope.mysistema.Nombre,
                "Abreviatura": $scope.mysistema.Abreviatura,
                "Descripcion": $scope.mysistema.Descripcion,
                "Estado": $scope.mysistema.Estado,
            };


        if (system.Id == "") //nuevo (insert)
        {
            $http({
                method: 'POST',
                url: '../api/Sistema/InsertarSistema',
                //headers: {
                //    'Content-Type': 'application/json'
                //},
                data: system,
            }).then(function successCallback(result) {
                $scope.nuevo();
                $http({
                    method: 'POST',
                    url: '../api/Sistema/ListarSistemas',
                }).then(function successCallback(result) {
                    $scope.sistemas = result.data;
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
                url: '../api/Sistema/ActualizarSistema/' + system.Id,
                //url: '../api/Sistema/ActualizarSistema',
                //headers: {
                //    'Content-Type': 'application/json'
                //},
                data: system,
            }).then(function successCallback(result) {
                $scope.nuevo();

                $http({
                    method: 'POST',
                    url: '../api/Sistema/ListarSistemas',
                }).then(function successCallback(result) {
                    $scope.sistemas = result.data;
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