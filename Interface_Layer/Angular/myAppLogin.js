'use strict';
var myAppLogin = angular.module('myAppLogin', ['ngRoute']);

myAppLogin.config(['$routeProvider', function ($routeProvider) {
    $routeProvider
        .when('/', {
            redirectTo: '/authenticated'
        })
        .when('/home', {
            templateUrl: '/Views/Index.html',
            controller: 'MenusCtrl'
        })
        .when('/authenticated', {
            templateUrl: '/login/authenticate.html',
            controller: 'authenticateController'
        })
        //.when('/authenticated', {
        //    templateUrl: '/login/authenticate.html',
        //    controller: 'authenticateController'
        //})
        .when('/login', {
            templateUrl: '/login/login.html',
            controller: 'loginController'
        })
}])

//constant
myAppLogin.constant('serviceBasePath', 'http://localhost:58309')

//controllers
//myAppLogin.controller('homeController', ['$scope', 'dataService', function ($scope, dataService) {
//    //FETCH DATA FROM SERVICES
//    console.debug("homeController");
//    $scope.data = "";
//    dataService.GetAnonymousData().then(function (data) {
//        $scope.data = data;
//    })
//}])
myAppLogin.controller('authenticateController', ['$scope', 'dataService', function ($scope, dataService) {
    //FETCH DATA FROM SERVICES
    console.debug("authenticateController");
    $scope.data = "";
    dataService.GetAuthenticateData().then(function (data) {
        $scope.data = data;
        //$scope.data = "Holas Mundo";
    })
}])
myAppLogin.controller('loginController', ['$scope', 'accountService', '$location', function ($scope, accountService, $location) {
    //FETCH DATA FROM SERVICES
    console.debug("loginController");
    $scope.account = {
        username: '',
        password: ''
    }
    $scope.message = "";
    $scope.login = function () {
        accountService.login($scope.account).then(function (data) {
            $location.path('/home');
        }, function (error) {
            $scope.message = error.error_description;
        })
    }
}])

//services
myAppLogin.factory('dataService', ['$http', 'serviceBasePath', function ($http, serviceBasePath) {
    var fac = {};
    console.debug("dataService");
    fac.GetAnonymousData = function () {
        console.debug("GetAnonymousData");
        return $http.get(serviceBasePath + '/api/data/forall').then(function (response) {
            return response.data;
        })
    }

    fac.GetAuthenticateData = function () {
        console.debug("GetAuthenticateData");
        return $http.get(serviceBasePath + '/api/data/authenticate').then(function (response) {
            return response.data;
        })
    }

    //fac.GetAuthorizeData = function () {
    //    console.debug("GetAuthorizeData");
    //    return $http.get(serviceBasePath + '/api/data/authorize').then(function (response) {
    //        console.debug(response);
    //        return response.data;
    //    })
    //}
    return fac;
}])
myAppLogin.factory('userService', function () {
    var fac = {};
    console.debug("userService");
    fac.CurrentUser = null;
    fac.SetCurrentUser = function (user) {
        console.debug("SetCurrentUser");
        fac.CurrentUser = user;
        sessionStorage.user = angular.toJson(user);
    }
    fac.GetCurrentUser = function () {
        console.debug("GetCurrentUser");
        fac.CurrentUser = angular.fromJson(sessionStorage.user);
        return fac.CurrentUser;
    }
    return fac;
})
myAppLogin.factory('accountService', ['$http', '$q', 'serviceBasePath', 'userService', function ($http, $q, serviceBasePath, userService) {
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
            url: serviceBasePath + "/token",
            data: Object.toparams(obj),
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
        }).then(function (response) {
            console.debug(response);
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

//http interceptor
myAppLogin.config(['$httpProvider', function ($httpProvider) {
    console.debug("interceptor");
    var interceptor = function (userService, $q, $location) {
        return {
            request: function (config) {
                var currentUser = userService.GetCurrentUser();
                console.debug("currentUser");
                console.debug(currentUser);
                if (currentUser != null) {
                    config.headers['Authorization'] = 'Bearer ' + currentUser.access_token;
                    console.debug(currentUser.access_token);
                    window.location = "Views/Index.html";
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