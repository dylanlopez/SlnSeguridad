using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Service_Layer.Models.Sistemas
{
    [DataContract]
    public class SistemaModel
    {
        public SistemaModel()
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
            Modulos = new List<ModuloModel>();
        }

        [DataMember(Name = "Id", Order = 0)]
        public int Id { get; set; }

        [DataMember(Name = "Codigo", Order = 1)]
        public string Codigo { get; set; }

        [DataMember(Name = "Nombre", Order = 2)]
        public string Nombre { get; set; }

        [DataMember(Name = "Abreviatura", Order = 3)]
        public string Abreviatura { get; set; }

        [DataMember(Name = "Estado", Order = 4)]
        public char Estado { get; set; }

        [DataMember(Name = "Descripcion", Order = 5)]
        public string Descripcion { get; set; }

        [DataMember(Name = "NombreServidor", Order = 6)]
        public string NombreServidor { get; set; }

        [DataMember(Name = "IPServidor", Order = 7)]
        public string IPServidor { get; set; }

        [DataMember(Name = "RutaFisica", Order = 8)]
        public string RutaFisica { get; set; }

        [DataMember(Name = "RutaLogica", Order = 9)]
        public string RutaLogica { get; set; }

        [DataMember(Name = "Modulos", Order = 10)]
        public List<ModuloModel> Modulos { get; set; }
    }
}