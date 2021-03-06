﻿//myApp.controller("UsuarioCtrl", function ($scope, $http, webAPIControllers) {
myApp.controller("UsuarioCtrl", function ($scope, $q, user, intitutiontype, intitution, 
                                          UbigeoFctr, UsuarioFctr, PersonaFctr, TipoInstitucionFctr, InstitucionFctr) {
    $scope.tiposinstitucion = [];
    $scope.instituciones = [];
    $scope.usuarios = [];
    $scope.persona = [];
    $scope.departamentos = [];
    $scope.provincias = [];
    $scope.distritos = [];
    $scope.estaCargando = true;
    $scope.estaEditable = false;
    $scope.tieneError = false;
    $scope.myusuario = [];

    $scope.buscarTipoInstitucion = function () {
        intitutiontype.Activo = 'S';
        TipoInstitucionFctr.ListarTipoInstitucion(intitutiontype)
            .then(function successCallback(response) {
                $scope.tiposinstitucion = response;
                $scope.tieneError = false;
                $scope.error = "";
                $scope.estaCargando = false;
            }, function errorCallback(response) {
                $scope.tieneError = true;
                $scope.error = "Ha ocurrido un error al listar: " + response;
                $scope.estaCargando = false;
            });
    };

    $scope.buscarTipoInstitucion();

    $scope.buscarInstituciones = function () {
        intitution.Activo = 'S';
        intitution.TipoInstitucion = $scope.myusuario.TipoInstitucion;
        InstitucionFctr.ListarInstitucion(intitution)
            .then(function successCallback(response) {
                $scope.instituciones = response;
                $scope.estaCargando = false;
            }, function errorCallback(response) {
                $scope.tieneError = true;
                $scope.error = "Ha ocurrido un error al listar: " + response;
                $scope.estaCargando = false;
            });
    };

    //$http({
    //    method: 'POST',
    //    url: webAPIControllers + '/api/Ubigeo/ListarDepartamentos',
    //    headers: {
    //        'Content-Type': 'application/json'
    //    }
    //}).then(function successCallback(result) {
    //    $scope.departamentos = result.data;
    //}, function errorCallback(result) {
    //    $scope.tieneError = true;
    //    $scope.error = "Ha ocuirrido un error al listar: " + result;
    //    $scope.estaCargando = false;
    //});

    $scope.buscarDepartamentos = function () {
        UbigeoFctr.ListarDepartamentos()
        .then(function successCallback(response) {
            //console.debug(response);
            //console.debug(response.promise);
            //console.debug(response.promise.value);
            //console.debug(response.promise.value.data);
            $scope.departamentos = response;
        }, function errorCallback(response) {
            $scope.tieneError = true;
            $scope.error = "Ha ocurrido un error al listar departamentos: " + response;
            $scope.estaCargando = false;
        });
    };

    $scope.buscarDepartamentos();

    $scope.buscarProvincias = function () {
        //$scope.tieneError = false;
        //$scope.error = "";
        $scope.estaCargando = true;
        var departamento =
            {
                "codigoDepartamento": '',
                "descripcionDepartamento": '',
                "codigoVersion": ''
            };
        if (angular.isUndefined($scope.myusuario.Departamento)) {
            $scope.tieneError = true;
            $scope.error = "Debe ingresar un departamento para poder ver sus provincias";
        } else {
            departamento = $scope.myusuario.Departamento;

            var provinciaRequest =
                {
                    "coDepartamento ": ''
                };

            provinciaRequest.coDepartamento = departamento.codigoDepartamento;
            //console.debug(departamento);
            //UbigeoFctr.ListarProvincias(departamento)
            UbigeoFctr.ListarProvincias(provinciaRequest)
                .then(function successCallback(response) {
                    //$q.all(response);
                    //console.debug(response);
                    $scope.provincias = response;
                    $scope.estaCargando = false;
               }, function errorCallback(response) {
                   $scope.tieneError = true;
                   $scope.error = "Ha ocurrido un error al listar provincias: " + response;
                   $scope.estaCargando = false;
                });
        }
        //console.debug(departamento);
        //$http({
        //    method: 'POST',
        //    url: webAPIControllers + '/api/Ubigeo/ListarProvincias',
        //    headers: {
        //        'Content-Type': 'application/json'
        //    },
        //    data: departamento,
        //}).then(function successCallback(result) {
        //    $scope.provincias = result.data;
        //    $scope.estaCargando = false;
        //}, function errorCallback(result) {
        //    $scope.tieneError = true;
        //    $scope.error = "Ha ocuirrido un error al listar: " + result;
        //    $scope.estaCargando = false;
        //});
    };

    $scope.buscarDistritos = function () {
        //$scope.tieneError = false;
        //$scope.error = "";
        $scope.estaCargando = true;
        var provincia =
        {
            "codigoProvincia": '',
            "codigoDepartamento": '',
            "descripcionProvincia": '',
            "codigoVersion": ''
        };
        if (angular.isUndefined($scope.myusuario.Provincia)) {
            $scope.tieneError = true;
            $scope.error = "Debe ingresar una provincia para poder ver sus distritos";
        } else {
            provincia = $scope.myusuario.Provincia;


            var distritoRequest =
                {
                    "coDepartamento ": '',
                    "coProvincia": ''
                };
            distritoRequest.coDepartamento = provincia.codigoDepartamento;
            distritoRequest.coProvincia = provincia.codigoProvincia;

            //UbigeoFctr.ListarDistritos(provincia)
            UbigeoFctr.ListarDistritos(distritoRequest)
                .then(function successCallback(response) {
                    $scope.distritos = response;
                    $scope.estaCargando = false;
                }, function errorCallback(response) {
                    $scope.tieneError = true;
                    $scope.error = "Ha ocurrido un error al listar provincias: " + response;
                    $scope.estaCargando = false;
                });
        }
        //$http({
        //    method: 'POST',
        //    url: webAPIControllers + '/api/Ubigeo/ListarDistritos',
        //    headers: {
        //        'Content-Type': 'application/json'
        //    },
        //    data: provincia,
        //}).then(function successCallback(result) {
        //    $scope.distritos = result.data;
        //    $scope.estaCargando = false;
        //}, function errorCallback(result) {
        //    $scope.tieneError = true;
        //    $scope.error = "Ha ocuirrido un error al listar: " + result;
        //    $scope.estaCargando = false;
        //});
    };

    $scope.buscar = function () {
        $scope.tieneError = false;
        $scope.error = "";
        $scope.estaCargando = true;
        //var user =
        //{
        //    "Id": '',
        //    "Usuario": '',
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
        //    "Activo": ''
        //};
        user.ApellidoPaterno = $scope.myusuario.ApellidoPaterno;
        user.ApellidoMaterno = $scope.myusuario.ApellidoMaterno;
        user.Nombres = $scope.myusuario.Nombres;
        if (!angular.isUndefined($scope.myusuario.Institucion) && $scope.myusuario.Institucion != null) {
            user.Institucion = $scope.myusuario.Institucion;
        }
        if (!angular.isUndefined($scope.myusuario.TipoInstitucion) && $scope.myusuario.TipoInstitucion != null) {
            user.Institucion.TipoInstitucion = $scope.myusuario.TipoInstitucion;
        }
        UsuarioFctr.ListarUsuarios(user)
            .then(function successCallback(response) {
                $scope.usuarios = response;
                $scope.estaCargando = false;
            }, function errorCallback(response) {
                $scope.tieneError = true;
                $scope.error = "Ha ocurrido un error al listar usuarios: " + response;
                $scope.estaCargando = false;
            });
        //$http({
        //    method: 'POST',
        //    url: webAPIControllers + '/api/Usuario/ListarUsuarios',
        //    headers: {
        //        'Content-Type': 'application/json'
        //    },
        //    data: user,
        //}).then(function successCallback(result) {
        //    $scope.usuarios = result.data;
        //    $scope.estaCargando = false;
        //}, function errorCallback(result) {
        //    $scope.tieneError = true;
        //    $scope.error = "Ha ocuirrido un error al listar: " + result;
        //    $scope.estaCargando = false;
        //});
    };

    $scope.buscarPersona = function () {
        $scope.tieneError = false;
        $scope.error = "";
        var person =
        {
            "Numero": '',
            "TipoDocumento": '',
            "NumeroDocumento": '',
            "ApellidoPaterno": '',
            "ApellidoMaterno": '',
            "Nombres": ''
        };
        person.TipoDocumento = "00030299";
        person.NumeroDocumento = $scope.myusuario.Usuario;
        //console.debug(person);
        PersonaFctr.BuscarPersona(person)
            .then(function successCallback(response) {
                //console.debug(person);
                if (response.ApellidoPaterno.length == 0 &&
                    response.ApellidoMaterno.length == 0 &&
                    response.Nombres.length == 0) {
                    $scope.tieneError = true;
                    $scope.error = "La persona no existe en la base de datos";
                    $scope.estaCargando = false;
                } else {
                    $scope.persona = response;
                    $scope.myusuario.ApellidoPaterno = $scope.persona.ApellidoPaterno;
                    $scope.myusuario.ApellidoMaterno = $scope.persona.ApellidoMaterno;
                    $scope.myusuario.Nombres = $scope.persona.Nombres;
                    $scope.estaCargando = false;
                }
            }, function errorCallback(response) {
                $scope.tieneError = true;
                $scope.error = "Ha ocurrido un error al buscar persona: " + response;
                $scope.estaCargando = false;
            });

        //$http({
        //    method: 'POST',
        //    url: webAPIControllers + '/api/Persona/BuscarPersona',
        //    headers: {
        //        'Content-Type': 'application/json'
        //    },
        //    data: person,
        //}).then(function successCallback(result) {
        //    //console.debug(result);
        //    $scope.persona = result.data;
        //    $scope.myusuario.ApellidoPaterno = $scope.persona.ApellidoPaterno;
        //    $scope.myusuario.ApellidoMaterno = $scope.persona.ApellidoMaterno;
        //    $scope.myusuario.Nombres = $scope.persona.Nombres;
        //    $scope.tieneError = false;
        //    $scope.error = "";
        //    $scope.estaCargando = false;
        //}, function errorCallback(result) {
        //    $scope.tieneError = true;
        //    $scope.error = "Ha ocuirrido un error al listar: " + result;
        //    $scope.estaCargando = false;
        //});
    };

    $scope.nuevo = function () {
        $scope.estaEditable = !$scope.estaEditable;
        $scope.myusuario.Id = "";
        if ($scope.estaEditable == false) {
            document.getElementById("txtUsuario").disabled = false;
            document.getElementById("btnBuscarUsuario").disabled = false;
            $scope.myusuario.TipoInstitucion = null;
            $scope.myusuario.Institucion = null;
            $scope.myusuario.Usuario = "";
            $scope.myusuario.Contrasena = "";
            //$scope.myusuario.ApellidoPaterno = "";
            //$scope.myusuario.ApellidoMaterno = "";
            //$scope.myusuario.Nombres = "";
            $scope.myusuario.Email = "";
            $scope.myusuario.Caduca = "";
            $scope.myusuario.EstaCaduca = false;
            $scope.myusuario.PeriodoCaducidad = "";
            $scope.myusuario.Distrito = null;
            $scope.myusuario.Provincia = null;
            $scope.myusuario.Departamento = null;
            $scope.myusuario.PrimeraVez = null;
            $scope.myusuario.UnicoIngreso = "";
            $scope.myusuario.HaIngresado = null;
            $scope.myusuario.EsUnicoIngreso = false;
            $scope.myusuario.OtrosLogeos = "";
            $scope.myusuario.TieneOtrosLogeos = false;
            $scope.myusuario.Tipo = "E";
            $scope.myusuario.Activo = "";
            $scope.myusuario.EstaActivo = false;
            UsuarioFctr.CleanUsuario(user)
        }
        $scope.myusuario.ApellidoPaterno = "";
        $scope.myusuario.ApellidoMaterno = "";
        $scope.myusuario.Nombres = "";
        $scope.usuarios = [];
        $scope.tieneError = false;
        $scope.error = "";
    };

    $scope.modificar = function (user) {
        $scope.estaEditable = !$scope.estaEditable;
        if ($scope.estaEditable == true) {
            document.getElementById("txtUsuario").disabled = true;
            document.getElementById("btnBuscarUsuario").disabled = true;
            $scope.myusuario.Id = user.Id;
            $scope.myusuario.Institucion = user.Institucion;
            $scope.myusuario.Usuario = user.Usuario;
            $scope.myusuario.Contrasena = user.Contrasena;
            $scope.myusuario.ApellidoPaterno = user.ApellidoPaterno;
            $scope.myusuario.ApellidoMaterno = user.ApellidoMaterno;
            $scope.myusuario.Nombres = user.Nombres;
            $scope.myusuario.Email = user.Email;
            if (user.Caduca == "S") {
                $scope.myusuario.EstaCaduca = true;
            } else if (user.Caduca == "N") {
                $scope.myusuario.EstaCaduca = false;
            }
            $scope.myusuario.PeriodoCaducidad = user.PeriodoCaducidad;
            //user.Ubigeo = $scope.myusuario.Departamento.codigoDepartamento + $scope.myusuario.Provincia.codigoProvincia + $scope.myusuario.Distrito.codigoDistrito;
            //console.debug($scope.myusuario.Departamento);
            //console.debug($scope.departamentos);
            //console.debug(user.Ubigeo);
            $scope.myusuario.PrimeraVez = user.PrimeraVez;
            $scope.myusuario.HaIngresado = user.HaIngresado;
            var codDepartamento = user.Ubigeo.substring(0, 2);
            var codProvincia = user.Ubigeo.substring(2, 4);
            var codDistrito = user.Ubigeo.substring(4, 6);
            //console.info(codDepartamento);
            //console.info(codProvincia);
            //console.info(codDistrito);

            //console.debug($scope.departamentos);
            angular.forEach($scope.departamentos, function (value) {
                if (value.codigoDepartamento == codDepartamento) {
                    $scope.myusuario.Departamento = value;
                    //$scope.buscarProvincias();

                    //console.debug(provincia);
                    //console.debug($scope.provincias);
                    //angular.forEach($scope.provincias, function (value2) {
                    //    console.debug(value2.codigoProvincia);
                    //    if (value2.codigoProvincia == provincia) {
                    //        $scope.myusuario.Provincia = value2;
                    //        $scope.buscarDistritos();
                    //    }
                    //});

                    //var searchProvinces = $scope.buscarProvincias()
                    //    .then(function successCallback(response) {
                    //        angular.forEach($scope.provincias, function (value) {
                    //            if (value.codigoProvincia == provincia) {
                    //                $scope.myusuario.Provincia = value;
                    //                $scope.buscarDistritos();
                    //            }
                    //        });
                    //    });
                    //$q.all($scope.buscarProvincias());

                    var departamento =
                        {
                            "codigoDepartamento": '',
                            "descripcionDepartamento": '',
                            "codigoVersion": ''
                        };
                    departamento.codigoDepartamento = codDepartamento;

                    var provinciaRequest =
                    {
                        "coDepartamento ": ''
                    };
                    provinciaRequest.coDepartamento = departamento.codigoDepartamento;

                    //UbigeoFctr.ListarProvincias(departamento)
                    UbigeoFctr.ListarProvincias(provinciaRequest)
                        .then(function successCallback(response) {
                            $scope.provincias = response;
                            angular.forEach($scope.provincias, function (value) {
                                if (value.codigoProvincia == codProvincia) {
                                    $scope.myusuario.Provincia = value;
                                    //$scope.buscarDistritos();

                                    var provincia =
                                    {
                                        "codigoProvincia": '',
                                        "codigoDepartamento": '',
                                        "descripcionProvincia": '',
                                        "codigoVersion": ''
                                    };
                                    provincia.codigoProvincia = codProvincia;
                                    provincia.codigoDepartamento = codDepartamento;

                                    var distritoRequest =
                                    {
                                        "coDepartamento ": '',
                                        "coProvincia": ''
                                    };
                                    distritoRequest.coDepartamento = provincia.codigoDepartamento;
                                    distritoRequest.coProvincia = provincia.codigoProvincia;

                                    //UbigeoFctr.ListarDistritos(provincia)
                                    UbigeoFctr.ListarDistritos(distritoRequest)
                                        .then(function successCallback(response) {
                                            $scope.distritos = response;
                                            angular.forEach($scope.distritos, function (value) {
                                                if (value.codigoDistrito == codDistrito) {
                                                    $scope.myusuario.Distrito = value;
                                                }
                                            });
                                            //$scope.estaCargando = false;
                                        }, function errorCallback(response) {
                                            $scope.tieneError = true;
                                            $scope.error = "Ha ocurrido un error al listar provincias: " + response;
                                            $scope.estaCargando = false;
                                        });
                                }
                            });

                            //$scope.myusuario.Provincia = value;
                            //$scope.estaCargando = false;
                        }, function errorCallback(response) {
                            $scope.tieneError = true;
                            $scope.error = "Ha ocurrido un error al listar provincias: " + response;
                            $scope.estaCargando = false;
                        });
                }
            });
            //console.debug($scope.provincias);
            //angular.forEach($scope.provincias, function (value) {
            //    if (value.codigoProvincia == provincia) {
            //        $scope.myusuario.Provincia = value;
            //        $scope.buscarDistritos();
            //    }
            //});
            //console.debug($scope.distritos);
            //angular.forEach($scope.distritos, function (value) {
            //    if (value.codigoDistrito == distrito) {
            //        $scope.myusuario.Distrito = value;
            //    }
            //});
            //$scope.myusuario.Departamento.codigoDepartamento = user.Ubigeo.substring(0, 2);

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
            if (user.Activo == "S") {
                $scope.myusuario.EstaActivo = true;
            } else if (user.Activo = "N") {
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
            $scope.myusuario.Activo = "S";
        }
        else {
            $scope.myusuario.Activo = "N";
        }
        var fecha = new Date();
        var dia = fecha.getDate().toString();
        if (dia.toString().length < 2) {
            dia = "0" + dia;
        }
        var mes = (fecha.getMonth() + 1).toString();
        if (mes.toString().length < 2) {
            mes = "0" + mes;
        }
        var anho = fecha.getFullYear().toString();
        var fechaUltimoCambio = dia + "/" + mes + "/" + anho;
        //console.info(fechaUltimoCambio);

        //var user =
        //{
        //    "Id": $scope.myusuario.Id,
        //    "Usuario": $scope.myusuario.Usuario,
        //    "Contrasena": $scope.myusuario.Contrasena,
        //    "ApellidoPaterno": $scope.myusuario.ApellidoPaterno,
        //    "ApellidoMaterno": $scope.myusuario.ApellidoMaterno,
        //    "Nombres": $scope.myusuario.Nombres,
        //    "Caduca": $scope.myusuario.Caduca,
        //    "PeriodoCaducidad": $scope.myusuario.PeriodoCaducidad,
        //    "FechaUltimoCambio": fechaUltimoCambio,
        //    "UnicoIngreso": $scope.myusuario.UnicoIngreso,
        //    "HaIngresado": 'N',
        //    "OtrosLogeos": $scope.myusuario.OtrosLogeos,
        //    "Tipo": $scope.myusuario.Tipo,
        //    "Activo": $scope.myusuario.Activo
        //};
        user.Id = $scope.myusuario.Id;
        user.Institucion = $scope.myusuario.Institucion;
        user.Usuario = $scope.myusuario.Usuario;
        user.Contrasena = $scope.myusuario.Contrasena;
        user.ApellidoPaterno = $scope.myusuario.ApellidoPaterno;
        user.ApellidoMaterno = $scope.myusuario.ApellidoMaterno;
        user.Nombres = $scope.myusuario.Nombres;
        user.Caduca = $scope.myusuario.Caduca;
        user.PeriodoCaducidad = $scope.myusuario.PeriodoCaducidad;
        //user.FechaUltimoCambio = $scope.myusuario.FechaUltimoCambio;
        user.FechaUltimoCambio = fechaUltimoCambio;
        user.Ubigeo = $scope.myusuario.Departamento.codigoDepartamento + $scope.myusuario.Provincia.codigoProvincia + $scope.myusuario.Distrito.codigoDistrito;
        user.CodigoVersion = $scope.myusuario.Departamento.codigoVersion;
        user.UnicoIngreso = $scope.myusuario.UnicoIngreso;
        user.OtrosLogeos = $scope.myusuario.OtrosLogeos;
        user.Tipo = $scope.myusuario.Tipo;
        user.Activo = $scope.myusuario.Activo;
        user.Email = $scope.myusuario.Email;
        //console.debug(user);
        if (user.Id == "") //nuevo (insert)
        {
            user.HaIngresado = 'N';
            user.PrimeraVez = 'S';
            UsuarioFctr.InsertarUsuario(user)
                .then(function successCallback(response) {
                    $scope.nuevo();
                    $scope.usuarios = [];
                    $scope.tieneError = false;
                    $scope.error = "";
                    $scope.estaCargando = false;
                }, function errorCallback(response) {
                    $scope.tieneError = true;
                    $scope.error = "Ha ocurrido un error al insertar: " + response.data.Message;
                    $scope.estaCargando = false;
                });
            //$http({
            //    method: 'POST',
            //    url: webAPIControllers + '/api/Usuario/InsertarUsuario',
            //    headers: {
            //        'Content-Type': 'application/json'
            //    },
            //    data: user,
            //}).then(function successCallback(result) {
            //    $scope.nuevo();
            //    $scope.usuarios = [];
            //    $scope.tieneError = false;
            //    $scope.error = "";
            //    $scope.estaCargando = false;
            //}, function errorCallback(result) {
            //    $scope.tieneError = true;
            //    $scope.error = "Ha ocuirrido un error al insertar: " + result;
            //    $scope.estaCargando = false;
            //});
        }
        else //actualizar (update)
        {
            user.HaIngresado = $scope.myusuario.HaIngresado;
            user.PrimeraVez = $scope.myusuario.PrimeraVez;
            UsuarioFctr.ActualizarUsuario(user)
                .then(function successCallback(response) {
                    $scope.nuevo();
                    $scope.usuarios = [];
                    $scope.tieneError = false;
                    $scope.error = "";
                    $scope.estaCargando = false;
                }, function errorCallback(response) {
                    $scope.tieneError = true;
                    $scope.error = "Ha ocurrido un error al insertar: " + response.data.Message;
                    $scope.estaCargando = false;
                });
            //$http({
            //    method: 'PUT',
            //    url: webAPIControllers + '/api/Usuario/ActualizarUsuario/' + user.Id,
            //    headers: {
            //        'Content-Type': 'application/json'
            //    },
            //    data: user,
            //}).then(function successCallback(result) {
            //    $scope.nuevo();
            //    $scope.usuarios = [];
            //    $scope.tieneError = false;
            //    $scope.error = "";
            //    $scope.estaCargando = false;
            //}, function errorCallback(result) {
            //    $scope.tieneError = true;
            //    $scope.error = "Ha ocuirrido un error al actualizar: " + result;
            //    $scope.estaCargando = false;
            //});
        }
    };
});