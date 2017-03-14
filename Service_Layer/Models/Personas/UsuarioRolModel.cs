using System.Runtime.Serialization;

namespace Service_Layer.Models.Personas
{
    [DataContract]
    public class UsuarioRolModel
    {
        [DataMember(Name = "Id")]
        public int Id { get; set; }

        [DataMember(Name = "Usuario")]
        public UsuarioModel Usuario { get; set; }

        [DataMember(Name = "Rol")]
        public RolModel Rol { get; set; }
    }
}