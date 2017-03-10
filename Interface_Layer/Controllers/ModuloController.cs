using Domain_Layer.Dtos.Sistemas;
using Interface_Layer.Models.Sistemas;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web.Http;

namespace Interface_Layer.Controllers
{
    public class ModuloController : ApiController
    {
        private DModuloDto _dto;
        private DataContractJsonSerializer _jsonSerializer;
        private RestOperation _restOperation;

        [HttpPut]
        public HttpResponseMessage ActualizarModulo(DModuloDto dto)
        {
            _dto = dto;
            try
            {
                var dataToSend = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_dto));
                using (_restOperation = new RestOperation())
                {
                    var stream = _restOperation.Post("http://localhost/SeguridadService/Services/SSistemasServices.svc/ActualizarModulo/", dataToSend);
                    //var stream = _restOperation.Post("http://localhost:55291/Services/SSistemasServices.svc/ActualizarModulo/", dataToSend);
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
        public HttpResponseMessage InsertarModulo(DModuloDto dto)
        {
            try
            {
                _dto = dto;
                var dataToSend = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_dto));
                using (_restOperation = new RestOperation())
                {
                    //var stream = _restOperation.Post("http://localhost/SeguridadService/Services/SSistemasServices.svc/InsertarModulo/", dataToSend);
                    var stream = _restOperation.Post("http://localhost:55291/Services/SSistemasServices.svc/InsertarModulo/", dataToSend);
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
        public IEnumerable<ModuloModel> ListarModulos(DSistemaDto dtoSistema)
        {
            List<ModuloModel> response;
            _dto = new DModuloDto();
            //_dto = dto;
            _dto.Sistema = dtoSistema;
            try
            {
                var dataToSend = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_dto));
                using (_restOperation = new RestOperation())
                {
                    var stream = _restOperation.Post("http://localhost/SeguridadService/Services/SSistemasServices.svc/ListarModulos/", dataToSend);
                    //var stream = _restOperation.Post("http://localhost:55291/Services/SSistemasServices.svc/ListarSistemas/", dataToSend);
                    _jsonSerializer = new DataContractJsonSerializer(typeof(List<ModuloModel>));
                    response = (List<ModuloModel>)_jsonSerializer.ReadObject(stream);
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