using Service_Layer.Models.Sistemas;
using System.Runtime.Serialization;

namespace Service_Layer.Models.Personas
{
    [DataContract]
    public class MenuRolModel
    {
        public MenuRolModel()
        {
            Id = 0;
            Menu = new MenuModel();
            Rol = new RolModel();
        }

        [DataMember(Name = "Id")]
        public int Id { get; set; }

        [DataMember(Name = "Menu")]
        public MenuModel Menu { get; set; }

        [DataMember(Name = "Rol")]
        public RolModel Rol { get; set; }
    }
}