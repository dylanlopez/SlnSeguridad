using System.Runtime.Serialization;

namespace Service_Layer.Models.Sistemas
{
    public class MenuOpcionModel
    {
        public MenuOpcionModel()
        {
            Id = 0;
            Activo = '\0';
            Visible = '\0';
            Menu = new MenuModel();
            Opcion = new OpcionModel();
        }

        [DataMember(Name = "Id", Order = 0)]
        public int Id { get; set; }

        [DataMember(Name = "Activo", Order = 1)]
        public char Activo { get; set; }

        [DataMember(Name = "Visible", Order = 2)]
        public char Visible { get; set; }

        [DataMember(Name = "Menu", Order = 3)]
        public MenuModel Menu { get; set; }

        [DataMember(Name = "Opcion", Order = 4)]
        public OpcionModel Opcion { get; set; }
    }
}