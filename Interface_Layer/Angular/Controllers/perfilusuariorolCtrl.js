myApp.controller("PerfilUsuarioRolCtrl", function ($scope, $http, webAPIControllers) {
    $scope.perfilesusuariosroles = [];
    $scope.perfiles = [];
    $scope.roles = [];
    $scope.estaCargando = true;
    $scope.estaEditable = false;
    $scope.tieneError = false;
    $scope.myperfilusuariorol = [];
    $scope.myusuario = [];

    $http({
        method: 'POST',
        url: webAPIControllers + '/api/Perfil/ListarPerfiles',
    }).then(function successCallback(result) {
        $scope.perfiles = result.data;
        $scope.tieneError = false;
        $scope.error = "";
        $scope.estaCargando = false;
    }, function errorCallback(result) {
        $scope.tieneError = true;
        $scope.error = "Ha ocuirrido un error al listar: " + result;
        $scope.estaCargando = false;
    });

    var role =
            {
                "Id": '',
                "Nombre": '',
                "Descripcion": '',
                "Estado": 'A',
            };
    $http({
        method: 'POST',
        url: webAPIControllers + '/api/Rol/ListarRoles',
        headers: {
            'Content-Type': 'application/json'
        },
        data: role,
    }).then(function successCallback(result) {
        $scope.roles = result.data;
        $scope.tieneError = false;
        $scope.error = "";
        $scope.estaCargando = false;
    }, function errorCallback(result) {
        $scope.tieneError = true;
        $scope.error = "Ha ocuirrido un error al listar: " + result;
        $scope.estaCargando = false;
    });

    $scope.buscarUsuario = function () {
        if ($scope.myperfilusuariorol.Usuario == '44481138') {
            $scope.myusuario.Id = "1";
            $scope.myusuario.ApellidoPaterno = "LOPEZ";
            $scope.myusuario.ApellidoMaterno = "ENCISO";
            $scope.myusuario.Nombres = "DYLAN";
            $scope.myusuario.NombresCompletos = "LOPEZ ENCISO DYLAN";
        } else if ($scope.myperfilusuariorol.Usuario == '32991309') {
            $scope.myusuario.Id = "2";
            $scope.myusuario.ApellidoPaterno = "VASQUEZ";
            $scope.myusuario.ApellidoMaterno = "RAMIREZ";
            $scope.myusuario.Nombres = "ALEX";
            $scope.myusuario.NombresCompletos = "VASQUEZ RAMIREZ ALEX";
        }
    };

    $scope.buscar = function () {
        //console.debug($scope.myperfilusuariorol.Perfil);
        //console.debug($scope.myperfilusuariorol.Usuario);
        //console.debug($scope.myperfilusuariorol.Rol);
        if (angular.isUndefined($scope.myperfilusuariorol.Perfil) &&
            angular.isUndefined($scope.myperfilusuariorol.Usuario) &&
            angular.isUndefined($scope.myperfilusuariorol.Rol)) {
            $scope.tieneError = true;
            $scope.error = "Debe ingresar un perfil o usuario o rol para poder buscar";
        }
        else {
            $scope.tieneError = false;
            $scope.error = "";

            var user =
            {
                "Id": $scope.myusuario.Id,
                "Usuario": $scope.myperfilusuariorol.Usuario,
                "Contrasena": '',
                "ApellidoPaterno": '',
                "ApellidoMaterno": '',
                "Nombres": '',
                "Caduca": '',
                "PeriodoCaducidad": '',
                "FechaUltimoCambio": '',
                "UnicoIngreso": '',
                "HaIngresado": '',
                "OtrosLogeos": '',
                "Tipo": '',
                "Estado": ''
            };

            var perfilusuariorol =
            {
                "Id": '',
                "Estado": '',
                "Perfil": $scope.myperfilusuariorol.Perfil,
                //"Usuario": $scope.myperfilusuariorol.Usuario,
                "Usuario": user,
                "Rol": $scope.myperfilusuariorol.Rol
            };

            $http({
                method: 'POST',
                url: webAPIControllers + '/api/PerfilUsuarioRol/ListarPerfilesUsuariosRoles',
                headers: {
                    'Content-Type': 'application/json'
                },
                data: perfilusuariorol,
            }).then(function successCallback(result) {
                $scope.perfilesusuariosroles = result.data;
                $scope.estaCargando = false;
            }, function errorCallback(result) {
                $scope.tieneError = true;
                $scope.error = "Ha ocurrido un error al listar: " + result;
                $scope.estaCargando = false;
            });
        }
    };

    $scope.nuevo = function () {
        $scope.estaEditable = !$scope.estaEditable;
        $scope.myperfilusuariorol.Id = "";
        if ($scope.estaEditable == false) {
            $scope.myperfilusuariorol.Estado = "";
            $scope.myperfilusuariorol.EstaActivo = false;
            $scope.myperfilusuariorol.Perfil = null;
            $scope.myperfilusuariorol.Usuario = null;
            $scope.myusuario.Id = "";
            $scope.myusuario.ApellidoPaterno = "";
            $scope.myusuario.ApellidoMaterno = "";
            $scope.myusuario.Nombres = "";
            $scope.myperfilusuariorol.Rol = null;
        }
        $scope.tieneError = false;
        $scope.error = "";
    };

    $scope.modificar = function (perfilusuariorol) {
        $scope.estaEditable = !$scope.estaEditable;
        if ($scope.estaEditable == true) {
            $scope.myperfilusuariorol.Id = perfilusuariorol.Id;
            $scope.myperfilusuariorol.Estado = perfilusuariorol.Estado;
            $scope.myperfilusuariorol.Perfil = perfilusuariorol.Perfil;
            $scope.myperfilusuariorol.Usuario = perfilusuariorol.Usuario.Usuario;
            $scope.buscarUsuario();
            //$scope.myusuario.ApellidoPaterno = perfilusuariorol.Usuario.ApellidoPaterno;
            //$scope.myusuario.ApellidoMaterno = perfilusuariorol.Usuario.ApellidoMaterno;
            //$scope.myusuario.Nombres = perfilusuariorol.Usuario.Nombres;
            $scope.myperfilusuariorol.Rol = perfilusuariorol.Rol;
            if (perfilusuariorol.Estado == 'S') {
                $scope.myperfilusuariorol.EstaActivo = true;
            }
            else if (perfilusuariorol.Estado == 'N') {
                $scope.myperfilusuariorol.EstaActivo = false;
            }
        }
    };

    $scope.guardar = function () {
        $scope.estaCargando = true;
        if ($scope.myperfilusuariorol.EstaActivo) {
            $scope.myperfilusuariorol.Estado = "S";
        }
        else {
            $scope.myperfilusuariorol.Estado = "N";
        }

        var user =
        {
            "Id": $scope.myusuario.Id,
            "Usuario": $scope.myperfilusuariorol.Usuario,
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
        //console.debug(user);
        
        var perfilusuariorol =
            {
                "Id": $scope.myperfilusuariorol.Id,
                "Estado": $scope.myperfilusuariorol.Estado,
                "Perfil": $scope.myperfilusuariorol.Perfil,
                //"Usuario": $scope.myperfilusuariorol.Usuario,
                "Usuario": user,
                "Rol": $scope.myperfilusuariorol.Rol,
            };
        //console.debug(perfilusuariorol);

        if (perfilusuariorol.Id == "") //nuevo (insert)
        {
            $http({
                method: 'POST',
                url: webAPIControllers + '/api/PerfilUsuarioRol/InsertarPerfilUsuarioRol',
                headers: {
                    'Content-Type': 'application/json'
                },
                data: perfilusuariorol,
            }).then(function successCallback(result) {
                $scope.nuevo();
                $scope.perfilesusuariosroles = [];
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
                url: webAPIControllers + '/api/PerfilUsuarioRol/ActualizarPerfilUsuarioRol/' + perfilusuariorol.Id,
                headers: {
                    'Content-Type': 'application/json'
                },
                data: perfilusuariorol,
            }).then(function successCallback(result) {
                $scope.nuevo();
                $scope.perfilesusuariosroles = [];
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