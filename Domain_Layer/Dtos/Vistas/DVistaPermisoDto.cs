using System;

namespace Domain_Layer.Dtos.Vistas
{
    public class DVistaPermisoDto
    {
        public int IdPerfil { get; set; }

        public string NombrePerfil { get; set; }

        public string Usuario { get; set; }

        public string Contrasena { get; set; }

        public string ApellidoPaterno { get; set; }

        public string ApellidoMaterno { get; set; }

        public string Nombres { get; set; }

        public string Ubigeo { get; set; }

        public int CodigoVersion { get; set; }

        public string Email { get; set; }

        public char Caduca { get; set; }

        public DateTime FechaUltimoCambio { get; set; }

        public int PeriodoCaducidad { get; set; }

        public char PrimeraVez { get; set; }

        public int IdRol { get; set; }

        public string NombreRol { get; set; }

        public int IdSistema { get; set; }

        public string CodigoSistema { get; set; }

        public string NombreSistema { get; set; }

        public string RutaLogica { get; set; }

        public int IdModulo { get; set; }

        public string CodigoModulo { get; set; }

        public string NombreModulo { get; set; }

        public int IdMenu { get; set; }

        public string CodigoMenu { get; set; }

        public string NombreMenu { get; set; }

        public string MenuRuta { get; set; }

        public int IdOpcion { get; set; }

        public string NombreOpcion { get; set; }

        public string ControlAsociado { get; set; }

        public char Visible { get; set; }
    }
}
