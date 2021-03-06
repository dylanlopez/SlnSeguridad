﻿using System.Runtime.Serialization;

namespace Service_Layer.Models.Personas
{
    [DataContract]
    public class RolModel
    {
        public RolModel()
        {
            Id = 0;
            Nombre = string.Empty;
            Descripcion = string.Empty;
        }

        [DataMember(Name = "Id")]
        public int Id { get; set; }

        [DataMember(Name = "Nombre")]
        public string Nombre { get; set; }

        [DataMember(Name = "Descripcion")]
        public string Descripcion { get; set; }
    }
}