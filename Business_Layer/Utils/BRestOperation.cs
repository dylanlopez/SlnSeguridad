using Logging_Layer;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;

namespace Business_Layer.Utils
{
    public class BRestOperation : IDisposable
    {
        private HttpWebRequest _request;
        private WebResponse _response;
        private Stream _requestStream;

        //private Loggin _logger;

        public object Get(string url)
        {
            return "";
        }

        public Stream Post(string url, byte[] dataToSend)
        {
            //if (_logger == null)
            //{
            //    _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            //}
            _request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                _request.ContentType = "application/json;charset=UTF-8";
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
                //_logger.WriteErrorLog(ex);
                WebResponse errorResponse = ex.Response;
                using (Stream responseStream = errorResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
                    String errorText = reader.ReadToEnd();
                }
                throw ex;
            }
            //finally
            //{
            //    _logger = null;
            //}
        }
        public Stream Post(string url)
        {
            //if (_logger == null)
            //{
            //    _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            //}
            _request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                _request.ContentType = "application/json";
                _request.Method = "POST";
                _request.Timeout = 60000;
                _requestStream = _request.GetRequestStream();
                _requestStream.Close();
                _response = _request.GetResponse();
                return _response.GetResponseStream();
            }
            catch (WebException ex)
            {
                //_logger.WriteErrorLog(ex);
                WebResponse errorResponse = ex.Response;
                using (Stream responseStream = errorResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
                    String errorText = reader.ReadToEnd();
                }
                throw ex;
            }
            //finally
            //{
            //    _logger = null;
            //}
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}