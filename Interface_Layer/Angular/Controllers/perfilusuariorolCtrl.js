//myApp.controller("PerfilUsuarioRolCtrl", function ($scope, $http, webAPIControllers) {
myApp.controller("PerfilUsuarioRolCtrl", function ($scope, user, role, profileuserrole, 
                                                   PerfilFctr, UsuarioFctr, RolFctr, PerfilUsuarioRolFctr) {
    $scope.perfilesusuariosroles = [];
    $scope.perfiles = [];
    $scope.roles = [];
    $scope.estaCargando = true;
    $scope.estaEditable = false;
    $scope.tieneError = false;
    $scope.myperfilusuariorol = [];
    $scope.myusuario = [];

    //$http({
    //    method: 'POST',
    //    url: webAPIControllers + '/api/Perfil/ListarPerfiles',
    //}).then(function successCallback(result) {
    //    $scope.perfiles = result.data;
    //    $scope.tieneError = false;
    //    $scope.error = "";
    //    $scope.estaCargando = false;
    //}, function errorCallback(result) {
    //    $scope.tieneError = true;
    //    $scope.error = "Ha ocuirrido un error al listar: " + result;
    //    $scope.estaCargando = false;
    //});

    PerfilFctr.ListarPerfiles()
        .then(function successCallback(response) {
            $scope.perfiles = response;
            $scope.tieneError = false;
            $scope.error = "";
            $scope.estaCargando = false;
        }, function errorCallback(response) {
            $scope.tieneError = true;
            $scope.error = "Ha ocurrido un error al listar: " + response;
            $scope.estaCargando = false;
        });

    //var role =
    //        {
    //            "Id": '',
    //            "Nombre": '',
    //            "Descripcion": '',
    //            "Estado": 'A',
    //        };
    //$http({
    //    method: 'POST',
    //    url: webAPIControllers + '/api/Rol/ListarRoles',
    //    headers: {
    //        'Content-Type': 'application/json'
    //    },
    //    data: role,
    //}).then(function successCallback(result) {
    //    $scope.roles = result.data;
    //    $scope.tieneError = false;
    //    $scope.error = "";
    //    $scope.estaCargando = false;
    //}, function errorCallback(result) {
    //    $scope.tieneError = true;
    //    $scope.error = "Ha ocuirrido un error al listar: " + result;
    //    $scope.estaCargando = false;
    //});

    RolFctr.ListarRoles(role)
        .then(function successCallback(response) {
            $scope.roles = response;
            $scope.tieneError = false;
            $scope.error = "";
            $scope.estaCargando = false;
        }, function errorCallback(response) {
            $scope.tieneError = true;
            $scope.error = "Ha ocurrido un error al listar: " + response;
            $scope.estaCargando = false;
        });
    

    $scope.buscarUsuario = function () {
        $scope.tieneError = false;
        $scope.error = "";
        $scope.estaCargando = true;
        user.Usuario = $scope.myperfilusuariorol.Usuario;
        UsuarioFctr.BuscarUsuarioPorUsuario(user)
            .then(function successCallback(response) {
                if (response.Id == 0) {
                    $scope.tieneError = true;
                    $scope.error = "El usuario no existe en la base de datos";
                    $scope.estaCargando = false;
                } else {
                    $scope.myusuario.Id = response.Id;
                    $scope.myusuario.ApellidoPaterno = response.ApellidoPaterno;
                    $scope.myusuario.ApellidoMaterno = response.ApellidoMaterno;
                    $scope.myusuario.Nombres = response.Nombres;
                    $scope.myusuario.NombresCompletos = response.ApellidoPaterno + " " + response.ApellidoMaterno + " " + response.Nombres;
                    $scope.estaCargando = false;
                }
            }, function errorCallback(response) {
                $scope.tieneError = true;
                $scope.error = "Ha ocurrido un error al buscar usuario: " + response;
                $scope.estaCargando = false;
            });
        //if ($scope.myperfilusuariorol.Usuario == '44481138') {
        //    $scope.myusuario.Id = "1";
        //    $scope.myusuario.ApellidoPaterno = "LOPEZ";
        //    $scope.myusuario.ApellidoMaterno = "ENCISO";
        //    $scope.myusuario.Nombres = "DYLAN";
        //    $scope.myusuario.NombresCompletos = "LOPEZ ENCISO DYLAN";
        //} else if ($scope.myperfilusuariorol.Usuario == '32991309') {
        //    $scope.myusuario.Id = "2";
        //    $scope.myusuario.ApellidoPaterno = "VASQUEZ";
        //    $scope.myusuario.ApellidoMaterno = "RAMIREZ";
        //    $scope.myusuario.Nombres = "ALEX";
        //    $scope.myusuario.NombresCompletos = "VASQUEZ RAMIREZ ALEX";
        //}
    };

    $scope.buscar = function () {
        //console.debug($scope.myperfilusuariorol.Perfil);
        //console.debug($scope.myperfilusuariorol.Usuario);
        //console.debug($scope.myperfilusuariorol.Rol);
        if ((angular.isUndefined($scope.myperfilusuariorol.Perfil) || $scope.myperfilusuariorol.Perfil == null) &&
            (angular.isUndefined($scope.myperfilusuariorol.Usuario) || $scope.myperfilusuariorol.Usuario == null) &&
            (angular.isUndefined($scope.myperfilusuariorol.Rol) || $scope.myperfilusuariorol.Rol == null)) {
            $scope.tieneError = true;
            $scope.error = "Debe ingresar un perfil o usuario o rol para poder buscar";
        }
        else {
            $scope.tieneError = false;
            $scope.error = "";

            //var user =
            //{
            //    "Id": $scope.myusuario.Id,
            //    "Usuario": $scope.myperfilusuariorol.Usuario,
            //    "Contrasena": '',
            //    "ApellidoPaterno": '',
            //    "ApellidoMaterno": '',
            //    "Nombres": '',
            //    "Caduca": '',
            //    "PeriodoCaducidad": '',
            //    "FechaUltimoCambio": '',
            //    "UnicoIngreso": '',
            //    "HaIngresado": '',
            //    "OtrosLogeos": '',
            //    "Tipo": '',
            //    "Estado": ''
            //};
            user.Id = $scope.myusuario.Id;
            user.Usuario = $scope.myperfilusuariorol.Usuario;
            user.ApellidoPaterno = $scope.myusuario.ApellidoPaterno;
            user.ApellidoMaterno = $scope.myusuario.ApellidoMaterno;
            user.Nombres = $scope.myusuario.Nombres;

            //var perfilusuariorol =
            //{
            //    "Id": '',
            //    "Estado": '',
            //    "Perfil": $scope.myperfilusuariorol.Perfil,
            //    //"Usuario": $scope.myperfilusuariorol.Usuario,
            //    "Usuario": user,
            //    "Rol": $scope.myperfilusuariorol.Rol
            //};
            if (!angular.isUndefined($scope.myperfilusuariorol.Perfil) && $scope.myperfilusuariorol.Perfil != null) {
                profileuserrole.Perfil = $scope.myperfilusuariorol.Perfil;
            }
            if (!angular.isUndefined(user) && user != null) {
                profileuserrole.Usuario = user;
            }
            if (!angular.isUndefined($scope.myperfilusuariorol.Rol) && $scope.myperfilusuariorol.Rol != null) {
                profileuserrole.Rol = $scope.myperfilusuariorol.Rol;
            }
            //$http({
            //    method: 'POST',
            //    url: webAPIControllers + '/api/PerfilUsuarioRol/ListarPerfilesUsuariosRoles',
            //    headers: {
            //        'Content-Type': 'application/json'
            //    },
            //    data: perfilusuariorol,
            //}).then(function successCallback(result) {
            //    $scope.perfilesusuariosroles = result.data;
            //    $scope.estaCargando = false;
            //}, function errorCallback(result) {
            //    $scope.tieneError = true;
            //    $scope.error = "Ha ocurrido un error al listar: " + result;
            //    $scope.estaCargando = false;
            //});
            PerfilUsuarioRolFctr.ListarPerfilesUsuariosRoles(profileuserrole)
                .then(function successCallback(response) {
                    $scope.perfilesusuariosroles = response;
                    $scope.tieneError = false;
                    $scope.error = "";
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
        $scope.myperfilusuariorol.Id = "";
        if ($scope.estaEditable == false) {
            $scope.myperfilusuariorol.Activo = "";
            $scope.myperfilusuariorol.EstaActivo = false;
        }
        $scope.myperfilusuariorol.Perfil = null;
        $scope.myperfilusuariorol.Usuario = null;
        //console.debug($scope.myusuario);
        $scope.myusuario.Id = "";
        $scope.myusuario.ApellidoPaterno = "";
        $scope.myusuario.ApellidoMaterno = "";
        $scope.myusuario.Nombres = "";
        $scope.myusuario.NombresCompletos = "";
        $scope.myperfilusuariorol.Rol = null;
        console.debug(profileuserrole);
        PerfilUsuarioRolFctr.CleanPerfilUsuarioRol(profileuserrole);
        $scope.perfilesusuariosroles = [];
        $scope.tieneError = false;
        $scope.error = "";
    };

    $scope.modificar = function (perfilusuariorol) {
        $scope.estaEditable = !$scope.estaEditable;
        if ($scope.estaEditable == true) {
            $scope.myperfilusuariorol.Id = perfilusuariorol.Id;
            $scope.myperfilusuariorol.Activo = perfilusuariorol.Activo;
            $scope.myperfilusuariorol.Perfil = perfilusuariorol.Perfil;
            $scope.myperfilusuariorol.Usuario = perfilusuariorol.Usuario.Usuario;
            $scope.buscarUsuario();
            //$scope.myusuario.ApellidoPaterno = perfilusuariorol.Usuario.ApellidoPaterno;
            //$scope.myusuario.ApellidoMaterno = perfilusuariorol.Usuario.ApellidoMaterno;
            //$scope.myusuario.Nombres = perfilusuariorol.Usuario.Nombres;
            $scope.myperfilusuariorol.Rol = perfilusuariorol.Rol;
            if (perfilusuariorol.Activo == 'S') {
                $scope.myperfilusuariorol.EstaActivo = true;
            }
            else if (perfilusuariorol.Activo == 'N') {
                $scope.myperfilusuariorol.EstaActivo = false;
            }
        }
    };

    $scope.guardar = function () {
        $scope.tieneError = false;
        $scope.error = "";
        $scope.estaCargando = true;
        if ($scope.myperfilusuariorol.EstaActivo) {
            $scope.myperfilusuariorol.Activo = "S";
        }
        else {
            $scope.myperfilusuariorol.Activo = "N";
        }

        //var user =
        //{
        //    "Id": $scope.myusuario.Id,
        //    "Usuario": $scope.myperfilusuariorol.Usuario,
        //    "Contrasena": '',
        //    "ApellidoPaterno": $scope.myusuario.ApellidoPaterno,
        //    "ApellidoMaterno": $scope.myusuario.ApellidoMaterno,
        //    "Nombres": $scope.myusuario.Nombres,
        //    "Caduca": '',
        //    "PeriodoCaducidad": '',
        //    "FechaUltimoCambio": '',
        //    "UnicoIngreso": '',
        //    "HaIngresado": '',
        //    "OtrosLogeos": '',
        //    "Tipo": '',
        //    "Estado": ''
        //};
        user.Id = $scope.myusuario.Id;
        user.Usuario = $scope.myperfilusuariorol.Usuario;
        user.ApellidoPaterno = $scope.myusuario.ApellidoPaterno;
        user.ApellidoMaterno = $scope.myusuario.ApellidoMaterno;
        user.Nombres = $scope.myusuario.Nombres;
        //console.debug(user);
        
        //var perfilusuariorol =
        //    {
        //        "Id": $scope.myperfilusuariorol.Id,
        //        "Estado": $scope.myperfilusuariorol.Estado,
        //        "Perfil": $scope.myperfilusuariorol.Perfil,
        //        //"Usuario": $scope.myperfilusuariorol.Usuario,
        //        "Usuario": user,
        //        "Rol": $scope.myperfilusuariorol.Rol,
        //    };
        //console.debug(perfilusuariorol);
        profileuserrole.Id = $scope.myperfilusuariorol.Id;
        profileuserrole.Activo = $scope.myperfilusuariorol.Activo;
        profileuserrole.Perfil = $scope.myperfilusuariorol.Perfil;
        profileuserrole.Usuario = user;
        profileuserrole.Rol = $scope.myperfilusuariorol.Rol;
        if (profileuserrole.Id == "") //nuevo (insert)
        {
            //$http({
            //    method: 'POST',
            //    url: webAPIControllers + '/api/PerfilUsuarioRol/InsertarPerfilUsuarioRol',
            //    headers: {
            //        'Content-Type': 'application/json'
            //    },
            //    data: perfilusuariorol,
            //}).then(function successCallback(result) {
            //    $scope.nuevo();
            //    $scope.perfilesusuariosroles = [];
            //    $scope.tieneError = false;
            //    $scope.error = "";
            //    $scope.estaCargando = false;
            //}, function errorCallback(result) {
            //    $scope.tieneError = true;
            //    $scope.error = "Ha ocuirrido un error al insertar: " + result;
            //    $scope.estaCargando = false;
            //});
            PerfilUsuarioRolFctr.InsertarPerfilUsuarioRol(profileuserrole)
                .then(function successCallback(response) {
                    $scope.nuevo();
                    $scope.perfilesusuariosroles = [];
                    $scope.estaCargando = false;
                }, function errorCallback(response) {
                    $scope.tieneError = true;
                    $scope.error = "Ha ocurrido un error al insertar: " + response.data.Message;
                    $scope.estaCargando = false;
                });
        }
        else //actualizar (update)
        {
            //$http({
            //    method: 'PUT',
            //    url: webAPIControllers + '/api/PerfilUsuarioRol/ActualizarPerfilUsuarioRol/' + perfilusuariorol.Id,
            //    headers: {
            //        'Content-Type': 'application/json'
            //    },
            //    data: perfilusuariorol,
            //}).then(function successCallback(result) {
            //    $scope.nuevo();
            //    $scope.perfilesusuariosroles = [];
            //    $scope.tieneError = false;
            //    $scope.error = "";
            //    $scope.estaCargando = false;
            //}, function errorCallback(result) {
            //    $scope.tieneError = true;
            //    $scope.error = "Ha ocuirrido un error al actualizar: " + result;
            //    $scope.estaCargando = false;
            //});
            PerfilUsuarioRolFctr.ActualizarPerfilUsuarioRol(profileuserrole)
                .then(function successCallback(response) {
                    $scope.nuevo();
                    $scope.perfilesusuariosroles = [];
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