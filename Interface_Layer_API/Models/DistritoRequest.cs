using System.Runtime.Serialization;

namespace Interface_Layer_API.Models
{
    [DataContract]
    public class DistritoRequest
    {
        [DataMember(Name = "coDepartamento", Order = 0)]
        public string coDepartamento { get; set; }

        [DataMember(Name = "coProvincia", Order = 1)]
        public string coProvincia { get; set; }
    }
}