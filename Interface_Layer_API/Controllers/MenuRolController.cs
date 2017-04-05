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
    public class MenuRolController : ApiController
    {
        private MenuRolModel _model;
        private DataContractJsonSerializer _jsonSerializer;
        private BRestOperation _restOperation;

        [HttpDelete]
        public HttpResponseMessage EliminarMenuRol(MenuRolModel model)
        {
            _model = model;
            try
            {
                var dataToSend = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_model));
                using (_restOperation = new BRestOperation())
                {
                    var stream = _restOperation.Post("http://localhost/SeguridadService/Services/SPersonasService.svc/EliminarMenuRol/", dataToSend);
                    //var stream = _restOperation.Post("http://localhost:55291/Services/SPersonasService.svc/EliminarMenuRol/", dataToSend);
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
        public HttpResponseMessage InsertarMenuRol(List<MenuRolModel> models)
        {
            try
            {
                foreach(var model in models)
                {
                    _model = model;
                    var dataToSend = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_model));
                    using (_restOperation = new BRestOperation())
                    {
                        var stream = _restOperation.Post("http://localhost/SeguridadService/Services/SPersonasService.svc/InsertarMenuRol/", dataToSend);
                        //var stream = _restOperation.Post("http://localhost:55291/Services/SPersonasService.svc/InsertarMenuRol/", dataToSend);
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
        public List<MenuRolModel> ListarMenusRoles(MenuRolModel model)
        {
            List<MenuRolModel> response;
            _model = model;
            try
            {
                var dataToSend = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_model));
                using (_restOperation = new BRestOperation())
                {
                    var stream = _restOperation.Post("http://localhost/SeguridadService/Services/SPersonasService.svc/ListarMenusRoles/", dataToSend);
                    //var stream = _restOperation.Post("http://localhost:55291/Services/SPersonasService.svc/ListarMenusRoles/", dataToSend);
                    _jsonSerializer = new DataContractJsonSerializer(typeof(List<MenuRolModel>));
                    response = (List<MenuRolModel>)_jsonSerializer.ReadObject(stream);
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