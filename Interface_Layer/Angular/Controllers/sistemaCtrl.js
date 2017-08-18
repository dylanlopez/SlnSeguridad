//myApp.controller("SistemaCtrl", function ($scope, $http, webAPIControllers) {
myApp.controller("SistemaCtrl", function ($scope, system, SistemaFctr) {
    $scope.sistemas = [];
    $scope.estaCargando = true;
    $scope.estaEditable = false;
    $scope.tieneError = false;
    $scope.mysistema = [];
    //var system =
    //{
    //    "Id": '',
    //    "Codigo": '',
    //    "Nombre": '',
    //    "Abreviatura": '',
    //    "Estado": '',
    //    "Descripcion": '',
    //    "NombreServidor": '',
    //    "IPServidor": '',
    //    "RutaFisica": '',
    //    "RutaLogica": ''
    //};

    //return $http.get(serviceBasePath + '/api/data/authenticate').then(function (response) {
    //    return response.data;
    //});

    $scope.buscar = function () {
        $scope.estaCargando = true;

        //var system =
        //{
        //    "Id": '',
        //    "Codigo": '',
        //    "Nombre": $scope.mysistema.Nombre,
        //    "Abreviatura": '',
        //    "Estado": '',
        //    "Descripcion": '',
        //    "NombreServidor": '',
        //    "IPServidor": '',
        //    "RutaFisica": '',
        //    "RutaLogica": ''
        //};
        system.Nombre = $scope.mysistema.Nombre;

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

        SistemaFctr.ListarSistemas(system)
            .then(function successCallback(response) {
                $scope.sistemas = response;
                $scope.tieneError = false;
                $scope.error = "";
                $scope.estaCargando = false;
            }, function errorCallback(response) {
                $scope.tieneError = true;
                $scope.error = "Ha ocurrido un error al listar: " + response;
                $scope.estaCargando = false;
            });
    };

    $scope.nuevo = function () {
        $scope.estaEditable = !$scope.estaEditable;
        $scope.mysistema.Id = "";
        if ($scope.estaEditable == false)
        {
            $scope.mysistema.Codigo = "";
            $scope.mysistema.Nombre = "";
            $scope.mysistema.Abreviatura = "";
            $scope.mysistema.Activo = "";
            $scope.mysistema.EstaActivo = false;
            $scope.mysistema.Descripcion = "";
            $scope.mysistema.NombreServidor = "";
            $scope.mysistema.IPServidor = "";
            $scope.mysistema.RutaFisica = "";
            $scope.mysistema.RutaLogica = "";
            SistemaFctr.CleanSistema(system);
            //system.Id = null;
            //system.Codigo = null;
            //system.Nombre = null;
            //system.Abreviatura = null;
            //system.Activo = null;
            //system.Descripcion = null;
            //system.NombreServidor = null;
            //system.IPServidor = null;
            //system.RutaFisica = null;
            //system.RutaLogica = null;
        }
        $scope.sistemas = [];
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
            $scope.mysistema.Activo = sistema.Activo;
            if (sistema.Activo == 'S') {
                $scope.mysistema.EstaActivo = true;
            }
            else if (sistema.Activo == 'N') {
                $scope.mysistema.EstaActivo = false;
            }
            $scope.mysistema.Descripcion = sistema.Descripcion;
            $scope.mysistema.NombreServidor = sistema.NombreServidor;
            $scope.mysistema.IPServidor = sistema.IPServidor;
            $scope.mysistema.RutaFisica = sistema.RutaFisica;
            $scope.mysistema.RutaLogica = sistema.RutaLogica;
        }
    };

    $scope.guardar = function () {
        $scope.estaCargando = true;
        if ($scope.mysistema.EstaActivo)
        {
            $scope.mysistema.Activo = "S";
        }
        else
        {
            $scope.mysistema.Activo = "N";
        }
        //var system =
        //    {
        //        "Id": $scope.mysistema.Id, 
        //        "Codigo": $scope.mysistema.Codigo, 
        //        "Nombre": $scope.mysistema.Nombre, 
        //        "Abreviatura": $scope.mysistema.Abreviatura, 
        //        "Estado": $scope.mysistema.Estado, 
        //        "Descripcion": $scope.mysistema.Descripcion, 
        //        "NombreServidor": $scope.mysistema.NombreServidor, 
        //        "IPServidor": $scope.mysistema.IPServidor, 
        //        "RutaFisica": $scope.mysistema.RutaFisica, 
        //        "RutaLogica": $scope.mysistema.RutaLogica
        //    };
        system.Id = $scope.mysistema.Id;
        system.Codigo = $scope.mysistema.Codigo;
        system.Nombre = $scope.mysistema.Nombre;
        system.Abreviatura = $scope.mysistema.Abreviatura;
        system.Activo = $scope.mysistema.Activo;
        system.Descripcion = $scope.mysistema.Descripcion;
        system.NombreServidor = $scope.mysistema.NombreServidor;
        system.IPServidor = $scope.mysistema.IPServidor;
        system.RutaFisica = $scope.mysistema.RutaFisica;
        system.RutaLogica = $scope.mysistema.RutaLogica;
        if (system.Id == "") //nuevo (insert)
        {
            SistemaFctr.InsertarSistema(system)
                .then(function successCallback(response) {
                    $scope.nuevo();
                    $scope.tieneError = false;
                    $scope.error = "";
                    $scope.estaCargando = false;
                }, function errorCallback(response) {
                    $scope.tieneError = true;
                    $scope.error = "Ha ocurrido un error al insertar: " + response.data.Message;
                    $scope.estaCargando = false;
                });

            //$http({
            //    method: 'POST',
            //    url: webAPIControllers + '/api/Sistema/InsertarSistema',
            //    headers: {
            //        'Content-Type': 'application/json'
            //    },
            //    data: system,
            //}).then(function successCallback(result) {
            //    $scope.nuevo();
            //    //$http({
            //    //    method: 'POST',
            //    //    url: webAPIControllers + '/api/Sistema/ListarSistemas',
            //    //}).then(function successCallback(result) {
            //    //    $scope.sistemas = result.data;
            //    //});
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
            SistemaFctr.ActualizarSistema(system)
                .then(function successCallback(response) {
                    $scope.nuevo();
                    $scope.tieneError = false;
                    $scope.error = "";
                    $scope.estaCargando = false;
                }, function errorCallback(response) {
                    $scope.tieneError = true;
                    $scope.error = "Ha ocurrido un error al actualizar: " + response.data.Message;
                    $scope.estaCargando = false;
                });

            //$http({
            //    method: 'PUT', 
            //    url: webAPIControllers + '/api/Sistema/ActualizarSistema/' + system.Id,
            //    headers: {
            //        'Content-Type': 'application/json'
            //    },
            //    data: system,
            //}).then(function successCallback(result) {
            //    $scope.nuevo();
            //    //$http({
            //    //    method: 'POST',
            //    //    url: webAPIControllers + '/api/Sistema/ListarSistemas',
            //    //}).then(function successCallback(result) {
            //    //    $scope.sistemas = result.data;
            //    //});
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