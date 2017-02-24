myApp.controller("MenuCtrl", function ($scope, $http) {
    //alert('iniciando');
    $scope.sistemas = [];
    $http({
        method: 'GET',
        url: '../api/Sistema/ListarSistemas',
    }).then(function successCallback(result) {
        console.log(result);
        //alert(result);
        $scope.sistemas = result.data;
    }, function errorCallback(result) {
        //alert('error');
        console.error(result);
    });

    //$http.get('http://localhost:55291/Services/Sistemas/SSistemaService.svc/ListarSistemas/')
    //    .then(function (response) {
    //        $scope.sistemas = response.data;
    //    });

    //$http.get('http://localhost:55291/Services/Sistemas/SModuloService.svc/ListarModulos/')
    //    .then(function (response) {
    //        $scope.modulos = response.data;
    //});
});