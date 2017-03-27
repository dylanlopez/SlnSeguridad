'use strict';
//var myApp = angular.module('myApp', []);
var myApp = angular.module('myApp', ['ngRoute', 'LocalStorageModule']);
//var app = angular.module('AngularAuthApp', ['ngRoute', 'LocalStorageModule', 'angular-loading-bar']);

//$routeProvider.when("/login", {
//    controller: "loginCtrl",
//    templateUrl: "/Views/Login.html"
//});



myApp.config(function ($routeProvider) {

    $routeProvider.when("/home", {
        controller: "MenusCtrl",
        templateUrl: "/Views/Index.html"
    });

    $routeProvider.when("/login", {
        controller: "loginCtrl",
        templateUrl: "/Views/Login.html"
    });

    $routeProvider.otherwise({ redirectTo: "/home" });

})
    .config(['$httpProvider', function ($httpProvider) {

        $httpProvider.interceptors.push(function ($q, $rootScope, $window, $location) {

            return {
                request: function (config) {

                    return config;
                },
                requestError: function (rejection) {

                    return $q.reject(rejection);
                },
                response: function (response) {
                    if (response.status == "401") {
                        $location.path('/login');
                    }
                    //the same response/modified/or a new one need to be returned.  
                    return response;
                },
                responseError: function (rejection) {

                    if (rejection.status == "401") {
                        $location.path('/login');
                    }
                    return $q.reject(rejection);
                }
            };
        });
    }]);
