using System;

namespace Entity_Layer.Entities.Personas
{
    public class EPersonaProgramaSocial
    {
        public virtual Int32 Id { get; set; }
        public virtual EPersona Persona { get; set; }
        public virtual EProgramaSocial ProgramaSocial { get; set; }
    }
}