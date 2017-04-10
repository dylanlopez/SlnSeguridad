using System.Runtime.Serialization;

namespace Service_Layer.Models.Personas
{
    [DataContract]
    public class PerfilModel
    {
        public PerfilModel()
        {
            Id = 0;
            Nombre = string.Empty;
            Descripcion = string.Empty;
        }

        [DataMember(Name = "Id", Order = 0)]
        public int Id { get; set; }

        [DataMember(Name = "Nombre", Order = 1)]
        public string Nombre { get; set; }

        [DataMember(Name = "Descripcion", Order = 2)]
        public string Descripcion { get; set; }
    }
}