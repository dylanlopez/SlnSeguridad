using Business_Layer.Utils;
using Newtonsoft.Json;
using Service_Layer.Models.Personas;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web.Http;

namespace Interface_Layer_API.Controllers
{
    public class RolController : ApiController
    {
        private RolModel _model;
        private DataContractJsonSerializer _jsonSerializer;
        private BRestOperation _restOperation;

        [HttpPut]
        //[Authorize]
        public HttpResponseMessage ActualizarRol(RolModel model)
        {
            try
            {
                _model = model;
                var path = ConfigurationManager.AppSettings["WCFPath"].ToString();
                path = path + "Services/SPersonasService.svc/ActualizarRol/";
                var dataToSend = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_model));
                using (_restOperation = new BRestOperation())
                {
                    //var stream = _restOperation.Post("http://localhost/SeguridadService/Services/SPersonasService.svc/ActualizarRol/", dataToSend);
                    //var stream = _restOperation.Post("http://localhost:55291/Services/SPersonasService.svc/ActualizarRol/", dataToSend);
                    var stream = _restOperation.Post(path, dataToSend);
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
        public RolModel BuscarRol(RolModel model)
        {
            _model = model;
            try
            {
                var path = ConfigurationManager.AppSettings["WCFPath"].ToString();
                path = path + "Services/SPersonasService.svc/BuscarRol/";
                var dataToSend = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_model));
                using (_restOperation = new BRestOperation())
                {
                    //var stream = _restOperation.Post("http://localhost/SeguridadService/Services/SPersonasService.svc/BuscarRol/", dataToSend);
                    //var stream = _restOperation.Post("http://localhost:55291/Services/SPersonasService.svc/BuscarRol/", dataToSend);
                    var stream = _restOperation.Post(path, dataToSend);
                    _jsonSerializer = new DataContractJsonSerializer(typeof(PersonaModel));
                    _model = (RolModel)_jsonSerializer.ReadObject(stream);
                    return _model;
                }
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, ex));
            }
        }

        [HttpDelete]
        //[Authorize]
        public HttpResponseMessage EliminarRol(RolModel model)
        {
            _model = model;
            try
            {
                var path = ConfigurationManager.AppSettings["WCFPath"].ToString();
                path = path + "Services/SPersonasService.svc/EliminarRol/";
                var dataToSend = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_model));
                using (_restOperation = new BRestOperation())
                {
                    //var stream = _restOperation.Post("http://localhost/SeguridadService/Services/SPersonasService.svc/EliminarRol/", dataToSend);
                    //var stream = _restOperation.Post("http://localhost:55291/Services/SPersonasService.svc/EliminarRol/", dataToSend);
                    var stream = _restOperation.Post(path, dataToSend);
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
        public HttpResponseMessage InsertarRol(RolModel model)
        {
            try
            {
                _model = model;
                var path = ConfigurationManager.AppSettings["WCFPath"].ToString();
                path = path + "Services/SPersonasService.svc/InsertarRol/";
                var dataToSend = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_model));
                using (_restOperation = new BRestOperation())
                {
                    //var stream = _restOperation.Post("http://localhost/SeguridadService/Services/SPersonasService.svc/InsertarRol/", dataToSend);
                    //var stream = _restOperation.Post("http://localhost:55291/Services/SPersonasService.svc/InsertarRol/", dataToSend);
                    var stream = _restOperation.Post(path, dataToSend);
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
        public List<RolModel> ListarRoles(RolModel model)
        {
            List<RolModel> response;
            _model = new RolModel();
            try
            {
                var path = ConfigurationManager.AppSettings["WCFPath"].ToString();
                path = path + "Services/SPersonasService.svc/ListarRoles/";
                var dataToSend = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_model));
                using (_restOperation = new BRestOperation())
                {
                    //var stream = _restOperation.Post("http://localhost/SeguridadService/Services/SPersonasService.svc/ListarRoles/", dataToSend);
                    //var stream = _restOperation.Post("http://localhost:55291/Services/SPersonasService.svc/ListarRoles/", dataToSend);
                    var stream = _restOperation.Post(path, dataToSend);
                    _jsonSerializer = new DataContractJsonSerializer(typeof(List<RolModel>));
                    response = (List<RolModel>)_jsonSerializer.ReadObject(stream);
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