using System;

namespace Entity_Layer.Entities.Personas
{
    public class EPersona
    {
        public virtual Int32 Id { get; set; }
        public virtual String Nombre { get; set; }
        public virtual String NumeroDocumento { get; set; }
        public virtual Char Tipo { get; set; }
        public virtual ETipoDocumentoPersona TipoDocumentoPersona { get; set; }
    }
}