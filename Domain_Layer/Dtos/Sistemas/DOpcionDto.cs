namespace Domain_Layer.Dtos.Sistemas
{
    /// <summary>
    /// Here is the DTO class DOpcionDto.
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    public class DOpcionDto
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DOpcionDto"/> class.
        /// </summary>
        public DOpcionDto()
        {
            Id = 0;
            Nombre = string.Empty;
            NombreControlAsociado = string.Empty;
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
        /// Gets or sets the Nombre, correspond to entity field Nombre.
        /// </summary>
        /// <value>
        /// value to the Nombre.
        /// </value>
        public string Nombre { get; set; }

        /// <summary>
        /// Gets or sets the NombreControlAsociado, correspond to entity field NombreControlAsociado.
        /// </summary>
        /// <value>
        /// value to the NombreControlAsociado.
        /// </value>
        public string NombreControlAsociado { get; set; }

        /// <summary>
        /// Gets or sets the Descripcion, correspond to entity field Descripcion.
        /// </summary>
        /// <value>
        /// value to the Descripcion.
        /// </value>
        public string Descripcion { get; set; }
    }
}