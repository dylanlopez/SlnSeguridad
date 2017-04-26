﻿using Business_Layer.Utils;
using Interface_Layer_API.Models;
using Newtonsoft.Json;
using Service_Layer.Models.Externos;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web.Http;

namespace Interface_Layer_API.Controllers
{
    public class UbigeoController : ApiController
    {
        private DepartamentoModel _modelDepartamento;
        private ProvinciaModel _modelProvincia;
        private DataContractJsonSerializer _jsonSerializer;
        private BRestOperation _restOperation;

        [HttpPost]
        public List<DepartamentoModel> ListarDepartamentos()
        {
            List<DepartamentoModel> response;
            try
            {
                //var dataToSend = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_model));
                using (_restOperation = new BRestOperation())
                {
                    var stream = _restOperation.Post("http://192.168.64.19:7070/SistemaS100/listarDepartamento/");
                    _jsonSerializer = new DataContractJsonSerializer(typeof(List<DepartamentoModel>));
                    response = (List<DepartamentoModel>)_jsonSerializer.ReadObject(stream);
                    return response;
                }
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, ex));
            }
        }

        [HttpPost]
        public List<ProvinciaModel> ListarProvincias(DepartamentoModel model)
        {
            ProvinciaRequest request = new ProvinciaRequest();
            //_modelDepartamento = model;
            //string coDepartamento = model.codigoDepartamento;
            request.coDepartamento = model.codigoDepartamento;
            List <ProvinciaModel> response;
            try
            {
                //var dataToSend = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_modelDepartamento));
                //var dataToSend = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(coDepartamento));
                var dataToSend = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(request));
                using (_restOperation = new BRestOperation())
                {
                    var stream = _restOperation.Post("http://192.168.64.19:7070/SistemaS100/listadoProvincias/", dataToSend);
                    _jsonSerializer = new DataContractJsonSerializer(typeof(List<ProvinciaModel>));
                    response = (List<ProvinciaModel>)_jsonSerializer.ReadObject(stream);
                    return response;
                }
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, ex));
            }
        }

        [HttpPost]
        public List<DistritoModel> ListarDistritos(ProvinciaModel model)
        {
            DistritoRequest request = new DistritoRequest();
            //_modelProvincia = model;
            request.coDepartamento = model.codigoDepartamento;
            request.coProvincia = model.codigoProvincia;
            List<DistritoModel> response;
            try
            {
                //var dataToSend = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_modelProvincia));
                var dataToSend = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(request));
                using (_restOperation = new BRestOperation())
                {
                    var stream = _restOperation.Post("http://192.168.64.19:7070/SistemaS100/listadoDistrito/", dataToSend);
                    _jsonSerializer = new DataContractJsonSerializer(typeof(List<DistritoModel>));
                    response = (List<DistritoModel>)_jsonSerializer.ReadObject(stream);
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