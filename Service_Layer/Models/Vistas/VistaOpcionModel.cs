using System.Runtime.Serialization;

namespace Service_Layer.Models.Vistas
{
    public class VistaOpcionModel
    {
        public VistaOpcionModel()
        {
            IdOpcion = 0;
            NombreOpcion = string.Empty;
            ControlAsociado = string.Empty;
            Visible = '\0';
        }

        internal int IdOpcion { get; set; }

        [DataMember(Name = "NombreOpcion", Order = 0)]
        public string NombreOpcion { get; set; }

        [DataMember(Name = "ControlAsociado", Order = 1)]
        public string ControlAsociado { get; set; }

        [DataMember(Name = "Visible", Order = 2)]
        public char Visible { get; set; }
    }
}