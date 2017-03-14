using System.Runtime.Serialization;

namespace Interface_Layer.Models.Sistemas
{
    [DataContract]
    public class MenuModel
    {
        [DataMember(Name = "Id")]
        public int Id { get; set; }

        [DataMember(Name = "Codigo")]
        public string Codigo { get; set; }

        [DataMember(Name = "Nombre")]
        public string Nombre { get; set; }

        [DataMember(Name = "Ruta")]
        public string Ruta { get; set; }

        [DataMember(Name = "Descripcion")]
        public string Descripcion { get; set; }

        [DataMember(Name = "Estado")]
        public char Estado { get; set; }

        [DataMember(Name = "Modulo")]
        public ModuloModel Modulo { get; set; }
    }
}