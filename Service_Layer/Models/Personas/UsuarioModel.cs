using System;
using System.Runtime.Serialization;

namespace Service_Layer.Models.Personas
{
    [DataContract]
    public class UsuarioModel
    {
        public UsuarioModel()
        {
            Id = 0;
            Usuario = string.Empty;
            Contrasena = string.Empty;
            Caduca = '\0';
            PeriodoCaducidad = 0;
            //FechaUltimoCambio = new DateTime();
            //FechaUltimoCambio = DateTime.Now;
            FechaUltimoCambio = string.Empty;
            UnicoIngreso = '\0';
            HaIngresado = '\0';
            OtrosLogeos = '\0';
            Tipo = '\0';
            Estado = '\0';
            Persona = new PersonaModel();
        }

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
        public string FechaUltimoCambio { get; set; }

        [DataMember(Name = "UnicoIngreso")]
        public char UnicoIngreso { get; set; }

        [DataMember(Name = "HaIngresado")]
        public char HaIngresado { get; set; }

        [DataMember(Name = "OtrosLogeos")]
        public char OtrosLogeos { get; set; }

        [DataMember(Name = "Tipo")]
        public char Tipo { get; set; }

        [DataMember(Name = "Estado")]
        public char Estado { get; set; }

        [DataMember(Name = "Persona")]
        public PersonaModel Persona { get; set; }
    }
}