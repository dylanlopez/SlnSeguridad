using System;

namespace Entity_Layer.Entities.Sistemas
{
    /// <summary>
    /// Here is the entity class EModulo, for store all the data and do the mapping after
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    public class EModulo
    {
        /// <summary>
        /// Gets or sets the Id, correspond to table field ID_MODULO.
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
        /// Gets or sets the Abreviatura, correspond to table field ABREVIATURA.
        /// </summary>
        /// <value>
        /// set a value to the Abreviatura.
        /// </value>
        public virtual String Abreviatura { get; set; }

        /// <summary>
        /// Gets or sets the Descripcion, correspond to table field DESCRIPCION.
        /// </summary>
        /// <value>
        /// set a value to the Descripcion.
        /// </value>
        public virtual String Descripcion { get; set; }

        /// <summary>
        /// Gets or sets the Estado, correspond to table field ESTADO.
        /// </summary>
        /// <value>
        /// set a value to the Estado.
        /// </value>
        public virtual Char Estado { get; set; }

        /// <summary>
        /// Gets or sets the Sistema, correspond to table field ID_SISTEMA.
        /// </summary>
        /// <value>
        /// set a value to the Sistema.
        /// </value>
        public virtual ESistema Sistema { get; set; }
    }
}