using Business_Layer.Utils;
using Newtonsoft.Json;
using Service_Layer.Models.Personas;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web.Http;

namespace Interface_Layer_API.Controllers
{
    public class SistemaPerfilController : ApiController
    {
        private SistemaPerfilModel _model;
        private DataContractJsonSerializer _jsonSerializer;
        private BRestOperation _restOperation;

        [HttpPut]
        public HttpResponseMessage ActualizarSistemaPerfil(SistemaPerfilModel model)
        {
            try
            {
                _model = model;
                var dataToSend = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_model));
                using (_restOperation = new BRestOperation())
                {
                    //var stream = _restOperation.Post("http://localhost/SeguridadService/Services/SPersonasService.svc/ActualizarSistemaPerfil/", dataToSend);
                    var stream = _restOperation.Post("http://localhost:55291/Services/SPersonasService.svc/ActualizarSistemaPerfil/", dataToSend);
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
        public HttpResponseMessage InsertarSistemaPerfil(SistemaPerfilModel model)
        {
            try
            {
                _model = model;
                var dataToSend = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_model));
                using (_restOperation = new BRestOperation())
                {
                    //var stream = _restOperation.Post("http://localhost/SeguridadService/Services/SPersonasService.svc/InsertarSistemaPerfil/", dataToSend);
                    var stream = _restOperation.Post("http://localhost:55291/Services/SPersonasService.svc/InsertarSistemaPerfil/", dataToSend);
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
        public List<SistemaPerfilModel> ListarSistemasPerfiles(SistemaPerfilModel model)
        {
            List<SistemaPerfilModel> response;
            _model = model;
            try
            {
                var dataToSend = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_model));
                using (_restOperation = new BRestOperation())
                {
                    //var stream = _restOperation.Post("http://localhost/SeguridadService/Services/SPersonasService.svc/ListarSistemasPerfiles/", dataToSend);
                    var stream = _restOperation.Post("http://localhost:55291/Services/SPersonasService.svc/ListarSistemasPerfiles/", dataToSend);
                    _jsonSerializer = new DataContractJsonSerializer(typeof(List<SistemaPerfilModel>));
                    response = (List<SistemaPerfilModel>)_jsonSerializer.ReadObject(stream);
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