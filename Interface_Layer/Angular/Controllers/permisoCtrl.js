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
    $scope.mymenuopcion = [];

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
        if (angular.isUndefined($scope.mymenuopcion.Sistema)) {
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
                    "Sistema": $scope.mymenuopcion.Sistema
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
        if (angular.isUndefined($scope.mymenuopcion.Sistema) &&
            angular.isUndefined($scope.mymenuopcion.Modulo)) {
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
                "Modulo": $scope.mymenuopcion.Modulo
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
        if (angular.isUndefined($scope.mymenuopcion.Sistema) &&
            angular.isUndefined($scope.mymenuopcion.Modulo) &&
            angular.isUndefined($scope.mymenuopcion.Menu)) {
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
                "Menu": $scope.mymenuopcion.Menu,
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

    $scope.buscar = function (rolusuarioperfil, index) {
        $scope.rolUsuarioPerfilSeleccionado = rolusuarioperfil;
        $scope.selectedRolUsuarioPerfil = index;
    };

    $scope.seleccionaMenuOpcion = function (menuopcion, index) {
        $scope.menuOpcionSeleccionado = menuopcion;
        $scope.selectedMenuOpcion = index;
    };

    $scope.agregaOpcionMenu = function () {
        $scope.tieneError = false;
        $scope.error = "";
        /*
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
        */
        var permiso =
            {
                "Id": '',
                "FechaAlta": '',
                "Estado": '',
                "PerfilUsuarioRol": $scope.rolUsuarioPerfilSeleccionado,
                "MenuOpcion": $scope.menuOpcionSeleccionado
            };
        var repetido = false;
        angular.forEach($scope.permisos, function (value) {
            if (value.PerfilUsuarioRol.Id == permiso.PerfilUsuarioRol.Id && value.MenuOpcion.Id == permiso.MenuOpcion.Id) {
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
});