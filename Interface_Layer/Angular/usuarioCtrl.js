myApp.controller("UsuarioCtrl", function ($scope, $http) {
    $scope.usuarios = [];
    $scope.personas = [];
    $scope.estaCargando = true;
    $scope.estaEditable = false;
    $scope.tieneError = false;
    $scope.mymodule = [];

    var person =
        {
            "Id": '',
            "Nombre": '',
            "NumeroDocumento": '',
            "Direccion": '',
            "Telefono": '',
            "Celular": '',
            "Email": '',
            "Tipo": '',
            "Ambito": '',
            "TipoDocumentoPersona": {},
        };
    $http({
        method: 'POST',
        url: '../api/Persona/ListarPersonas',
        headers: {
            'Content-Type': 'application/json'
        },
        data: person,
    }).then(function successCallback(result) {
        $scope.personas = result.data;
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
        var user =
        {
            "Id": '',
            "Usuario": '',
            "Contrasena": '',
            "Caduca": '',
            "PeriodoCaducidad": '',
            "FechaUltimoCambio": '',
            "UnicoIngreso": '',
            "HaIngresado": '',
            "OtrosLogeos": '',
            "Tipo": '',
            "Estado": '',
            "Persona": '',
        };
        if (!angular.isUndefined($scope.Persona)) {
            user.Persona = $scope.Persona;
        }
        //console.debug(module);
        $http({
            method: 'POST',
            url: '../api/Modulo/ListarModulos',
            headers: {
                'Content-Type': 'application/json'
            },
            data: user,
        }).then(function successCallback(result) {
            $scope.usuarios = result.data;
            $scope.estaCargando = false;
        }, function errorCallback(result) {
            $scope.tieneError = true;
            $scope.error = "Ha ocuirrido un error al listar: " + result;
            $scope.estaCargando = false;
        });
    };

    $scope.nuevo = function () {
        $scope.estaEditable = !$scope.estaEditable;
        $scope.mymodule.Id = "";
        if ($scope.estaEditable == false) {
            $scope.mymodule.Codigo = "";
            $scope.mymodule.Nombre = "";
            $scope.mymodule.Abreviatura = "";
            $scope.mymodule.Descripcion = "";
            $scope.mymodule.Estado = "";
            $scope.mymodule.EstaActivo = false;
            $scope.mymodule.Sistema = null;
        }
        $scope.modulos = [];
        $scope.tieneError = false;
        $scope.error = "";
    };

    $scope.modificar = function (modulo) {
        $scope.estaEditable = !$scope.estaEditable;
        if ($scope.estaEditable == true) {
            $scope.mymodule.Id = modulo.Id;
            $scope.mymodule.Codigo = modulo.Codigo;
            $scope.mymodule.Nombre = modulo.Nombre;
            $scope.mymodule.Abreviatura = modulo.Abreviatura;
            $scope.mymodule.Descripcion = modulo.Descripcion;
            $scope.mymodule.Estado = modulo.Estado;
            if (modulo.Estado == 'A') {
                $scope.mymodule.EstaActivo = true;
            }
            else if (modulo.Estado == 'I') {
                $scope.mymodule.EstaActivo = false;
            }
            $scope.mymodule.Sistema = modulo.Sistema;
        }
    };

    $scope.guardar = function () {
        $scope.estaCargando = true;
        if ($scope.mymodule.EstaActivo) {
            $scope.mymodule.Estado = "A";
        }
        else {
            $scope.mymodule.Estado = "I";
        }
        var module =
            {
                "Id": $scope.mymodule.Id,
                "Codigo": $scope.mymodule.Codigo,
                "Nombre": $scope.mymodule.Nombre,
                "Abreviatura": $scope.mymodule.Abreviatura,
                "Descripcion": $scope.mymodule.Descripcion,
                "Estado": $scope.mymodule.Estado,
                "Sistema": $scope.mymodule.Sistema
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
});