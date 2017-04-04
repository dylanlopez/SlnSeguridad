namespace Domain_Layer.Dtos.Sistemas
{
    /// <summary>
    /// Here is the DTO class DSistemaDto.
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    public class DSistemaDto
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DSistemaDto"/> class.
        /// </summary>
        public DSistemaDto()
        {
            Id = 0;
            Codigo = string.Empty;
            Nombre = string.Empty;
            Abreviatura = string.Empty;
            Estado = '\0';
            Descripcion = string.Empty;
            NombreServidor = string.Empty;
            IPServidor = string.Empty;
            RutaFisica = string.Empty;
            RutaLogica = string.Empty;
        }

        /// <summary>
        /// Gets or sets the Id, correspond to entity field Id.
        /// </summary>
        /// <value>
        /// value to the Id.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Codigo, correspond to entity field Codigo.
        /// </summary>
        /// <value>
        /// value to the Codigo.
        /// </value>
        public string Codigo { get; set; }

        /// <summary>
        /// Gets or sets the Nombre, correspond to entity field Nombre.
        /// </summary>
        /// <value>
        /// value to the Nombre.
        /// </value>
        public string Nombre { get; set; }

        /// <summary>
        /// Gets or sets the Abreviatura, correspond to entity field Abreviatura.
        /// </summary>
        /// <value>
        /// value to the Abreviatura.
        /// </value>
        public string Abreviatura { get; set; }

        /// <summary>
        /// Gets or sets the Estado, correspond to entity field Estado.
        /// </summary>
        /// <value>
        /// value to the Estado.
        /// </value>
        public char Estado { get; set; }

        /// <summary>
        /// Gets or sets the Descripcion, correspond to entity field Descripcion.
        /// </summary>
        /// <value>
        /// value to the Descripcion.
        /// </value>
        public string Descripcion { get; set; }

        /// <summary>
        /// Gets or sets the NombreServidor, correspond to entity field NombreServidor.
        /// </summary>
        /// <value>
        /// set a value to the NombreServidor.
        /// </value>
        public string NombreServidor { get; set; }

        /// <summary>
        /// Gets or sets the IPServidor, correspond to entity field IPServidor.
        /// </summary>
        /// <value>
        /// set a value to the IPServidor.
        /// </value>
        public string IPServidor { get; set; }

        /// <summary>
        /// Gets or sets the RutaFisica, correspond to entity field RutaFisica.
        /// </summary>
        /// <value>
        /// set a value to the RutaFisica.
        /// </value>
        public string RutaFisica { get; set; }

        /// <summary>
        /// Gets or sets the RutaLogica, correspond to entity field RutaLogica.
        /// </summary>
        /// <value>
        /// set a value to the RutaLogica.
        /// </value>
        public string RutaLogica { get; set; }
    }
}