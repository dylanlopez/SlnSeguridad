'use strict';
var myApp = angular.module('myApp', [])

myApp.constant('webAPIControllers', 'http://localhost/MidisSeguridadDOF_API/');
//myApp.constant('webAPIControllers_Local', 'http://localhost:58309/');
//myApp.constant('webAPIControllers_IIS', 'http://localhost/MidisSeguridadDOF_API/');
//myApp.constant('webAPIControllers_QA', 'http://app_pruebas.midis.gob.pe/Interface_Layer_API/');

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
        Email: ''
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