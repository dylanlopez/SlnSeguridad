myApp.controller("SistemaCtrl", function ($scope, $http) {
    $scope.sistemas = [];
    $scope.estaCargando = true;
    $scope.estaEditable = false;
    $scope.tieneError = false;
    $scope.mysystem = [];

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
        $scope.mysystem.Id = "";
        if ($scope.estaEditable == false)
        {
            $scope.mysystem.Codigo = "";
            $scope.mysystem.Nombre = "";
            $scope.mysystem.Abreviatura = "";
            $scope.mysystem.Descripcion = "";
            $scope.mysystem.Estado = "";
            $scope.mysystem.EstaActivo = false;
            //$scope.mysystem.EstaInactivo = false;
        }
        $scope.sistemas = [];
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
            //alert($scope.mysystem);
            $scope.mysystem.Id = sistema.Id;
            $scope.mysystem.Codigo = sistema.Codigo;
            //$scope.mysystem = sistema;
            $scope.mysystem.Nombre = sistema.Nombre;
            $scope.mysystem.Abreviatura = sistema.Abreviatura;
            $scope.mysystem.Descripcion = sistema.Descripcion;
            $scope.mysystem.Estado = sistema.Estado;
            //alert($scope.mysystem.Estado);
            if (sistema.Estado == 'A')
            {
                $scope.mysystem.EstaActivo = true;
                //$scope.mysystem.EstaInactivo = false;
            }
            else if(sistema.Estado == 'I')
            {
                $scope.mysystem.EstaActivo = false;
                //$scope.mysystem.EstaInactivo = true;
            }
            //alert($scope.mysystem.EstaActivo);
            //alert($scope.mysystem.Id);
        }
    };

    $scope.guardar = function () {
        $scope.estaCargando = true;
        //var system = sistema;
        if ($scope.mysystem.EstaActivo)
        {
            $scope.mysystem.Estado = "A";
        }
        else
        {
            $scope.mysystem.Estado = "I";
        }
        //alert($scope.mysystem.Estado);
        var system =
            {
                "Id": $scope.mysystem.Id,
                "Codigo": $scope.mysystem.Codigo,
                "Nombre": $scope.mysystem.Nombre,
                "Abreviatura": $scope.mysystem.Abreviatura,
                "Descripcion": $scope.mysystem.Descripcion,
                "Estado": $scope.mysystem.Estado,
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