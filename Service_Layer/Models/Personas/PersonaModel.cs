using System.Runtime.Serialization;

namespace Service_Layer.Models.Personas
{
    [DataContract]
    public class PersonaModel
    {
        public PersonaModel()
        {
            Numero = 0;
            TipoDocumento = string.Empty;
            NumeroDocumento = string.Empty;
            ApellidoPaterno = string.Empty;
            ApellidoMaterno = string.Empty;
            Nombres = string.Empty;
        }

        [DataMember(Name = "Numero", Order = 0)]
        public int Numero { get; set; }

        [DataMember(Name = "TipoDocumento", Order = 1)]
        public string TipoDocumento { get; set; }

        [DataMember(Name = "NumeroDocumento", Order = 2)]
        public string NumeroDocumento { get; set; }

        [DataMember(Name = "ApellidoPaterno", Order = 3)]
        public string ApellidoPaterno { get; set; }

        [DataMember(Name = "ApellidoMaterno", Order = 4)]
        public string ApellidoMaterno { get; set; }

        [DataMember(Name = "Nombres", Order = 5)]
        public string Nombres { get; set; }
    }
}