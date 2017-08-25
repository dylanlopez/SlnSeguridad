//myApp.controller("ModuloCtrl", function ($scope, $http, webAPIControllers) {
myApp.controller("ModuloCtrl", function ($scope, system, module, SistemaFctr, ModuloFctr) {
    $scope.sistemas = [];
    $scope.modulos = [];
    $scope.estaCargando = false;
    $scope.estaEditable = false;
    $scope.tieneError = false;
    $scope.mymodulo = [];

    //var system =
    //    {
    //        "Id": '',
    //        "Codigo": '',
    //        "Nombre": '',
    //        "Abreviatura": '',
    //        "Estado": '',
    //        "Descripcion": '',
    //        "NombreServidor": '',
    //        "IPServidor": '',
    //        "RutaFisica": '',
    //        "RutaLogica": ''
    //    };

    system.Activo = 'S';
    $scope.listarSistemas = function () {
        $scope.tipoError = "";
        $scope.error = "";
        $scope.tieneError = false;
        SistemaFctr.ListarSistemas(system)
            .then(function successCallback(response) {
                $scope.sistemas = response;
                //$scope.estaCargando = false;
            }, function errorCallback(response) {
                $scope.tipoError = "alert alert-danger";
                $scope.error = "Ha ocurrido un error al listar: " + response;
                $scope.tieneError = true;
                //$scope.estaCargando = false;
            });
        };
    $scope.listarSistemas();

    //$http({
    //    method: 'POST',
    //    url: webAPIControllers + '/api/Sistema/ListarSistemas',
    //    headers: {
    //        'Content-Type': 'application/json'
    //    },
    //    data: system
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

    $scope.setearSistema = function () {
        if (!angular.isUndefined($scope.mymodulo.Sistema) && $scope.mymodulo.Sistema != null) {
            $scope.mymodulo.Codigo = $scope.mymodulo.Sistema.Codigo;
        }
    };

    $scope.buscar = function () {
        if (angular.isUndefined($scope.mymodulo.Sistema) || $scope.mymodulo.Sistema == null) {
            $scope.tipoError = "alert alert-warning";
            $scope.error = "Debe ingresar un sistema para poder ver sus módulos";
            $scope.tieneError = true;
        }
        else {
            $scope.tipoError = "";
            $scope.error = "";
            $scope.tieneError = false;
            $scope.estaCargando = true;
            //var module =
            //{
            //    "Id": '',
            //    "Codigo": '',
            //    "Nombre": $scope.mymodulo.Nombre,
            //    "Abreviatura": '',
            //    "Estado": '',
            //    "Descripcion": '',
            //    "Sistema": $scope.mymodulo.Sistema,
            //};
            module.Nombre = $scope.mymodulo.Nombre;
            module.Sistema = $scope.mymodulo.Sistema;
            ModuloFctr.ListarModulos(module)
                .then(function successCallback(response) {
                    $scope.modulos = response;
                    $scope.estaCargando = false;
                }, function errorCallback(response) {
                    $scope.estaCargando = false;
                    $scope.tipoError = "alert alert-danger";
                    $scope.error = "Ha ocurrido un error al listar: " + response;
                    $scope.tieneError = true;
                });

            //$http({
            //    method: 'POST',
            //    url: webAPIControllers + '/api/Modulo/ListarModulos',
            //    headers: {
            //        'Content-Type': 'application/json'
            //    },
            //    data: module,
            //}).then(function successCallback(result) {
            //    $scope.modulos = result.data;
            //    $scope.estaCargando = false;
            //}, function errorCallback(result) {
            //    $scope.tieneError = true;
            //    $scope.error = "Ha ocuirrido un error al listar: " + result;
            //    $scope.estaCargando = false;
            //});
        }
    };

    $scope.nuevo = function () {
        $scope.estaEditable = !$scope.estaEditable;
        $scope.mymodulo.Id = "";
        if ($scope.estaEditable == false) {
            $scope.mymodulo.Codigo = "";
            $scope.mymodulo.Nombre = "";
            $scope.mymodulo.Abreviatura = "";
            $scope.mymodulo.Activo = "";
            $scope.mymodulo.EstaActivo = false;
            $scope.mymodulo.Descripcion = "";
            $scope.mymodulo.Sistema = null;
            //module.Id = null;
            //module.Codigo = null;
            //module.Nombre = null;
            //module.Abreviatura = null;
            //module.Activo = null;
            //module.Descripcion = null;
            //module.Sistema = null;
        }
        ModuloFctr.CleanModulo(module);
        $scope.modulos = [];
        $scope.tipoError = "";
        $scope.error = "";
        $scope.tieneError = false;
    };

    $scope.modificar = function (modulo) {
        $scope.estaEditable = !$scope.estaEditable;
        if ($scope.estaEditable == true) {
            $scope.mymodulo.Id = modulo.Id;
            $scope.mymodulo.Codigo = modulo.Codigo;
            $scope.mymodulo.Nombre = modulo.Nombre;
            $scope.mymodulo.Abreviatura = modulo.Abreviatura;
            $scope.mymodulo.Activo = modulo.Activo;
            if (modulo.Activo == 'S') {
                $scope.mymodulo.EstaActivo = true;
            }
            else if (modulo.Activo == 'N') {
                $scope.mymodulo.EstaActivo = false;
            }
            $scope.mymodulo.Descripcion = modulo.Descripcion;
            $scope.mymodulo.Sistema = modulo.Sistema;
        }
    };

    $scope.guardar = function () {
        if ($scope.mymodulo.EstaActivo) {
            $scope.mymodulo.Activo = "S";
        }
        else {
            $scope.mymodulo.Activo = "N";
        }
        $scope.estaCargando = true;
        $scope.tipoError = "";
        $scope.error = "";
        $scope.tieneError = false;

        //var module =
        //    {
        //        "Id": $scope.mymodulo.Id,
        //        "Codigo": $scope.mymodulo.Codigo,
        //        "Nombre": $scope.mymodulo.Nombre,
        //        "Abreviatura": $scope.mymodulo.Abreviatura,
        //        "Estado": $scope.mymodulo.Estado,
        //        "Descripcion": $scope.mymodulo.Descripcion,
        //        "Sistema": $scope.mymodulo.Sistema
        //    };
        module.Id = $scope.mymodulo.Id;
        module.Codigo = $scope.mymodulo.Codigo;
        module.Nombre = $scope.mymodulo.Nombre;
        module.Abreviatura = $scope.mymodulo.Abreviatura;
        module.Activo = $scope.mymodulo.Activo;
        module.Descripcion = $scope.mymodulo.Descripcion;
        module.Sistema = $scope.mymodulo.Sistema;
        if (module.Id == "") //nuevo (insert)
        {
            ModuloFctr.InsertarModulo(module)
                .then(function successCallback(response) {
                    $scope.nuevo();
                    //$scope.modulos = [];
                    //$scope.tieneError = false;
                    //$scope.error = "";
                    $scope.estaCargando = false;
                }, function errorCallback(response) {
                    $scope.tipoError = "alert alert-danger";
                    $scope.error = "Ha ocurrido un error al insertar: " + response.data.Message;
                    $scope.tieneError = true;
                    $scope.estaCargando = false;
                });
            //$http({
            //    method: 'POST',
            //    url: webAPIControllers + '/api/Modulo/InsertarModulo',
            //    headers: {
            //        'Content-Type': 'application/json'
            //    },
            //    data: module,
            //}).then(function successCallback(result) {
            //    $scope.nuevo();
            //    $scope.modulos = [];
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
            ModuloFctr.ActualizarModulo(module)
                .then(function successCallback(response) {
                    $scope.nuevo();
                    //$scope.modulos = [];
                    //$scope.tieneError = false;
                    //$scope.error = "";
                    //$scope.estaCargando = false;
                }, function errorCallback(response) {
                    $scope.tipoError = "alert alert-danger";
                    $scope.error = "Ha ocurrido un error al actualizar: " + response.data.Message;
                    $scope.tieneError = true;
                    $scope.estaCargando = false;
                });
            //$http({
            //    method: 'PUT',
            //    url: webAPIControllers + '/api/Modulo/ActualizarModulo/' + module.Id,
            //    headers: {
            //        'Content-Type': 'application/json'
            //    },
            //    data: module,
            //}).then(function successCallback(result) {
            //    $scope.nuevo();
            //    $scope.modulos = [];
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