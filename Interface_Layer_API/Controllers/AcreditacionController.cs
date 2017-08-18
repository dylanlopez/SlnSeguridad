using Business_Layer.Utils;
using Newtonsoft.Json;
using Service_Layer.Models.Vistas;
using System;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web.Http;

namespace Interface_Layer_API.Controllers
{
    public class AcreditacionController : ApiController
    {
        private AcreditacionUPSRequest _request;
        private DataContractJsonSerializer _jsonSerializer;
        private BRestOperation _restOperation;

        [HttpPost]
        public AcreditacionUPSResponse AcreditacionUPS(AcreditacionUPSRequest request)
        {
            AcreditacionUPSResponse response;
            _request = request;
            try
            {
                var path = ConfigurationManager.AppSettings["WCFPath"].ToString();
                path = path + "Services/SPersonasService.svc/AcreditacionUPS/";
                var dataToSend = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_request));
                using (_restOperation = new BRestOperation())
                {
                    var stream = _restOperation.Post(path, dataToSend);
                    _jsonSerializer = new DataContractJsonSerializer(typeof(AcreditacionUPSResponse));
                    response = (AcreditacionUPSResponse)_jsonSerializer.ReadObject(stream);
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