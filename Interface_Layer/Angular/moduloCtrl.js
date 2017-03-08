myApp.controller("ModuloCtrl", function ($scope, $http) {
    $scope.sistemas = [];
    $scope.modulos = [];
    $scope.estaCargando = true;
    $scope.estaEditable = false;
    $scope.mymodulo = [];

    $http({
        method: 'POST',
        url: '../api/Sistema/ListarSistemas',
    }).then(function successCallback(result) {
        console.log(result.data);
        $scope.sistemas = result.data;
        //$scope.selectedSistema = $scope.sistemas[1];
        $scope.estaCargando = false;
    }, function errorCallback(result) {
        //console.error(result);
        $scope.error = "Ha ocuirrido un error al listar: " + result;
        $scope.estaCargando = false;
    });

    $scope.buscar = function () {
        console.log($scope.sistema);
        var system =
            {
                "Id": $scope.sistema.Id,
                "Codigo": $scope.sistema.Codigo,
                "Nombre": $scope.sistema.Nombre,
                "Abreviatura": $scope.sistema.Abreviatura,
                "Descripcion": $scope.sistema.Descripcion,
                "Estado": $scope.sistema.Estado,
            };

        $http({
            method: 'POST',
            url: '../api/Modulo/ListarModulos',
            data: system,
        }).then(function successCallback(result) {
            //console.log(result.data);
            $scope.modulos = result.data;
            $scope.estaCargando = false;
        }, function errorCallback(result) {
            $scope.error = "Ha ocuirrido un error al listar: " + result;
            $scope.estaCargando = false;
        });
    };

    $scope.nuevo = function () {
        $scope.estaEditable = !$scope.estaEditable;
        $scope.mymodulo.Id = "";
        if ($scope.estaEditable == false) {
            $scope.mymodulo.Codigo = "";
            $scope.mymodulo.Nombre = "";
            $scope.mymodulo.Abreviatura = "";
            $scope.mymodulo.Descripcion = "";
            $scope.mymodulo.Estado = "";
            $scope.mymodulo.EstaActivo = false;
        }
    };

    $scope.modificar = function (modulo) {
        $scope.estaEditable = !$scope.estaEditable;
        if ($scope.estaEditable == true) {
            $scope.mymodulo.Id = modulo.Id;
            $scope.mymodulo.Codigo = modulo.Codigo;
            $scope.mymodulo.Nombre = modulo.Nombre;
            $scope.mymodulo.Abreviatura = modulo.Abreviatura;
            $scope.mymodulo.Descripcion = modulo.Descripcion;
            $scope.mymodulo.Estado = modulo.Estado;
            if (sistema.Estado == 'A') {
                $scope.mymodulo.EstaActivo = true;
            }
            else if (sistema.Estado == 'I') {
                $scope.mymodulo.EstaActivo = false;
            }


            //alert($scope.mymodulo.EstaActivo);
            //alert($scope.mysistema.Id);
        }
    };

    $scope.guardar = function () {
        $scope.estaCargando = true;
        //var system = sistema;
        if ($scope.mymodulo.EstaActivo) {
            $scope.mymodulo.Estado = "A";
        }
        else {
            $scope.mymodulo.Estado = "I";
        }
        alert($scope.mymodulo.Estado);
        var system =
            {
                "Id": $scope.mymodulo.Id,
                "Codigo": $scope.mymodulo.Codigo,
                "Nombre": $scope.mymodulo.Nombre,
                "Abreviatura": $scope.mymodulo.Abreviatura,
                "Descripcion": $scope.mymodulo.Descripcion,
                "Estado": $scope.mymodulo.Estado,
            };


        if (system.Id == "") //nuevo (insert)
        {
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
                    $scope.modulos = result.data;
                });

                $scope.estaCargando = false;
            }, function errorCallback(result) {
                //console.error(result);
                $scope.error = "Ha ocuirrido un error al insertar: " + result;
                $scope.estaCargando = false;
            });
        }
        else //actualizar (update)
        {
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
                    $scope.modulos = result.data;
                });
                $scope.estaCargando = false;
            }, function errorCallback(result) {
                //console.error(result);
                $scope.error = "Ha ocuirrido un error al actualizar: " + result;
                $scope.estaCargando = false;
            });
        }
    };
});