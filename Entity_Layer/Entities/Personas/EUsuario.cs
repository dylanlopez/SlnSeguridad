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
        /// Gets or sets the Usuario, correspond to table field USUARIO.
        /// </summary>
        /// <value>
        /// set a value to the Usuario.
        /// </value>
        public virtual String Usuario { get; set; }

        /// <summary>
        /// Gets or sets the Contrasena, correspond to table field CONTRASENA.
        /// </summary>
        /// <value>
        /// set a value to the Contrasena.
        /// </value>
        public virtual String Contrasena { get; set; }

        /// <summary>
        /// Gets or sets the Caduca, correspond to table field CADUCA.
        /// </summary>
        /// <value>
        /// set a value to the Caduca.
        /// </value>
        public virtual Char Caduca { get; set; }

        /// <summary>
        /// Gets or sets the PeriodoCaducidad, correspond to table field PERIODO_CADUCIDAD.
        /// </summary>
        /// <value>
        /// set a value to the PeriodoCaducidad.
        /// </value>
        public virtual Int32 PeriodoCaducidad { get; set; }

        /// <summary>
        /// Gets or sets the FechaUltimoCambio, correspond to table field FECHA_ULTIMOCAMBIO.
        /// </summary>
        /// <value>
        /// set a value to the FechaUltimoCambio.
        /// </value>
        public virtual DateTime FechaUltimoCambio { get; set; }

        /// <summary>
        /// Gets or sets the Tipo, correspond to table field TIPO.
        /// </summary>
        /// <value>
        /// set a value to the Tipo.
        /// </value>
        public virtual Char Tipo { get; set; }

        /// <summary>
        /// Gets or sets the Estado, correspond to table field ESTADO.
        /// </summary>
        /// <value>
        /// set a value to the Estado.
        /// </value>
        public virtual Char Estado { get; set; }

        /// <summary>
        /// Gets or sets the Persona, correspond to table field ID_PERSONA.
        /// </summary>
        /// <value>
        /// set a value to the Persona.
        /// </value>
        public virtual EPersona Persona { get; set; }
    }
}