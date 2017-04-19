myApp.controller("PermisoCtrl", function ($scope, $http, webAPIControllers) {
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
        $scope.error = "Ha ocuirrido un error al listar perfiles: " + result;
        $scope.estaCargando = false;
    });

    $scope.buscarUsuario = function () {
        if ($scope.mypermiso.Usuario == '44481138') {
            $scope.myusuario.Id = "1";
            $scope.myusuario.ApellidoPaterno = "LOPEZ";
            $scope.myusuario.ApellidoMaterno = "ENCISO";
            $scope.myusuario.Nombres = "DYLAN";
            $scope.myusuario.NombresCompletos = "LOPEZ ENCISO DYLAN";
        } else if ($scope.mypermiso.Usuario == '32991309') {
            $scope.myusuario.Id = "2";
            $scope.myusuario.ApellidoPaterno = "VASQUEZ";
            $scope.myusuario.ApellidoMaterno = "RAMIREZ";
            $scope.myusuario.Nombres = "ALEX";
            $scope.myusuario.NombresCompletos = "VASQUEZ RAMIREZ ALEX";
        }
    };

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

    $scope.buscarRolesUsuariosPerfiles = function () {
        if (angular.isUndefined($scope.mypermiso.Perfil) &&
            angular.isUndefined($scope.mypermiso.Usuario) &&
            angular.isUndefined($scope.mypermiso.Rol)) {
            $scope.tieneError = true;
            $scope.error = "Debe ingresar un perfil o usuario o rol para poder buscar";
        }
        else {
            $scope.tieneError = false;
            $scope.error = "";

            var user =
            {
                "Id": $scope.myusuario.Id,
                "Usuario": $scope.mypermiso.Usuario,
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
                "Perfil": $scope.mypermiso.Perfil,
                //"Usuario": $scope.myperfilusuariorol.Usuario,
                "Usuario": user,
                "Rol": $scope.mypermiso.Rol
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


    //MenusOpciones
    $http({
        method: 'POST',
        url: webAPIControllers + '/api/Sistema/ListarSistemas',
    }).then(function successCallback(result) {
        $scope.sistemas = result.data;
        $scope.tieneError = false;
        $scope.error = "";
        $scope.estaCargando = false;
    }, function errorCallback(result) {
        $scope.tieneError = true;
        $scope.error = "Ha ocurrido un error al listar: " + result;
        $scope.estaCargando = false;
    });

    $scope.buscarModulo = function () {
        if (angular.isUndefined($scope.mypermiso.Sistema)) {
            $scope.tieneError = true;
            $scope.error = "Debe ingresar un sistema para poder ver sus módulos";
        }
        else {
            $scope.tieneError = false;
            $scope.error = "";

            var module =
                {
                    "Id": '',
                    "Codigo": '',
                    "Nombre": '',
                    "Abreviatura": '',
                    "Descripcion": '',
                    "Estado": '',
                    "Sistema": $scope.mypermiso.Sistema
                };

            $http({
                method: 'POST',
                url: webAPIControllers + '/api/Modulo/ListarModulos',
                headers: {
                    'Content-Type': 'application/json'
                },
                data: module,
            }).then(function successCallback(result) {
                $scope.modulos = result.data;
                $scope.estaCargando = false;
            }, function errorCallback(result) {
                $scope.tieneError = true;
                $scope.error = "Ha ocurrido un error al listar: " + result;
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
            $scope.tieneError = false;
            $scope.error = "";

            var menu =
            {
                "Id": '',
                "Codigo": '',
                "Nombre": '',
                "Ruta": '',
                "Descripcion": '',
                "Estado": '',
                "Modulo": $scope.mypermiso.Modulo
            };

            $http({
                method: 'POST',
                url: webAPIControllers + '/api/Menu/ListarMenus',
                headers: {
                    'Content-Type': 'application/json'
                },
                data: menu,
            }).then(function successCallback(result) {
                $scope.menus = result.data;
                $scope.estaCargando = false;
            }, function errorCallback(result) {
                $scope.tieneError = true;
                $scope.error = "Ha ocurrido un error al listar: " + result;
                $scope.estaCargando = false;
            });
        }
    };

    $scope.buscarMenuesOpciones = function () {
        if (angular.isUndefined($scope.mypermiso.Sistema) &&
            angular.isUndefined($scope.mypermiso.Modulo) &&
            angular.isUndefined($scope.mypermiso.Menu)) {
            $scope.tieneError = true;
            $scope.error = "Debe ingresar un sistema, módulo y menú para poder ver sus opciones";
        }
        else {
            $scope.tieneError = false;
            $scope.error = "";

            var menuopcion =
            {
                "Id": '',
                "Estado": '',
                "Visible": '',
                "Menu": $scope.mypermiso.Menu,
                "Opcion": ''
            };

            $http({
                method: 'POST',
                url: webAPIControllers + '/api/MenuOpcion/ListarMenuOpciones',
                headers: {
                    'Content-Type': 'application/json'
                },
                data: menuopcion,
            }).then(function successCallback(result) {
                $scope.menuesopciones = result.data;
                $scope.estaCargando = false;
            }, function errorCallback(result) {
                $scope.tieneError = true;
                $scope.error = "Ha ocurrido un error al listar: " + result;
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
        //console.info("buscar");
        var permiso =
            {
                "Id": '',
                "FechaAlta": '',
                "Estado": '',
                "PerfilUsuarioRol": {},
                "MenuOpcion": {}
            };
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

        var menuopcion =
        {
            "Id": '',
            "Estado": '',
            "Visible": '',
            "Menu": {},
            "Opcion": {}
        };
        if (!angular.isUndefined($scope.mypermiso.Menu)) {
            console.debug("Undefined 1");
            menuopcion.Menu = $scope.mypermiso.Menu;
        } else {
            if (!angular.isUndefined($scope.mypermiso.Modulo)) {
                console.debug("Undefined 2");
                var menu =
                {
                    "Id": '',
                    "Codigo": '',
                    "Nombre": '',
                    "Ruta": '',
                    "Descripcion": '',
                    "Estado": '',
                    "Modulo": $scope.mypermiso.Modulo
                };
                menuopcion.Menu = menu;
            } else {
                if (!angular.isUndefined($scope.mypermiso.Sistema)) {
                    console.debug("Undefined 3");
                    var module =
                    {
                        "Id": '',
                        "Codigo": '',
                        "Nombre": '',
                        "Abreviatura": '',
                        "Estado": '',
                        "Descripcion": '',
                        "Sistema": $scope.mypermiso.Sistema
                    };
                    var menu =
                    {
                        "Id": '',
                        "Codigo": '',
                        "Nombre": '',
                        "Ruta": '',
                        "Descripcion": '',
                        "Estado": '',
                        "Modulo": module
                    };
                    menuopcion.Menu = menu;
                }
            }
        }
        console.debug($scope.rolUsuarioPerfilSeleccionado);
        //console.debug(perfilusuariorol);
        permiso.PerfilUsuarioRol = $scope.rolUsuarioPerfilSeleccionado;
        //permiso.PerfilUsuarioRol = perfilusuariorol;
        console.debug(menuopcion);
        permiso.MenuOpcion = menuopcion;
        console.debug(permiso);
        $http({
            method: 'POST',
            url: webAPIControllers + '/api/Permiso/ListarPermisos',
            headers: {
                'Content-Type': 'application/json'
            },
            data: permiso,
        }).then(function successCallback(result) {
            $scope.permisos = result.data;
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

    $scope.agregaOpcionMenu = function () {
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
        
        var permiso =
            {
                "Id": '',
                "FechaAlta": fechaUltimoCambio,
                "Estado": 'S',
                "PerfilUsuarioRol": $scope.rolUsuarioPerfilSeleccionado,
                "MenuOpcion": $scope.menuOpcionSeleccionado
            };
        var repetido = false;
        angular.forEach($scope.permisos, function (value) {
            if (value.PerfilUsuarioRol.Id == permiso.PerfilUsuarioRol.Id &&
                value.MenuOpcion.Id == permiso.MenuOpcion.Id) {
                repetido = true;
            }
        });
        if (!repetido) {
            $scope.permisos.push(permiso);
            $scope.tieneError = false;
            $scope.error = "";
        } else {
            $scope.tieneError = true;
            $scope.error = "Ha ocurrido un error, al agregar el menu al rol. Ya se encuentra ingresado";
        }
    };

    $scope.cambiarEstado = function (permiso) {
        $scope.estaCargando = true;
        console.debug(permiso);
        if (permiso.Id != '') {
            if (permiso.Estado == 'S') {
                permiso.Estado = 'N';
            } else if (permiso.Estado == 'N') {
                permiso.Estado = 'S';
            }
            $http({
                method: 'PUT',
                url: webAPIControllers + '/api/Permiso/ActualizarPermiso/' + permiso.Id,
                headers: {
                    'Content-Type': 'application/json'
                },
                data: permiso,
            }).then(function successCallback(result) {
                $scope.tieneError = false;
                $scope.error = "";
                $scope.estaCargando = false;
            }, function errorCallback(result) {
                $scope.tieneError = true;
                $scope.error = "Ha ocurrido un error al actualizar: " + result;
                $scope.estaCargando = false;
            });
        } else {
            $scope.tieneError = true;
            $scope.error = "No se puede cambiar de estado un permiso que aun no ha sido ingresado, guardelo primero";
        }
    };

    $scope.guardar = function (permiso) {
        $scope.estaCargando = true;
        $http({
            method: 'POST',
            url: webAPIControllers + '/api/Permiso/InsertarPermiso',
            headers: {
                'Content-Type': 'application/json'
            },
            data: permiso,
        }).then(function successCallback(result) {
            $scope.tieneError = false;
            $scope.error = "";
            $scope.estaCargando = false;
        }, function errorCallback(result) {
            $scope.tieneError = true;
            $scope.error = "Ha ocurrido un error al insertar: " + result;
            $scope.estaCargando = false;
        });
    };
});