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
    public class PermisoController : ApiController
    {
        private PermisoModel _model;
        private DataContractJsonSerializer _jsonSerializer;
        private BRestOperation _restOperation;

        [HttpPut]
        //[Authorize]
        public HttpResponseMessage ActualizarPermiso(PermisoModel model)
        {
            try
            {
                _model = model;
                var path = ConfigurationManager.AppSettings["WCFPath"].ToString();
                path = path + "Services/SPersonasService.svc/ActualizarPermiso/";
                var dataToSend = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_model));
                using (_restOperation = new BRestOperation())
                {
                    //var stream = _restOperation.Post("http://localhost/SeguridadService/Services/SPersonasService.svc/ActualizarPermiso/", dataToSend);
                    //var stream = _restOperation.Post("http://localhost:55291/Services/SPersonasService.svc/ActualizarPermiso/", dataToSend);
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

        [HttpDelete]
        //[Authorize]
        public HttpResponseMessage EliminarPermiso(PermisoModel model)
        {
            _model = model;
            try
            {
                var path = ConfigurationManager.AppSettings["WCFPath"].ToString();
                path = path + "Services/SPersonasService.svc/EliminarPermiso/";
                var dataToSend = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_model));
                using (_restOperation = new BRestOperation())
                {
                    //var stream = _restOperation.Post("http://localhost/SeguridadService/Services/SPersonasService.svc/EliminarPermiso/", dataToSend);
                    //var stream = _restOperation.Post("http://localhost:55291/Services/SPersonasService.svc/EliminarPermiso/", dataToSend);
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
        public HttpResponseMessage InsertarPermiso(PermisoModel model)
        {
            try
            {
                _model = model;
                var path = ConfigurationManager.AppSettings["WCFPath"].ToString();
                path = path + "Services/SPersonasService.svc/InsertarPermiso/";
                var dataToSend = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_model));
                using (_restOperation = new BRestOperation())
                {
                    //var stream = _restOperation.Post("http://localhost/SeguridadService/Services/SPersonasService.svc/InsertarPermiso/", dataToSend);
                    //var stream = _restOperation.Post("http://localhost:55291/Services/SPersonasService.svc/InsertarPermiso/", dataToSend);
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
        public List<PermisoModel> ListarPermisos(PermisoModel model)
        {
            List<PermisoModel> response;
            _model = model;
            try
            {
                var path = ConfigurationManager.AppSettings["WCFPath"].ToString();
                path = path + "Services/SPersonasService.svc/ListarPermisos/";
                var dataToSend = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_model));
                using (_restOperation = new BRestOperation())
                {
                    //var stream = _restOperation.Post("http://localhost/SeguridadService/Services/SPersonasService.svc/ListarPermisos/", dataToSend);
                    //var stream = _restOperation.Post("http://localhost:55291/Services/SPersonasService.svc/ListarPermisos/", dataToSend);
                    var stream = _restOperation.Post(path, dataToSend);
                    _jsonSerializer = new DataContractJsonSerializer(typeof(List<PermisoModel>));
                    response = (List<PermisoModel>)_jsonSerializer.ReadObject(stream);
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