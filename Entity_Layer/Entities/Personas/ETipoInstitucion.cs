using System;

namespace Entity_Layer.Entities.Personas
{
    /// <summary>
    /// Here is the entity class ETipoInstitucion, for store all the data and do the mapping after.
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    public class ETipoInstitucion
    {
        /// <summary>
        /// Gets or sets the Id, correspond to table field ID_INSTITUCION_TIPO.
        /// </summary>
        /// <value>
        /// set a value to the Id.
        /// </value>
        public virtual Int32 Id { get; set; }
        
        /// <summary>
        /// Gets or sets the Nombre, correspond to table field NO_INSTITUCION_TIPO.
        /// </summary>
        /// <value>
        /// set a value to the Nombre.
        /// </value>
        public virtual String Nombre { get; set; }

        /// <summary>
        /// Gets or sets the Descripcion, correspond to table field DE_DESCRIPCION.
        /// </summary>
        /// <value>
        /// set a value to the Descripcion.
        /// </value>
        public virtual String Descripcion { get; set; }

        /// <summary>
        /// Gets or sets the Activo, correspond to table field IN_ACTIVO.
        /// </summary>
        /// <value>
        /// set a value to the Activo.
        /// </value>
        public virtual Char Activo { get; set; }
    }
}