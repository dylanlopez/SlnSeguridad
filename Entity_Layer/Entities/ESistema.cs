//using NHibernate.Mapping;
using System;
//using System.Collections;
using System.Collections.Generic;

namespace Entity_Layer.Entities
{
    public class ESistema
    {
        public ESistema()
        {
            //Modulos = new List();
        }

        public virtual Int32 Id { get; set; }
        public virtual String Codigo { get; set; }
        public virtual String Nombre { get; set; }
        public virtual String Abreviatura { get; set; }
        public virtual String Descripcion { get; set; }
        public virtual Char Estado { get; set; }
        public virtual ICollection<EModulo> Modulos { get; set; }
    }
}