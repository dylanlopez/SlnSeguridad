using System.Runtime.Serialization;

namespace Service_Layer.Models.Vistas
{
    [DataContract]
    public class UsuarioURequest
    {
        public UsuarioURequest()
        {
            Usuario = string.Empty;
            //HaIngresado = '\0';
        }

        [DataMember(Name = "Usuario", Order = 0)]
        public string Usuario { get; set; }

        //[DataMember(Name = "HaIngresado", Order = 1)]
        //public char HaIngresado { get; set; }
    }
}