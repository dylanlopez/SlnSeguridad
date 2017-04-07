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
            NumeroDocumento = string.Empty;
            ApellidoPaterno = string.Empty;
            ApellidoMaterno = string.Empty;
            Nombres = string.Empty;
        }

        /// <summary>
        /// Gets or sets the Nombre, correspond to entity field Nombre.
        /// </summary>
        /// <value>
        /// set a value to the Nombre.
        /// </value>
        public string NumeroDocumento { get; set; }

        /// <summary>
        /// Gets or sets the NumeroDocumento, correspond to entity field NumeroDocumento.
        /// </summary>
        /// <value>
        /// set a value to the NumeroDocumento.
        /// </value>
        public string ApellidoPaterno { get; set; }

        /// <summary>
        /// Gets or sets the Direccion, correspond to entity field Direccion.
        /// </summary>
        /// <value>
        /// value to the Direccion.
        /// </value>
        public string ApellidoMaterno { get; set; }

        /// <summary>
        /// Gets or sets the Telefono, correspond to entity field Telefono.
        /// </summary>
        /// <value>
        /// value to the Telefono.
        /// </value>
        public string Nombres { get; set; }
    }
}