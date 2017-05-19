using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Service_Layer.Models.Vistas
{
    public class VistaMenuModel
    {
        public VistaMenuModel()
        {
            IdMenu = 0;
            Codigomenu = string.Empty;
            NombreMenu = string.Empty;
            MenuRuta = string.Empty;
            Opciones = null;
        }

        internal int IdMenu { get; set; }

        internal string Codigomenu { get; set; }

        [DataMember(Name = "NombreMenu", Order = 0)]
        public string NombreMenu { get; set; }

        [DataMember(Name = "MenuRuta", Order = 1)]
        public string MenuRuta { get; set; }

        [DataMember(Name = "Opciones", Order = 2)]
        public List<VistaOpcionModel> Opciones { get; set; }
    }
}