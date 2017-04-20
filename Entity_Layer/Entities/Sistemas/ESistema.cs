using System;

namespace Entity_Layer.Entities.Sistemas
{
    /// <summary>
    /// Here is the entity class ESistema, for store all the data and do the mapping after.
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
    public class ESistema
    {
        /// <summary>
        /// Gets or sets the Id, correspond to table field ID_SISTEMA.
        /// </summary>
        /// <value>
        /// set a value to the Id.
        /// </value>
        public virtual Int32 Id { get; set; }

        /// <summary>
        /// Gets or sets the Codigo, correspond to table field CO_SISTEMA.
        /// </summary>
        /// <value>
        /// set a value to the Codigo.
        /// </value>
        public virtual String Codigo { get; set; }

        /// <summary>
        /// Gets or sets the Nombre, correspond to table field NO_SISTEMA.
        /// </summary>
        /// <value>
        /// set a value to the Nombre.
        /// </value>
        public virtual String Nombre { get; set; }

        /// <summary>
        /// Gets or sets the Abreviatura, correspond to table field NO_ABREVIATURA.
        /// </summary>
        /// <value>
        /// set a value to the Abreviatura.
        /// </value>
        public virtual String Abreviatura { get; set; }

        /// <summary>
        /// Gets or sets the Estado, correspond to table field IN_ACTIVO.
        /// </summary>
        /// <value>
        /// set a value to the Estado.
        /// </value>
        public virtual Char Activo { get; set; }

        /// <summary>
        /// Gets or sets the Descripcion, correspond to table field DE_DESCRIPCION.
        /// </summary>
        /// <value>
        /// set a value to the Descripcion.
        /// </value>
        public virtual String Descripcion { get; set; }

        /// <summary>
        /// Gets or sets the NombreServidor, correspond to table field NO_SERVIDOR.
        /// </summary>
        /// <value>
        /// set a value to the NombreServidor.
        /// </value>
        public virtual String NombreServidor { get; set; }

        /// <summary>
        /// Gets or sets the IPServidor, correspond to table field IP_SERVIDOR.
        /// </summary>
        /// <value>
        /// set a value to the IPServidor.
        /// </value>
        public virtual String IPServidor { get; set; }

        /// <summary>
        /// Gets or sets the RutaFisica, correspond to table field DE_RUTA_FISICA.
        /// </summary>
        /// <value>
        /// set a value to the RutaFisica.
        /// </value>
        public virtual String RutaFisica { get; set; }

        /// <summary>
        /// Gets or sets the RutaLogica, correspond to table field DE_RUTA_LOGICA.
        /// </summary>
        /// <value>
        /// set a value to the RutaLogica.
        /// </value>
        public virtual String RutaLogica { get; set; }
    }
}