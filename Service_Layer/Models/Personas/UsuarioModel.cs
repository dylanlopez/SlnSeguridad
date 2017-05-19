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
            ApellidoPaterno = string.Empty;
            ApellidoMaterno = string.Empty;
            Nombres = string.Empty;
            Caduca = '\0';
            PeriodoCaducidad = 0;
            FechaUltimoCambio = string.Empty;
            Ubigeo = string.Empty;
            CodigoVersion = 0;
            Email = string.Empty;
            PrimeraVez = '\0';
            UnicoIngreso = '\0';
            HaIngresado = '\0';
            OtrosLogeos = '\0';
            Tipo = '\0';
            Activo = '\0';
        }

        [DataMember(Name = "Id", Order = 0)]
        public int Id { get; set; }

        [DataMember(Name = "Usuario", Order = 1)]
        public string Usuario { get; set; }

        [DataMember(Name = "Contrasena", Order = 2)]
        public string Contrasena { get; set; }

        [DataMember(Name = "ApellidoPaterno", Order = 3)]
        public string ApellidoPaterno { get; set; }

        [DataMember(Name = "ApellidoMaterno", Order = 4)]
        public string ApellidoMaterno { get; set; }

        [DataMember(Name = "Nombres", Order = 5)]
        public string Nombres { get; set; }

        [DataMember(Name = "Caduca", Order = 6)]
        public char Caduca { get; set; }

        [DataMember(Name = "PeriodoCaducidad", Order = 7)]
        public int PeriodoCaducidad { get; set; }

        [DataMember(Name = "FechaUltimoCambio", Order = 8)]
        public string FechaUltimoCambio { get; set; }

        [DataMember(Name = "Ubigeo", Order = 9)]
        public string Ubigeo { get; set; }

        [DataMember(Name = "CodigoVersion", Order = 10)]
        public int CodigoVersion { get; set; }

        [DataMember(Name = "PrimeraVez", Order = 11)]
        public char PrimeraVez { get; set; }

        [DataMember(Name = "UnicoIngreso", Order = 12)]
        public char UnicoIngreso { get; set; }

        [DataMember(Name = "HaIngresado", Order = 13)]
        public char HaIngresado { get; set; }

        [DataMember(Name = "OtrosLogeos", Order = 14)]
        public char OtrosLogeos { get; set; }

        [DataMember(Name = "Tipo", Order = 15)]
        public char Tipo { get; set; }

        [DataMember(Name = "Activo", Order = 16)]
        public char Activo { get; set; }

        [DataMember(Name = "Email", Order = 17)]
        public string Email { get; set; }
    }
}