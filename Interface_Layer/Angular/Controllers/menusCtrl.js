﻿myApp.controller("MenusCtrl", function ($scope, $http, webAPIControllers) {
    var passParam = { "Id": 1 };
    $scope.modulos = [];

    $http({
        method: 'POST', 
        //url: '../api/Sistema/BuscarSistema',
        url: webAPIControllers + '/api/Sistema/BuscarSistema',
        headers: {
            'Content-Type': 'application/json'
        },
        data: passParam, 
    }).then(function successCallback(result) {
        //console.log(result.data);
        //console.log(result.data.Modulos);
        $scope.modulos = result.data.Modulos;
    }, function errorCallback(result) {
        console.error(result);
    });
});