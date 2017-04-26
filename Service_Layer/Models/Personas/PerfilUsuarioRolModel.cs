using System.Runtime.Serialization;

namespace Service_Layer.Models.Personas
{
    public class PerfilUsuarioRolModel
    {
        public PerfilUsuarioRolModel()
        {
            Id = 0;
            Activo = '\0';
            Perfil = new PerfilModel();
            Usuario = new UsuarioModel();
            Rol = new RolModel();
        }

        [DataMember(Name = "Id", Order = 0)]
        public int Id { get; set; }

        [DataMember(Name = "Activo", Order = 1)]
        public char Activo { get; set; }

        [DataMember(Name = "Perfil", Order = 2)]
        public PerfilModel Perfil { get; set; }

        [DataMember(Name = "Usuario", Order = 3)]
        public UsuarioModel Usuario { get; set; }

        [DataMember(Name = "Rol", Order = 4)]
        public RolModel Rol { get; set; }
    }
}