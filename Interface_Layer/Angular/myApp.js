'use strict';
//var myApp = angular.module('myApp', [])
var myApp = angular.module('myApp', ['ngRoute']);

myApp.constant('webAPIControllers', 'http://localhost/MidisSeguridadDOF_API/');
//myApp.constant('webAPIControllers_Local', 'http://localhost:58309/');
//myApp.constant('webAPIControllers_DEV', 'http://localhost/MidisSeguridadDOF_API/');
//myApp.constant('webAPIControllers_QA', 'http://app_pruebas.midis.gob.pe/MidisSeguridadDOF_0API/');
//myApp.constant('webAPIControllers_PROD', 'http://sdv.midis.gob.pe/MidisSeguridadDOF_API/');
//myApp.constant('webAPIControllers_PROD', 'https://10.10.20.35/MidisSeguridadDOF_API/');

myApp.value('system',
    {
        Id: '',
        Codigo: '',
        Nombre: '',
        Abreviatura: '',
        Activo: '',
        Descripcion: '',
        NombreServidor: '',
        IPServidor: '',
        RutaFisica: '',
        RutaLogica: ''
    });

myApp.value('module',
    {
        Id: '',
        Codigo: '',
        Nombre: '',
        Abreviatura: '',
        Activo: '',
        Descripcion: '',
        Sistema: {
            Id: '',
            Codigo: '',
            Nombre: '',
            Abreviatura: '',
            Activo: '',
            Descripcion: '',
            NombreServidor: '',
            IPServidor: '',
            RutaFisica: '',
            RutaLogica: ''
        }
    });

myApp.value('menu',
    {
        Id: '',
        Codigo: '',
        Nombre: '',
        Ruta: '',
        Descripcion: '',
        Estado: '',
        Modulo: {
            Id: '',
            Codigo: '',
            Nombre: '',
            Abreviatura: '',
            Activo: '',
            Descripcion: '',
            Sistema: {
                Id: '',
                Codigo: '',
                Nombre: '',
                Abreviatura: '',
                Activo: '',
                Descripcion: '',
                NombreServidor: '',
                IPServidor: '',
                RutaFisica: '',
                RutaLogica: ''
            }
        }
    });

myApp.value('option',
    {
        Id: '',
        Nombre: '',
        NombreControlAsociado: '',
        Descripcion: ''
    });

myApp.value('menuoption',
    {
        Id: '',
        Activo: '',
        Visible: '',
        Menu: {
            Id: '',
            Codigo: '',
            Nombre: '',
            Ruta: '',
            Descripcion: '',
            Estado: '',
            Modulo: {
                Id: '',
                Codigo: '',
                Nombre: '',
                Abreviatura: '',
                Activo: '',
                Descripcion: '',
                Sistema: {
                    Id: '',
                    Codigo: '',
                    Nombre: '',
                    Abreviatura: '',
                    Activo: '',
                    Descripcion: '',
                    NombreServidor: '',
                    IPServidor: '',
                    RutaFisica: '',
                    RutaLogica: ''
                }
            }
        },
        Opcion: {
            Id: '',
            Nombre: '',
            NombreControlAsociado: '',
            Descripcion: ''
        }
    });

myApp.value('intitutiontype',
    {
        Id: '',
        Nombre: '',
        Descripcion: '',
        Activo: ''
    });

myApp.value('intitution',
    {
        Id: '', 
        Nombre: '',
        NombreCorto: '',
        Direccion: '',
        Activo: '',
        TipoInstitucion: {
            Id: '',
            Nombre: '',
            NombreControlAsociado: '',
            Descripcion: ''
        }
    });

myApp.value('user',
    {
        Id: '',
        Usuario: '',
        Contrasena: '',
        ApellidoPaterno: '',
        ApellidoMaterno: '',
        Nombres: '',
        Caduca: '',
        PeriodoCaducidad: '',
        FechaUltimoCambio: '',
        Ubigeo: '',
        CodigoVersion: '',
        PrimeraVez: '',
        UnicoIngreso: '',
        HaIngresado: '',
        OtrosLogeos: '',
        Tipo: '',
        Activo: '',
        Email: '',
        Institucion: {
            Id: '',
            Nombre: '',
            NombreCorto: '',
            Direccion: '',
            Activo: '',
            TipoInstitucion: {
                Id: '',
                Nombre: '',
                NombreControlAsociado: '',
                Descripcion: ''
            }
        }
    });

myApp.value('profile',
    {
        Id: '',
        Nombre: '',
        Descripcion: ''
    });

myApp.value('systemprofile',
    {
        Id: '',
        Activo: '',
        Sistema: {
            Id: '',
            Codigo: '',
            Nombre: '',
            Abreviatura: '',
            Activo: '',
            Descripcion: '',
            NombreServidor: '',
            IPServidor: '',
            RutaFisica: '',
            RutaLogica: ''
        },
        Perfil: {
            Id: '',
            Nombre: '',
            Descripcion: ''
        }
    });

myApp.value('role',
    {
        Id: '',
        Nombre: '',
        Descripcion: ''
    });

