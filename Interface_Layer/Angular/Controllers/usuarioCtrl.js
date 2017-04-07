myApp.controller("UsuarioCtrl", function ($scope, $http, webAPIControllers) {
    $scope.usuarios = [];
    $scope.estaCargando = true;
    $scope.estaEditable = false;
    $scope.tieneError = false;
    $scope.myusuario = [];

    $scope.buscar = function () {
        $scope.tieneError = false;
        $scope.error = "";
        var user =
        {
            "Id": '',
            "Usuario": '',
            "Contrasena": '',
            "ApellidoPaterno": $scope.myusuario.ApellidoPaterno,
            "ApellidoMaterno": $scope.myusuario.ApellidoMaterno,
            "Nombres": $scope.myusuario.Nombres,
            "Caduca": '',
            "PeriodoCaducidad": '',
            "FechaUltimoCambio": '',
            "UnicoIngreso": '',
            "HaIngresado": '',
            "OtrosLogeos": '',
            "Tipo": '',
            "Estado": ''
        };
        $http({
            method: 'POST',
            url: webAPIControllers + '/api/Usuario/ListarUsuarios',
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
        $scope.myusuario.Id = "";
        if ($scope.estaEditable == false) {
            $scope.myusuario.Usuario = "";
            $scope.myusuario.Contrasena = "";
            $scope.myusuario.ApellidoPaterno = "";
            $scope.myusuario.ApellidoMaterno = "";
            $scope.myusuario.Nombres = "";
            $scope.myusuario.Caduca = "";
            $scope.myusuario.EstaCaduca = false;
            $scope.myusuario.PeriodoCaducidad = "";
            $scope.myusuario.UnicoIngreso = "";
            $scope.myusuario.EsUnicoIngreso = false;
            $scope.myusuario.OtrosLogeos = "";
            $scope.myusuario.TieneOtrosLogeos = false;
            $scope.myusuario.Tipo = "E";
            $scope.myusuario.Estado = "";
            $scope.myusuario.EstaActivo = false;
        }
        $scope.usuarios = [];
        $scope.tieneError = false;
        $scope.error = "";
    };

    $scope.modificar = function (user) {
        $scope.estaEditable = !$scope.estaEditable;
        if ($scope.estaEditable == true) {
            $scope.myusuario.Id = user.Id;
            $scope.myusuario.Usuario = user.Usuario;
            $scope.myusuario.Contrasena = user.Contrasena;
            $scope.myusuario.ApellidoPaterno = user.ApellidoPaterno;
            $scope.myusuario.ApellidoMaterno = user.ApellidoMaterno;
            $scope.myusuario.Nombres = user.Nombres;
            if (user.Caduca == "S") {
                $scope.myusuario.EstaCaduca = true;
            } else if (user.Caduca == "N") {
                $scope.myusuario.EstaCaduca = false;
            }
            $scope.myusuario.PeriodoCaducidad = user.PeriodoCaducidad;
            if (user.UnicoIngreso == "S") {
                $scope.myusuario.EsUnicoIngreso = true;
            } else if (user.UnicoIngreso == "N") {
                $scope.myusuario.EsUnicoIngreso = false;
            }
            if (user.OtrosLogeos == "S") {
                $scope.myusuario.TieneOtrosLogeos = true;
            } else if (user.OtrosLogeos == "N") {
                $scope.myusuario.TieneOtrosLogeos = false;
            }
            $scope.myusuario.Tipo = user.Tipo;
            $scope.myusuario.EstaActivo = user.EstaActivo;
            if (user.Estado == "A") {
                $scope.myusuario.EstaActivo = true;
            } else if (user.Estado = "I") {
                $scope.myusuario.EstaActivo = false;
            }
        }
    };

    $scope.guardar = function () {
        $scope.estaCargando = true;
        if ($scope.myusuario.EstaCaduca) {
            $scope.myusuario.Caduca = "S";
        }
        else {
            $scope.myusuario.Caduca = "N";
        }
        if ($scope.myusuario.EsUnicoIngreso) {
            $scope.myusuario.UnicoIngreso = "S";
        }
        else {
            $scope.myusuario.UnicoIngreso = "N";
        }
        if ($scope.myusuario.TieneOtrosLogeos) {
            $scope.myusuario.OtrosLogeos = "S";
        }
        else {
            $scope.myusuario.OtrosLogeos = "N";
        }
        if ($scope.myusuario.EstaActivo) {
            $scope.myusuario.Estado = "A";
        }
        else {
            $scope.myusuario.Estado = "I";
        }
        var fecha = new Date();
        var dia = fecha.getDate().toString();
        if (dia.toString().length < 2) {
            dia = "0" + dia;
        }
        var mes = fecha.getMonth().toString();
        if (mes.toString().length < 2) {
            mes = "0" + mes;
        }
        var anho = fecha.getFullYear().toString();
        var fechaUltimoCambio = dia + "/" + mes + "/" + anho;
        var user =
        {
            "Id": $scope.myusuario.Id,
            "Usuario": $scope.myusuario.Usuario,
            "Contrasena": $scope.myusuario.Contrasena,
            "ApellidoPaterno": $scope.myusuario.ApellidoPaterno,
            "ApellidoMaterno": $scope.myusuario.ApellidoMaterno,
            "Nombres": $scope.myusuario.Nombres,
            "Caduca": $scope.myusuario.Caduca,
            "PeriodoCaducidad": $scope.myusuario.PeriodoCaducidad,
            "FechaUltimoCambio": fechaUltimoCambio,
            "UnicoIngreso": $scope.myusuario.UnicoIngreso,
            "HaIngresado": 'N',
            "OtrosLogeos": $scope.myusuario.OtrosLogeos,
            "Tipo": $scope.myusuario.Tipo,
            "Estado": $scope.myusuario.Estado
        };
        if (user.Id == "") //nuevo (insert)
        {
            $http({
                method: 'POST',
                url: webAPIControllers + '/api/Usuario/InsertarUsuario',
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
                url: webAPIControllers + '/api/Usuario/ActualizarUsuario/' + user.Id,
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