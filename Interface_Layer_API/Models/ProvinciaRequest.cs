using System.Runtime.Serialization;

namespace Interface_Layer_API.Models
{
    [DataContract]
    public class ProvinciaRequest
    {
        [DataMember(Name = "coDepartamento", Order = 0)]
        public string coDepartamento { get; set; }
    }
}