myApp.value('profileuserrole',
    {
        Id: '',
        Activo: '',
        Perfil: {
            Id: '',
            Nombre: '',
            Descripcion: ''
        },
        Usuario: {
            Id: '',
            Usuario: '',
            Contrasena: '',
            ApellidoPaterno: '',
            ApellidoMaterno: '',
            Nombres: '',
            Caduca: '',
            PeriodoCaducidad: '',
            FechaUltimoCambio: '',
            Ubigeo: '',
            CodigoVersion: '',
            PrimeraVez: '',
            UnicoIngreso: '',
            HaIngresado: '',
            OtrosLogeos: '',
            Tipo: '',
            Activo: '',
            Email: ''
        },
        Rol: {
            Id: '',
            Nombre: '',
            Descripcion: ''
        }
    });

myApp.value('permission',
    {
        Id: '',
        FechaAlta: '',
        Activo: '',
        PerfilUsuarioRol: {
            Id: '',
            Activo: '',
            Perfil: {
                Id: '',
                Nombre: '',
                Descripcion: ''
            },
            Usuario: {
                Id: '',
                Usuario: '',
                Contrasena: '',
                ApellidoPaterno: '',
                ApellidoMaterno: '',
                Nombres: '',
                Caduca: '',
                PeriodoCaducidad: '',
                FechaUltimoCambio: '',
                Ubigeo: '',
                CodigoVersion: '',
                PrimeraVez: '',
                UnicoIngreso: '',
                HaIngresado: '',
                OtrosLogeos: '',
                Tipo: '',
                Activo: '',
                Email: ''
            },
            Rol: {
                Id: '',
                Nombre: '',
                Descripcion: ''
            }
        },
        MenuOpcion: {
            Id: '',
            Activo: '',
            Visible: '',
            Menu: {
                Id: '',
                Codigo: '',
                Nombre: '',
                Ruta: '',
                Descripcion: '',
                Estado: '',
                Modulo: {
                    Id: '',
                    Codigo: '',
                    Nombre: '',
                    Abreviatura: '',
                    Activo: '',
                    Descripcion: '',
                    Sistema: {
                        Id: '',
                        Codigo: '',
                        Nombre: '',
                        Abreviatura: '',
                        Activo: '',
                        Descripcion: '',
                        NombreServidor: '',
                        IPServidor: '',
                        RutaFisica: '',
                        RutaLogica: ''
                    }
                }
            },
            Opcion: {
                Id: '',
                Nombre: '',
                NombreControlAsociado: '',
                Descripcion: ''
            }
        }
    });

myApp.config(['$routeProvider', function ($routeProvider) {
    $routeProvider
        .when('/', {
            redirectTo: '/login'
        })
        .when('/home', {
            templateUrl: 'Views/Index.html'
        })
        .when('/sistemas', {
            templateUrl: 'Views/Sistemas.html'
//            controller: 'SistemaCtrl'
        })
        .when('/modulos', {
            templateUrl: 'Views/Modulos.html'
//            controller: 'ModuloCtrl'
        })
        .when('/menus', {
            templateUrl: 'Views/Menus.html'
//            controller: 'MenuCtrl'
        })
        .when('/opciones', {
            templateUrl: 'Views/Opciones.html'
//            controller: 'OpcionCtrl'
        })
        .when('/menusopciones', {
            templateUrl: 'Views/MenusOpciones.html'
//            controller: 'MenuOpcionCtrl'
        })
        .when('/instituciones', {
            templateUrl: 'Views/Instituciones.html'
        })
        .when('/tiposinstitucion', {
            templateUrl: 'Views/TiposInstitucion.html'
        })
        .when('/perfiles', {
            templateUrl: 'Views/Perfiles.html'
//            controller: 'PerfilCtrl'
        })
        .when('/sistemasperfiles', {
            templateUrl: 'Views/SistemasPerfiles.html'
//            controller: 'SistemaPerfilCtrl'
        })
        .when('/usuarios', {
            templateUrl: 'Views/Usuarios.html'
//            controller: 'UsuarioCtrl'
        })
        .when('/roles', {
            templateUrl: 'Views/Roles.html'
//            controller: 'RolCtrl'
        })
        .when('/perfilesusuariosroles', {
            templateUrl: 'Views/PerfilesUsuariosRoles.html'
//            controller: 'PerfilUsuarioRolCtrl'
        })
        .when('/permisos', {
            templateUrl: 'Views/Permisos.html'
//            controller: 'PermisoCtrl'
        })
        .when('/authenticated', {
            templateUrl: 'login/authenticate.html'
//            controller: 'authenticateController'
        })
        //.when('/authenticated', {
        //    templateUrl: '/login/authenticate.html',
        //    controller: 'authenticateController'
        //})
        .when('/login', {
            templateUrl: 'login/login.html',
            controller: 'loginController'
        })
}])

myApp.controller('authenticateController', ['$scope', 'dataService', function ($scope, dataService) {
    //FETCH DATA FROM SERVICES
    //console.debug("authenticateController");

    $scope.data = "";
    dataService.GetAuthenticateData().then(function (data) {
        $scope.data = data;
        //$scope.data = "Holas Mundo";
    })
}])

