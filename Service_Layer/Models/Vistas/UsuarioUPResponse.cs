using System.Runtime.Serialization;

namespace Service_Layer.Models.Vistas
{
    [DataContract]
    public class UsuarioUPResponse
    {
        public UsuarioUPResponse()
        {
            Codigo = "0000";
            Descripcion = "Actualizado correctamente";
        }

        [DataMember(Name = "Codigo", Order = 0)]
        public string Codigo { get; set; }

        [DataMember(Name = "Descripcion", Order = 1)]
        public string Descripcion { get; set; }
    }
}