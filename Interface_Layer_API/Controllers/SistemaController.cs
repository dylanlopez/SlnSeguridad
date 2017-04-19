using Business_Layer.Utils;
using Interface_Layer.App_Start;
using Newtonsoft.Json;
using Service_Layer.Models.Sistemas;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web.Http;

namespace Interface_Layer_API.Controllers
{
    public class SistemaController : ApiController
    {
        private SistemaModel _model;
        private DataContractJsonSerializer _jsonSerializer;
        private BRestOperation _restOperation;

        public SistemaController()
        {
            //Mapper.Initialize(config =>
            //{
            //    config.CreateMap<SistemaModel, DSistemaDto>();
            //    config.CreateMap<ModuloModel, DModuloDto>();
            //});
        }

        [HttpPut]
        public HttpResponseMessage ActualizarSistema(SistemaModel model)
        {
            _model = model;
            try
            {
                var dataToSend = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_model));
                using (_restOperation = new BRestOperation())
                {
                    //var stream = _restOperation.Post("http://localhost/SeguridadService/Services/SSistemasServices.svc/ActualizarSistema/", dataToSend);
                    var stream = _restOperation.Post("http://localhost:55291/Services/SSistemasServices.svc/ActualizarSistema/", dataToSend);
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
        public SistemaModel BuscarSistema(SistemaModel model)
        {
            _model = model;
            try
            {
                if (GlobalVariables.sistemaModel != null)
                {
                    return GlobalVariables.sistemaModel;
                }
                var dataToSend = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_model));
                using(_restOperation = new BRestOperation())
                {
                    //var stream = _restOperation.Post("http://localhost/SeguridadService/Services/SSistemasServices.svc/BuscarSistema/", dataToSend);
                    var stream = _restOperation.Post("http://localhost:55291/Services/SSistemasServices.svc/BuscarSistema/", dataToSend);
                    _jsonSerializer = new DataContractJsonSerializer(typeof(SistemaModel));
                    _model = (SistemaModel)_jsonSerializer.ReadObject(stream);
                    GlobalVariables.sistemaModel = _model;
                    return _model;
                }
            }
            catch(Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, ex));
            }
        }

        [HttpPost]
        public HttpResponseMessage InsertarSistema(SistemaModel model)
        {
            try
            {
                _model = model;
                var dataToSend = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_model));
                using (_restOperation = new BRestOperation())
                {
                    //var stream = _restOperation.Post("http://localhost/SeguridadService/Services/SSistemasServices.svc/InsertarSistema/", dataToSend);
                    var stream = _restOperation.Post("http://localhost:55291/Services/SSistemasServices.svc/InsertarSistema/", dataToSend);
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
        public List<SistemaModel> ListarSistemas(SistemaModel model)
        {
            List<SistemaModel> response;
            _model = model;
            try
            {
                var dataToSend = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_model));
                using (_restOperation = new BRestOperation())
                {
                    //var stream = _restOperation.Post("http://localhost/SeguridadService/Services/SSistemasServices.svc/ListarSistemas/", dataToSend);
                    var stream = _restOperation.Post("http://localhost:55291/Services/SSistemasServices.svc/ListarSistemas/", dataToSend);
                    _jsonSerializer = new DataContractJsonSerializer(typeof(List<SistemaModel>));
                    response = (List<SistemaModel>)_jsonSerializer.ReadObject(stream);
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