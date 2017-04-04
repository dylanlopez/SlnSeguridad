myApp.controller("PersonaCtrl", function ($scope, $http, webAPIControllers) {
    $scope.tiposDocumentosPersonas = [];
    $scope.personas = [];
    $scope.estaCargando = true;
    $scope.estaEditable = false;
    $scope.tieneError = false;
    $scope.myperson = [];

    $http({
        method: 'POST',
        url: webAPIControllers + '/api/TipoDocumentoPersona/ListarTipoDocumentoPersona',
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
        //console.debug(person);

        if (!angular.isUndefined($scope.tipoDocumentoPersona)) {
            person.TipoDocumentoPersona = $scope.tipoDocumentoPersona;
        }
        $http({
            method: 'POST',
            url: webAPIControllers + '/api/Persona/ListarPersonas',
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
    
    $scope.nuevo = function () {
        $scope.estaEditable = !$scope.estaEditable;
        $scope.myperson.Id = "";
        if ($scope.estaEditable == false) {
            $scope.myperson.Nombre = "";
            $scope.myperson.NumeroDocumento = "";
            $scope.myperson.Direccion = "";
            $scope.myperson.Telefono = "";
            $scope.myperson.Celular = "";
            $scope.myperson.EsNatural = false;
            $scope.myperson.EsInterno = null;
            $scope.myperson.TipoDocumentoPersona = null;
        }
        $scope.personas = [];
        $scope.tieneError = false;
        $scope.error = "";
    };
    
    $scope.modificar = function (person) {
        $scope.estaEditable = !$scope.estaEditable;
        if ($scope.estaEditable == true) {
            $scope.myperson.Id = person.Id;
            $scope.myperson.Nombre = person.Nombre;
            $scope.myperson.NumeroDocumento = person.NumeroDocumento;
            $scope.myperson.Direccion = person.Direccion;
            $scope.myperson.Telefono = person.Telefono;
            $scope.myperson.Celular = person.Celular;
            $scope.myperson.Email = person.Email;
            $scope.myperson.Tipo = person.Tipo;
            if (person.Tipo == 'N') {
                $scope.myperson.EsNatural = true;
            }
            else if (person.Tipo == 'J') {
                $scope.myperson.EsNatural = false;
            }
            $scope.myperson.Ambito = person.Ambito;
            if (person.Ambito == 'I') {
                $scope.myperson.EsInterno = true;
            }
            else if (person.Ambito == 'E') {
                $scope.myperson.EsInterno = false;
            }
            $scope.myperson.TipoDocumentoPersona = person.TipoDocumentoPersona;
        }
    };
    
    $scope.guardar = function () {
        $scope.estaCargando = true;
        if ($scope.myperson.EsNatural) {
            $scope.myperson.Tipo = "N";
        }
        else {
            $scope.myperson.Tipo = "J";
        }
        if ($scope.myperson.EsInterno) {
            $scope.myperson.Ambito = "I";
        }
        else {
            $scope.myperson.Ambito = "E";
        }
        var module =
            {
                "Id": $scope.myperson.Id,
                "Nombre": $scope.myperson.Nombre,
                "NumeroDocumento": $scope.myperson.NumeroDocumento,
                "Direccion": $scope.myperson.Direccion,
                "Telefono": $scope.myperson.Telefono,
                "Celular": $scope.myperson.Celular,
                "Email": $scope.myperson.Email,
                "Tipo": $scope.myperson.Tipo,
                "Ambito": $scope.myperson.Ambito,
                "TipoDocumentoPersona": $scope.myperson.TipoDocumentoPersona
            };

        if (module.Id == "") //nuevo (insert)
        {
            $http({
                method: 'POST',
                url: webAPIControllers + '/api/Persona/InsertarPersona',
                headers: {
                    'Content-Type': 'application/json'
                },
                data: module,
            }).then(function successCallback(result) {
                $scope.nuevo();
                $scope.personas = [];
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
                url: webAPIControllers + '/api/Persona/ActualizarPersona/' + module.Id,
                headers: {
                    'Content-Type': 'application/json'
                },
                data: module,
            }).then(function successCallback(result) {
                $scope.nuevo();
                $scope.personas = [];
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