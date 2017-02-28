using System;

namespace Entity_Layer.Entities.Personas
{
    /// <summary>
    /// Here is the entity class EProgramaSocial, for store all the data and do the mapping after.
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    public class EProgramaSocial
    {
        /// <summary>
        /// Gets or sets the Id, correspond to table field ID_PROGRAMA_SOCIAL.
        /// </summary>
        /// <value>
        /// set a value to the Id.
        /// </value>
        public virtual Int32 Id { get; set; }

        /// <summary>
        /// Gets or sets the Codigo, correspond to table field CODIGO.
        /// </summary>
        /// <value>
        /// set a value to the Codigo.
        /// </value>
        public virtual String Codigo { get; set; }

        /// <summary>
        /// Gets or sets the Nombre, correspond to table field NOMBRE.
        /// </summary>
        /// <value>
        /// set a value to the Nombre.
        /// </value>
        public virtual String Nombre { get; set; }

        /// <summary>
        /// Gets or sets the Descripcion, correspond to table field DESCRIPCION.
        /// </summary>
        /// <value>
        /// set a value to the Descripcion.
        /// </value>
        public virtual String Descripcion { get; set; }

        /// <summary>
        /// Gets or sets the Alcance, correspond to table field ALCANCE.
        /// </summary>
        /// <value>
        /// set a value to the Alcance.
        /// </value>
        public virtual String Alcance { get; set; }

        /// <summary>
        /// Gets or sets the Estado, correspond to table field ESTADO.
        /// </summary>
        /// <value>
        /// set a value to the Estado.
        /// </value>
        public virtual Char Estado { get; set; }
    }
}