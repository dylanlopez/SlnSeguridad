myApp.controller("PersonaCtrl", function ($scope, $http) {
    $scope.tiposDocumentosPersonas = [];
    $scope.personas = [];
    $scope.estaCargando = true;
    $scope.estaEditable = false;
    $scope.tieneError = false;
    $scope.myperson = [];

    $http({
        method: 'POST',
        url: '../api/TipoDocumentoPersona/ListarTipoDocumentoPersona',
    }).then(function successCallback(result) {
        $scope.tiposDocumentosPersonas = result.data;
        $scope.tieneError = false;
        $scope.error = "";
        $scope.estaCargando = false;
    }, function errorCallback(result) {
        $scope.tieneError = true;
        $scope.error = "Ha ocuirrido un error al listar: " + result;
        $scope.estaCargando = false;
    });



    
    $scope.buscar = function () {
        $scope.tieneError = false;
        $scope.error = "";

        var person =
        {
            "Id": '',
            "Nombre": $scope.nombre,
            "NumeroDocumento": '',
            "Direccion": '',
            "Telefono": '',
            "Celular": '',
            "Email": '',
            "Tipo": '',
            "Ambito": '',
            "TipoDocumentoPersona": {},
        };
        console.debug(person);

        if (!angular.isUndefined($scope.tipoDocumentoPersona)) {
            person.TipoDocumentoPersona = $scope.tipoDocumentoPersona;
        }
        $http({
            method: 'POST',
            url: '../api/Persona/ListarPersonas',
            headers: {
                'Content-Type': 'application/json'
            },
            data: person,
        }).then(function successCallback(result) {
            $scope.personas = result.data;
            $scope.estaCargando = false;
        }, function errorCallback(result) {
            $scope.tieneError = true;
            $scope.error = "Ha ocuirrido un error al listar: " + result;
            $scope.estaCargando = false;
        });
    };
    /*
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
            $scope.mymodulo.Sistema = null;
        }
        $scope.tieneError = false;
        $scope.error = "";
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
            if (modulo.Estado == 'A') {
                $scope.mymodulo.EstaActivo = true;
            }
            else if (modulo.Estado == 'I') {
                $scope.mymodulo.EstaActivo = false;
            }
            $scope.mymodulo.Sistema = modulo.Sistema;
        }
    };

    $scope.guardar = function () {
        $scope.estaCargando = true;
        if ($scope.mymodulo.EstaActivo) {
            $scope.mymodulo.Estado = "A";
        }
        else {
            $scope.mymodulo.Estado = "I";
        }
        var module =
            {
                "Id": $scope.mymodulo.Id,
                "Codigo": $scope.mymodulo.Codigo,
                "Nombre": $scope.mymodulo.Nombre,
                "Abreviatura": $scope.mymodulo.Abreviatura,
                "Descripcion": $scope.mymodulo.Descripcion,
                "Estado": $scope.mymodulo.Estado,
                "Sistema": $scope.mymodulo.Sistema
            };

        if (module.Id == "") //nuevo (insert)
        {
            $http({
                method: 'POST',
                url: '../api/Modulo/InsertarModulo',
                headers: {
                    'Content-Type': 'application/json'
                },
                data: module,
            }).then(function successCallback(result) {
                $scope.nuevo();
                $scope.modulos = [];
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
                url: '../api/Modulo/ActualizarModulo/' + module.Id,
                headers: {
                    'Content-Type': 'application/json'
                },
                data: module,
            }).then(function successCallback(result) {
                $scope.nuevo();
                $scope.modulos = [];
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
    */

});