using System.Runtime.Serialization;

namespace Service_Layer.Models.Sistemas
{
    [DataContract]
    public class OpcionModel
    {
        public OpcionModel()
        {
            Id = 0;
            Nombre = string.Empty;
            NombreControlAsociado = string.Empty;
            Descripcion = string.Empty;
        }

        [DataMember(Name = "Id", Order = 0)]
        public int Id { get; set; }

        [DataMember(Name = "Nombre", Order = 1)]
        public string Nombre { get; set; }

        [DataMember(Name = "NombreControlAsociado", Order = 2)]
        public string NombreControlAsociado { get; set; }

        [DataMember(Name = "Descripcion", Order = 3)]
        public string Descripcion { get; set; }
    }
}