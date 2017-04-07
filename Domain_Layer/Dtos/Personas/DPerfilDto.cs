namespace Domain_Layer.Dtos.Personas
{
    /// <summary>
    /// Here is the DTO class DPerfilDto.
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    public class DPerfilDto
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DPerfilDto"/> class.
        /// </summary>
        public DPerfilDto()
        {
            Id = 0;
            Nombre = string.Empty;
            Descripcion = string.Empty;
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
        /// Gets or sets the Descripcion, correspond to entity field Descripcion.
        /// </summary>
        /// <value>
        /// set a value to the Descripcion.
        /// </value>
        public string Descripcion { get; set; }
    }
}