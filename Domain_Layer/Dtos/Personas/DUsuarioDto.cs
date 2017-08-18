using System;

namespace Domain_Layer.Dtos.Personas
{
    /// <summary>
    /// Here is the DTO class DUsuarioDto.
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    public class DUsuarioDto
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DUsuarioDto"/> class.
        /// </summary>
        public DUsuarioDto()
        {
            Id = 0;
            Usuario = string.Empty;
            Contrasena = string.Empty;
            ApellidoPaterno = string.Empty;
            ApellidoMaterno = string.Empty;
            Nombres = string.Empty;
            Caduca = '\0';
            PeriodoCaducidad = 0;
            //FechaUltimoCambio = new DateTime();
            FechaUltimoCambio = string.Empty;
            Ubigeo = string.Empty;
            CodigoVersion = 0;
            PrimeraVez = '\0';
            UnicoIngreso = '\0';
            HaIngresado = '\0';
            OtrosLogeos = '\0';
            Tipo = '\0';
            Activo = '\0';
            Institucion = new DInstitucionDto();
        }

        /// <summary>
        /// Gets or sets the Id, correspond to entity field Id.
        /// </summary>
        /// <value>
        /// set a value to the Id.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Usuario, correspond to entity field Usuario.
        /// </summary>
        /// <value>
        /// set a value to the Usuario.
        /// </value>
        public string Usuario { get; set; }

        /// <summary>
        /// Gets or sets the Contrasena, correspond to entity field Contrasena.
        /// </summary>
        /// <value>
        /// set a value to the Contrasena.
        /// </value>
        public string Contrasena { get; set; }

        /// <summary>
        /// Gets or sets the ApellidoPaterno, correspond to entity field ApellidoPaterno.
        /// </summary>
        /// <value>
        /// set a value to the ApellidoPaterno.
        /// </value>
        public string ApellidoPaterno { get; set; }

        /// <summary>
        /// Gets or sets the ApellidoMaterno, correspond to entity field ApellidoMaterno.
        /// </summary>
        /// <value>
        /// set a value to the ApellidoMaterno.
        /// </value>
        public string ApellidoMaterno { get; set; }

        /// <summary>
        /// Gets or sets the Nombres, correspond to entity field Nombres.
        /// </summary>
        /// <value>
        /// set a value to the Nombres.
        /// </value>
        public string Nombres { get; set; }

        /// <summary>
        /// Gets or sets the Caduca, correspond to entity field Caduca.
        /// </summary>
        /// <value>
        /// set a value to the Caduca.
        /// </value>
        public char Caduca { get; set; }

        /// <summary>
        /// Gets or sets the PeriodoCaducidad, correspond to entity field PeriodoCaducidad.
        /// </summary>
        /// <value>
        /// set a value to the PeriodoCaducidad.
        /// </value>
        public int PeriodoCaducidad { get; set; }

        /// <summary>
        /// Gets or sets the FechaUltimoCambio, correspond to entity field FechaUltimoCambio.
        /// </summary>
        /// <value>
        /// set a value to the FechaUltimoCambio.
        /// </value>
        public string FechaUltimoCambio { get; set; }

        /// <summary>
        /// Gets or sets the Ubigeo, correspond to entity field Ubigeo.
        /// </summary>
        /// <value>
        /// set a value to the Ubigeo.
        /// </value>
        public string Ubigeo { get; set; }

        /// <summary>
        /// Gets or sets the CodigoVersion, correspond to entity field CodigoVersion.
        /// </summary>
        /// <value>
        /// set a value to the CodigoVersion.
        /// </value>
        public int CodigoVersion { get; set; }

        /// <summary>
        /// Gets or sets the PrimeraVez, correspond to entity field PrimeraVez.
        /// </summary>
        /// <value>
        /// set a value to the PrimeraVez.
        /// </value>
        public char PrimeraVez { get; set; }

        /// <summary>
        /// Gets or sets the UnicoIngreso, correspond to entity field UnicoIngreso.
        /// </summary>
        /// <value>
        /// set a value to the UnicoIngreso.
        /// </value>
        public char UnicoIngreso { get; set; }

        /// <summary>
        /// Gets or sets the HaIngresado, correspond to entity field HaIngresado.
        /// </summary>
        /// <value>
        /// set a value to the HaIngresado.
        /// </value>
        public char HaIngresado { get; set; }

        /// <summary>
        /// Gets or sets the OtrosLogeos, correspond to entity field OtrosLogeos.
        /// </summary>
        /// <value>
        /// set a value to the OtrosLogeos.
        /// </value>
        public char OtrosLogeos { get; set; }

        /// <summary>
        /// Gets or sets the Tipo, correspond to entity field Tipo.
        /// </summary>
        /// <value>
        /// set a value to the Tipo.
        /// </value>
        public char Tipo { get; set; }

        /// <summary>
        /// Gets or sets the Estado, correspond to entity field Estado.
        /// </summary>
        /// <value>
        /// set a value to the Estado.
        /// </value>
        public char Activo { get; set; }

        /// <summary>
        /// Gets or sets the Email, correspond to entity field Email.
        /// </summary>
        /// <value>
        /// set a value to the Email.
        /// </value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the Institucion, correspond to entity Institucion.
        /// </summary>
        /// <value>
        /// set a value to the Institucion.
        /// </value>
        public DInstitucionDto Institucion { get; set; }
    }
}