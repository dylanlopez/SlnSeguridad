namespace Domain_Layer.Dtos.Sistemas
{
    /// <summary>
    /// Here is the DTO class DModuloDto.
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    public class DModuloDto
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DModuloDto"/> class.
        /// </summary>
        public DModuloDto()
        {
            Id = 0;
            Codigo = string.Empty;
            Nombre = string.Empty;
            Abreviatura = string.Empty;
            Descripcion = string.Empty;
            Activo = '\0';
            Sistema = new DSistemaDto();
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
        /// Gets or sets the Sistema, correspond to entity ESistema.
        /// </summary>
        /// <value>
        /// set a value to the Sistema.
        /// </value>
        public DSistemaDto Sistema { get; set; }
    }
}