myApp.controller('loginController', ['$rootScope', '$scope', 'accountService', 'userService', '$location', 'MenusFctr', function ($rootScope, $scope, accountService, userService, $location, MenusFctr) {
    //FETCH DATA FROM SERVICES
    //console.debug("loginController");
    //$scope.estaLogeado = false;

    $scope.account = {
        username: '',
        password: ''
    }
    $scope.message = "";

    var currentUser = userService.GetCurrentUser();
    //console.debug(currentUser);
    if (currentUser != null) {
        //config.headers['Authorization'] = 'Bearer ' + currentUser.access_token;
        //$rootScope.estaLogeado = true;
        //UsuarioLogeadoFctr.EstaLogeado = true;

        //console.info($rootScope.estaLogeado);
        //$scope.estaLogeado = UsuarioLogeadoFctr.EstaLogeado;
        $location.path('/home');
    }

    $scope.login = function () {
        accountService.login($scope.account).then(function (data) {
            //UsuarioLogeadoFctr.EstaLogeado = true;
            //console.info($scope.estaLogeado);
            //$scope.estaLogeado = UsuarioLogeadoFctr.EstaLogeado;

            //$rootScope.estaLogeado = true;
            //console.info($rootScope.estaLogeado);

            var passParam = { "Id": 1 };
            MenusFctr.ListarMenusSistema(passParam)
            .then(function successCallback(response) {
                $rootScope.modulos = response.Modulos;
            }, function errorCallback(response) {
            });

            $location.path('/home');
            //$scope.logi();
        }, function (error) {
            $scope.message = error.error_description;
        })
    }
}])

//services
myApp.factory('dataService', ['$http', 'webAPIControllers', function ($http, webAPIControllers) {
    var fac = {};
    console.debug("dataService");
    fac.GetAnonymousData = function () {
        console.debug("GetAnonymousData");
        return $http.get(webAPIControllers + 'api/data/forall').then(function (response) {
            return response.data;
        })
    }

    fac.GetAuthenticateData = function () {
        console.debug("GetAuthenticateData");
        return $http.get(webAPIControllers + 'api/data/authenticate').then(function (response) {
            return response.data;
        })
    }

    return fac;
}])

myApp.factory('userService', function () {
    var fac = {};
    //console.debug("userService");
    fac.CurrentUser = null;
    fac.SetCurrentUser = function (user) {
        //console.debug("SetCurrentUser");
        fac.CurrentUser = user;
        sessionStorage.user = angular.toJson(user);
    }
    fac.GetCurrentUser = function () {
        //console.debug("GetCurrentUser");
        fac.CurrentUser = angular.fromJson(sessionStorage.user);
        return fac.CurrentUser;
    }
    return fac;
})

myApp.factory('accountService', ['$http', '$q', 'webAPIControllers', 'userService', function ($http, $q, webAPIControllers, userService) {
    var fac = {};
    console.debug("accountService");
    fac.login = function (user) {
        var obj = { 'username': user.username, 'password': user.password, 'grant_type': 'password' };
        Object.toparams = function ObjectsToParams(obj) {
            var p = [];
            for (var key in obj) {
                p.push(key + '=' + encodeURIComponent(obj[key]));
            }
            return p.join('&');
        }

        var defer = $q.defer();
        $http({
            method: 'post',
            url: webAPIControllers + "token",
            data: Object.toparams(obj),
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
        }).then(function (response) {
            //console.debug(response);
            userService.SetCurrentUser(response.data);
            defer.resolve(response.data);
        }, function (error) {
            defer.reject(error.data);
        })
        return defer.promise;
    }

    fac.logout = function () {
        userService.CurrentUser = null;
        userService.SetCurrentUser(userService.CurrentUser);
    }
    return fac;
}])


myApp.factory('SistemaFctr', function ($http, $q, webAPIControllers) {
    var sistema = {};
    var urlListarSistemas = webAPIControllers + 'api/Sistema/ListarSistemas';
    var urlInsertarSistema = webAPIControllers + 'api/Sistema/InsertarSistema';
    var urlActualizarSistema = webAPIControllers + 'api/Sistema/ActualizarSistema';
    var header = {
        'Content-Type': 'application/json'
    }

    sistema.ListarSistemas = function (system) {
        var defer = $q.defer();
        $http.post(urlListarSistemas, system, header).then(function (response) {
            defer.resolve(response.data);
        }, function (error) {
            defer.reject(error.data);
        });
        return defer.promise;
    }

    sistema.InsertarSistema = function (system) {
        return $http.post(urlInsertarSistema, system, header).then(function (response) {
            return response.data;
        });
    }

    sistema.ActualizarSistema = function (system) {
        return $http.post(urlActualizarSistema, system, header).then(function (response) {
            return response.data;
        });
    }

    sistema.CleanSistema = function (system) {
        system.Id = null;
        system.Codigo = null;
        system.Nombre = null;
        system.Abreviatura = null;
        system.Activo = null;
        system.Descripcion = null;
        system.NombreServidor = null;
        system.IPServidor = null;
        system.RutaFisica = null;
        system.RutaLogica = null;
    }

    return sistema;
});

