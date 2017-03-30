myApp.controller("LoginCtrl", function ($scope, serviceBasePath, $location) {
    $scope.account = {
        username: '',
        password: ''
    }
    $scope.message = "";
    $scope.login = function () {
        AccountSrv.login($scope.account).then(function (data) {
            $location.path('/home');
        }, function (error) {
            $scope.message = error.error_description;
        })
    }
});