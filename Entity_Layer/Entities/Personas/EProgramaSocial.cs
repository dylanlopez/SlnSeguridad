using System;

namespace Entity_Layer.Entities.Personas
{
    public class EProgramaSocial
    {
        public virtual Int32 Id { get; set; }
        public virtual String Codigo { get; set; }
        public virtual String Nombre { get; set; }
        public virtual String Descripcion { get; set; }
        public virtual String Alcance { get; set; }
        public virtual Char Estado { get; set; }
    }
}