using System.Runtime.Serialization;

namespace Service_Layer.Models.Externos
{
    [DataContract]
    public class DistritoModel
    {
        [DataMember(Name = "codigoDistrito", Order = 0)]
        public string codigoDistrito { get; set; }

        [DataMember(Name = "codigoDepartamento", Order = 1)]
        public string codigoDepartamento { get; set; }

        [DataMember(Name = "codigoProvincia", Order = 2)]
        public string codigoProvincia { get; set; }

        [DataMember(Name = "descripcionDistrito", Order = 3)]
        public string descripcionDistrito { get; set; }

        [DataMember(Name = "codigoVersion", Order = 4)]
        public int codigoVersion { get; set; }
    }
}