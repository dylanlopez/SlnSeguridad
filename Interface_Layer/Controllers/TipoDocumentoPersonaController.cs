using Newtonsoft.Json;
using Service_Layer.Models.Personas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web.Http;

namespace Interface_Layer.Controllers
{
    public class TipoDocumentoPersonaController : ApiController
    {
        private TipoDocumentoPersonaModel _model;
        private DataContractJsonSerializer _jsonSerializer;
        private BRestOperation _restOperation;

        [HttpPost]
        public TipoDocumentoPersonaModel BuscarTipoDocumentoPersona(TipoDocumentoPersonaModel model)
        {
            _model = model;
            try
            {
                var dataToSend = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_model));
                using (_restOperation = new BRestOperation())
                {
                    var stream = _restOperation.Post("http://localhost/SeguridadService/Services/SPersonasService.svc/BuscarTipoDocumentoPersona/", dataToSend);
                    //var stream = _restOperation.Post("http://localhost:55291/Services/SPersonasService.svc/BuscarTipoDocumentoPersona/", dataToSend);
                    _jsonSerializer = new DataContractJsonSerializer(typeof(TipoDocumentoPersonaModel));
                    _model = (TipoDocumentoPersonaModel)_jsonSerializer.ReadObject(stream);
                    return _model;
                }
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, ex));
            }
        }

        [HttpPost]
        public List<TipoDocumentoPersonaModel> ListarTipoDocumentoPersona()
        {
            List<TipoDocumentoPersonaModel> response;
            _model = new TipoDocumentoPersonaModel();
            try
            {
                var dataToSend = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_model));
                using (_restOperation = new BRestOperation())
                {
                    var stream = _restOperation.Post("http://localhost/SeguridadService/Services/SPersonasService.svc/ListarTipoDocumentoPersona/", dataToSend);
                    //var stream = _restOperation.Post("http://localhost:55291/Services/SPersonasService.svc/ListarTipoDocumentoPersona/", dataToSend);
                    _jsonSerializer = new DataContractJsonSerializer(typeof(List<TipoDocumentoPersonaModel>));
                    response = (List<TipoDocumentoPersonaModel>)_jsonSerializer.ReadObject(stream);
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