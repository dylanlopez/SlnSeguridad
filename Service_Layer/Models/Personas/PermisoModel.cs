using Service_Layer.Models.Sistemas;
using System.Runtime.Serialization;

namespace Service_Layer.Models.Personas
{
    [DataContract]
    public class PermisoModel
    {
        public PermisoModel()
        {
            Id = 0;
            FechaAlta = string.Empty;
            Estado = '\0';
            PerfilUsuarioRol = new PerfilUsuarioRolModel();
            MenuOpcion = new MenuOpcionModel();
        }

        [DataMember(Name = "Id", Order = 0)]
        public int Id { get; set; }

        [DataMember(Name = "FechaAlta", Order = 1)]
        public string FechaAlta { get; set; }

        [DataMember(Name = "Estado", Order = 2)]
        public char Estado { get; set; }

        [DataMember(Name = "PerfilUsuarioRol", Order = 3)]
        public PerfilUsuarioRolModel PerfilUsuarioRol { get; set; }

        [DataMember(Name = "MenuOpcion", Order = 4)]
        public MenuOpcionModel MenuOpcion { get; set; }
    }
}