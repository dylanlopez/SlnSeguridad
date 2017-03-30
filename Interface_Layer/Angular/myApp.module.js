//'use strict';
var myApp = angular.module('myApp', ['ngRoute']);

myApp.config(['$routeProvider', function ($routeProvider) {
    $routeProvider
        .when('/', {
            redirectTo: '/login'
        })
        .when('/home', {
            templateUrl: '/Views/Index.html'
        })
        .when('/login', {
            templateUrl: '/Views/Login.html',
            controller: 'LoginCtrl'
        })
}])

myApp.constant('serviceBasePath', 'http://localhost:58309')

myApp.config(['$httpProvider', function ($httpProvider) {
    console.debug("interceptor");
    var interceptor = function (LoginSrv, $q, $location) {
        return {
            request: function (config) {
                var currentUser = LoginSrv.GetCurrentUser();
                if (currentUser != null) {
                    config.headers['Authorization'] = 'Bearer ' + currentUser.access_token;
                }
                return config;
            },
            responseError: function (rejection) {
                console.debug("rejection.status");
                console.debug(rejection.status);
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
    var params = ['LoginSrv', '$q', '$location'];
    interceptor.$inject = params;
    $httpProvider.interceptors.push(interceptor);
}]);