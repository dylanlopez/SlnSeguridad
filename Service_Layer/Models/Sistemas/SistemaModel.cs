using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Interface_Layer.Models.Sistemas
{
    [DataContract]
    public class SistemaModel
    {
        public SistemaModel()
        {
            Id = 0;
            Codigo = string.Empty;
            Nombre = string.Empty;
            Abreviatura = string.Empty;
            Descripcion = string.Empty;
            Estado = '\0';
            Modulos = new List<ModuloModel>();
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

        [DataMember(Name = "Estado")]
        public char Estado { get; set; }

        [DataMember(Name = "Modulos")]
        public List<ModuloModel> Modulos { get; set; }
    }
}