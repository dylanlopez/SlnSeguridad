using System.Runtime.Serialization;

namespace Service_Layer.Models.Personas
{
    [DataContract]
    public class PersonaModel
    {
        public PersonaModel()
        {
            NumeroDocumento = string.Empty;
            ApellidoPaterno = string.Empty;
            ApellidoMaterno = string.Empty;
            Nombres = string.Empty;
        }

        [DataMember(Name = "NumeroDocumento")]
        public string NumeroDocumento { get; set; }

        [DataMember(Name = "ApellidoPaterno")]
        public string ApellidoPaterno { get; set; }

        [DataMember(Name = "ApellidoMaterno")]
        public string ApellidoMaterno { get; set; }

        [DataMember(Name = "Nombres")]
        public string Nombres { get; set; }
    }
}