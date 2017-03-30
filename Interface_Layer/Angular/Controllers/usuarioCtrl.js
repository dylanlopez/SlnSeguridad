myApp.controller("UsuarioCtrl", function ($scope, $http) {
    $scope.usuarios = [];
    $scope.personas = [];
    $scope.estaCargando = true;
    $scope.estaEditable = false;
    $scope.tieneError = false;
    $scope.myuser = [];

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
            "Usuario": $scope.usuario,
            "Contrasena": '',
            "Caduca": '',
            "PeriodoCaducidad": '',
            "FechaUltimoCambio": '',
            "UnicoIngreso": '',
            "HaIngresado": '',
            "OtrosLogeos": '',
            "Tipo": '',
            "Estado": '',
            "Persona": {
                //"Id": '',
                //"Nombre": '',
                //"NumeroDocumento": '',
                //"Direccion": '',
                //"Telefono": '',
                //"Celular": '',
                //"Email": '',
                //"Tipo": '',
                //"Ambito": '',
                //"TipoDocumentoPersona": {}
                }
        };
        if (!angular.isUndefined($scope.nombrePersona)) {
            user.Persona.Nombre = $scope.nombrePersona;
        }
        //console.debug(user);
        $http({
            method: 'POST',
            url: '../api/Usuario/ListarUsuarios',
            headers: {
                'Content-Type': 'application/json'
            },
            data: user,
        }).then(function successCallback(result) {
            //console.debug(result.data);
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
        $scope.myuser.Id = "";
        if ($scope.estaEditable == false) {
            $scope.myuser.Usuario = "";
            $scope.myuser.Contrasena = "";
            $scope.myuser.Caduca = "";
            $scope.myuser.EstaCaduca = false;
            $scope.myuser.PeriodoCaducidad = "";
            $scope.myuser.UnicoIngreso = "";
            $scope.myuser.EsUnicoIngreso = false;
            $scope.myuser.OtrosLogeos = "";
            $scope.myuser.TieneOtrosLogeos = false;
            $scope.myuser.Tipo = "E";
            $scope.myuser.Estado = "";
            $scope.myuser.EstaActivo = false;
            $scope.myuser.Persona = null;
        }
        $scope.usuarios = [];
        $scope.tieneError = false;
        $scope.error = "";
    };

    $scope.modificar = function (user) {
        $scope.estaEditable = !$scope.estaEditable;
        //console.debug($scope.myuser);
        //console.debug(user);
        //console.debug($scope.myuser.Id);
        if ($scope.estaEditable == true) {
            $scope.myuser.Id = user.Id;
            $scope.myuser.Usuario = user.Usuario;
            $scope.myuser.Contrasena = user.Contrasena;
            //$scope.myuser.Caduca = user.Caduca;
            //console.debug(user.Caduca);
            if (user.Caduca == "S") {
                $scope.myuser.EstaCaduca = true;
            } else if (user.Caduca == "N") {
                $scope.myuser.EstaCaduca = false;
            }
            //console.debug($scope.myuser.EstaCaduca);
            $scope.myuser.PeriodoCaducidad = user.PeriodoCaducidad;
            //$scope.myuser.UnicoIngreso = user.UnicoIngreso;
            if (user.UnicoIngreso == "S") {
                $scope.myuser.EsUnicoIngreso = true;
            } else if (user.UnicoIngreso == "N") {
                $scope.myuser.EsUnicoIngreso = false;
            }
            //console.debug(user.OtrosLogeos);
            if (user.OtrosLogeos == "S") {
                $scope.myuser.TieneOtrosLogeos = true;
            } else if (user.OtrosLogeos == "N") {
                $scope.myuser.TieneOtrosLogeos = false;
            }
            //console.debug($scope.myuser.TieneOtrosLogeos);
            $scope.myuser.Tipo = user.Tipo;
            $scope.myuser.EstaActivo = user.EstaActivo;
            if (user.Estado == "A") {
                $scope.myuser.EstaActivo = true;
            } else if (user.Estado = "I") {
                $scope.myuser.EstaActivo = false;
            }
            $scope.myuser.Persona = user.Persona;
        }
    };

    $scope.guardar = function () {
        $scope.estaCargando = true;
        if ($scope.myuser.EstaCaduca) {
            $scope.myuser.Caduca = "S";
        }
        else {
            $scope.myuser.Caduca = "N";
        }
        if ($scope.myuser.EsUnicoIngreso) {
            $scope.myuser.UnicoIngreso = "S";
        }
        else {
            $scope.myuser.UnicoIngreso = "N";
        }
        if ($scope.myuser.TieneOtrosLogeos) {
            $scope.myuser.OtrosLogeos = "S";
        }
        else {
            $scope.myuser.OtrosLogeos = "N";
        }
        if ($scope.myuser.EstaActivo) {
            $scope.myuser.Estado = "A";
        }
        else {
            $scope.myuser.Estado = "I";
        }
        var fecha = new Date();
        var dia = fecha.getDate().toString();
        if (dia.toString().length < 2) {
            dia = "0" + dia;
        }
        var mes = fecha.getMonth().toString();
        //console.debug(mes.length);
        //alert(mes);
        if (mes.toString().length < 2) {
            mes = "0" + mes;
            //alert(mes);
        }
        var anho = fecha.getFullYear().toString();
        var fechaUltimoCambio = dia + "/" + mes + "/" + anho;
        //console.debug(mes);
        var user =
        {
            "Id": $scope.myuser.Id,
            "Usuario": $scope.myuser.Usuario,
            "Contrasena": $scope.myuser.Contrasena,
            "Caduca": $scope.myuser.Caduca,
            "PeriodoCaducidad": $scope.myuser.PeriodoCaducidad,
            "FechaUltimoCambio": fechaUltimoCambio,
            "UnicoIngreso": $scope.myuser.UnicoIngreso,
            "HaIngresado": 'N',
            "OtrosLogeos": $scope.myuser.OtrosLogeos,
            "Tipo": $scope.myuser.Tipo,
            "Estado": $scope.myuser.Estado,
            "Persona": $scope.myuser.Persona
        };
        //console.debug(user);
        if (user.Id == "") //nuevo (insert)
        {
            $http({
                method: 'POST',
                url: '../api/Usuario/InsertarUsuario',
                headers: {
                    'Content-Type': 'application/json'
                },
                data: user,
            }).then(function successCallback(result) {
                $scope.nuevo();
                $scope.usuarios = [];
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
                url: '../api/Usuario/ActualizarUsuario/' + user.Id,
                headers: {
                    'Content-Type': 'application/json'
                },
                data: user,
            }).then(function successCallback(result) {
                $scope.nuevo();
                $scope.usuarios = [];
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