myApp.controller("MenuCtrl", function ($scope, $http) {
    alert('post');
    var passParam = { "Id": 1 };
    $scope.sistema = [];
    //$scope.sistemas = [];
    $scope.modulos = [];

    $http({
        method: 'POST', 
        url: '../api/Sistema/BuscarSistema', 
        data: passParam, 
    }).then(function successCallback(result) {
        console.log(result);
        //alert(result);
        //$scope.sistemas = result.data;
        $scope.sistema = result.data;


        //$scope.sistemas.forEach(function (obj, i) {
        //    console.log('Id: ' + obj.Nombre + '   i: ' + i);

        //    var dat = { "Id": obj.Id };

        //    //$http({
        //    //    method: 'POST',
        //    //    url: '../api/Modulo/ListarModulos',
        //    //    //data: { Id: obj.idSistema }
        //    //    data: dat
        //    //}).then(function successCallback(result) {
        //    //    console.log(result);
        //    //    //alert(result);
        //    //    $scope.modulos = result.data;
        //    //}, function errorCallback(result) {
        //    //    //alert('error');
        //    //    console.error(result);
        //    //});


        //});
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