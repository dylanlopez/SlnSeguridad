//myApp.controller("MenusCtrl", function ($rootScope, $scope, $http, webAPIControllers, accountService, userService, $location) {
myApp.controller("MenusCtrl", function ($rootScope, $scope, $http, webAPIControllers, accountService, userService, $location, MenusFctr) {
    var passParam = { "Id": 1 };
    //$scope.modulos = [];
    //$rootScope.modulos = [];

    //$scope.estaLogeado = false;

    //var currentUser = userService.GetCurrentUser();
    //console.debug(currentUser);
    //if (currentUser != null) {
        //$scope.estaLogeado = true;
    //}

    //UsuarioLogeadoFctr.EstaLogeado = false;
    //$scope.estaLogeado = UsuarioLogeadoFctr.EstaLogeado;

    //$rootScope.estaLogeado = false;
    //console.info("Entrando a controlador de menu");
    //console.info($rootScope.estaLogeado);

    $scope.logout = function () {
        //UsuarioLogeadoFctr.EstaLogeado = false;
        //$scope.estaLogeado = UsuarioLogeadoFctr.EstaLogeado;
        //$rootScope.estaLogeado = false;
        //console.log();
        accountService.logout();
        $location.path('/login');
        //$rootScope.modulos = [];
    }

    //var passParam = { "Id": 1 };
    //MenusFctr.ListarMenusSistema(passParam)
    //.then(function successCallback(response) {
    //    //$scope.modulos = response.Modulos;
    //    $rootScope.modulos = response.Modulos;
    //}, function errorCallback(response) {
    //});

    //$scope.logi = function () {
    //    var passParam = { "Id": 1 };
    //    MenusFctr.ListarMenusSistema(passParam);
    //}

    //$http({
    //    method: 'POST', 
    //    //url: '../api/Sistema/BuscarSistema',
    //    url: webAPIControllers + '/api/Sistema/BuscarSistema',
    //    headers: {
    //        'Content-Type': 'application/json'
    //    },
    //    data: passParam,
    //}).then(function successCallback(result) {
    //    //console.log(result.data);
    //    //console.log(result.data.Modulos);
    //    $scope.modulos = result.data.Modulos;
    //}, function errorCallback(result) {
    //    console.error(result);
    //});
});