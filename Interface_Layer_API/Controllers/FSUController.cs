using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Interface_Layer_API.Controllers
{
    public class FSUController : ApiController
    {
        [HttpPost]
        public string BuscarSistema()
        {
            try
            {
                string path = @"E:\datcito.dat";
                if (!File.Exists(path))
                {
                    //File.Create(path).Dispose();
                    var file = File.Create(path);
                    file.Close();
                    //var file = File.Open(path, FileMode.Open);
                    using (var tw = new StreamWriter(path))
                    {
                        tw.WriteLine("Para que veas x1");
                        tw.Close();
                    }
                }
                else if (File.Exists(path))
                {
                    using (var tw = new StreamWriter(path, true))
                    {
                        tw.WriteLine("Para que veas x2");
                        tw.Close();
                    }
                }
                return string.Empty;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
    }
}
