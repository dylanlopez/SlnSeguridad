//using AutoMapper;
using Interface_Layer.App_Start;
//using Interface_Layer.Models;
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
    public class SistemaController : ApiController
    {
        private SistemaModel _model;
        private DataContractJsonSerializer _jsonSerializer;
        private RestOperation _restOperation;

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
                using (_restOperation = new RestOperation())
                {
                    var stream = _restOperation.Post("http://localhost/SeguridadService/Services/SSistemasServices.svc/ActualizarSistema/", dataToSend);
                    //var stream = _restOperation.Post("http://localhost:55291/Services/SSistemasServices.svc/ActualizarSistema/", dataToSend);
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
            //SistemaModel response;
            try
            {
                if (GlobalVariables.sistemaModel != null)
                {
                    return GlobalVariables.sistemaModel;
                }
                //_model = new SistemaModel();
                //_model.Id = postParam.Id;
                var dataToSend = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_model));
                using(_restOperation = new RestOperation())
                {
                    //var stream = _restOperation.Post("http://localhost/SeguridadService/Services/SSistemasServices.svc/BuscarSistema/", dataToSend);
                    var stream = _restOperation.Post("http://localhost:55291/Services/SSistemasServices.svc/BuscarSistema/", dataToSend);
                    _jsonSerializer = new DataContractJsonSerializer(typeof(SistemaModel));
                    _model = (SistemaModel)_jsonSerializer.ReadObject(stream);
                    //if (response.Estado == 'A')
                    //{
                    //    response.EstaActivo = true;
                    //}
                    //else if (response.Estado == 'I')
                    //{
                    //    response.EstaActivo = false;
                    //}
                    //response.EstaInactivo = !response.EstaActivo;
                    //response.Modulos = GetModulosFromSistema(Mapper.Map<DSistemaDto>(response));
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
        public HttpResponseMessage InsertarSistema(SistemaModel dto)
        {
            try
            {
                _model = dto;
                var dataToSend = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_model));
                using (_restOperation = new RestOperation())
                {
                    var stream = _restOperation.Post("http://localhost/SeguridadService/Services/SSistemasServices.svc/InsertarSistema/", dataToSend);
                    //var stream = _restOperation.Post("http://localhost:55291/Services/SSistemasServices.svc/InsertarSistema/", dataToSend);
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
        public List<SistemaModel> ListarSistemas()
        {
            List<SistemaModel> response;
            _model = new SistemaModel();
            try
            {
                var dataToSend = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_model));
                using (_restOperation = new RestOperation())
                {
                    var stream = _restOperation.Post("http://localhost/SeguridadService/Services/SSistemasServices.svc/ListarSistemas/", dataToSend);
                    //var stream = _restOperation.Post("http://localhost:55291/Services/SSistemasServices.svc/ListarSistemas/", dataToSend);
                    _jsonSerializer = new DataContractJsonSerializer(typeof(List<SistemaModel>));
                    response = (List<SistemaModel>)_jsonSerializer.ReadObject(stream);
                    //foreach(var item in response)
                    //{
                    //    if (item.Estado == 'A')
                    //    {
                    //        item.EstaActivo = true;
                    //    }
                    //    else if (item.Estado == 'I')
                    //    {
                    //        item.EstaActivo = false;
                    //    }
                    //    item.EstaInactivo = !item.EstaActivo;
                    //}
                    return response;
                }
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, ex));
            }
        }

        //private List<ModuloModel> GetModulosFromSistema(DSistemaDto dtoSistema)
        //{
        //    DModuloDto dtoModulo = new DModuloDto();
        //    List<ModuloModel> modulosModels;
        //    try
        //    {
        //        dtoModulo.Sistema = dtoSistema;
        //        var dataToSend = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(dtoModulo));
        //        using (_restOperation = new RestOperation())
        //        {
        //            var stream = _restOperation.Post("http://localhost/SeguridadService/Services/SSistemasServices.svc/ListarModulos/", dataToSend);
        //            //var stream = _restOperation.Post("http://localhost:55291/Services/SSistemasServices.svc/ListarModulos/", dataToSend);
        //            _jsonSerializer = new DataContractJsonSerializer(typeof(List<ModuloModel>));
        //            modulosModels = (List<ModuloModel>)_jsonSerializer.ReadObject(stream);
        //            foreach (var moduloModel in modulosModels)
        //            {
        //                moduloModel.Menus = GetMenusFromModulo(Mapper.Map<DModuloDto>(moduloModel));
        //            }
        //            return modulosModels;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}
        //private List<MenuModel> GetMenusFromModulo(DModuloDto dtoModulo)
        //{
        //    DMenuDto dtoMenu = new DMenuDto();
        //    List<MenuModel> menusModels;
        //    try
        //    {
        //        dtoMenu.Estado = 'A';
        //        dtoMenu.Modulo = dtoModulo;
        //        var dataToSend = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(dtoMenu));
        //        using (_restOperation = new RestOperation())
        //        {
        //            var stream = _restOperation.Post("http://localhost/SeguridadService/Services/SSistemasServices.svc/ListarMenus/", dataToSend);
        //            //var stream = _restOperation.Post("http://localhost:55291/Services/SSistemasServices.svc/ListarMenus/", dataToSend);
        //            _jsonSerializer = new DataContractJsonSerializer(typeof(List<MenuModel>));
        //            menusModels = (List<MenuModel>)_jsonSerializer.ReadObject(stream);
        //            return menusModels;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}
    }
}