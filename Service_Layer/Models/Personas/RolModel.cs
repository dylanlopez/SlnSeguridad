using System.Runtime.Serialization;

namespace Service_Layer.Models.Personas
{
    [DataContract]
    public class RolModel
    {
        [DataMember(Name = "Id")]
        public int Id { get; set; }

        [DataMember(Name = "Nombre")]
        public string Nombre { get; set; }

        [DataMember(Name = "Descripcion")]
        public string Descripcion { get; set; }

        [DataMember(Name = "Estado")]
        public char Estado { get; set; }
    }
}