myApp.factory('ModuloFctr', function ($http, $q, webAPIControllers) {
    var modulo = {};
    var urlListarModulos = webAPIControllers + 'api/Modulo/ListarModulos';
    var urlInsertarModulo = webAPIControllers + 'api/Modulo/InsertarModulo';
    var urlActualizarModulo = webAPIControllers + 'api/Modulo/ActualizarModulo';
    var header = {
        'Content-Type': 'application/json'
    }

    modulo.ListarModulos = function (module) {
        var defer = $q.defer();
        $http.post(urlListarModulos, module, header).then(function (response) {
            defer.resolve(response.data);
        }, function (error) {
            defer.reject(error.data);
        });
        return defer.promise;
    }

    modulo.InsertarModulo = function (module) {
        return $http.post(urlInsertarModulo, module, header).then(function (response) {
            return response.data;
        });
    }

    modulo.ActualizarModulo = function (module) {
        return $http.post(urlActualizarModulo, module, header).then(function (response) {
            return response.data;
        });
    }

    modulo.CleanModulo = function (module) {
        module.Id = null;
        module.Codigo = null;
        module.Nombre = null;
        module.Abreviatura = null;
        module.Activo = null;
        module.Descripcion = null;
        module.Sistema.Id = null;
        module.Sistema.Codigo = null;
        module.Sistema.Nombre = null;
        module.Sistema.Abreviatura = null;
        module.Sistema.Activo = null;
        module.Sistema.Descripcion = null;
        module.Sistema.NombreServidor = null;
        module.Sistema.IPServidor = null;
        module.Sistema.RutaFisica = null;
        module.Sistema.RutaLogica = null;
    }

    return modulo;
});

myApp.factory('MenuFctr', function ($http, $q, webAPIControllers) {
    var menue = {};
    var urlListarMenus = webAPIControllers + 'api/Menu/ListarMenus';
    var urlInsertarMenu = webAPIControllers + 'api/Menu/InsertarMenu';
    var urlActualizarMenu = webAPIControllers + 'api/Menu/ActualizarMenu';
    var header = {
        'Content-Type': 'application/json'
    }

    menue.ListarMenus = function (menu) {
        var defer = $q.defer();
        $http.post(urlListarMenus, menu, header).then(function (response) {
            defer.resolve(response.data);
        }, function (error) {
            defer.reject(error.data);
        });
        return defer.promise;
    }

    menue.InsertarMenu = function (menu) {
        return $http.post(urlInsertarMenu, menu, header).then(function (response) {
            return response.data;
        });
    }

    menue.ActualizarMenu = function (menu) {
        return $http.post(urlActualizarMenu, menu, header).then(function (response) {
            return response.data;
        });
    }

    menue.CleanMenu = function (menu) {
        menu.Id = null;
        menu.Codigo = null;
        menu.Nombre = null;
        menu.Ruta = null;
        menu.Descripcion = null;
        menu.Activo = null;
        menu.Modulo.Id = null;
        menu.Modulo.Codigo = null;
        menu.Modulo.Nombre = null;
        menu.Modulo.Abreviatura = null;
        menu.Modulo.Activo = null;
        menu.Modulo.Descripcion = null;
        menu.Modulo.Sistema.Id = null;
        menu.Modulo.Sistema.Codigo = null;
        menu.Modulo.Sistema.Nombre = null;
        menu.Modulo.Sistema.Abreviatura = null;
        menu.Modulo.Sistema.Activo = null;
        menu.Modulo.Sistema.Descripcion = null;
        menu.Modulo.Sistema.NombreServidor = null;
        menu.Modulo.Sistema.IPServidor = null;
        menu.Modulo.Sistema.RutaFisica = null;
        menu.Modulo.Sistema.RutaLogica = null;
    }

    return menue;
});

myApp.factory('MenusFctr', function ($http, $q, webAPIControllers) {
//myApp.factory('MenusFctr', function ($http, $scope, $q, webAPIControllers) {
    var menue = {};
    var urlListarMenusSistema = webAPIControllers + '/api/Sistema/BuscarSistema';
    var header = {
        'Content-Type': 'application/json'
    }

    menue.ListarMenusSistema = function (menu) {
        var defer = $q.defer();
        $http.post(urlListarMenusSistema, menu, header).then(function (response) {
            defer.resolve(response.data);
        }, function (error) {
            defer.reject(error.data);
        });
        //$scope.modulos = defer.promise;
        return defer.promise;
    }

    return menue;
});

myApp.factory('OpcionFctr', function ($http, $q, webAPIControllers) {
    var opcion = {};
    var urlListarOpciones = webAPIControllers + 'api/Opcion/ListarOpciones';
    var urlInsertarOpcion = webAPIControllers + 'api/Opcion/InsertarOpcion';
    var urlActualizarOpcion = webAPIControllers + 'api/Opcion/ActualizarOpcion';
    var header = {
        'Content-Type': 'application/json'
    }

    opcion.ListarOpciones = function (option) {
        var defer = $q.defer();
        $http.post(urlListarOpciones, option, header).then(function (response) {
            defer.resolve(response.data);
        }, function (error) {
            defer.reject(error.data);
        });
        return defer.promise;
    }

    opcion.InsertarOpcion = function (option) {
        return $http.post(urlInsertarOpcion, option, header).then(function (response) {
            return response.data;
        });
    }

    opcion.ActualizarOpcion = function (option) {
        return $http.post(urlActualizarOpcion, option, header).then(function (response) {
            return response.data;
        });
    }

    opcion.CleanOpcion = function (option) {
        option.Id = null;
        option.Nombre = null;
        option.NombreControlAsociado = null;
        option.Descripcion = null;
    }

    return opcion;
});

