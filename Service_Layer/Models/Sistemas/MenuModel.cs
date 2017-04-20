using System.Runtime.Serialization;

namespace Service_Layer.Models.Sistemas
{
    [DataContract]
    public class MenuModel
    {
        public MenuModel()
        {
            Id = 0;
            Codigo = string.Empty;
            Nombre = string.Empty;
            Ruta = string.Empty;
            Activo = '\0';
            Descripcion = string.Empty;
            Modulo = new ModuloModel();
        }

        [DataMember(Name = "Id", Order = 0)]
        public int Id { get; set; }

        [DataMember(Name = "Codigo", Order = 1)]
        public string Codigo { get; set; }

        [DataMember(Name = "Nombre", Order = 2)]
        public string Nombre { get; set; }

        [DataMember(Name = "Ruta", Order = 3)]
        public string Ruta { get; set; }

        [DataMember(Name = "Activo", Order = 4)]
        public char Activo { get; set; }

        [DataMember(Name = "Descripcion", Order = 5)]
        public string Descripcion { get; set; }

        [DataMember(Name = "Modulo", Order = 6)]
        public ModuloModel Modulo { get; set; }
    }
}