﻿using System;

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
        /// Gets or sets the Id, correspond to table field ID_PERSONA.
        /// </summary>
        /// <value>
        /// set a value to the Id.
        /// </value>
        public virtual Int32 Id { get; set; }

        /// <summary>
        /// Gets or sets the Nombre, correspond to table field NOMBRE.
        /// </summary>
        /// <value>
        /// set a value to the Nombre.
        /// </value>
        public virtual String Nombre { get; set; }

        /// <summary>
        /// Gets or sets the NumeroDocumento, correspond to table field NUMERO_DOCUMENTO.
        /// </summary>
        /// <value>
        /// set a value to the NumeroDocumento.
        /// </value>
        public virtual String NumeroDocumento { get; set; }

        /// <summary>
        /// Gets or sets the Tipo, correspond to table field TIPO.
        /// </summary>
        /// <value>
        /// set a value to the Tipo.
        /// </value>
        public virtual Char Tipo { get; set; }

        /// <summary>
        /// Gets or sets the TipoDocumentoPersona, correspond to table field ID_TIPO_DOCUMENTO_PERSONA.
        /// </summary>
        /// <value>
        /// set a value to the TipoDocumentoPersona.
        /// </value>
        public virtual ETipoDocumentoPersona TipoDocumentoPersona { get; set; }
    }
}