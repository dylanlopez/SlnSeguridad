myApp.factory('UbigeoFctr', function ($http, webAPIControllers) {
    var ubigeo = {};
    var urlListarDepartamentos = webAPIControllers + 'api/Ubigeo/ListarDepartamentos';
    var urlListarProvincias = webAPIControllers + 'api/Ubigeo/ListarProvincias';
    var urlListarDistritos = webAPIControllers + 'api/Ubigeo/ListarDistritos';

    var header = {
        'Content-Type': 'application/json'
    }
    //var deferred = $q.defer();

    ubigeo.ListarDepartamentos = function () {
        return $http.post(urlListarDepartamentos, header).then(function (response) {
            return response.data;
        });
        //return $http.post(urlListarDepartamentos, header){
        //    return response.data;
        //}
            //.then(function (response) {
              //.then(function successCallback(response) {
              //    //deferred.resolve({
              //    //    data: response.data
              //    //});
              //    //return deferred;
              //    //console.debug(response);
              //    //defer.resolve(response.data);
              //    //}).error(function (msg, code) {
              //    //    defer.reject(msg);
              //    //});
              //}, function errorCallback(response) {
              //    defer.reject(response);
                  //});
        //return defer.promise;
    }

    ubigeo.ListarProvincias = function (provinciaRequest) {
        return $http.post(urlListarProvincias, provinciaRequest, header).then(function (response) {
            //return deferred.resolve({
            //    data: response.data
            //});
            return response.data;
        });
    }

    ubigeo.ListarDistritos = function (distritoRequest) {
        return $http.post(urlListarDistritos, distritoRequest, header).then(function (response) {
            return response.data;
        });
    }

    return ubigeo;
});