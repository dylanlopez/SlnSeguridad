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
    public class PerfilController : ApiController
    {
        private PerfilModel _model;
        private DataContractJsonSerializer _jsonSerializer;
        private BRestOperation _restOperation;

        [HttpPost]
        //[HttpPut]
        //[Authorize]
        public HttpResponseMessage ActualizarPerfil(PerfilModel model)
        {
            try
            {
                _model = model;
                var path = ConfigurationManager.AppSettings["WCFPath"].ToString();
                path = path + "Services/SPersonasService.svc/ActualizarPerfil/";
                var dataToSend = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_model));
                using (_restOperation = new BRestOperation())
                {
                    //var stream = _restOperation.Post("http://localhost/SeguridadService/Services/SPersonasService.svc/ActualizarPerfil/", dataToSend);
                    //var stream = _restOperation.Post("http://localhost:55291/Services/SPersonasService.svc/ActualizarPerfil/", dataToSend);
                    var stream = _restOperation.Post(path, dataToSend);
                    _jsonSerializer = new DataContractJsonSerializer(typeof(int));
                    var response = (int)_jsonSerializer.ReadObject(stream);
                    if (response == 0)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No se actualizó correctamente");
                    }
                    else if (response == -2146232008)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Se intentó guardar un nombre duplicado");
                    }
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
        public HttpResponseMessage InsertarPerfil(PerfilModel model)
        {
            try
            {
                _model = model;
                var path = ConfigurationManager.AppSettings["WCFPath"].ToString();
                path = path + "Services/SPersonasService.svc/InsertarPerfil/";
                var dataToSend = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_model));
                using (_restOperation = new BRestOperation())
                {
                    //var stream = _restOperation.Post("http://localhost/SeguridadService/Services/SPersonasService.svc/InsertarPerfil/", dataToSend);
                    //var stream = _restOperation.Post("http://localhost:55291/Services/SPersonasService.svc/InsertarPerfil/", dataToSend);
                    var stream = _restOperation.Post(path, dataToSend);
                    _jsonSerializer = new DataContractJsonSerializer(typeof(int));
                    var response = (int)_jsonSerializer.ReadObject(stream);
                    if (response == 0)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No se insertó correctamente");
                    }
                    else if (response == -2146232008)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Se intentó guardar un nombre duplicado");
                    }
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
        public List<PerfilModel> ListarPerfiles()
        {
            List<PerfilModel> response;
            _model = new PerfilModel();
            try
            {
                var path = ConfigurationManager.AppSettings["WCFPath"].ToString();
                path = path + "Services/SPersonasService.svc/ListarPerfiles/";
                var dataToSend = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_model));
                using (_restOperation = new BRestOperation())
                {
                    //var stream = _restOperation.Post("http://localhost/SeguridadService/Services/SPersonasService.svc/ListarPerfiles/", dataToSend);
                    //var stream = _restOperation.Post("http://localhost:55291/Services/SPersonasService.svc/ListarPerfiles/", dataToSend);
                    var stream = _restOperation.Post(path, dataToSend);
                    _jsonSerializer = new DataContractJsonSerializer(typeof(List<PerfilModel>));
                    response = (List<PerfilModel>)_jsonSerializer.ReadObject(stream);
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