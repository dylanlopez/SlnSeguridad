myApp.factory('UsuarioFctr', function ($http, webAPIControllers) {
    var usuario = {};

    var urlListarUsuarios = webAPIControllers + '/api/Usuario/ListarUsuarios';
    var urlInsertarUsuario = webAPIControllers + '/api/Usuario/InsertarUsuario';
    var urlActualizarUsuario = webAPIControllers + '/api/Usuario/ActualizarUsuario/';
    var urlBuscarUsuarioPorUsuario = webAPIControllers + '/api/Usuario/BuscarUsuarioPorUsuario';
    var header = {
        'Content-Type': 'application/json'
    }

    usuario.ListarUsuarios = function (user) {
        return $http.post(urlListarUsuarios, user, header).then(function (response) {
            return response.data;
        });
    }

    usuario.InsertarUsuario = function (user) {
        return $http.post(urlInsertarUsuario, user, header).then(function (response) {
            return response.data;
        });
    }

    usuario.ActualizarUsuario = function (user) {
        return $http.put(urlActualizarUsuario + user.Id, user, header).then(function (response) {
            return response.data;
        });
    }

    usuario.BuscarUsuarioPorUsuario = function (user) {
        return $http.post(urlBuscarUsuarioPorUsuario, user, header).then(function (response) {
            return response.data;
        });
    }

    usuario.CleanUsuario = function (user) {
        user.Id = null;
        user.Usuario = null;
        user.Contrasena = null;
        user.ApellidoPaterno = null;
        user.ApellidoMaterno = null;
        user.Nombres = null;
        user.Caduca = null;
        user.PeriodoCaducidad = null;
        user.FechaUltimoCambio = null;
        user.Ubigeo = null;
        user.CodigoVersion = null;
        user.UnicoIngreso = null;
        user.HaIngresado = null;
        user.OtrosLogeos = null;
        user.Tipo = null;
        user.Activo = null;
        user.Email = null;
    }

    return usuario;
});