myApp.controller("RolUsuarioCtrl", function ($scope, $http, webAPIControllers) {
    $scope.usuariosroles = [];
    $scope.usuarios = [];
    $scope.roles = [];
    $scope.estaCargando = true;
    $scope.estaEditable = false;
    $scope.tieneError = false;

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
        //console.error(result);
        $scope.tieneError = true;
        $scope.error = "Ha ocuirrido un error al listar: " + result;
        $scope.estaCargando = false;
    });

    $scope.buscarUsuarios = function () {
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
            "Persona": { }
        };
        user.Usuario = $scope.usuario;
        if (!angular.isUndefined($scope.nombrePersona)) {
            user.Persona.Nombre = $scope.nombrePersona;
        }
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

    $scope.selectedUsuario = 0;
    $scope.selectedRol = 0;

    $scope.buscar = function (usuario, index) {
        $scope.usuarioSeleccionado = usuario;
        $scope.selectedUsuario = index;

        var usuariorol =
            {
                "Id": '',
                "Usuario": {},
                "Rol": {}
            };
        usuariorol.Usuario = usuario;
        //console.debug(usuariorol);
        $http({
            method: 'POST',
            url: webAPIControllers + '/api/UsuarioRol/ListarUsuariosRoles',
            headers: {
                'Content-Type': 'application/json'
            },
            data: usuariorol,
        }).then(function successCallback(result) {
            //console.debug(result);
            $scope.usuariosroles = result.data;
            $scope.tieneError = false;
            $scope.error = "";
            $scope.estaCargando = false;
        }, function errorCallback(result) {
            //console.error(result);
            $scope.tieneError = true;
            $scope.error = "Ha ocuirrido un error al listar: " + result;
            $scope.estaCargando = false;
        });
    };

    $scope.seleccionaRol = function (rol, index) {
        $scope.rolSeleccionado = rol;
        $scope.selectedRol = index;
    };

    $scope.agregaRol = function () {
        $scope.tieneError = false;
        $scope.error = "";
        var usuariorol =
            {
                "Id": '',
                "Usuario": $scope.usuarioSeleccionado,
                "Rol": $scope.rolSeleccionado
            };
        var repetido = false;
        angular.forEach($scope.usuariosroles, function (value) {
            //console.debug("USUARIO");
            //console.debug(value.Usuario);
            //console.debug(usuariorol.Usuario);
            //console.debug("ROL");
            //console.debug(value.Rol);
            //console.debug(usuariorol.Rol);
            if (value.Usuario.Id == usuariorol.Usuario.Id && value.Rol.Id == usuariorol.Rol.Id) {
                repetido = true;
            }
        });
        if (!repetido) {
            $scope.usuariosroles.push(usuariorol);
            $scope.tieneError = false;
            $scope.error = "";
        } else {
            $scope.tieneError = true;
            $scope.error = "Ha ocurrido un error, al agregar el menu al rol. Ya se encuentra ingresado";
        }
    };

    $scope.eliminarRol = function (usuariorol) {
        //console.debug(usuariorol);
        for (var i = 0; i < $scope.usuariosroles.length; i++) {
            var obj = $scope.usuariosroles[i];
            if (obj.Id == usuariorol.Id) {
                $scope.usuariosroles.splice(i, 1);
            }
        }
    };

    $scope.guardar = function () {
        $scope.estaCargando = true;
        //console.debug($scope.menusroles);
        //console.debug($scope.menusroles[0]);
        $http({
            method: 'DELETE',
            url: webAPIControllers + '/api/UsuarioRol/EliminarUsuarioRol/' + $scope.usuariosroles[0].Id,
            headers: {
                'Content-Type': 'application/json'
            },
            data: $scope.usuariosroles[0],
        }).then(function successCallback(result) {
            $http({
                method: 'POST',
                url: webAPIControllers + '/api/UsuarioRol/InsertarUsuarioRol',
                headers: {
                    'Content-Type': 'application/json'
                },
                data: $scope.usuariosroles,
            }).then(function successCallback(result) {
                $scope.usuariosroles = [];
                $scope.rolSeleccionado = {};
                $scope.selectedRol = 0;
                $scope.usuarioSeleccionado = {};
                $scope.selectedUsuario = 0;
                $scope.tieneError = false;
                $scope.error = "";
                $scope.estaCargando = false;
            }, function errorCallback(result) {
                $scope.tieneError = true;
                $scope.error = "Ha ocurrido un error al insertar: " + result;
                $scope.estaCargando = false;
            });
        }, function errorCallback(result) {
            $scope.tieneError = true;
            $scope.error = "Ha ocurrido un error al insertar: " + result;
            $scope.estaCargando = false;
        });
    };
});