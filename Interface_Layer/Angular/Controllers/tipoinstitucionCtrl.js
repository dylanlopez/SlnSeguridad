myApp.controller("TipoInstitucionCtrl", function ($scope, intitutiontype, TipoInstitucionFctr) {
    $scope.tiposinstitucion = [];
    $scope.estaCargando = true;
    $scope.estaEditable = false;
    $scope.tieneError = false;
    $scope.mytipoinstitucion = [];

    $scope.buscar = function () {
        $scope.estaCargando = true;

        console.debug($scope.mytipoinstitucion);
        intitutiontype.Nombre = $scope.mytipoinstitucion.Nombre;

        TipoInstitucionFctr.ListarTipoInstitucion(intitutiontype)
            .then(function successCallback(response) {
                $scope.tiposinstitucion = response;
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
        $scope.mytipoinstitucion.Id = "";
        if ($scope.estaEditable == false) {
            $scope.mytipoinstitucion.Nombre = "";
            $scope.mytipoinstitucion.Activo = "";
            $scope.mytipoinstitucion.EstaActivo = false;
            $scope.mytipoinstitucion.Descripcion = "";
            TipoInstitucionFctr.CleanTipoInstitucion(intitutiontype);
        }
        $scope.tiposinstitucion = [];
        $scope.tieneError = false;
        $scope.error = "";
    };

    $scope.modificar = function (instituciontipo) {
        $scope.estaEditable = !$scope.estaEditable;
        if ($scope.estaEditable == true) {
            $scope.mytipoinstitucion.Id = instituciontipo.Id;
            $scope.mytipoinstitucion.Nombre = instituciontipo.Nombre;
            $scope.mytipoinstitucion.Activo = instituciontipo.Activo;
            if (instituciontipo.Activo == 'S') {
                $scope.mytipoinstitucion.EstaActivo = true;
            }
            else if (instituciontipo.Activo == 'N') {
                $scope.mytipoinstitucion.EstaActivo = false;
            }
            $scope.mytipoinstitucion.Descripcion = instituciontipo.Descripcion;
        }
    };

    $scope.guardar = function () {
        $scope.estaCargando = true;
        if ($scope.mytipoinstitucion.EstaActivo) {
            $scope.mytipoinstitucion.Activo = "S";
        }
        else {
            $scope.mytipoinstitucion.Activo = "N";
        }
        intitutiontype.Id = $scope.mytipoinstitucion.Id;
        intitutiontype.Nombre = $scope.mytipoinstitucion.Nombre;
        intitutiontype.Activo = $scope.mytipoinstitucion.Activo;
        intitutiontype.Descripcion = $scope.mytipoinstitucion.Descripcion;
        if (intitutiontype.Id == "") //nuevo (insert)
        {
            TipoInstitucionFctr.InsertarTipoInstitucion(intitutiontype)
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
        }
        else //actualizar (update)
        {
            TipoInstitucionFctr.ActualizarTipoInstitucion(intitutiontype)
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
        }
    };
});