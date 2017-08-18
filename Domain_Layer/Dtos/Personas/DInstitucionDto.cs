namespace Domain_Layer.Dtos.Personas
{
    /// <summary>
    /// Here is the DTO class DInstitucionDto.
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    public class DInstitucionDto
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DInstitucionDto"/> class.
        /// </summary>
        public DInstitucionDto()
        {
            Id = 0;
            Nombre = string.Empty;
            NombreCorto = string.Empty;
            Direccion = string.Empty;
            Activo = '\0';
            TipoInstitucion = new DTipoInstitucionDto();
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
        /// Gets or sets the NombreCorto, correspond to entity field NombreCorto.
        /// </summary>
        /// <value>
        /// set a value to the NombreCorto.
        /// </value>
        public string NombreCorto { get; set; }

        /// <summary>
        /// Gets or sets the Direccion, correspond to entity field Direccion.
        /// </summary>
        /// <value>
        /// value to the Direccion.
        /// </value>
        public string Direccion { get; set; }

        /// <summary>
        /// Gets or sets the Estado, correspond to entity field Estado.
        /// </summary>
        /// <value>
        /// value to the Estado.
        /// </value>
        public char Activo { get; set; }

        /// <summary>
        /// Gets or sets the TipoInstitucion, correspond to entity TipoInstitucion.
        /// </summary>
        /// <value>
        /// set a value to the TipoInstitucion.
        /// </value>
        public DTipoInstitucionDto TipoInstitucion { get; set; }
    }
}