namespace Domain_Layer.Dtos.Personas
{
    /// <summary>
    /// Here is the DTO class DUsuarioRolDto.
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    public class DUsuarioRolDto
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DUsuarioRolDto"/> class.
        /// </summary>
        public DUsuarioRolDto()
        {
            Id = 0;
            Usuario = new DUsuarioDto();
            Rol = new DRolDto();
        }

        /// <summary>
        /// Gets or sets the Id, correspond to entity field Id.
        /// </summary>
        /// <value>
        /// set a value to the Id.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Usuario, correspond to entity Usuario.
        /// </summary>
        /// <value>
        /// set a value to the Usuario.
        /// </value>
        public DUsuarioDto Usuario { get; set; }

        /// <summary>
        /// Gets or sets the Rol, correspond to entity Rol.
        /// </summary>
        /// <value>
        /// set a value to the Rol.
        /// </value>
        public DRolDto Rol { get; set; }
    }
}