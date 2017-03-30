'use strict';
myApp.factory('LoginSrv', function () {
    var fac = {};
    console.debug("LoginSrv");
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