myApp.factory('MenuOpcionFctr', function ($http, $q, webAPIControllers) {
    var menuopcion = {};
    var urlListarMenuOpciones = webAPIControllers + 'api/MenuOpcion/ListarMenuOpciones';
    var urlInsertarMenuOpcion = webAPIControllers + 'api/MenuOpcion/InsertarMenuOpcion';
    var urlActualizarMenuOpcion = webAPIControllers + 'api/MenuOpcion/ActualizarMenuOpcion';
    var header = {
        'Content-Type': 'application/json'
    }

    menuopcion.ListarMenuOpciones = function (menuoption) {
        var defer = $q.defer();
        $http.post(urlListarMenuOpciones, menuoption, header).then(function (response) {
            defer.resolve(response.data);
        }, function (error) {
            defer.reject(error.data);
        });
        return defer.promise;
    }

    menuopcion.InsertarMenuOpcion = function (menuoption) {
        return $http.post(urlInsertarMenuOpcion, menuoption, header).then(function (response) {
            return response.data;
        });
    }

    menuopcion.ActualizarMenuOpcion = function (menuoption) {
        return $http.post(urlActualizarMenuOpcion, menuoption, header).then(function (response) {
            return response.data;
        });
    }

    menuopcion.CleanMenuOpcion = function (menuoption) {
        menuoption.Id = null;
        menuoption.Estado = null;
        menuoption.Visible = null;
        menuoption.Menu.Id = null;
        menuoption.Menu.Codigo = null;
        menuoption.Menu.Nombre = null;
        menuoption.Menu.Ruta = null;
        menuoption.Menu.Descripcion = null;
        menuoption.Menu.Activo = null;
        menuoption.Menu.Modulo.Id = null;
        menuoption.Menu.Modulo.Codigo = null;
        menuoption.Menu.Modulo.Nombre = null;
        menuoption.Menu.Modulo.Abreviatura = null;
        menuoption.Menu.Modulo.Activo = null;
        menuoption.Menu.Modulo.Descripcion = null;
        menuoption.Menu.Modulo.Sistema.Id = null;
        menuoption.Menu.Modulo.Sistema.Codigo = null;
        menuoption.Menu.Modulo.Sistema.Nombre = null;
        menuoption.Menu.Modulo.Sistema.Abreviatura = null;
        menuoption.Menu.Modulo.Sistema.Activo = null;
        menuoption.Menu.Modulo.Sistema.Descripcion = null;
        menuoption.Menu.Modulo.Sistema.NombreServidor = null;
        menuoption.Menu.Modulo.Sistema.IPServidor = null;
        menuoption.Menu.Modulo.Sistema.RutaFisica = null;
        menuoption.Menu.Modulo.Sistema.RutaLogica = null;
        menuoption.Opcion.Id = null;
        menuoption.Opcion.Nombre = null;
        menuoption.Opcion.NombreControlAsociado = null;
        menuoption.Opcion.Descripcion = null;
    }

    return menuopcion;
});

myApp.factory('TipoInstitucionFctr', function ($http, $q, webAPIControllers) {
    var tipoinstitucion = {};
    var urlListarTipoInstitucion = webAPIControllers + 'api/TipoInstitucion/Listar';
    var urlInsertarTipoInstitucion = webAPIControllers + 'api/TipoInstitucion/Insertar';
    var urlActualizarTipoInstitucion = webAPIControllers + 'api/TipoInstitucion/Actualizar';
    var header = {
        'Content-Type': 'application/json'
    }

    tipoinstitucion.ListarTipoInstitucion = function (intitutiontype) {
        var defer = $q.defer();
        $http.post(urlListarTipoInstitucion, intitutiontype, header).then(function (response) {
            defer.resolve(response.data);
        }, function (error) {
            defer.reject(error.data);
        });
        return defer.promise;
    }

    tipoinstitucion.InsertarTipoInstitucion = function (intitutiontype) {
        return $http.post(urlInsertarTipoInstitucion, intitutiontype, header).then(function (response) {
            return response.data;
        });
    }

    tipoinstitucion.ActualizarTipoInstitucion = function (intitutiontype) {
        return $http.post(urlActualizarTipoInstitucion, intitutiontype, header).then(function (response) {
            return response.data;
        });
    }

    tipoinstitucion.CleanTipoInstitucion = function (intitutiontype) {
        intitutiontype.Id = null;
        intitutiontype.Nombre = null;
        intitutiontype.Activo = null;
        intitutiontype.Descripcion = null;
    }

    return tipoinstitucion;
});

