namespace Domain_Layer.Dtos.Sistemas
{
    /// <summary>
    /// Here is the DTO class DMenuDto.
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    public class DMenuDto
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DMenuDto"/> class.
        /// </summary>
        public DMenuDto()
        {
            Id = 0;
            Codigo = string.Empty;
            Nombre = string.Empty;
            Ruta = string.Empty;
            Descripcion = string.Empty;
            Activo = '\0';
            Modulo = new DModuloDto();
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
        /// Gets or sets the Ruta, correspond to entity field Ruta.
        /// </summary>
        /// <value>
        /// value to the Ruta.
        /// </value>
        public string Ruta { get; set; }

        /// <summary>
        /// Gets or sets the Estado, correspond to entity field Estado.
        /// </summary>
        /// <value>
        /// value to the Estado.
        /// </value>
        public char Activo { get; set; }

        /// <summary>
        /// Gets or sets the Descripcion, correspond to entity field Descripcion.
        /// </summary>
        /// <value>
        /// value to the Descripcion.
        /// </value>
        public string Descripcion { get; set; }

        /// <summary>
        /// Gets or sets the Modulo, correspond to entity EModulo.
        /// </summary>
        /// <value>
        /// set a value to the Modulo.
        /// </value>
        public DModuloDto Modulo { get; set; }
    }
}