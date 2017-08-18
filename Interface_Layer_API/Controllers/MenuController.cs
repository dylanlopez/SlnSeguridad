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
    public class MenuController : ApiController
    {
        private MenuModel _model;
        private DataContractJsonSerializer _jsonSerializer;
        private BRestOperation _restOperation;

        [HttpPost]
        //[HttpPut]
        [Authorize]
        public HttpResponseMessage ActualizarMenu(MenuModel model)
        {
            try
            {
                var path = ConfigurationManager.AppSettings["WCFPath"].ToString();
                path = path + "Services/SSistemasServices.svc/ActualizarMenu/";
                _model = model;
                if (_model.Modulo.Descripcion == null)
                {
                    _model.Modulo.Descripcion = String.Empty;
                }
                if (_model.Modulo.Sistema.Descripcion == null)
                {
                    _model.Modulo.Sistema.Descripcion = String.Empty;
                }
                var dataToSend = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_model));
                using (_restOperation = new BRestOperation())
                {
                    //var stream = _restOperation.Post("http://localhost/SeguridadService/Services/SSistemasServices.svc/ActualizarMenu/", dataToSend);
                    //var stream = _restOperation.Post("http://localhost:55291/Services/SSistemasServices.svc/ActualizarMenu/", dataToSend);
                    var stream = _restOperation.Post(path, dataToSend);
                    _jsonSerializer = new DataContractJsonSerializer(typeof(int));
                    var response = (int)_jsonSerializer.ReadObject(stream);
                    if (response == 0)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No se actualizó correctamente");
                    }
                    else if (response == -2146232008)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Se intentó guardar un código duplicado");
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
        [Authorize]
        public HttpResponseMessage EliminarMenu(MenuModel model)
        {
            _model = model;
            try
            {
                var path = ConfigurationManager.AppSettings["WCFPath"].ToString();
                path = path + "Services/SSistemasServices.svc/EliminarMenu/";
                var dataToSend = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_model));
                using (_restOperation = new BRestOperation())
                {
                    //var stream = _restOperation.Post("http://localhost/SeguridadService/Services/SSistemasServices.svc/EliminarMenu/", dataToSend);
                    //var stream = _restOperation.Post("http://localhost:55291/Services/SSistemasServices.svc/EliminarMenu/", dataToSend);
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
        [Authorize]
        public HttpResponseMessage InsertarMenu(MenuModel model)
        {
            _model = model;
            try
            {
                if(_model.Modulo.Descripcion == null)
                {
                    _model.Modulo.Descripcion = String.Empty;
                }
                if (_model.Modulo.Sistema.Descripcion == null)
                {
                    _model.Modulo.Sistema.Descripcion = String.Empty;
                }
                var path = ConfigurationManager.AppSettings["WCFPath"].ToString();
                path = path + "Services/SSistemasServices.svc/InsertarMenu/";
                var dataToSend = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_model));
                using (_restOperation = new BRestOperation())
                {
                    //var stream = _restOperation.Post("http://localhost/SeguridadService/Services/SSistemasServices.svc/InsertarMenu/", dataToSend);
                    //var stream = _restOperation.Post("http://localhost:55291/Services/SSistemasServices.svc/InsertarMenu/", dataToSend);
                    var stream = _restOperation.Post(path, dataToSend);
                    _jsonSerializer = new DataContractJsonSerializer(typeof(int));
                    var response = (int)_jsonSerializer.ReadObject(stream);
                    if (response == 0)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No se insertó correctamente");
                    }
                    else if (response == -2146232008)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Se intentó guardar un código duplicado");
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
        [Authorize]
        public List<MenuModel> ListarMenus(MenuModel model)
        {
            List<MenuModel> response;
            _model = new MenuModel();
            //_model.Modulo = model.Modulo;
            _model = model;
            try
            {
                var path = ConfigurationManager.AppSettings["WCFPath"].ToString();
                path = path + "Services/SSistemasServices.svc/ListarMenus/";
                if (_model.Modulo != null)
                {
                    var dataToSend = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_model));
                    using (_restOperation = new BRestOperation())
                    {
                        //var stream = _restOperation.Post("http://localhost/SeguridadService/Services/SSistemasServices.svc/ListarMenus/", dataToSend);
                        //var stream = _restOperation.Post("http://localhost:55291/Services/SSistemasServices.svc/ListarMenus/", dataToSend);
                        var stream = _restOperation.Post(path, dataToSend);
                        _jsonSerializer = new DataContractJsonSerializer(typeof(List<MenuModel>));
                        response = (List<MenuModel>)_jsonSerializer.ReadObject(stream);
                        return response;
                    }
                }
                else
                {
                    return new List<MenuModel>();
                }
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, ex));
            }
        }
    }
}