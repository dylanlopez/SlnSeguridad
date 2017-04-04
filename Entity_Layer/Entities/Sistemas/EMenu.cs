using System;

namespace Entity_Layer.Entities.Sistemas
{
    /// <summary>
    /// Here is the entity class EMenu, for store all the data and do the mapping after
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    /// <v2.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Include fields of database changes</description>
    /// </v2.0>
    public class EMenu
    {
        /// <summary>
        /// Gets or sets the Id, correspond to table field ID_MENU.
        /// </summary>
        /// <value>
        /// set a value to the Id.
        /// </value>
        public virtual Int32 Id { get; set; }

        /// <summary>
        /// Gets or sets the Codigo, correspond to table field CO_MENU.
        /// </summary>
        /// <value>
        /// set a value to the Codigo.
        /// </value>
        public virtual String Codigo { get; set; }

        /// <summary>
        /// Gets or sets the Nombre, correspond to table field NO_MENU.
        /// </summary>
        /// <value>
        /// set a value to the Nombre.
        /// </value>
        public virtual String Nombre { get; set; }

        /// <summary>
        /// Gets or sets the Ruta, correspond to table field DE_RUTA.
        /// </summary>
        /// <value>
        /// set a value to the Ruta.
        /// </value>
        public virtual String Ruta { get; set; }

        /// <summary>
        /// Gets or sets the Estado, correspond to table field IN_ACTIVO.
        /// </summary>
        /// <value>
        /// set a value to the Estado.
        /// </value>
        public virtual Char Estado { get; set; }

        /// <summary>
        /// Gets or sets the Descripcion, correspond to table field DE_DESCRIPCION.
        /// </summary>
        /// <value>
        /// set a value to the Descripcion.
        /// </value>
        public virtual String Descripcion { get; set; }

        /// <summary>
        /// Gets or sets the Modulo, correspond to table field ID_MODULO.
        /// </summary>
        /// <value>
        /// set a value to the Modulo.
        /// </value>
        public virtual EModulo Modulo { get; set; }
    }
}