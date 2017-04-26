using System.Runtime.Serialization;

namespace Service_Layer.Models.Externos
{
    [DataContract]
    public class ProvinciaModel
    {
        [DataMember(Name = "codigoProvincia", Order = 0)]
        public string codigoProvincia { get; set; }

        [DataMember(Name = "codigoDepartamento", Order = 1)]
        public string codigoDepartamento { get; set; }

        [DataMember(Name = "descripcionProvincia", Order = 2)]
        public string descripcionProvincia { get; set; }

        [DataMember(Name = "codigoVersion", Order = 3)]
        public int codigoVersion { get; set; }
    }
}