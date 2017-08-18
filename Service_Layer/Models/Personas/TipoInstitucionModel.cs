using System.Runtime.Serialization;

namespace Service_Layer.Models.Personas
{
    [DataContract]
    public class TipoInstitucionModel
    {
        public TipoInstitucionModel()
        {
            Id = 0;
            Nombre = string.Empty;
            Descripcion = string.Empty;
            Activo = '\0';
        }

        [DataMember(Name = "Id", Order = 1)]
        public int Id { get; set; }

        [DataMember(Name = "Nombre", Order = 2)]
        public string Nombre { get; set; }

        [DataMember(Name = "Descripcion", Order = 3)]
        public string Descripcion { get; set; }

        [DataMember(Name = "Activo", Order = 4)]
        public char Activo { get; set; }
    }
}