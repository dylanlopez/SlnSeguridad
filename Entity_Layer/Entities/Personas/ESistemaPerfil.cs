using Entity_Layer.Entities.Sistemas;
using System;

namespace Entity_Layer.Entities.Personas
{
    /// <summary>
    /// Here is the entity class ESistemaPerfil, for store all the data and do the mapping after.
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    public class ESistemaPerfil
    {
        /// <summary>
        /// Gets or sets the Id, correspond to table field ID_PERFIL.
        /// </summary>
        /// <value>
        /// set a value to the Id.
        /// </value>
        public virtual Int32 Id { get; set; }

        /// <summary>
        /// Gets or sets the Activo, correspond to table field IN_ACTIVO.
        /// </summary>
        /// <value>
        /// set a value to the Activo.
        /// </value>
        public virtual Char Activo { get; set; }

        /// <summary>
        /// Gets or sets the Sistema, correspond to table field ID_SISTEMA.
        /// </summary>
        /// <value>
        /// set a value to the Sistema.
        /// </value>
        public virtual ESistema Sistema { get; set; }

        /// <summary>
        /// Gets or sets the Perfil, correspond to table field ID_PERFIL.
        /// </summary>
        /// <value>
        /// set a value to the Perfil.
        /// </value>
        public virtual EPerfil Perfil { get; set; }
    }
}