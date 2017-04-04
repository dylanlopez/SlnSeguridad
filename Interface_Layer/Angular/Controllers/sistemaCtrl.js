myApp.controller("SistemaCtrl", function ($scope, $http, webAPIControllers) {
    $scope.sistemas = [];
    $scope.estaCargando = true;
    $scope.estaEditable = false;
    $scope.tieneError = false;
    $scope.mysistema = [];

    $http({
        method: 'POST',
        url: webAPIControllers + '/api/Sistema/ListarSistemas',
    }).then(function successCallback(result) {
        $scope.sistemas = result.data;
        $scope.tieneError = false;
        $scope.error = "";
        $scope.estaCargando = false;
    }, function errorCallback(result) {
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
            $scope.mysistema.NombreServidor = "";
            $scope.mysistema.IPServidor = "";
            $scope.mysistema.RutaFisica = "";
            $scope.mysistema.RutaLogica = "";
            $scope.mysistema.Estado = "";
            $scope.mysistema.EstaActivo = false;
        }
        $scope.tieneError = false;
        $scope.error = "";
    };

    $scope.modificar = function (sistema) {
        $scope.estaEditable = !$scope.estaEditable;
        if ($scope.estaEditable == true) {
            $scope.mysistema.Id = sistema.Id;
            $scope.mysistema.Codigo = sistema.Codigo;
            $scope.mysistema.Nombre = sistema.Nombre;
            $scope.mysistema.Abreviatura = sistema.Abreviatura;
            $scope.mysistema.Descripcion = sistema.Descripcion;
            $scope.mysistema.NombreServidor = sistema.NombreServidor;
            $scope.mysistema.IPServidor = sistema.IPServidor;
            $scope.mysistema.RutaFisica = sistema.RutaFisica;
            $scope.mysistema.RutaLogica = sistema.RutaLogica;
            $scope.mysistema.Estado = sistema.Estado;
            if (sistema.Estado == 'S')
            {
                $scope.mysistema.EstaActivo = true;
            }
            else if(sistema.Estado == 'N')
            {
                $scope.mysistema.EstaActivo = false;
            }
        }
    };

    $scope.guardar = function () {
        $scope.estaCargando = true;
        if ($scope.mysistema.EstaActivo)
        {
            $scope.mysistema.Estado = "S";
        }
        else
        {
            $scope.mysistema.Estado = "N";
        }
        var system =
            {
                "Id": $scope.mysistema.Id, 
                "Codigo": $scope.mysistema.Codigo, 
                "Nombre": $scope.mysistema.Nombre, 
                "Abreviatura": $scope.mysistema.Abreviatura, 
                "Estado": $scope.mysistema.Estado, 
                "Descripcion": $scope.mysistema.Descripcion, 
                "NombreServidor": $scope.mysistema.NombreServidor, 
                "IPServidor": $scope.mysistema.IPServidor, 
                "RutaFisica": $scope.mysistema.RutaFisica, 
                "RutaLogica": $scope.mysistema.RutaLogica
            };


        if (system.Id == "") //nuevo (insert)
        {
            $http({
                method: 'POST',
                url: webAPIControllers + '/api/Sistema/InsertarSistema',
                headers: {
                    'Content-Type': 'application/json'
                },
                data: system,
            }).then(function successCallback(result) {
                $scope.nuevo();

                $http({
                    method: 'POST',
                    url: webAPIControllers + '/api/Sistema/ListarSistemas',
                }).then(function successCallback(result) {
                    $scope.sistemas = result.data;
                });
                $scope.tieneError = false;
                $scope.error = "";
                $scope.estaCargando = false;
            }, function errorCallback(result) {
                $scope.tieneError = true;
                $scope.error = "Ha ocuirrido un error al insertar: " + result;
                $scope.estaCargando = false;
            });
        }
        else //actualizar (update)
        {
            $http({
                method: 'PUT', 
                url: webAPIControllers + '/api/Sistema/ActualizarSistema/' + system.Id,
                headers: {
                    'Content-Type': 'application/json'
                },
                data: system,
            }).then(function successCallback(result) {
                $scope.nuevo();

                $http({
                    method: 'POST',
                    url: webAPIControllers + '/api/Sistema/ListarSistemas',
                }).then(function successCallback(result) {
                    $scope.sistemas = result.data;
                });
                $scope.tieneError = false;
                $scope.error = "";
                $scope.estaCargando = false;
            }, function errorCallback(result) {
                $scope.tieneError = true;
                $scope.error = "Ha ocuirrido un error al actualizar: " + result;
                $scope.estaCargando = false;
            });
        }
    };
});