using System;

namespace Entity_Layer.Entities.Personas
{
    /// <summary>
    /// Here is the entity class EInstitucion, for store all the data and do the mapping after.
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    public class EInstitucion
    {
        /// <summary>
        /// Gets or sets the Id, correspond to table field ID_INSTITUCION.
        /// </summary>
        /// <value>
        /// set a value to the Id.
        /// </value>
        public virtual Int32 Id { get; set; }

        /// <summary>
        /// Gets or sets the Nombre, correspond to table field NO_INSTITUCION.
        /// </summary>
        /// <value>
        /// set a value to the Nombre.
        /// </value>
        public virtual String Nombre { get; set; }

        /// <summary>
        /// Gets or sets the NombreCorto, correspond to table field NO_INSTITUCION_CORTA.
        /// </summary>
        /// <value>
        /// set a value to the NombreCorto.
        /// </value>
        public virtual String NombreCorto { get; set; }

        /// <summary>
        /// Gets or sets the Direccion, correspond to table field DE_DIRECCION.
        /// </summary>
        /// <value>
        /// set a value to the Direccion.
        /// </value>
        public virtual String Direccion { get; set; }

        /// <summary>
        /// Gets or sets the Activo, correspond to table field IN_ACTIVO.
        /// </summary>
        /// <value>
        /// set a value to the Activo.
        /// </value>
        public virtual Char Activo { get; set; }

        /// <summary>
        /// Gets or sets the TipoInstitucion, correspond to table field ID_INSTITUCION_TIPO.
        /// </summary>
        /// <value>
        /// set a value to the TipoInstitucion.
        /// </value>
        public virtual ETipoInstitucion TipoInstitucion { get; set; }
    }
}