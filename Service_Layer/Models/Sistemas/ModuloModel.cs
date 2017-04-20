using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Service_Layer.Models.Sistemas
{
    [DataContract]
    public class ModuloModel
    {
        public ModuloModel()
        {
            Id = 0;
            Codigo = string.Empty;
            Nombre = string.Empty;
            Abreviatura = string.Empty;
            Activo = '\0';
            Descripcion = string.Empty;
            Sistema = new SistemaModel();
            Menus = new List<MenuModel>();
        }

        [DataMember(Name = "Id", Order = 0)]
        public int Id { get; set; }

        [DataMember(Name = "Codigo", Order = 1)]
        public string Codigo { get; set; }

        [DataMember(Name = "Nombre", Order = 2)]
        public string Nombre { get; set; }

        [DataMember(Name = "Abreviatura", Order = 3)]
        public string Abreviatura { get; set; }

        [DataMember(Name = "Activo", Order = 4)]
        public char Activo { get; set; }

        [DataMember(Name = "Descripcion", Order = 5)]
        public string Descripcion { get; set; }

        [DataMember(Name = "Sistema", Order = 6)]
        public SistemaModel Sistema { get; set; }

        [DataMember(Name = "Menus", Order = 7)]
        public List<MenuModel> Menus { get; set; }
    }
}