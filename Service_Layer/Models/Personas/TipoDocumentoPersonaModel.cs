using System.Runtime.Serialization;

namespace Service_Layer.Models.Personas
{
    [DataContract]
    public class TipoDocumentoPersonaModel
    {
        public TipoDocumentoPersonaModel()
        {
            Id = 0;
            Codigo = string.Empty;
            Nombre = string.Empty;
            Abreviatura = string.Empty;
            Descripcion = string.Empty;
        }

        [DataMember(Name = "Id")]
        public int Id { get; set; }

        [DataMember(Name = "Codigo")]
        public string Codigo { get; set; }

        [DataMember(Name = "Nombre")]
        public string Nombre { get; set; }

        [DataMember(Name = "Abreviatura")]
        public string Abreviatura { get; set; }

        [DataMember(Name = "Descripcion")]
        public string Descripcion { get; set; }
    }
}