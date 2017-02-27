using System;

namespace Entity_Layer.Entities.Personas
{
    public class EUsuario
    {
        public virtual Int32 Id { get; set; }
        public virtual String Usuario { get; set; }
        public virtual String Contrasena { get; set; }
        public virtual Char Caduca { get; set; }
        public virtual Int32 PeriodoCaducidad { get; set; }
        public virtual DateTime FechaUltimoCambio { get; set; }
        public virtual Char Tipo { get; set; }
        public virtual Char Estado { get; set; }
        public virtual EPersona Persona { get; set; }
    }
}