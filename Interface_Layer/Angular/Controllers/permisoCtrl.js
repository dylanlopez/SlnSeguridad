//myApp.controller("PermisoCtrl", function ($scope, $http, webAPIControllers) {
myApp.controller("PermisoCtrl", function ($scope, user, role, profileuserrole,
                                          system, module, menu, option, menuoption,
                                          permission, 
                                          PerfilFctr, UsuarioFctr, RolFctr, PerfilUsuarioRolFctr, 
                                          SistemaFctr, ModuloFctr, MenuFctr, OpcionFctr, MenuOpcionFctr, 
                                          PermisoFctr) {
    $scope.permisos = [];
    $scope.perfilesusuariosroles = [];
    $scope.perfiles = [];
    $scope.roles = [];
    $scope.sistemas = [];
    $scope.modulos = [];
    $scope.menus = [];
    $scope.opciones = [];
    $scope.estaCargando = true;
    $scope.estaEditable = false;
    $scope.tieneError = false;
    $scope.mypermiso = [];
    $scope.myusuario = [];

    $scope.selectedRolUsuarioPerfil = 0;
    $scope.selectedMenuOpcion = 0;
    //PerfilesUsuariosRoles
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
    //    $scope.error = "Ha ocuirrido un error al listar perfiles: " + result;
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
            $scope.error = "Ha ocurrido un error al listar perfiles: " + response;
            $scope.estaCargando = false;
        });

    $scope.buscarUsuario = function () {
        //if ($scope.mypermiso.Usuario == '44481138') {
        //    $scope.myusuario.Id = "1";
        //    $scope.myusuario.ApellidoPaterno = "LOPEZ";
        //    $scope.myusuario.ApellidoMaterno = "ENCISO";
        //    $scope.myusuario.Nombres = "DYLAN";
        //    $scope.myusuario.NombresCompletos = "LOPEZ ENCISO DYLAN";
        //} else if ($scope.mypermiso.Usuario == '32991309') {
        //    $scope.myusuario.Id = "2";
        //    $scope.myusuario.ApellidoPaterno = "VASQUEZ";
        //    $scope.myusuario.ApellidoMaterno = "RAMIREZ";
        //    $scope.myusuario.Nombres = "ALEX";
        //    $scope.myusuario.NombresCompletos = "VASQUEZ RAMIREZ ALEX";
        //}
        $scope.tieneError = false;
        $scope.error = "";
        $scope.estaCargando = true;
        user.Usuario = $scope.mypermiso.Usuario;
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
    };

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
            $scope.error = "Ha ocurrido un error al listar roles: " + response;
            $scope.estaCargando = false;
        });

    $scope.buscarRolesUsuariosPerfiles = function () {
        if ((angular.isUndefined($scope.mypermiso.Perfil) || $scope.mypermiso.Perfil == null) &&
            angular.isUndefined($scope.mypermiso.Usuario) &&
            angular.isUndefined($scope.mypermiso.Rol)) {
            $scope.tieneError = true;
            $scope.error = "Debe ingresar un perfil o usuario o rol para poder buscar";
        }
        else {
            $scope.tieneError = false;
            $scope.error = "";
            $scope.estaCargando = true;
            //var user =
            //{
            //    "Id": $scope.myusuario.Id,
            //    "Usuario": $scope.mypermiso.Usuario,
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
            user.Usuario = $scope.mypermiso.Usuario;

            //var perfilusuariorol =
            //{
            //    "Id": '',
            //    "Estado": '',
            //    "Perfil": $scope.mypermiso.Perfil,
            //    //"Usuario": $scope.myperfilusuariorol.Usuario,
            //    "Usuario": user,
            //    "Rol": $scope.mypermiso.Rol
            //};
            if (!angular.isUndefined($scope.mypermiso.Perfil) && $scope.mypermiso.Perfil != null) {
                profileuserrole.Perfil = $scope.mypermiso.Perfil;
            }
            if (!angular.isUndefined(user) && user != null) {
                profileuserrole.Usuario = user;
            }
            if (!angular.isUndefined($scope.mypermiso.Rol) && $scope.mypermiso.Rol != null) {
                profileuserrole.Rol = $scope.mypermiso.Rol;
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
                    $scope.estaCargando = false;
                }, function errorCallback(response) {
                    $scope.tieneError = true;
                    $scope.error = "Ha ocurrido un error al listar los roles por usuarios por roles: " + response;
                    $scope.estaCargando = false;
                });
        }
    };


    //MenusOpciones
    //$http({
    //    method: 'POST',
    //    url: webAPIControllers + '/api/Sistema/ListarSistemas',
    //}).then(function successCallback(result) {
    //    $scope.sistemas = result.data;
    //    $scope.tieneError = false;
    //    $scope.error = "";
    //    $scope.estaCargando = false;
    //}, function errorCallback(result) {
    //    $scope.tieneError = true;
    //    $scope.error = "Ha ocurrido un error al listar: " + result;
    //    $scope.estaCargando = false;
    //});
    system.Activo = 'S';
    SistemaFctr.ListarSistemas(system)
        .then(function successCallback(response) {
            $scope.sistemas = response;
            $scope.tieneError = false;
            $scope.error = "";
            $scope.estaCargando = false;
        }, function errorCallback(response) {
            $scope.tieneError = true;
            $scope.error = "Ha ocurrido un error al listar sistemas: " + response;
            $scope.estaCargando = false;
        });

    $scope.buscarModulo = function () {
        if (angular.isUndefined($scope.mypermiso.Sistema)) {
            $scope.tieneError = true;
            $scope.error = "Debe ingresar un sistema para poder ver sus módulos";
        }
        else {
            //$scope.tieneError = false;
            //$scope.error = "";

            //var module =
            //    {
            //        "Id": '',
            //        "Codigo": '',
            //        "Nombre": '',
            //        "Abreviatura": '',
            //        "Descripcion": '',
            //        "Estado": '',
            //        "Sistema": $scope.mypermiso.Sistema
            //    };

            //$http({
            //    method: 'POST',
            //    url: webAPIControllers + '/api/Modulo/ListarModulos',
            //    headers: {
            //        'Content-Type': 'application/json'
            //    },
            //    data: module,
            //}).then(function successCallback(result) {
            //    $scope.modulos = result.data;
            //    $scope.estaCargando = false;
            //}, function errorCallback(result) {
            //    $scope.tieneError = true;
            //    $scope.error = "Ha ocurrido un error al listar: " + result;
            //    $scope.estaCargando = false;
            //});
            $scope.tieneError = false;
            $scope.error = "";
            $scope.estaCargando = true;
            module.Activo = 'S';
            module.Sistema = $scope.mypermiso.Sistema;
            ModuloFctr.ListarModulos(module)
                .then(function successCallback(response) {
                    $scope.modulos = response;
                    $scope.estaCargando = false;
                }, function errorCallback(response) {
                    $scope.tieneError = true;
                    $scope.error = "Ha ocurrido un error al listar modulos: " + response;
                    $scope.estaCargando = false;
                });
        }
    };

    $scope.buscarMenu = function () {
        if (angular.isUndefined($scope.mypermiso.Sistema) &&
            angular.isUndefined($scope.mypermiso.Modulo)) {
            $scope.tieneError = true;
            $scope.error = "Debe ingresar un sistema y módulo para poder ver sus menús";
        }
        else {
            //$scope.tieneError = false;
            //$scope.error = "";
            //var menu =
            //{
            //    "Id": '',
            //    "Codigo": '',
            //    "Nombre": '',
            //    "Ruta": '',
            //    "Descripcion": '',
            //    "Estado": '',
            //    "Modulo": $scope.mypermiso.Modulo
            //};

            //$http({
            //    method: 'POST',
            //    url: webAPIControllers + '/api/Menu/ListarMenus',
            //    headers: {
            //        'Content-Type': 'application/json'
            //    },
            //    data: menu,
            //}).then(function successCallback(result) {
            //    $scope.menus = result.data;
            //    $scope.estaCargando = false;
            //}, function errorCallback(result) {
            //    $scope.tieneError = true;
            //    $scope.error = "Ha ocurrido un error al listar: " + result;
            //    $scope.estaCargando = false;
            //});
            $scope.tieneError = false;
            $scope.error = "";
            $scope.estaCargando = true;
            menu.Modulo = $scope.mypermiso.Modulo;
            MenuFctr.ListarMenus(menu)
                .then(function successCallback(response) {
                    $scope.menus = response;
                    $scope.estaCargando = false;
                }, function errorCallback(response) {
                    $scope.tieneError = true;
                    $scope.error = "Ha ocurrido un error al listar menus: " + response;
                    $scope.estaCargando = false;
                });
        }
    };

    $scope.buscarMenuesOpciones = function () {
        console.debug($scope.mypermiso.Sistema);
        console.debug($scope.mypermiso.Modulo);
        console.debug($scope.mypermiso.Menu);
        if ((angular.isUndefined($scope.mypermiso.Sistema) || $scope.mypermiso.Sistema == null) || 
            (angular.isUndefined($scope.mypermiso.Modulo) || $scope.mypermiso.Modulo == null) || 
            (angular.isUndefined($scope.mypermiso.Menu) || $scope.mypermiso.Menu == null)) {
            //console.info("if");
            $scope.tieneError = true;
            $scope.error = "Debe ingresar un sistema, módulo y menú para poder ver sus opciones";
        }
        else {
            //console.info("else");
            //$scope.tieneError = false;
            //$scope.error = "";
            //var menuopcion =
            //{
            //    "Id": '',
            //    "Estado": '',
            //    "Visible": '',
            //    "Menu": $scope.mypermiso.Menu,
            //    "Opcion": ''
            //};

            //$http({
            //    method: 'POST',
            //    url: webAPIControllers + '/api/MenuOpcion/ListarMenuOpciones',
            //    headers: {
            //        'Content-Type': 'application/json'
            //    },
            //    data: menuopcion,
            //}).then(function successCallback(result) {
            //    $scope.menuesopciones = result.data;
            //    $scope.estaCargando = false;
            //}, function errorCallback(result) {
            //    $scope.tieneError = true;
            //    $scope.error = "Ha ocurrido un error al listar: " + result;
            //    $scope.estaCargando = false;
            //});
            $scope.tieneError = false;
            $scope.error = "";
            $scope.estaCargando = true;
            menuoption.Menu = $scope.mypermiso.Menu;
            MenuOpcionFctr.ListarMenuOpciones(menuoption)
                .then(function successCallback(response) {
                    $scope.menuesopciones = response;
                    $scope.estaCargando = false;
                }, function errorCallback(response) {
                    $scope.tieneError = true;
                    $scope.error = "Ha ocurrido un error al listar opciones por menu: " + response;
                    $scope.estaCargando = false;
                });
        }
    };

    $scope.seleccionaPerfilUsuarioRol = function (rolusuarioperfil, index) {
        $scope.rolUsuarioPerfilSeleccionado = rolusuarioperfil;
        $scope.selectedRolUsuarioPerfil = index;
    };

    $scope.seleccionaMenuOpcion = function (menuopcion, index) {
        $scope.menuOpcionSeleccionado = menuopcion;
        $scope.selectedMenuOpcion = index;
    };

    $scope.buscar = function () {
        $scope.tieneError = false;
        $scope.error = "";
        //console.info("buscar");
        //var permiso =
        //    {
        //        "Id": '',
        //        "FechaAlta": '',
        //        "Estado": '',
        //        "PerfilUsuarioRol": {},
        //        "MenuOpcion": {}
        //    };
        //var user =
        //{
        //    "Id": $scope.myusuario.Id,
        //    "Usuario": $scope.mypermiso.Usuario,
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
        //var perfilusuariorol =
        //{
        //    "Id": '',
        //    "Estado": '',
        //    "Perfil": $scope.mypermiso.Perfil,
        //    "Usuario": user,
        //    "Rol": $scope.mypermiso.Rol,
        //};

        //var menuopcion =
        //{
        //    "Id": '',
        //    "Estado": '',
        //    "Visible": '',
        //    "Menu": {},
        //    "Opcion": {}
        //};
        if (!angular.isUndefined($scope.mypermiso.Menu)) {
            //console.debug("Undefined 1");
            //menuopcion.Menu = $scope.mypermiso.Menu;
            menuoption.Menu = $scope.mypermiso.Menu;
        } else {
            if (!angular.isUndefined($scope.mypermiso.Modulo)) {
                //console.debug("Undefined 2");
                //var menu =
                //{
                //    "Id": '',
                //    "Codigo": '',
                //    "Nombre": '',
                //    "Ruta": '',
                //    "Descripcion": '',
                //    "Estado": '',
                //    "Modulo": $scope.mypermiso.Modulo
                //};
                menu.Modulo = $scope.mypermiso.Modulo;
                //menuopcion.Menu = menu;
            } else {
                if (!angular.isUndefined($scope.mypermiso.Sistema)) {
                    //console.debug("Undefined 3");
                    //var module =
                    //{
                    //    "Id": '',
                    //    "Codigo": '',
                    //    "Nombre": '',
                    //    "Abreviatura": '',
                    //    "Estado": '',
                    //    "Descripcion": '',
                    //    "Sistema": $scope.mypermiso.Sistema
                    //};
                    module.Sistema = $scope.mypermiso.Sistema;
                    //var menu =
                    //{
                    //    "Id": '',
                    //    "Codigo": '',
                    //    "Nombre": '',
                    //    "Ruta": '',
                    //    "Descripcion": '',
                    //    "Estado": '',
                    //    "Modulo": module
                    //};
                    menu.Modulo = module;
                    menuoption.Menu = menu;
                }
            }
        }
        //console.debug($scope.rolUsuarioPerfilSeleccionado);
        //console.debug(perfilusuariorol);
        //permiso.PerfilUsuarioRol = $scope.rolUsuarioPerfilSeleccionado;
        permission.PerfilUsuarioRol = $scope.rolUsuarioPerfilSeleccionado;
        //permiso.PerfilUsuarioRol = perfilusuariorol;
        //console.debug(menuopcion);
        //permiso.MenuOpcion = menuopcion;
        permission.MenuOpcion = menuoption;
        //console.debug(permiso);

        PermisoFctr.ListarPermisos(permission)
                .then(function successCallback(response) {
                    $scope.permisos = response;
                    $scope.estaCargando = false;
                }, function errorCallback(response) {
                    $scope.tieneError = true;
                    $scope.error = "Ha ocurrido un error al listar permisos: " + response;
                    $scope.estaCargando = false;
                });
        //$http({
        //    method: 'POST',
        //    url: webAPIControllers + '/api/Permiso/ListarPermisos',
        //    headers: {
        //        'Content-Type': 'application/json'
        //    },
        //    data: permiso,
        //}).then(function successCallback(result) {
        //    $scope.permisos = result.data;
        //    $scope.tieneError = false;
        //    $scope.error = "";
        //    $scope.estaCargando = false;
        //}, function errorCallback(result) {
        //    //console.error(result);
        //    $scope.tieneError = true;
        //    $scope.error = "Ha ocuirrido un error al listar: " + result;
        //    $scope.estaCargando = false;
        //});
    };

    $scope.agregaOpcionMenu = function () {
        if ((angular.isUndefined($scope.rolUsuarioPerfilSeleccionado) || $scope.rolUsuarioPerfilSeleccionado == null) || 
            (angular.isUndefined($scope.menuOpcionSeleccionado) || $scope.menuOpcionSeleccionado == null)) {
            $scope.tieneError = true;
            $scope.error = "Debe ingresar un rol por usuario por perfil y/o una opcion por menu";
        } else {
            $scope.tieneError = false;
            $scope.error = "";

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

            //var permiso =
            //    {
            //        "Id": '',
            //        "FechaAlta": fechaUltimoCambio,
            //        "Estado": 'S',
            //        "PerfilUsuarioRol": $scope.rolUsuarioPerfilSeleccionado,
            //        "MenuOpcion": $scope.menuOpcionSeleccionado
            //    };
            console.debug($scope.rolUsuarioPerfilSeleccionado);
            console.debug($scope.menuOpcionSeleccionado);
            permission.FechaAlta = fechaUltimoCambio;
            permission.Activo = "S";
            permission.PerfilUsuarioRol = $scope.rolUsuarioPerfilSeleccionado;
            permission.MenuOpcion = $scope.menuOpcionSeleccionado;
            var repetido = false;
            angular.forEach($scope.permisos, function (value) {
                if (value.PerfilUsuarioRol.Id == permission.PerfilUsuarioRol.Id &&
                    value.MenuOpcion.Id == permission.MenuOpcion.Id) {
                    repetido = true;
                }
            });
            if (!repetido) {
                $scope.permisos.push(permission);
                $scope.tieneError = false;
                $scope.error = "";
            } else {
                $scope.tieneError = true;
                $scope.error = "Ha ocurrido un error, al agregar el menu al rol. Ya se encuentra ingresado";
            }
        }
    };

    $scope.cambiarEstado = function (permiso) {
        $scope.tieneError = false;
        $scope.error = "";
        $scope.estaCargando = true;
        console.debug(permiso);
        if (permiso.Id != '') {
            if (permiso.Activo == 'S') {
                permiso.Activo = 'N';
            } else if (permiso.Activo == 'N') {
                permiso.Activo = 'S';
            }

            PermisoFctr.ActualizarPermiso(permiso)
                .then(function successCallback(response) {
                    $scope.estaCargando = false;
                }, function errorCallback(response) {
                    $scope.tieneError = true;
                    $scope.error = "Ha ocuirrido un error al actualizar: " + response.data.Message;
                    $scope.estaCargando = false;
                });

            //$http({
            //    method: 'PUT',
            //    url: webAPIControllers + '/api/Permiso/ActualizarPermiso/' + permiso.Id,
            //    headers: {
            //        'Content-Type': 'application/json'
            //    },
            //    data: permiso,
            //}).then(function successCallback(result) {
            //    $scope.tieneError = false;
            //    $scope.error = "";
            //    $scope.estaCargando = false;
            //}, function errorCallback(result) {
            //    $scope.tieneError = true;
            //    $scope.error = "Ha ocurrido un error al actualizar: " + result;
            //    $scope.estaCargando = false;
            //});
        } else {
            $scope.tieneError = true;
            $scope.error = "No se puede cambiar de estado un permiso que aun no ha sido ingresado, guardelo primero";
        }
    };

    $scope.guardar = function (permiso) {
        //$scope.estaCargando = true;
        //$http({
        //    method: 'POST',
        //    url: webAPIControllers + '/api/Permiso/InsertarPermiso',
        //    headers: {
        //        'Content-Type': 'application/json'
        //    },
        //    data: permiso,
        //}).then(function successCallback(result) {
        //    $scope.tieneError = false;
        //    $scope.error = "";
        //    $scope.estaCargando = false;
        //}, function errorCallback(result) {
        //    $scope.tieneError = true;
        //    $scope.error = "Ha ocurrido un error al insertar: " + result;
        //    $scope.estaCargando = false;
        //});
        $scope.tieneError = false;
        $scope.error = "";
        $scope.estaCargando = true;
        PermisoFctr.InsertarPermiso(permiso)
            .then(function successCallback(response) {
                $scope.estaCargando = false;
            }, function errorCallback(response) {
                $scope.tieneError = true;
                $scope.error = "Ha ocurrido un error al insertar: " + response.data.Message;
                $scope.estaCargando = false;
            });
    };
});