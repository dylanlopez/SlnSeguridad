using Entity_Layer.Entities.Sistemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Layer.Entities.Personas
{
    /// <summary>
    /// Here is the entity class EPermiso, for store all the data and do the mapping after.
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    public class EPermiso
    {
        /// <summary>
        /// Gets or sets the Id, correspond to table field ID_ROL.
        /// </summary>
        /// <value>
        /// set a value to the Id.
        /// </value>
        public virtual Int32 Id { get; set; }

        /// <summary>
        /// Gets or sets the Id, correspond to table field ID_ROL.
        /// </summary>
        /// <value>
        /// set a value to the Id.
        /// </value>
        public virtual DateTime FechaAlta { get; set; }

        /// <summary>
        /// Gets or sets the Estado, correspond to table field IN_ACTIVO.
        /// </summary>
        /// <value>
        /// set a value to the Estado.
        /// </value>
        public virtual Char Estado { get; set; }

        /// <summary>
        /// Gets or sets the PerfilUsuarioRol, correspond to table field ID_PERFIL_USUARIO_ROL.
        /// </summary>
        /// <value>
        /// set a value to the PerfilUsuarioRol.
        /// </value>
        public virtual EPerfilUsuarioRol PerfilUsuarioRol { get; set; }

        /// <summary>
        /// Gets or sets the MenuOpcion, correspond to table field ID_MENU_OPCION.
        /// </summary>
        /// <value>
        /// set a value to the MenuOpcion.
        /// </value>
        public virtual EMenuOpcion MenuOpcion { get; set; }
    }
}