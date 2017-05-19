using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Service_Layer.Models.Vistas
{
    public class VistaModuloModel
    {
        public VistaModuloModel()
        {
            IdModulo = 0;
            CodigoModulo = string.Empty;
            NombreModulo = string.Empty;
            Menus = null;
        }

        internal int IdModulo { get; set; }

        [DataMember(Name = "CodigoModulo", Order = 0)]
        public string CodigoModulo { get; set; }

        [DataMember(Name = "NombreModulo", Order = 1)]
        public string NombreModulo { get; set; }

        [DataMember(Name = "Menus", Order = 2)]
        public List<VistaMenuModel> Menus { get; set; }
    }
}