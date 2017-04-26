using Business_Layer.Utils;
using Newtonsoft.Json;
using Service_Layer.Models.Personas;
using System;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web.Http;

namespace Interface_Layer_API.Controllers
{
    public class PersonaController : ApiController
    {
        private PersonaModel _model;
        private DataContractJsonSerializer _jsonSerializer;
        private BRestOperation _restOperation;

        [HttpPost]
        public PersonaModel BuscarPersona(PersonaModel model)
        {
            _model = model;
            try
            {
                var dataToSend = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_model));
                using (_restOperation = new BRestOperation())
                {
                    //var stream = _restOperation.Post("http://localhost/SeguridadService/Services/SPersonasService.svc/BuscarPersona/", dataToSend);
                    var stream = _restOperation.Post("http://localhost:55291/Services/SPersonasService.svc/BuscarPersona/", dataToSend);
                    _jsonSerializer = new DataContractJsonSerializer(typeof(PersonaModel));
                    _model = (PersonaModel) _jsonSerializer.ReadObject(stream);
                    return _model;
                }
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, ex));
            }
        }
    }
}