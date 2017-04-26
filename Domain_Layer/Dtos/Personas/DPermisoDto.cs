using Domain_Layer.Dtos.Sistemas;

namespace Domain_Layer.Dtos.Personas
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DPermisoDto"/> class.
    /// </summary>
    public class DPermisoDto
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DPermisoDto"/> class.
        /// </summary>
        public DPermisoDto()
        {
            Id = 0;
            FechaAlta = string.Empty;
            Activo = '\0';
            PerfilUsuarioRol = new DPerfilUsuarioRolDto();
            MenuOpcion = new DMenuOpcionDto();
        }

        /// <summary>
        /// Gets or sets the Id, correspond to entity field Id.
        /// </summary>
        /// <value>
        /// set a value to the Id.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the FechaAlta, correspond to entity field FechaAlta.
        /// </summary>
        /// <value>
        /// set a value to the FechaAlta.
        /// </value>
        public string FechaAlta { get; set; }

        /// <summary>
        /// Gets or sets the Estado, correspond to entity field Estado.
        /// </summary>
        /// <value>
        /// set a value to the Estado.
        /// </value>
        public char Activo { get; set; }

        /// <summary>
        /// Gets or sets the PerfilUsuarioRol, correspond to entity field PerfilUsuarioRol.
        /// </summary>
        /// <value>
        /// set a value to the PerfilUsuarioRol.
        /// </value>
        public DPerfilUsuarioRolDto PerfilUsuarioRol { get; set; }

        /// <summary>
        /// Gets or sets the MenuOpcion, correspond to entity field MenuOpcion.
        /// </summary>
        /// <value>
        /// set a value to the MenuOpcion.
        /// </value>
        public DMenuOpcionDto MenuOpcion { get; set; }
    }
}