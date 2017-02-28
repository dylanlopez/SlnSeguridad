namespace Domain_Layer.Dtos.Personas
{
    /// <summary>
    /// Here is the DTO class DPersonaProgramaSocialDto.
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    public class DPersonaProgramaSocialDto
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DPersonaProgramaSocialDto"/> class.
        /// </summary>
        public DPersonaProgramaSocialDto()
        {
            Id = 0;
            Persona = new DPersonaDto();
            ProgramaSocial = new DProgramaSocialDto();
        }

        /// <summary>
        /// Gets or sets the Id, correspond to entity field Id.
        /// </summary>
        /// <value>
        /// set a value to the Id.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Persona, correspond to entity Persona.
        /// </summary>
        /// <value>
        /// value to the Persona.
        /// </value>
        public DPersonaDto Persona { get; set; }

        /// <summary>
        /// Gets or sets the ProgramaSocial, correspond to entity ProgramaSocial.
        /// </summary>
        /// <value>
        /// value to the ProgramaSocial.
        /// </value>
        public DProgramaSocialDto ProgramaSocial { get; set; }
    }
}