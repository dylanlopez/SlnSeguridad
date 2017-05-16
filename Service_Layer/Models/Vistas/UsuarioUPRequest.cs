using System.Runtime.Serialization;

namespace Service_Layer.Models.Vistas
{
    [DataContract]
    public class UsuarioUPRequest
    {
        public UsuarioUPRequest()
        {
            Usuario = string.Empty;
            ContrasenaAnterior = string.Empty;
            ContrasenaNueva = string.Empty;
        }

        [DataMember(Name = "Usuario", Order = 0)]
        public string Usuario { get; set; }

        [DataMember(Name = "ContrasenaAnterior", Order = 1)]
        public string ContrasenaAnterior { get; set; }

        [DataMember(Name = "ContrasenaNueva", Order = 2)]
        public string ContrasenaNueva { get; set; }
    }
}