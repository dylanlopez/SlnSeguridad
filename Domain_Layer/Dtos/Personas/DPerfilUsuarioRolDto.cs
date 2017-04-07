namespace Domain_Layer.Dtos.Personas
{
    public class DPerfilUsuarioRolDto
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DPerfilUsuarioRolDto"/> class.
        /// </summary>
        public DPerfilUsuarioRolDto()
        {
            Id = 0;
            Estado = '\0';
            Perfil = new DPerfilDto();
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
        /// Gets or sets the Estado, correspond to entity field Estado.
        /// </summary>
        /// <value>
        /// set a value to the Estado.
        /// </value>
        public char Estado { get; set; }

        /// <summary>
        /// Gets or sets the Perfil, correspond to entity field Perfil.
        /// </summary>
        /// <value>
        /// set a value to the Perfil.
        /// </value>
        public DPerfilDto Perfil { get; set; }

        /// <summary>
        /// Gets or sets the Usuario, correspond to entity field Usuario.
        /// </summary>
        /// <value>
        /// set a value to the Usuario.
        /// </value>
        public DUsuarioDto Usuario { get; set; }

        /// <summary>
        /// Gets or sets the Rol, correspond to entity field Rol.
        /// </summary>
        /// <value>
        /// set a value to the Rol.
        /// </value>
        public DRolDto Rol { get; set; }
    }
}