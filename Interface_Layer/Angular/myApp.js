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