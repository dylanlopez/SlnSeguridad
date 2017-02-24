using Interface_Layer.Models.Sistemas;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web.Http;

namespace Interface_Layer.Controllers
{
    public class SistemaController : ApiController
    {
        public SistemaController() { }

        [HttpGet]
        public IEnumerable<SistemaModel> ListarSistemas()
        {
            var response = GET("http://localhost/SeguridadService/Services/Sistemas/SSistemaService.svc/ListarSistemas/");
            List<SistemaModel> jsonResponse = (List<SistemaModel>)response;

            ////var resp = new SistemaResponse();
            ////if (jsonResponse.Count > 0)
            ////{
            ////    resp.Result = "OK";
            ////    foreach (SistemaModel item in jsonResponse)
            ////    {
            ////        resp.Data.Add(item);
            ////    }
            ////}
            ////return Json(jsonResponse, JsonRequestBehavior.AllowGet);

            return jsonResponse;
            ////return resp;


            //var response2 = Request.CreateResponse(HttpStatusCode.OK, jsonResponse);
            //response2.Content = new StringContent(jObject.ToString(), Encoding.UTF8, "application/json");
            //return Request.CreateResponse(HttpStatusCode.OK, jsonResponse);
        }

        object GET(string url)
        {
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(url);
            try
            {
                request.ContentType = "application/json";
                WebResponse response = request.GetResponse();
                //var response = request.GetResponse();
                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(List<SistemaModel>));
                Stream responseStream = response.GetResponseStream();
                object objResponse = jsonSerializer.ReadObject(responseStream);

                //List<SistemaModel> jsonResponse = (SistemaModel) objResponse;

                return objResponse;


                //using (Stream responseStream = response.GetResponseStream())
                //{
                //    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                //    return reader.ReadToEnd();
                //}
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