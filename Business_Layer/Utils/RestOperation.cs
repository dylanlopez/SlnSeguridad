using System;
using System.IO;
using System.Net;
using System.Text;

namespace Interface_Layer.Controllers
{
    public static class RestOperation
    {
        private static HttpWebRequest _request;
        private static WebResponse _response;

        public static object Get(string url)
        {
            return "";
        }

        public static Stream Post(string url, byte[] dataToSend)
        {
            _request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                _request.ContentType = "application/json";
                _request.ContentLength = dataToSend.Length;
                _request.Method = "POST";
                _request.GetRequestStream().Write(dataToSend, 0, dataToSend.Length);
                _response = _request.GetResponse();
                return _response.GetResponseStream();
            }
            catch (WebException ex)
            {
                WebResponse errorResponse = ex.Response;
                using (Stream responseStream = errorResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
                    String errorText = reader.ReadToEnd();
                }
                throw ex;
            }
        }
    }
}