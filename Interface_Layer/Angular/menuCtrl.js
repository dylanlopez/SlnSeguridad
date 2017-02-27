myApp.controller("MenuCtrl", function ($scope, $http) {
    alert('post');
    $scope.sistemas = [];
    $scope.modulos = [];

    $http({
        method: 'POST',
        url: '../api/Sistema/ListarSistemas',
    }).then(function successCallback(result) {
        //console.log(result);
        //alert(result);
        $scope.sistemas = result.data;

        $scope.sistemas.forEach(function (obj, i) {
            console.log('Id: ' + obj.Nombre + '   i: ' + i);
        });
    }, function errorCallback(result) {
        //alert('error');
        console.error(result);
    });

    

    //$http({
    //    method: 'GET',
    //    url: '../api/Modulo/ListarModulos',
    //}).then(function successCallback(result) {
    //    console.log(result);
    //    //alert(result);
    //    $scope.modulos = result.data;
    //}, function errorCallback(result) {
    //    //alert('error');
    //    console.error(result);
    //});


    //$http.get('http://localhost:55291/Services/Sistemas/SSistemaService.svc/ListarSistemas/')
    //    .then(function (response) {
    //        $scope.sistemas = response.data;
    //    });

    //$http.get('http://localhost:55291/Services/Sistemas/SModuloService.svc/ListarModulos/')
    //    .then(function (response) {
    //        $scope.modulos = response.data;
    //});
});