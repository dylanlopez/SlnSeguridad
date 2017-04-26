using Domain_Layer.Dtos.Sistemas;

namespace Domain_Layer.Dtos.Personas
{
    /// <summary>
    /// Here is the DTO class DSistemaPerfilDto.
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    public class DSistemaPerfilDto
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DSistemaPerfilDto"/> class.
        /// </summary>
        public DSistemaPerfilDto()
        {
            Id = 0;
            Activo = '\0';
            Sistema = new DSistemaDto();
            Perfil = new DPerfilDto();
        }

        /// <summary>
        /// Gets or sets the Id, correspond to entity field Id.
        /// </summary>
        /// <value>
        /// set a value to the Id.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Estado, correspond to entity field Estado.
        /// </summary>
        /// <value>
        /// set a value to the Estado.
        /// </value>
        public char Activo { get; set; }

        /// <summary>
        /// Gets or sets the Sistema, correspond to entity field Sistema.
        /// </summary>
        /// <value>
        /// set a value to the Sistema.
        /// </value>
        public DSistemaDto Sistema { get; set; }

        /// <summary>
        /// Gets or sets the Perfil, correspond to entity field Perfil.
        /// </summary>
        /// <value>
        /// set a value to the Perfil.
        /// </value>
        public DPerfilDto Perfil { get; set; }
    }
}