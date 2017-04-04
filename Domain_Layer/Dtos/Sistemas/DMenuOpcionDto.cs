namespace Domain_Layer.Dtos.Sistemas
{
    /// <summary>
    /// Here is the DTO class DMenuOpcionDto.
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    public class DMenuOpcionDto
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DMenuOpcionDto"/> class.
        /// </summary>
        public DMenuOpcionDto()
        {
            Id = 0;
            Estado = '\0';
            Visible = '\0';
            Menu = new DMenuDto();
            Opcion = new DOpcionDto();
        }

        /// <summary>
        /// Gets or sets the Id, correspond to entity field Id.
        /// </summary>
        /// <value>
        /// value to the Id.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Estado, correspond to entity field Estado.
        /// </summary>
        /// <value>
        /// value to the Estado.
        /// </value>
        public char Estado { get; set; }

        /// <summary>
        /// Gets or sets the Visible, correspond to entity field Visible.
        /// </summary>
        /// <value>
        /// value to the Visible.
        /// </value>
        public char Visible { get; set; }

        /// <summary>
        /// Gets or sets the Menu, correspond to entity EMenu.
        /// </summary>
        /// <value>
        /// set a value to the Menu.
        /// </value>
        public DMenuDto Menu { get; set; }

        /// <summary>
        /// Gets or sets the Opcion, correspond to entity EOpcion.
        /// </summary>
        /// <value>
        /// set a value to the Opcion.
        /// </value>
        public DOpcionDto Opcion { get; set; }
    }
}