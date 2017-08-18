using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Service_Layer.Models.Vistas
{
    public class VistaSistemaModel
    {
        public VistaSistemaModel()
        {
            IdSistema = 0;
            CodigoSistema = string.Empty;
            AbreviaturaSistema = string.Empty;
            NombreSistema = string.Empty;
            RutaLogica = string.Empty;
            Modulos = null;
        }

        internal int IdSistema { get; set; }

        [DataMember(Name = "CodigoSistema", Order = 0)]
        public string CodigoSistema { get; set; }

        [DataMember(Name = "AbreviaturaSistema", Order = 1)]
        public string AbreviaturaSistema { get; set; }

        [DataMember(Name = "NombreSistema", Order = 2)]
        public string NombreSistema { get; set; }

        [DataMember(Name = "RutaLogica", Order = 3)]
        public string RutaLogica { get; set; }

        [DataMember(Name = "Modulos", Order = 4)]
        public List<VistaModuloModel> Modulos { get; set; }
    }
}