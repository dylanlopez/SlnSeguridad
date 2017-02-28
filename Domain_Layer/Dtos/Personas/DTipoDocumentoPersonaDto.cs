namespace Domain_Layer.Dtos.Personas
{
    /// <summary>
    /// Here is the DTO class DProgramaSocialDto.
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    public class DTipoDocumentoPersonaDto
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DTipoDocumentoPersonaDto"/> class.
        /// </summary>
        public DTipoDocumentoPersonaDto()
        {
            Id = 0;
            Codigo = string.Empty;
            Nombre = string.Empty;
            Abreviatura = string.Empty;
            Descripcion = string.Empty;
        }

        /// <summary>
        /// Gets or sets the Id, correspond to entity field Id.
        /// </summary>
        /// <value>
        /// value to the Id.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Codigo, correspond to entity field Codigo.
        /// </summary>
        /// <value>
        /// set a value to the Codigo.
        /// </value>
        public string Codigo { get; set; }

        /// <summary>
        /// Gets or sets the Nombre, correspond to entity field Nombre.
        /// </summary>
        /// <value>
        /// set a value to the Nombre.
        /// </value>
        public string Nombre { get; set; }

        /// <summary>
        /// Gets or sets the Abreviatura, correspond to entity field Abreviatura.
        /// </summary>
        /// <value>
        /// value to the Abreviatura.
        /// </value>
        public string Abreviatura { get; set; }

        /// <summary>
        /// Gets or sets the Descripcion, correspond to entity field Descripcion.
        /// </summary>
        /// <value>
        /// value to the Descripcion.
        /// </value>
        public string Descripcion { get; set; }
    }
}