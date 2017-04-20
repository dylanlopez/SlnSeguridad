using System;

namespace Entity_Layer.Entities.Sistemas
{
    /// <summary>
    /// Here is the entity class EMenuOpcion, for store all the data and do the mapping after
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    public class EMenuOpcion
    {
        /// <summary>
        /// Gets or sets the Id, correspond to table field ID_MENU_OPCION.
        /// </summary>
        /// <value>
        /// set a value to the Id.
        /// </value>
        public virtual Int32 Id { get; set; }

        /// <summary>
        /// Gets or sets the Estado, correspond to table field IN_ACTIVO.
        /// </summary>
        /// <value>
        /// set a value to the Estado.
        /// </value>
        public virtual Char Activo { get; set; }

        /// <summary>
        /// Gets or sets the Visible, correspond to table field IN_VISIBLE.
        /// </summary>
        /// <value>
        /// set a value to the Visible.
        /// </value>
        public virtual Char Visible { get; set; }

        /// <summary>
        /// Gets or sets the Menu, correspond to table field ID_MENU.
        /// </summary>
        /// <value>
        /// set a value to the Menu.
        /// </value>
        public virtual EMenu Menu { get; set; }

        /// <summary>
        /// Gets or sets the Opcion, correspond to table field ID_OPCION.
        /// </summary>
        /// <value>
        /// set a value to the Opcion.
        /// </value>
        public virtual EOpcion Opcion { get; set; }
    }
}