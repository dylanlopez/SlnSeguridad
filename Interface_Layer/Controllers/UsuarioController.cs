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
    public class UsuarioController : ApiController
    {
        private UsuarioModel _model;
        private DataContractJsonSerializer _jsonSerializer;
        private RestOperation _restOperation;

        [HttpPut]
        public HttpResponseMessage ActualizarUsuario(UsuarioModel model)
        {
            try
            {
                _model = model;
                //if (_model.TipoDocumentoPersona.Nombre == null)
                //{
                //    _model.TipoDocumentoPersona.Nombre = String.Empty;
                //}
                var dataToSend = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_model));
                using (_restOperation = new RestOperation())
                {
                    var stream = _restOperation.Post("http://localhost/SeguridadService/Services/SPersonasService.svc/ActualizarUsuario/", dataToSend);
                    //var stream = _restOperation.Post("http://localhost:55291/Services/SPersonasService.svc/ActualizarUsuario/", dataToSend);
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
        public UsuarioModel BuscarUsuario(UsuarioModel model)
        {
            _model = model;
            try
            {
                var dataToSend = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_model));
                using (_restOperation = new RestOperation())
                {
                    var stream = _restOperation.Post("http://localhost/SeguridadService/Services/SPersonasService.svc/BuscarUsuario/", dataToSend);
                    //var stream = _restOperation.Post("http://localhost:55291/Services/SPersonasService.svc/BuscarUsuario/", dataToSend);
                    _jsonSerializer = new DataContractJsonSerializer(typeof(UsuarioModel));
                    _model = (UsuarioModel)_jsonSerializer.ReadObject(stream);
                    return _model;
                }
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, ex));
            }
        }

        [HttpDelete]
        public HttpResponseMessage EliminarUsuario(UsuarioModel model)
        {
            _model = model;
            try
            {
                var dataToSend = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_model));
                using (_restOperation = new RestOperation())
                {
                    var stream = _restOperation.Post("http://localhost/SeguridadService/Services/SPersonasService.svc/EliminarUsuario/", dataToSend);
                    //var stream = _restOperation.Post("http://localhost:55291/Services/SPersonasService.svc/EliminarUsuario/", dataToSend);
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
        public HttpResponseMessage InsertarUsuario(UsuarioModel model)
        {
            try
            {
                _model = model;
                //if (_model.TipoDocumentoPersona.Nombre == null)
                //{
                //    _model.TipoDocumentoPersona.Nombre = String.Empty;
                //}
                var dataToSend = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_model));
                using (_restOperation = new RestOperation())
                {
                    var stream = _restOperation.Post("http://localhost/SeguridadService/Services/SPersonasService.svc/InsertarUsuario/", dataToSend);
                    //var stream = _restOperation.Post("http://localhost:55291/Services/SPersonasService.svc/InsertarUsuario/", dataToSend);
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
        public List<UsuarioModel> ListarUsuarios(UsuarioModel model)
        {
            List<UsuarioModel> response;
            _model = new UsuarioModel();
            _model.Usuario = model.Usuario;
            _model.Persona = model.Persona;
            try
            {
                var dataToSend = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_model));
                using (_restOperation = new RestOperation())
                {
                    //var stream = _restOperation.Post("http://localhost/SeguridadService/Services/SPersonasService.svc/ListarUsuarios/", dataToSend);
                    var stream = _restOperation.Post("http://localhost:55291/Services/SPersonasService.svc/ListarUsuarios/", dataToSend);
                    _jsonSerializer = new DataContractJsonSerializer(typeof(List<UsuarioModel>));
                    response = (List<UsuarioModel>)_jsonSerializer.ReadObject(stream);
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