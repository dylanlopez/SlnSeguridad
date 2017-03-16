using System.Runtime.Serialization;

namespace Service_Layer.Models.Personas
{
    [DataContract]
    public class PersonaModel
    {
        public PersonaModel()
        {
            Id = 0;
            Nombre = string.Empty;
            NumeroDocumento = string.Empty;
            Direccion = string.Empty;
            Telefono = string.Empty;
            Celular = string.Empty;
            Email = string.Empty;
            Tipo = '\0';
            Ambito = '\0';
            TipoDocumentoPersona = new TipoDocumentoPersonaModel();
        }

        [DataMember(Name = "Id")]
        public int Id { get; set; }

        [DataMember(Name = "Nombre")]
        public string Nombre { get; set; }

        [DataMember(Name = "NumeroDocumento")]
        public string NumeroDocumento { get; set; }

        [DataMember(Name = "Direccion")]
        public string Direccion { get; set; }

        [DataMember(Name = "Telefono")]
        public string Telefono { get; set; }

        [DataMember(Name = "Celular")]
        public string Celular { get; set; }

        [DataMember(Name = "Email")]
        public string Email { get; set; }

        [DataMember(Name = "Tipo")]
        public char Tipo { get; set; }

        [DataMember(Name = "Ambito")]
        public char Ambito { get; set; }

        [DataMember(Name = "TipoDocumentoPersona")]
        public TipoDocumentoPersonaModel TipoDocumentoPersona { get; set; }
    }
}