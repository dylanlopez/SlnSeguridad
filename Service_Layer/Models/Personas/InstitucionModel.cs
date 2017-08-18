using System.Runtime.Serialization;

namespace Service_Layer.Models.Personas
{
    [DataContract]
    public class InstitucionModel
    {
        [DataMember(Name = "Id", Order = 1)]
        public int Id { get; set; }

        [DataMember(Name = "Nombre", Order = 2)]
        public string Nombre { get; set; }

        [DataMember(Name = "NombreCorto", Order = 3)]
        public string NombreCorto { get; set; }

        [DataMember(Name = "Direccion", Order = 4)]
        public string Direccion { get; set; }

        [DataMember(Name = "Activo", Order = 5)]
        public char Activo { get; set; }

        [DataMember(Name = "TipoInstitucion", Order = 6)]
        public TipoInstitucionModel TipoInstitucion { get; set; }
    }
}