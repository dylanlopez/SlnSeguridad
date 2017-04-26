myApp.factory('PersonaFctr', function ($http, webAPIControllers) {
    var persona = {};
    var urlBuscarPersona = webAPIControllers + '/api/Persona/BuscarPersona';

    var header = {
        'Content-Type': 'application/json'
    }

    persona.BuscarPersona = function (person) {
        return $http.post(urlBuscarPersona, person, header).then(function (response) {
            return response.data;
        });
    }

    return persona;
});