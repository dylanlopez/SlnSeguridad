using Service_Layer.Models.Sistemas;
using System.Runtime.Serialization;

namespace Service_Layer.Models.Personas
{
    [DataContract]
    public class SistemaPerfilModel
    {
        public SistemaPerfilModel()
        {
            Id = 0;
            Activo = '\0';
            Sistema = new SistemaModel();
            Perfil = new PerfilModel();
        }

        [DataMember(Name = "Id", Order = 0)]
        public int Id { get; set; }

        [DataMember(Name = "Activo", Order = 1)]
        public char Activo { get; set; }

        [DataMember(Name = "Sistema", Order = 2)]
        public SistemaModel Sistema { get; set; }

        [DataMember(Name = "Perfil", Order = 3)]
        public PerfilModel Perfil { get; set; }
    }
}