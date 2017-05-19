using System;

namespace Entity_Layer.Entities.Personas
{
    /// <summary>
    /// Here is the entity class EUsuario, for store all the data and do the mapping after.
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    public class EUsuario
    {
        /// <summary>
        /// Gets or sets the Id, correspond to table field ID_USUARIO.
        /// </summary>
        /// <value>
        /// set a value to the Id.
        /// </value>
        public virtual Int32 Id { get; set; }

        /// <summary>
        /// Gets or sets the Usuario, correspond to table field US_USUARIO.
        /// </summary>
        /// <value>
        /// set a value to the Usuario.
        /// </value>
        public virtual String Usuario { get; set; }

        /// <summary>
        /// Gets or sets the Contrasena, correspond to table field US_CONTRASENA.
        /// </summary>
        /// <value>
        /// set a value to the Contrasena.
        /// </value>
        public virtual String Contrasena { get; set; }

        /// <summary>
        /// Gets or sets the ApellidoPaterno, correspond to table field NO_APELLIDO_PATERNO.
        /// </summary>
        /// <value>
        /// set a value to the ApellidoPaterno.
        /// </value>
        public virtual String ApellidoPaterno { get; set; }

        /// <summary>
        /// Gets or sets the ApellidoMaterno, correspond to table field NO_APELLIDO_MATERNO.
        /// </summary>
        /// <value>
        /// set a value to the ApellidoMaterno.
        /// </value>
        public virtual String ApellidoMaterno { get; set; }

        /// <summary>
        /// Gets or sets the Nombres, correspond to table field NO_NOMBRE.
        /// </summary>
        /// <value>
        /// set a value to the Nombres.
        /// </value>
        public virtual String Nombres { get; set; }

        /// <summary>
        /// Gets or sets the Caduca, correspond to table field IN_CADUCA.
        /// </summary>
        /// <value>
        /// set a value to the Caduca.
        /// </value>
        public virtual Char Caduca { get; set; }

        /// <summary>
        /// Gets or sets the PeriodoCaducidad, correspond to table field NU_PERIODO_CADUCIDAD.
        /// </summary>
        /// <value>
        /// set a value to the PeriodoCaducidad.
        /// </value>
        public virtual Int32 PeriodoCaducidad { get; set; }

        /// <summary>
        /// Gets or sets the FechaUltimoCambio, correspond to table field FE_ULTIMOCAMBIO.
        /// </summary>
        /// <value>
        /// set a value to the FechaUltimoCambio.
        /// </value>
        public virtual DateTime FechaUltimoCambio { get; set; }

        /// <summary>
        /// Gets or sets the Ubigeo, correspond to table field UBIGEO.
        /// </summary>
        /// <value>
        /// set a value to the Ubigeo.
        /// </value>
        public virtual String Ubigeo { get; set; }

        /// <summary>
        /// Gets or sets the CodigoVersion, correspond to table field CO_VERSION.
        /// </summary>
        /// <value>
        /// set a value to the CodigoVersion.
        /// </value>
        public virtual Int32 CodigoVersion { get; set; }

        /// <summary>
        /// Gets or sets the PrimeraVez, correspond to table field IN_PRIMERA_VEZ.
        /// </summary>
        /// <value>
        /// set a value to the PrimeraVez.
        /// </value>
        public virtual Char PrimeraVez { get; set; }

        /// <summary>
        /// Gets or sets the UnicoIngreso, correspond to table field IN_UNICO_INGRESO.
        /// </summary>
        /// <value>
        /// set a value to the UnicoIngreso.
        /// </value>
        public virtual Char UnicoIngreso { get; set; }

        /// <summary>
        /// Gets or sets the HaIngresado, correspond to table field IN_HA_INGRESADO.
        /// </summary>
        /// <value>
        /// set a value to the HaIngresado.
        /// </value>
        public virtual Char HaIngresado { get; set; }

        /// <summary>
        /// Gets or sets the OtrosLogeos, correspond to table field IN_OTROS_LOGEOS.
        /// </summary>
        /// <value>
        /// set a value to the OtrosLogeos.
        /// </value>
        public virtual Char OtrosLogeos { get; set; }

        /// <summary>
        /// Gets or sets the Tipo, correspond to table field IN_TIPO.
        /// </summary>
        /// <value>
        /// set a value to the Tipo.
        /// </value>
        public virtual Char Tipo { get; set; }

        /// <summary>
        /// Gets or sets the Estado, correspond to table field IN_ACTIVO.
        /// </summary>
        /// <value>
        /// set a value to the Estado.
        /// </value>
        public virtual Char Activo { get; set; }

        /// <summary>
        /// Gets or sets the Email, correspond to table field NO_EMAIL.
        /// </summary>
        /// <value>
        /// set a value to the Email.
        /// </value>
        public virtual String Email { get; set; }
    }
}