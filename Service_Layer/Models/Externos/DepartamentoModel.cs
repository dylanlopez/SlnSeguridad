using System.Runtime.Serialization;

namespace Service_Layer.Models.Externos
{
    [DataContract]
    public class DepartamentoModel
    {
        [DataMember(Name = "codigoDepartamento", Order = 0)]
        public string codigoDepartamento { get; set; }

        [DataMember(Name = "descripcionDepartamento", Order = 1)]
        public string descripcionDepartamento { get; set; }

        [DataMember(Name = "codigoVersion", Order = 2)]
        public int codigoVersion { get; set; }
    }
}