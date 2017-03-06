using Domain_Layer.Dtos.Sistemas;
using Interface_Layer.Models;
using Interface_Layer.Models.Sistemas;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web.Http;

namespace Interface_Layer.Controllers
{
    public class ModuloController : ApiController
    {
        [HttpPost]
        public IEnumerable<ModuloModel> ListarModulos(PassParameter idSistema)
        {
            //var response = GET("http://localhost/SeguridadService/Services/Sistemas/SModuloService.svc/ListarModulos/");
            var response = GET("http://localhost:55291/Services/SSistemasServices.svc/ListarModulos/", idSistema.Id);
            List<ModuloModel> jsonResponse = (List<ModuloModel>)response;
            return jsonResponse;
        }

        object GET(string url, int idSistema)
        {
            DModuloDto dto = new DModuloDto();
            dto.Sistema.Id = idSistema;
            var dataToSend = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(dto));

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                //request.ContentType = "application/json";

                request.ContentType = "application/json";
                request.ContentLength = dataToSend.Length;
                request.Method = "POST";
                request.GetRequestStream().Write(dataToSend, 0, dataToSend.Length);

                WebResponse response = request.GetResponse();

                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(List<ModuloModel>));
                Stream responseStream = response.GetResponseStream();
                object objResponse = jsonSerializer.ReadObject(responseStream);
                return objResponse;
            }
            catch (WebException ex)
            {
                WebResponse errorResponse = ex.Response;
                using (Stream responseStream = errorResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
                    String errorText = reader.ReadToEnd();
                }
                throw;
            }
        }
    }
}