myApp.factory('InstitucionFctr', function ($http, $q, webAPIControllers) {
    var institucion = {};
    var urlListarInstitucion = webAPIControllers + 'api/Institucion/Listar';
    var urlInsertarInstitucion = webAPIControllers + 'api/Institucion/Insertar';
    var urlActualizarInstitucion = webAPIControllers + 'api/Institucion/Actualizar';
    var header = {
        'Content-Type': 'application/json'
    }

    institucion.ListarInstitucion = function (intitution) {
        var defer = $q.defer();
        $http.post(urlListarInstitucion, intitution, header).then(function (response) {
            defer.resolve(response.data);
        }, function (error) {
            defer.reject(error.data);
        });
        return defer.promise;
    }

    institucion.InsertarInstitucion = function (intitution) {
        return $http.post(urlInsertarInstitucion, intitution, header).then(function (response) {
            return response.data;
        });
    }

    institucion.ActualizarInstitucion = function (intitution) {
        return $http.post(urlActualizarInstitucion, intitution, header).then(function (response) {
            return response.data;
        });
    }

    institucion.CleanInstitucion = function (intitution) {
        intitution.Id = null;
        intitution.Nombre = null;
        intitution.NombreCorto = null;
        intitution.Activo = null;
        intitution.Direccion = null;
        intitution.TipoInstitucion = null;
    }

    return institucion;
});

myApp.factory('PerfilFctr', function ($http, $q, webAPIControllers) {
    var perfil = {};
    var urlListarPerfiles = webAPIControllers + 'api/Perfil/ListarPerfiles';
    var urlInsertarPerfil = webAPIControllers + 'api/Perfil/InsertarPerfil';
    var urlActualizarPerfil = webAPIControllers + 'api/Perfil/ActualizarPerfil';
    var header = {
        'Content-Type': 'application/json'
    }

    perfil.ListarPerfiles = function () {
        var defer = $q.defer();
        $http.post(urlListarPerfiles, header).then(function (response) {
            defer.resolve(response.data);
        }, function (error) {
            defer.reject(error.data);
        });
        return defer.promise;
    }

    perfil.InsertarPerfil = function (profile) {
        return $http.post(urlInsertarPerfil, profile, header).then(function (response) {
            return response.data;
        });
    }

    perfil.ActualizarPerfil = function (profile) {
        return $http.post(urlActualizarPerfil, profile, header).then(function (response) {
            return response.data;
        });
    }

    perfil.CleanPerfil = function (profile) {
        profile.Id = null;
        profile.Nombre = null;
        profile.Descripcion = null;
    }

    return perfil;
});

myApp.factory('SistemaPerfilFctr', function ($http, $q, webAPIControllers) {
    var sistemaperfil = {};
    var urlListarSistemasPerfiles = webAPIControllers + 'api/SistemaPerfil/ListarSistemasPerfiles';
    var urlInsertarSistemaPerfil = webAPIControllers + 'api/SistemaPerfil/InsertarSistemaPerfil';
    var urlActualizarSistemaPerfil = webAPIControllers + 'api/SistemaPerfil/ActualizarSistemaPerfil';
    var header = {
        'Content-Type': 'application/json'
    }

    sistemaperfil.ListarSistemasPerfiles = function (systemprofile) {
        var defer = $q.defer();
        $http.post(urlListarSistemasPerfiles, systemprofile, header).then(function (response) {
            defer.resolve(response.data);
        }, function (error) {
            defer.reject(error.data);
        });
        return defer.promise;
    }

    sistemaperfil.InsertarSistemaPerfil = function (systemprofile) {
        return $http.post(urlInsertarSistemaPerfil, systemprofile, header).then(function (response) {
            return response.data;
        });
    }

    sistemaperfil.ActualizarSistemaPerfil = function (systemprofile) {
        return $http.post(urlActualizarSistemaPerfil, systemprofile, header).then(function (response) {
            return response.data;
        });
    }

    sistemaperfil.CleanSistemaPerfil = function (systemprofile) {
        systemprofile.Id = null;
        systemprofile.Estado = null;
        systemprofile.Sistema.Id = null;
        systemprofile.Sistema.Codigo = null;
        systemprofile.Sistema.Nombre = null;
        systemprofile.Sistema.Abreviatura = null;
        systemprofile.Sistema.Activo = null;
        systemprofile.Sistema.Descripcion = null;
        systemprofile.Sistema.NombreServidor = null;
        systemprofile.Sistema.IPServidor = null;
        systemprofile.Sistema.RutaFisica = null;
        systemprofile.Sistema.RutaLogica = null;
        systemprofile.Perfil.Id = null;
        systemprofile.Perfil.Nombre = null;
        systemprofile.Perfil.Descripcion = null;
    }

    return sistemaperfil;
});

