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
    public class PersonaController : ApiController
    {
        private PersonaModel _model;
        private DataContractJsonSerializer _jsonSerializer;
        private BRestOperation _restOperation;

        [HttpPut]
        public HttpResponseMessage ActualizarPersona(PersonaModel model)
        {
            try
            {
                _model = model;
                //if (_model.TipoDocumentoPersona.Nombre == null)
                //{
                //    _model.TipoDocumentoPersona.Nombre = String.Empty;
                //}
                var dataToSend = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_model));
                using (_restOperation = new BRestOperation())
                {
                    var stream = _restOperation.Post("http://localhost/SeguridadService/Services/SPersonasService.svc/ActualizarPersona/", dataToSend);
                    //var stream = _restOperation.Post("http://localhost:55291/Services/SPersonasService.svc/ActualizarPersona/", dataToSend);
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
        public PersonaModel BuscarPersona(PersonaModel model)
        {
            _model = model;
            try
            {
                var dataToSend = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_model));
                using (_restOperation = new BRestOperation())
                {
                    var stream = _restOperation.Post("http://localhost/SeguridadService/Services/SPersonasService.svc/BuscarPersona/", dataToSend);
                    //var stream = _restOperation.Post("http://localhost:55291/Services/SPersonasService.svc/BuscarPersona/", dataToSend);
                    _jsonSerializer = new DataContractJsonSerializer(typeof(PersonaModel));
                    _model = (PersonaModel) _jsonSerializer.ReadObject(stream);
                    return _model;
                }
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, ex));
            }
        }

        [HttpDelete]
        public HttpResponseMessage EliminarPersona(PersonaModel model)
        {
            _model = model;
            try
            {
                var dataToSend = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_model));
                using (_restOperation = new BRestOperation())
                {
                    var stream = _restOperation.Post("http://localhost/SeguridadService/Services/SPersonasService.svc/EliminarPersona/", dataToSend);
                    //var stream = _restOperation.Post("http://localhost:55291/Services/SPersonasService.svc/EliminarPersona/", dataToSend);
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
        public HttpResponseMessage InsertarPersona(PersonaModel model)
        {
            try
            {
                _model = model;
                //if (_model.TipoDocumentoPersona.Nombre == null)
                //{
                //    _model.TipoDocumentoPersona.Nombre = String.Empty;
                //}
                var dataToSend = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_model));
                using (_restOperation = new BRestOperation())
                {
                    var stream = _restOperation.Post("http://localhost/SeguridadService/Services/SPersonasService.svc/InsertarPersona/", dataToSend);
                    //var stream = _restOperation.Post("http://localhost:55291/Services/SPersonasService.svc/InsertarPersona/", dataToSend);
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
        //[Authorize]
        public List<PersonaModel> ListarPersonas(PersonaModel model)
        {
            List<PersonaModel> response;
            _model = new PersonaModel();
            //_model.Modulo = model.Modulo;
            _model.Nombre = model.Nombre;
            _model.TipoDocumentoPersona = model.TipoDocumentoPersona;
            try
            {
                var dataToSend = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_model));
                using (_restOperation = new BRestOperation())
                {
                    //var stream = _restOperation.Post("http://localhost/SeguridadService/Services/SPersonasService.svc/ListarPersonas/", dataToSend);
                    var stream = _restOperation.Post("http://localhost:55291/Services/SPersonasService.svc/ListarPersonas/", dataToSend);
                    _jsonSerializer = new DataContractJsonSerializer(typeof(List<PersonaModel>));
                    response = (List<PersonaModel>)_jsonSerializer.ReadObject(stream);
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