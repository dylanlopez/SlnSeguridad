using System;

namespace Entity_Layer.Entities.Personas
{
    /// <summary>
    /// Here is the entity class EUsuarioRol, for store all the data and do the mapping after.
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    public class EUsuarioRol
    {
        /// <summary>
        /// Gets or sets the Id, correspond to table field ID_USUARIO_ROL.
        /// </summary>
        /// <value>
        /// set a value to the Id.
        /// </value>
        public virtual Int32 Id { get; set; }

        /// <summary>
        /// Gets or sets the Usuario, correspond to table field ID_USUARIO.
        /// </summary>
        /// <value>
        /// set a value to the Usuario.
        /// </value>
        public virtual EUsuario Usuario { get; set; }

        /// <summary>
        /// Gets or sets the Rol, correspond to table field ID_ROL.
        /// </summary>
        /// <value>
        /// set a value to the Rol.
        /// </value>
        public virtual ERol Rol { get; set; }
    }
}