myApp.factory('UbigeoFctr', function ($http, $q, webAPIControllers) {
    var ubigeo = {};
    //var urlListarDepartamentos = webAPIControllers + 'api/Ubigeo/ListarDepartamentos';
    var urlListarDepartamentos = 'http://200.48.102.17:28080/SistemaS100/listarDepartamento';
    //var urlListarProvincias = webAPIControllers + 'api/Ubigeo/ListarProvincias';
    var urlListarProvincias = 'http://200.48.102.17:28080/SistemaS100/listadoProvincias';
    //var urlListarDistritos = webAPIControllers + 'api/Ubigeo/ListarDistritos';
    var urlListarDistritos = 'http://200.48.102.17:28080/SistemaS100/listadoDistrito';

    var header = {
        'Content-Type': 'application/json'
    }

    ubigeo.ListarDepartamentos = function () {
        var defer = $q.defer();
        //console.info(urlListarDepartamentos);
        $http.post(urlListarDepartamentos, header).then(function (response) {
            //console.debug(response);
            defer.resolve(response.data);
        }, function (error) {
            //console.debug(error);
            defer.reject(error.data);
        });
        return defer.promise;
    }

    ubigeo.ListarProvincias = function (provinciaRequest) {
        var defer = $q.defer();
        $http.post(urlListarProvincias, provinciaRequest, header).then(function (response) {
            //console.debug(response);
            defer.resolve(response.data);
        }, function (error) {
            //console.debug(error);
            defer.reject(error.data);
        });
        return defer.promise;
    }

    ubigeo.ListarDistritos = function (distritoRequest) {
        var defer = $q.defer();
        $http.post(urlListarDistritos, distritoRequest, header).then(function (response) {
            defer.resolve(response.data);
        }, function (error) {
            //console.debug(error);
            defer.reject(error.data);
        });
        return defer.promise;
    }

    return ubigeo;
});

myApp.factory('PersonaFctr', function ($http, $q, webAPIControllers) {
    var persona = {};
    var urlBuscarPersona = webAPIControllers + 'api/Persona/BuscarPersona';

    var header = {
        'Content-Type': 'application/json'
    }

    persona.BuscarPersona = function (person) {
        return $http.post(urlBuscarPersona, person, header).then(function (response) {
            return response.data;
        });
    }

    return persona;
});

myApp.factory('UsuarioFctr', function ($http, $q, webAPIControllers) {
    var usuario = {};

    var urlListarUsuarios = webAPIControllers + 'api/Usuario/ListarUsuarios';
    var urlInsertarUsuario = webAPIControllers + 'api/Usuario/InsertarUsuario';
    var urlActualizarUsuario = webAPIControllers + 'api/Usuario/ActualizarUsuario';
    var urlBuscarUsuarioPorUsuario = webAPIControllers + 'api/Usuario/BuscarUsuarioPorUsuario';
    var header = {
        'Content-Type': 'application/json'
    }

    usuario.ListarUsuarios = function (user) {
        var defer = $q.defer();
        $http.post(urlListarUsuarios, user, header).then(function (response) {
            defer.resolve(response.data);
        }, function (error) {
            defer.reject(error.data);
        });
        return defer.promise;
    }

    usuario.InsertarUsuario = function (user) {
        return $http.post(urlInsertarUsuario, user, header).then(function (response) {
            return response.data;
        });
    }

    usuario.ActualizarUsuario = function (user) {
        return $http.post(urlActualizarUsuario, user, header).then(function (response) {
            return response.data;
        });
    }

    usuario.BuscarUsuarioPorUsuario = function (user) {
        return $http.post(urlBuscarUsuarioPorUsuario, user, header).then(function (response) {
            return response.data;
        });
    }

    usuario.CleanUsuario = function (user) {
        user.Id = null;
        user.Usuario = null;
        user.Contrasena = null;
        user.ApellidoPaterno = null;
        user.ApellidoMaterno = null;
        user.Nombres = null;
        user.Caduca = null;
        user.PeriodoCaducidad = null;
        user.FechaUltimoCambio = null;
        user.Ubigeo = null;
        user.CodigoVersion = null;
        user.UnicoIngreso = null;
        user.HaIngresado = null;
        user.OtrosLogeos = null;
        user.Tipo = null;
        user.Activo = null;
        user.Email = null;
    }

    return usuario;
});

myApp.factory('RolFctr', function ($http, $q, webAPIControllers) {
    var rol = {};
    var urlListarRoles = webAPIControllers + 'api/Rol/ListarRoles';
    var urlInsertarRol = webAPIControllers + 'api/Rol/InsertarRol';
    var urlActualizarRol = webAPIControllers + 'api/Rol/ActualizarRol';
    var header = {
        'Content-Type': 'application/json'
    }

    rol.ListarRoles = function (role) {
        var defer = $q.defer();
        $http.post(urlListarRoles, role, header).then(function (response) {
            defer.resolve(response.data);
        }, function (error) {
            defer.reject(error.data);
        });
        return defer.promise;
    }

    rol.InsertarRol = function (role) {
        return $http.post(urlInsertarRol, role, header).then(function (response) {
            return response.data;
        });
    }

    rol.ActualizarRol = function (role) {
        return $http.post(urlActualizarRol, role, header).then(function (response) {
            return response.data;
        });
    }

    rol.CleanRol = function (role) {
        role.Id = null;
        role.Nombre = null;
        role.Descripcion = null;
    }

    return rol;
});

