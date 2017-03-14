using Interface_Layer.Models.Sistemas;
using System.Runtime.Serialization;

namespace Service_Layer.Models.Personas
{
    [DataContract]
    public class MenuRolModel
    {
        [DataMember(Name = "Id")]
        public int Id { get; set; }

        [DataMember(Name = "Menu")]
        public MenuModel Menu { get; set; }

        [DataMember(Name = "Rol")]
        public RolModel Rol { get; set; }
    }
}