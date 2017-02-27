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
    public class MenuController : ApiController
    {
        [HttpGet]
        public IEnumerable<MenuModel> ListarModulos()
        {
            //var response = GET("http://localhost/SeguridadService/Services/Sistemas/SModuloService.svc/ListarModulos/");
            var response = GET("http://localhost:55291/Services/Sistemas/SMenuService.svc/ListarMenus/");
            List<MenuModel> jsonResponse = (List<MenuModel>)response;
            return jsonResponse;
        }

        object GET(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                request.ContentType = "application/json";
                WebResponse response = request.GetResponse();
                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(List<MenuModel>));
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