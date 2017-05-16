using System.Runtime.Serialization;

namespace Service_Layer.Models.Vistas
{
    [DataContract]
    public class VistaPermisoModel
    {
        public VistaPermisoModel()
        {
            NombrePerfil = string.Empty;
            Usuario = string.Empty;
            Contrasena = string.Empty;
            ApellidoPaterno = string.Empty;
            ApellidoMaterno = string.Empty;
            Nombres = string.Empty;
            Ubigeo = string.Empty;
            CodigoVersion = 0;
            Email = string.Empty;
            NombreRol = string.Empty;
            CodigoSistema = string.Empty;
            NombreSistema = string.Empty;
            NombreModulo = string.Empty;
            NombreMenu = string.Empty;
            NombreOpcion = string.Empty;
            ControlAsociado = string.Empty;
            Visible = '\0';
        }

        [DataMember(Name = "NombrePerfil", Order = 0)]
        public string NombrePerfil { get; set; }

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

        [DataMember(Name = "Ubigeo", Order = 6)]
        public string Ubigeo { get; set; }

        [DataMember(Name = "CodigoVersion", Order = 7)]
        public int CodigoVersion { get; set; }

        [DataMember(Name = "Email", Order = 8)]
        public string Email { get; set; }

        [DataMember(Name = "NombreRol", Order = 9)]
        public string NombreRol { get; set; }

        [DataMember(Name = "CodigoSistema", Order = 10)]
        public string CodigoSistema { get; set; }

        [DataMember(Name = "NombreSistema", Order = 11)]
        public string NombreSistema { get; set; }

        [DataMember(Name = "RutaLogica", Order = 12)]
        public string RutaLogica { get; set; }

        [DataMember(Name = "NombreModulo", Order = 13)]
        public string NombreModulo { get; set; }

        [DataMember(Name = "NombreMenu", Order = 14)]
        public string NombreMenu { get; set; }

        [DataMember(Name = "MenuRuta", Order = 15)]
        public string MenuRuta { get; set; }

        [DataMember(Name = "NombreOpcion", Order = 16)]
        public string NombreOpcion { get; set; }

        [DataMember(Name = "ControlAsociado", Order = 17)]
        public string ControlAsociado { get; set; }

        [DataMember(Name = "Visible", Order = 18)]
        public char Visible { get; set; }
    }
}