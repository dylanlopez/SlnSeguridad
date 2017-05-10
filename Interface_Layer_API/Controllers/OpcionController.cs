using Business_Layer.Utils;
using Newtonsoft.Json;
using Service_Layer.Models.Sistemas;
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
    public class OpcionController : ApiController
    {
        private OpcionModel _model;
        private DataContractJsonSerializer _jsonSerializer;
        private BRestOperation _restOperation;

        [HttpPost]
        //[HttpPut]
        //[Authorize]
        public HttpResponseMessage ActualizarOpcion(OpcionModel model)
        {
            try
            {
                _model = model;
                var path = ConfigurationManager.AppSettings["WCFPath"].ToString();
                path = path + "Services/SSistemasServices.svc/ActualizarOpcion/";
                var dataToSend = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_model));
                using (_restOperation = new BRestOperation())
                {
                    //var stream = _restOperation.Post("http://localhost/SeguridadService/Services/SSistemasServices.svc/ActualizarOpcion/", dataToSend);
                    //var stream = _restOperation.Post("http://localhost:55291/Services/SSistemasServices.svc/ActualizarOpcion/", dataToSend);
                    var stream = _restOperation.Post(path, dataToSend);
                    _jsonSerializer = new DataContractJsonSerializer(typeof(int));
                    var response = (int)_jsonSerializer.ReadObject(stream);
                    if (response == 0)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No se actualizó correctamente");
                    }
                    else if (response == -2146232008)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Se intentó guardar un nombre con control asociado duplicado");
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
        //[HttpDelete]
        //[Authorize]
        public HttpResponseMessage EliminarOpcion(OpcionModel model)
        {
            _model = model;
            try
            {
                var path = ConfigurationManager.AppSettings["WCFPath"].ToString();
                path = path + "Services/SSistemasServices.svc/EliminarOpcion/";
                var dataToSend = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_model));
                using (_restOperation = new BRestOperation())
                {
                    //var stream = _restOperation.Post("http://localhost/SeguridadService/Services/SSistemasServices.svc/EliminarOpcion/", dataToSend);
                    //var stream = _restOperation.Post("http://localhost:55291/Services/SSistemasServices.svc/EliminarOpcion/", dataToSend);
                    var stream = _restOperation.Post(path, dataToSend);
                    _jsonSerializer = new DataContractJsonSerializer(typeof(int));
                    var response = (int)_jsonSerializer.ReadObject(stream);
                    if (response == 0)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No se eliminó correctamente");
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
        public HttpResponseMessage InsertarOpcion(OpcionModel model)
        {
            try
            {
                _model = model;
                var path = ConfigurationManager.AppSettings["WCFPath"].ToString();
                path = path + "Services/SSistemasServices.svc/InsertarOpcion/";
                var dataToSend = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_model));
                using (_restOperation = new BRestOperation())
                {
                    //var stream = _restOperation.Post("http://localhost/SeguridadService/Services/SSistemasServices.svc/InsertarOpcion/", dataToSend);
                    //var stream = _restOperation.Post("http://localhost:55291/Services/SSistemasServices.svc/InsertarOpcion/", dataToSend);
                    var stream = _restOperation.Post(path, dataToSend);
                    _jsonSerializer = new DataContractJsonSerializer(typeof(int));
                    var response = (int)_jsonSerializer.ReadObject(stream);
                    if (response == 0)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No se insertó correctamente");
                    }
                    else if (response == -2146232008)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Se intentó guardar un nombre con control asociado duplicado");
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
        public List<OpcionModel> ListarOpciones(OpcionModel model)
        {
            List<OpcionModel> response;
            _model = model;
            try
            {
                var path = ConfigurationManager.AppSettings["WCFPath"].ToString();
                path = path + "Services/SSistemasServices.svc/ListarOpciones/";
                var dataToSend = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_model));
                using (_restOperation = new BRestOperation())
                {
                    //var stream = _restOperation.Post("http://localhost/SeguridadService/Services/SSistemasServices.svc/ListarOpciones/", dataToSend);
                    //var stream = _restOperation.Post("http://localhost:55291/Services/SSistemasServices.svc/ListarOpciones/", dataToSend);
                    var stream = _restOperation.Post(path, dataToSend);
                    _jsonSerializer = new DataContractJsonSerializer(typeof(List<OpcionModel>));
                    response = (List<OpcionModel>)_jsonSerializer.ReadObject(stream);
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