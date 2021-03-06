﻿namespace Domain_Layer.Dtos.Personas
{
    /// <summary>
    /// Here is the DTO class DTipoInstitucionDto.
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    public class DTipoInstitucionDto
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DTipoInstitucionDto"/> class.
        /// </summary>
        public DTipoInstitucionDto()
        {
            Id = 0;
            Nombre = string.Empty;
            Descripcion = string.Empty;
            Activo = '\0';
        }

        /// <summary>
        /// Gets or sets the Id, correspond to entity field Id.
        /// </summary>
        /// <value>
        /// value to the Id.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Nombre, correspond to entity field Nombre.
        /// </summary>
        /// <value>
        /// set a value to the Nombre.
        /// </value>
        public string Nombre { get; set; }

        /// <summary>
        /// Gets or sets the Descripcion, correspond to entity field Descripcion.
        /// </summary>
        /// <value>
        /// value to the Descripcion.
        /// </value>
        public string Descripcion { get; set; }

        /// <summary>
        /// Gets or sets the Estado, correspond to entity field Estado.
        /// </summary>
        /// <value>
        /// value to the Estado.
        /// </value>
        public char Activo { get; set; }
    }
}