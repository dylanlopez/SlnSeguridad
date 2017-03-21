myApp.controller("MenuRolCtrl", function ($scope, $http) {
    $scope.personas = [];
    $scope.menusroles = [];
    $scope.roles = [{ "Id": '1', "Nombre": 'Admin' },
                        { "Id": '2', "Nombre": 'Contable' }];

    $scope.seleccionaPersona = function (persona) {
        //$scope.personaNombre = persona.Nombre;
        $scope.personaSeleccionada = persona;
    };

    $scope.seleccionaRol = function (rol) {
        $scope.personas = [{ "Id": '1', "Nombre": 'Dylan' },
                        { "Id": '2', "Nombre": 'Alejandro' },
                        { "Id": '3', "Nombre": 'Lopez' }];
        //$scope.rolNombre = rol.Nombre;
        $scope.rolSeleccionado = rol;
    };

    $scope.selecciona = function (personaSeleccionada, rolSeleccionado) {
        $scope.menusroles = [{ "Persona": personaSeleccionada.Nombre, "Rol": rolSeleccionado.Nombre }];
    };
});