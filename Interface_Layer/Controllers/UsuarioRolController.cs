using Newtonsoft.Json;
using Service_Layer.Models.Personas;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web.Http;

namespace Interface_Layer.Controllers
{
    public class UsuarioRolController : ApiController
    {
        private UsuarioRolModel _model;
        private DataContractJsonSerializer _jsonSerializer;
        private BRestOperation _restOperation;

        [HttpDelete]
        public HttpResponseMessage EliminarUsuarioRol(UsuarioRolModel model)
        {
            _model = model;
            try
            {
                var dataToSend = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_model));
                using (_restOperation = new BRestOperation())
                {
                    //var stream = _restOperation.Post("http://localhost/SeguridadService/Services/SPersonasService.svc/EliminarUsuarioRol/", dataToSend);
                    var stream = _restOperation.Post("http://localhost:55291/Services/SPersonasService.svc/EliminarUsuarioRol/", dataToSend);
                    _jsonSerializer = new DataContractJsonSerializer(typeof(int));
                    var response = (int)_jsonSerializer.ReadObject(stream);
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
        }

        [HttpPost]
        public HttpResponseMessage InsertarUsuarioRol(List<UsuarioRolModel> models)
        {
            try
            {
                foreach (var model in models)
                {
                    _model = model;
                    var dataToSend = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_model));
                    using (_restOperation = new BRestOperation())
                    {
                        //var stream = _restOperation.Post("http://localhost/SeguridadService/Services/SPersonasService.svc/InsertarUsuarioRol/", dataToSend);
                        var stream = _restOperation.Post("http://localhost:55291/Services/SPersonasService.svc/InsertarUsuarioRol/", dataToSend);
                        _jsonSerializer = new DataContractJsonSerializer(typeof(int));
                        var response = (int)_jsonSerializer.ReadObject(stream);
                    }
                }
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
        }

        [HttpPost]
        public List<UsuarioRolModel> ListarUsuariosRoles(UsuarioRolModel model)
        {
            List<UsuarioRolModel> response;
            _model = model;
            try
            {
                var dataToSend = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_model));
                using (_restOperation = new BRestOperation())
                {
                    //var stream = _restOperation.Post("http://localhost/SeguridadService/Services/SPersonasService.svc/ListarUsuariosRoles/", dataToSend);
                    var stream = _restOperation.Post("http://localhost:55291/Services/SPersonasService.svc/ListarUsuariosRoles/", dataToSend);
                    _jsonSerializer = new DataContractJsonSerializer(typeof(List<UsuarioRolModel>));
                    response = (List<UsuarioRolModel>)_jsonSerializer.ReadObject(stream);
                    return response;
                }
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, ex));
            }
        }
    }
}