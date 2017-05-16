using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Service_Layer.Models.Vistas
{
    [DataContract]
    public class AcreditacionUPSResponse
    {
        public AcreditacionUPSResponse()
        {
            Codigo = "0000";
            Descripcion = "Ok";
            Result = null;
        }

        [DataMember(Name = "Codigo", Order = 0)]
        public string Codigo { get; set; }

        [DataMember(Name = "Descripcion", Order = 1)]
        public string Descripcion { get; set; }

        [DataMember(Name = "Result", Order = 2)]
        public List<VistaPermisoModel> Result { get; set; }
    }
}