using System;
using System.Runtime.Serialization;

namespace Service_Layer.Models.Personas
{
    [DataContract]
    public class UsuarioModel
    {
        [DataMember(Name = "Id")]
        public int Id { get; set; }

        [DataMember(Name = "Usuario")]
        public string Usuario { get; set; }

        [DataMember(Name = "Contrasena")]
        public string Contrasena { get; set; }

        [DataMember(Name = "Caduca")]
        public char Caduca { get; set; }

        [DataMember(Name = "PeriodoCaducidad")]
        public int PeriodoCaducidad { get; set; }

        [DataMember(Name = "FechaUltimoCambio")]
        public DateTime FechaUltimoCambio { get; set; }

        [DataMember(Name = "UnicoIngreso")]
        public char UnicoIngreso { get; set; }

        [DataMember(Name = "HaIngresado")]
        public char HaIngresado { get; set; }

        [DataMember(Name = "Tipo")]
        public char Tipo { get; set; }

        [DataMember(Name = "Estado")]
        public char Estado { get; set; }

        [DataMember(Name = "Persona")]
        public PersonaModel Persona { get; set; }
    }
}