myApp.factory('PerfilUsuarioRolFctr', function ($http, $q, webAPIControllers) {
    var perfilusuariorol = {};
    var urlListarPerfilesUsuariosRoles = webAPIControllers + 'api/PerfilUsuarioRol/ListarPerfilesUsuariosRoles';
    var urlInsertarPerfilUsuarioRol = webAPIControllers + 'api/PerfilUsuarioRol/InsertarPerfilUsuarioRol';
    var urlActualizarPerfilUsuarioRol = webAPIControllers + 'api/PerfilUsuarioRol/ActualizarPerfilUsuarioRol';
    var header = {
        'Content-Type': 'application/json'
    }

    perfilusuariorol.ListarPerfilesUsuariosRoles = function (profileuserrole) {
        var defer = $q.defer();
        $http.post(urlListarPerfilesUsuariosRoles, profileuserrole, header).then(function (response) {
            defer.resolve(response.data);
        }, function (error) {
            defer.reject(error.data);
        });
        return defer.promise;
    }

    perfilusuariorol.InsertarPerfilUsuarioRol = function (profileuserrole) {
        return $http.post(urlInsertarPerfilUsuarioRol, profileuserrole, header).then(function (response) {
            return response.data;
        });
    }

    perfilusuariorol.ActualizarPerfilUsuarioRol = function (profileuserrole) {
        return $http.post(urlActualizarPerfilUsuarioRol, profileuserrole, header).then(function (response) {
            return response.data;
        });
    }

    perfilusuariorol.CleanPerfilUsuarioRol = function (profileuserrole) {
        profileuserrole.Id = null;
        profileuserrole.Estado = null;
        profileuserrole.Perfil.Id = null;
        profileuserrole.Perfil.Nombre = null;
        profileuserrole.Perfil.Descripcion = null;
        profileuserrole.Usuario.Id = null;
        profileuserrole.Usuario.Usuario = null;
        profileuserrole.Usuario.Contrasena = null;
        profileuserrole.Usuario.ApellidoPaterno = null;
        profileuserrole.Usuario.ApellidoMaterno = null;
        profileuserrole.Usuario.Nombres = null;
        profileuserrole.Usuario.Caduca = null;
        profileuserrole.Usuario.PeriodoCaducidad = null;
        profileuserrole.Usuario.FechaUltimoCambio = null;
        profileuserrole.Usuario.Ubigeo = null;
        profileuserrole.Usuario.CodigoVersion = null;
        profileuserrole.Usuario.UnicoIngreso = null;
        profileuserrole.Usuario.HaIngresado = null;
        profileuserrole.Usuario.OtrosLogeos = null;
        profileuserrole.Usuario.Tipo = null;
        profileuserrole.Usuario.Activo = null;
        profileuserrole.Usuario.Email = null;
        profileuserrole.Rol.Id = null;
        profileuserrole.Rol.Nombre = null;
        profileuserrole.Rol.Descripcion = null;
    }

    return perfilusuariorol;
});

myApp.factory('PermisoFctr', function ($http, $q, webAPIControllers) {
    var permiso = {};
    var urlListarPermisos = webAPIControllers + 'api/Permiso/ListarPermisos';
    var urlInsertarPermiso = webAPIControllers + 'api/Permiso/InsertarPermiso';
    var urlActualizarPermiso = webAPIControllers + 'api/Permiso/ActualizarPermiso';
    var header = {
        'Content-Type': 'application/json'
    }

    permiso.ListarPermisos = function (permission) {
        var defer = $q.defer();
        $http.post(urlListarPermisos, permission, header).then(function (response) {
            defer.resolve(response.data);
        }, function (error) {
            defer.reject(error.data);
        });
        return defer.promise;
    }

    permiso.InsertarPermiso = function (permission) {
        return $http.post(urlInsertarPermiso, permission, header).then(function (response) {
            return response.data;
        });
    }

    permiso.ActualizarPermiso = function (permission) {
        return $http.post(urlActualizarPermiso, permission, header).then(function (response) {
            return response.data;
        });
    }

    permiso.CleanPermiso = function (permission) {
        permission.Id = null;
        permission.FechaAlta = null;
        permission.Estado = null;
        permission.PerfilUsuarioRol = null;
        permission.MenuOpcion = null;
    }

    return permiso;
});

myApp.factory('UsuarioLogeadoFctr', function () {
    this.EstaLogeado = false;
    return this;
});

//http interceptor
myApp.config(['$httpProvider', function ($httpProvider) {
    //console.debug("interceptor");
    var interceptor = function (userService, $q, $location) {
        return {
            request: function (config) {
                var currentUser = userService.GetCurrentUser();
                console.debug("currentUser");
                //console.debug(currentUser);
                if (currentUser != null) {
                    config.headers['Authorization'] = 'Bearer ' + currentUser.access_token;
                    //$location.path('/home');
                    //console.debug(currentUser.access_token);
                    //window.location = "Views/Index.html";
                }
                return config;
            },
            responseError: function (rejection) {
                if (rejection.status === 401) {
                    $location.path('/login');
                    return $q.reject(rejection);
                }
                if (rejection.status === 403) {
                    $location.path('/unauthorized');
                    return $q.reject(rejection);
                }
                return $q.reject(rejection);
            }

        }
    }
    var params = ['userService', '$q', '$location'];
    interceptor.$inject = params;
    $httpProvider.interceptors.push(interceptor);
}]);
