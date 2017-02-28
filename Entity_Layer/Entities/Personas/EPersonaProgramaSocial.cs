﻿using System;

namespace Entity_Layer.Entities.Personas
{
    /// <summary>
    /// Here is the entity class EPersonaProgramaSocial, for store all the data and do the mapping after.
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    public class EPersonaProgramaSocial
    {
        /// <summary>
        /// Gets or sets the Id, correspond to table field ID_PERSONA_PROGRAMA_SOCIAL.
        /// </summary>
        /// <value>
        /// set a value to the Id.
        /// </value>
        public virtual Int32 Id { get; set; }

        /// <summary>
        /// Gets or sets the Persona, correspond to table field ID_PERSONA.
        /// </summary>
        /// <value>
        /// set a value to the Persona.
        /// </value>
        public virtual EPersona Persona { get; set; }

        /// <summary>
        /// Gets or sets the ProgramaSocial, correspond to table field ID_PROGRAMA_SOCIAL.
        /// </summary>
        /// <value>
        /// set a value to the ProgramaSocial.
        /// </value>
        public virtual EProgramaSocial ProgramaSocial { get; set; }
    }
}