namespace Domain_Layer.Dtos.Personas
{
    /// <summary>
    /// Here is the DTO class DPersonaDto.
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    public class DPersonaDto
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DPersonaDto"/> class.
        /// </summary>
        public DPersonaDto()
        {
            Id = 0;
            Nombre = string.Empty;
            NumeroDocumento = string.Empty;
            Tipo = '\0';
            TipoDocumentoPersona = new DTipoDocumentoPersonaDto();
        }

        /// <summary>
        /// Gets or sets the Id, correspond to entity field Id.
        /// </summary>
        /// <value>
        /// set a value to the Id.
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
        /// Gets or sets the NumeroDocumento, correspond to entity field NumeroDocumento.
        /// </summary>
        /// <value>
        /// set a value to the NumeroDocumento.
        /// </value>
        public string NumeroDocumento { get; set; }

        /// <summary>
        /// Gets or sets the Direccion, correspond to entity field Direccion.
        /// </summary>
        /// <value>
        /// value to the Direccion.
        /// </value>
        public string Direccion { get; set; }

        /// <summary>
        /// Gets or sets the Telefono, correspond to entity field Telefono.
        /// </summary>
        /// <value>
        /// value to the Telefono.
        /// </value>
        public string Telefono { get; set; }

        /// <summary>
        /// Gets or sets the Celular, correspond to entity field Celular.
        /// </summary>
        /// <value>
        /// value to the Celular.
        /// </value>
        public string Celular { get; set; }

        /// <summary>
        /// Gets or sets the Email, correspond to entity field Email.
        /// </summary>
        /// <value>
        /// value to the Email.
        /// </value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the Tipo, correspond to entity field Tipo.
        /// </summary>
        /// <value>
        /// value to the Tipo.
        /// </value>
        public char Tipo { get; set; }

        /// <summary>
        /// Gets or sets the Ambito, correspond to entity field Ambito.
        /// </summary>
        /// <value>
        /// value to the Ambito.
        /// </value>
        public char Ambito { get; set; }

        /// <summary>
        /// Gets or sets the TipoDocumentoPersona, correspond to entity TipoDocumentoPersona.
        /// </summary>
        /// <value>
        /// value to the TipoDocumentoPersona.
        /// </value>
        public DTipoDocumentoPersonaDto TipoDocumentoPersona { get; set; }
    }
}