'use strict';
myApp.factory('AccountSrv', ['$http', '$q', 'serviceBasePath', 'LoginSrv', function ($http, $q, serviceBasePath, LoginSrv) {
    var fac = {};
    console.debug("AccountSrv");
    fac.login = function (user) {
        var obj =
            {
                'username': user.username,
                'password': user.password,
                'grant_type': 'password'
            };
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
            LoginSrv.SetCurrentUser(response.data);
            defer.resolve(response.data);
        }, function (error) {
            defer.reject(error.data);
        })
        return defer.promise;
    }
    fac.logout = function () {
        LoginSrv.CurrentUser = null;
        LoginSrv.SetCurrentUser(LoginSrv.CurrentUser);
    }
    return fac;
}])