using Domain_Layer.Dtos.Sistemas;

namespace Domain_Layer.Dtos.Personas
{
    /// <summary>
    /// Here is the DTO class DMenuRolDto.
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    public class DMenuRolDto
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DMenuRolDto"/> class.
        /// </summary>
        public DMenuRolDto()
        {
            Id = 0;
            Menu = new DMenuDto();
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
        /// Gets or sets the Menu, correspond to entity Menu.
        /// </summary>
        /// <value>
        /// set a value to the Menu.
        /// </value>
        public DMenuDto Menu { get; set; }

        /// <summary>
        /// Gets or sets the Rol, correspond to entity Rol.
        /// </summary>
        /// <value>
        /// set a value to the Rol.
        /// </value>
        public DRolDto Rol { get; set; }
    }
}