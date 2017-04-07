using System;

namespace Entity_Layer.Entities.Personas
{
    /// <summary>
    /// Here is the entity class EPersona, for store all the data and do the mapping after.
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    public class EPersona
    {
        /// <summary>
        /// Gets or sets the NumeroDocumento, correspond to table field NUMERO_DOCUMENTO.
        /// </summary>
        /// <value>
        /// set a value to the NumeroDocumento.
        /// </value>
        public virtual String NumeroDocumento { get; set; }

        /// <summary>
        /// Gets or sets the Nombre, correspond to table field NOMBRE.
        /// </summary>
        /// <value>
        /// set a value to the Nombre.
        /// </value>
        public virtual String ApellidoPaterno { get; set; }

        /// <summary>
        /// Gets or sets the Direccion, correspond to table field DIRECCION.
        /// </summary>
        /// <value>
        /// set a value to the Direccion.
        /// </value>
        public virtual String ApellidoMaterno { get; set; }

        /// <summary>
        /// Gets or sets the Telefono, correspond to table field TELEFONO.
        /// </summary>
        /// <value>
        /// set a value to the Telefono.
        /// </value>
        public virtual String Nombres { get; set; }
    }
}