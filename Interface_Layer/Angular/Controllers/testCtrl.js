myApp.controller("TestCtrl", function ($scope, $http, webAPIControllers) {
    $scope.acreditaciones = [];
    

    $scope.buscar = function () {
        var acreditacionUPSRequest =
        {
            "Usuario": '41172516',
            "Contrasena": '12345678',
            "CodigoSistema": '50'
        };

        $http({
            method: 'POST',
            url: webAPIControllers + 'api/Test/Acreditar/',
            headers: {
                'Content-Type': 'application/json'
            },
            data: acreditacionUPSRequest
        }).then(function successCallback(response) {
            //console.info("hola");
            //console.log(response);
            var datos = response.data;
            var result = response.data.Result;
            //console.log(datos);
            //console.log(result);
            for (var a = 0; a < result.length; a++) {
                var sistemas = result[a].Sistemas;
                //console.log(sistemas);
                for (var e = 0; e < sistemas.length; e++) {
                    var modulos = sistemas[e].Modulos;
                    //console.log(modulos);
                    for (var i = 0; i < modulos.length; i++) {
                        var menus = modulos[i].Menus;
                        //console.log(menus);
                        for (var o = 0; o < menus.length; o++) {
                            var opciones = menus[o].Opciones;
                            //console.log(opciones);
                            for (var u = 0; u < opciones.length; u++) {
                                var opcion = opciones[u];
                                //console.log(opcion);
                                $scope.acreditaciones.push(opcion);
                            }
                            
                        }
                        
                    }
                    
                }
            }
            console.log($scope.acreditaciones);
        }, function errorCallback(result) {
            $scope.tieneError = true;
        });
    };
});