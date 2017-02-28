using Entity_Layer.Entities.Sistemas;
using System;

namespace Entity_Layer.Entities.Personas
{
    /// <summary>
    /// Here is the entity class EMenuRol, for store all the data and do the mapping after.
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    public class EMenuRol
    {
        /// <summary>
        /// Gets or sets the Id, correspond to table field ID_MENU_ROL.
        /// </summary>
        /// <value>
        /// set a value to the Id.
        /// </value>
        public virtual Int32 Id { get; set; }

        /// <summary>
        /// Gets or sets the Menu, correspond to table field ID_MENU.
        /// </summary>
        /// <value>
        /// set a value to the Menu.
        /// </value>
        public virtual EMenu Menu { get; set; }

        /// <summary>
        /// Gets or sets the Rol, correspond to table field ID_ROL.
        /// </summary>
        /// <value>
        /// set a value to the Rol.
        /// </value>
        public virtual ERol Rol { get; set; }
    }
}