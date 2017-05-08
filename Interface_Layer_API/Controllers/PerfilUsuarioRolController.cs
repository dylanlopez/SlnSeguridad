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
    public class PerfilUsuarioRolController : ApiController
    {
        private PerfilUsuarioRolModel _model;
        private DataContractJsonSerializer _jsonSerializer;
        private BRestOperation _restOperation;

        [HttpPut]
        //[Authorize]
        public HttpResponseMessage ActualizarPerfilUsuarioRol(PerfilUsuarioRolModel model)
        {
            try
            {
                _model = model;
                var path = ConfigurationManager.AppSettings["WCFPath"].ToString();
                path = path + "Services/SPersonasService.svc/ActualizarPerfilUsuarioRol/";
                var dataToSend = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_model));
                using (_restOperation = new BRestOperation())
                {
                    //var stream = _restOperation.Post("http://localhost/SeguridadService/Services/SPersonasService.svc/ActualizarPerfilUsuarioRol/", dataToSend);
                    //var stream = _restOperation.Post("http://localhost:55291/Services/SPersonasService.svc/ActualizarPerfilUsuarioRol/", dataToSend);
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
        public HttpResponseMessage InsertarPerfilUsuarioRol(PerfilUsuarioRolModel model)
        {
            try
            {
                _model = model;
                var path = ConfigurationManager.AppSettings["WCFPath"].ToString();
                path = path + "Services/SPersonasService.svc/InsertarPerfilUsuarioRol/";
                var dataToSend = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_model));
                using (_restOperation = new BRestOperation())
                {
                    //var stream = _restOperation.Post("http://localhost/SeguridadService/Services/SPersonasService.svc/InsertarPerfilUsuarioRol/", dataToSend);
                    //var stream = _restOperation.Post("http://localhost:55291/Services/SPersonasService.svc/InsertarPerfilUsuarioRol/", dataToSend);
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
        public List<PerfilUsuarioRolModel> ListarPerfilesUsuariosRoles(PerfilUsuarioRolModel model)
        {
            List<PerfilUsuarioRolModel> response;
            _model = model;
            try
            {
                var path = ConfigurationManager.AppSettings["WCFPath"].ToString();
                path = path + "Services/SPersonasService.svc/ListarPerfilesUsuariosRoles/";
                var dataToSend = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_model));
                using (_restOperation = new BRestOperation())
                {
                    //var stream = _restOperation.Post("http://localhost/SeguridadService/Services/SPersonasService.svc/ListarPerfilesUsuariosRoles/", dataToSend);
                    //var stream = _restOperation.Post("http://localhost:55291/Services/SPersonasService.svc/ListarPerfilesUsuariosRoles/", dataToSend);
                    var stream = _restOperation.Post(path, dataToSend);
                    _jsonSerializer = new DataContractJsonSerializer(typeof(List<PerfilUsuarioRolModel>));
                    response = (List<PerfilUsuarioRolModel>)_jsonSerializer.ReadObject(stream);
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