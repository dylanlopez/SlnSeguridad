using System;

namespace Entity_Layer.Entities
{
    public class EModulo
    {
        public virtual Int32 Id { get; set; }
        public virtual String Codigo { get; set; }
        public virtual String Nombre { get; set; }
        public virtual String Abreviatura { get; set; }
        public virtual String Descripcion { get; set; }
        public virtual Char Estado { get; set; }
        public virtual ESistema Sistema { get; set; }
    }
}