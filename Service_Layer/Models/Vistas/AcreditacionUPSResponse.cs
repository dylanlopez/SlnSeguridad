using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Service_Layer.Models.Vistas
{
    [DataContract]
    public class AcreditacionUPSResponse
    {
        public AcreditacionUPSResponse()
        {
            Codigo = "0000";
            Descripcion = "Ok";
            Usuario = string.Empty;
            Contrasena = string.Empty;
            ApellidoPaterno = string.Empty;
            ApellidoMaterno = string.Empty;
            Nombres = string.Empty;
            Ubigeo = string.Empty;
            CodigoVersion = 0;
            Email = string.Empty;
            //NombreRol = string.Empty;
            PrimeraVez = '\0';
            Result = null;
        }

        [DataMember(Name = "Codigo", Order = 0)]
        public string Codigo { get; set; }

        [DataMember(Name = "Descripcion", Order = 1)]
        public string Descripcion { get; set; }

        [DataMember(Name = "Usuario", Order = 2)]
        public string Usuario { get; set; }

        [DataMember(Name = "Contrasena", Order = 3)]
        public string Contrasena { get; set; }

        [DataMember(Name = "ApellidoPaterno", Order = 4)]
        public string ApellidoPaterno { get; set; }

        [DataMember(Name = "ApellidoMaterno", Order = 5)]
        public string ApellidoMaterno { get; set; }

        [DataMember(Name = "Nombres", Order = 6)]
        public string Nombres { get; set; }

        [DataMember(Name = "Ubigeo", Order = 7)]
        public string Ubigeo { get; set; }

        [DataMember(Name = "CodigoVersion", Order = 8)]
        public int CodigoVersion { get; set; }

        [DataMember(Name = "Email", Order = 9)]
        public string Email { get; set; }

        //[DataMember(Name = "NombreRol", Order = 10)]
        //public string NombreRol { get; set; }

        [DataMember(Name = "PrimeraVez", Order = 10)]
        public char PrimeraVez { get; set; }

        [DataMember(Name = "TipoInstitucion", Order = 11)]
        public string TipoInstitucion { get; set; }

        [DataMember(Name = "Institucion", Order = 12)]
        public string Institucion { get; set; }

        [DataMember(Name = "InstitucionCorto", Order = 13)]
        public string InstitucionCorto { get; set; }

        [DataMember(Name = "Result", Order = 14)]
        public List<VistaPermisoModel> Result { get; set; }
    }
}