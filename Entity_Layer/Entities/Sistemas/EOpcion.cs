using System;

namespace Entity_Layer.Entities.Sistemas
{
    /// <summary>
    /// Here is the entity class EOpcion, for store all the data and do the mapping after
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    public class EOpcion
    {
        /// <summary>
        /// Gets or sets the Id, correspond to table field ID_OPCION.
        /// </summary>
        /// <value>
        /// set a value to the Id.
        /// </value>
        public virtual Int32 Id { get; set; }

        /// <summary>
        /// Gets or sets the Nombre, correspond to table field NO_OPCION.
        /// </summary>
        /// <value>
        /// set a value to the Nombre.
        /// </value>
        public virtual String Nombre { get; set; }

        /// <summary>
        /// Gets or sets the Nombre, correspond to table field NO_CONTROL_ASOC.
        /// </summary>
        /// <value>
        /// set a value to the Nombre.
        /// </value>
        public virtual String NombreControlAsociado { get; set; }

        /// <summary>
        /// Gets or sets the Descripcion, correspond to table field DE_DESCRIPCION.
        /// </summary>
        /// <value>
        /// set a value to the Descripcion.
        /// </value>
        public virtual String Descripcion { get; set; }
    }
}