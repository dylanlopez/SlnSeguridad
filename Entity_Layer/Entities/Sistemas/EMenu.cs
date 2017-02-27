using System;

namespace Entity_Layer.Entities.Sistemas
{
    public class EMenu
    {
        public virtual Int32 Id { get; set; }
        public virtual String Codigo { get; set; }
        public virtual String Nombre { get; set; }
        public virtual String Ruta { get; set; }
        public virtual String Descripcion { get; set; }
        public virtual Char Estado { get; set; }
        public virtual EModulo Modulo { get; set; }
    }
}