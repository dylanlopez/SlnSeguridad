using System.Runtime.Serialization;

namespace Interface_Layer.Models.Sistemas
{
    [DataContract]
    public class ModuloModel
    {
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

        [DataMember(Name = "Estado")]
        public char Estado { get; set; }

        [DataMember(Name = "Sistema")]
        public SistemaModel Sistema { get; set; }
    }
}