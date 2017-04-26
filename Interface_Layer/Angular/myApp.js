'use strict';
var myApp = angular.module('myApp', [])

myApp.constant('webAPIControllers', 'http://localhost:58309');

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
        Sistema: ''
    });
myApp.value('menu',
    {
        Id: '',
        Codigo: '',
        Nombre: '',
        Ruta: '',
        Descripcion: '',
        Estado: '',
        Modulo: ''
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
        Menu: '',
        Opcion: ''
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
        Sistema: '',
        Perfil: ''
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
        Perfil: '',
        Usuario: '',
        Rol: ''
    });
myApp.value('permission',
    {
        Id: '',
        FechaAlta: '',
        Estado: '',
        PerfilUsuarioRol: '',
        MenuOpcion: ''
    });