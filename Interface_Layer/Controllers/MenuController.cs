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
    public class MenuController : ApiController
    {
        private DMenuDto _dto;
        private DataContractJsonSerializer _jsonSerializer;
        private RestOperation _restOperation;

        [HttpPut]
        public HttpResponseMessage ActualizarMenu(DMenuDto dto)
        {
            try
            {
                _dto = dto;
                if (_dto.Modulo.Descripcion == null)
                {
                    _dto.Modulo.Descripcion = String.Empty;
                }
                if (_dto.Modulo.Sistema.Descripcion == null)
                {
                    _dto.Modulo.Sistema.Descripcion = String.Empty;
                }
                var dataToSend = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_dto));
                using (_restOperation = new RestOperation())
                {
                    var stream = _restOperation.Post("http://localhost/SeguridadService/Services/SSistemasServices.svc/ActualizarMenu/", dataToSend);
                    //var stream = _restOperation.Post("http://localhost:55291/Services/SSistemasServices.svc/ActualizarMenu/", dataToSend);
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
        public HttpResponseMessage EliminarMenu(DMenuDto dto)
        {
            _dto = dto;
            try
            {
                var dataToSend = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_dto));
                using (_restOperation = new RestOperation())
                {
                    var stream = _restOperation.Post("http://localhost/SeguridadService/Services/SSistemasServices.svc/EliminarMenu/", dataToSend);
                    //var stream = _restOperation.Post("http://localhost:55291/Services/SSistemasServices.svc/EliminarMenu/", dataToSend);
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
        public HttpResponseMessage InsertarMenu(DMenuDto dto)
        {
            try
            {
                _dto = dto;
                if(_dto.Modulo.Descripcion == null)
                {
                    _dto.Modulo.Descripcion = String.Empty;
                }
                if (_dto.Modulo.Sistema.Descripcion == null)
                {
                    _dto.Modulo.Sistema.Descripcion = String.Empty;
                }
                var dataToSend = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_dto));
                using (_restOperation = new RestOperation())
                {
                    var stream = _restOperation.Post("http://localhost/SeguridadService/Services/SSistemasServices.svc/InsertarMenu/", dataToSend);
                    //var stream = _restOperation.Post("http://localhost:55291/Services/SSistemasServices.svc/InsertarMenu/", dataToSend);
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
        public List<MenuModel> ListarMenus(DModuloDto dtoModulo)
        {
            List<MenuModel> response;
            _dto = new DMenuDto();
            _dto.Modulo = dtoModulo;
            try
            {
                var dataToSend = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_dto));
                using (_restOperation = new RestOperation())
                {
                    var stream = _restOperation.Post("http://localhost/SeguridadService/Services/SSistemasServices.svc/ListarMenus/", dataToSend);
                    //var stream = _restOperation.Post("http://localhost:55291/Services/SSistemasServices.svc/ListarMenus/", dataToSend);
                    _jsonSerializer = new DataContractJsonSerializer(typeof(List<MenuModel>));
                    response = (List<MenuModel>)_jsonSerializer.ReadObject(stream);
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