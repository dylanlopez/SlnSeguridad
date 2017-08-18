myApp.controller("InstitucionCtrl", function ($scope, intitutiontype, intitution, TipoInstitucionFctr, InstitucionFctr) {
    $scope.tiposinstitucion = [];
    $scope.instituciones = [];
    $scope.estaCargando = true;
    $scope.estaEditable = false;
    $scope.tieneError = false;
    $scope.myinstitucion = [];

    intitutiontype.Activo = 'S';
    $scope.buscarTipoInstitucion = function () {
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

    $scope.buscarTipoInstitucion();

    $scope.buscar = function () {
        if (angular.isUndefined($scope.myinstitucion.TipoInstitucion) || $scope.myinstitucion.TipoInstitucion == null) {
            $scope.tieneError = true;
            $scope.error = "Debe ingresar un tipo de institución para ver sus instituciones";
        }
        else {
            $scope.error = "";
            $scope.tieneError = false;
            $scope.estaCargando = true;

            intitution.Nombre = $scope.myinstitucion.Nombre;
            intitution.TipoInstitucion = $scope.myinstitucion.TipoInstitucion;

            InstitucionFctr.ListarInstitucion(intitution)
                .then(function successCallback(response) {
                    $scope.instituciones = response;
                    $scope.estaCargando = false;
                }, function errorCallback(response) {
                    $scope.tieneError = true;
                    $scope.error = "Ha ocurrido un error al listar: " + response;
                    $scope.estaCargando = false;
                });
        }
    };

    $scope.nuevo = function () {
        $scope.estaEditable = !$scope.estaEditable;
        $scope.myinstitucion.Id = "";
        if ($scope.estaEditable == false) {
            $scope.myinstitucion.Nombre = "";
            $scope.myinstitucion.NombreCorto = "";
            $scope.myinstitucion.Activo = "";
            $scope.myinstitucion.EstaActivo = false;
            $scope.myinstitucion.Direccion = "";
            $scope.myinstitucion.TipoInstitucion = null;
        }
        InstitucionFctr.CleanInstitucion(intitution);
        $scope.instituciones = [];
        $scope.tieneError = false;
        $scope.error = "";
    };

    $scope.modificar = function (institucion) {
        console.debug(institucion);
        $scope.estaEditable = !$scope.estaEditable;
        if ($scope.estaEditable == true) {
            $scope.myinstitucion.Id = institucion.Id;
            $scope.myinstitucion.Nombre = institucion.Nombre;
            $scope.myinstitucion.NombreCorto = institucion.NombreCorto;
            $scope.myinstitucion.Activo = institucion.Activo;
            if (institucion.Activo == 'S') {
                $scope.myinstitucion.EstaActivo = true;
            }
            else if (institucion.Activo == 'N') {
                $scope.myinstitucion.EstaActivo = false;
            }
            $scope.myinstitucion.Direccion = institucion.Direccion;
            $scope.myinstitucion.TipoInstitucion = institucion.TipoInstitucion;
        }
    };

    $scope.guardar = function () {
        $scope.estaCargando = true;
        if ($scope.myinstitucion.EstaActivo) {
            $scope.myinstitucion.Activo = "S";
        }
        else {
            $scope.myinstitucion.Activo = "N";
        }
        intitution.Id = $scope.myinstitucion.Id;
        intitution.Nombre = $scope.myinstitucion.Nombre;
        intitution.NombreCorto = $scope.myinstitucion.NombreCorto;
        intitution.Activo = $scope.myinstitucion.Activo;
        intitution.Direccion = $scope.myinstitucion.Direccion;
        intitution.TipoInstitucion = $scope.myinstitucion.TipoInstitucion;
        if (intitution.Id == "") //nuevo (insert)
        {
            InstitucionFctr.InsertarInstitucion(intitution)
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
            InstitucionFctr.ActualizarInstitucion(intitution)
                .then(function successCallback(response) {
                    $scope.nuevo();
                    $scope.tieneError = false;
                    $scope.error = "";
                    $scope.estaCargando = false;
                }, function errorCallback(response) {
                    $scope.tieneError = true;
                    $scope.error = "Ha ocurrido un error al actualizar: " + response.data.Message;
                    $scope.estaCargando = false;
                    $scope.estaCargando = false;
                });
        }
    };
});