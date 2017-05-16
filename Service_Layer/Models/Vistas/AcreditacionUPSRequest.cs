using System.Runtime.Serialization;

namespace Service_Layer.Models.Vistas
{
    [DataContract]
    public class AcreditacionUPSRequest
    {
        public AcreditacionUPSRequest()
        {
            Usuario = string.Empty;
            Contrasena = string.Empty;
            CodigoSistema = string.Empty;
        }

        [DataMember(Name = "Usuario", Order = 0)]
        public string Usuario { get; set; }

        [DataMember(Name = "Contrasena", Order = 1)]
        public string Contrasena { get; set; }

        [DataMember(Name = "CodigoSistema", Order = 2)]
        public string CodigoSistema { get; set; }
    }
}