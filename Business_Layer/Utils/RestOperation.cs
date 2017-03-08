using System;
using System.IO;
using System.Net;
using System.Text;

namespace Interface_Layer.Controllers
{
    public class RestOperation : IDisposable
    {
        private HttpWebRequest _request;
        private WebResponse _response;
        private Stream _requestStream;

        public object Get(string url)
        {
            return "";
        }

        public Stream Post(string url, byte[] dataToSend)
        {
            _request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                _request.ContentType = "application/json";
                _request.ContentLength = dataToSend.Length;
                _request.Method = "POST";
                _request.Timeout = 60000;
                _requestStream = _request.GetRequestStream();
                _requestStream.Write(dataToSend, 0, dataToSend.Length);
                _requestStream.Close();

                //_request.GetRequestStream().Write(dataToSend, 0, dataToSend.Length);

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

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}