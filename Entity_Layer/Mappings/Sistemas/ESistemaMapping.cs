using Entity_Layer.Entities.Sistemas;
using NHibernate.Mapping.ByCode.Conformist;
using System;

namespace Entity_Layer.Mappings.Sistemas
{
    public class ESistemaMapping : ClassMapping<ESistema>
    {
        public ESistemaMapping()
        {
            Schema("ES_SEGURIDAD");
            Table("SISTEMA");
            Id<Int32>(x => x.Id, col => col.Column("ID_SISTEMA"));
            Property<String>(x => x.Codigo,
                map =>
                {
                    map.Column("CODIGO");
                    map.Length(2);
                    map.NotNullable(true);
                });
            Property<String>(x => x.Nombre, map =>
            {
                map.Column("NOMBRE");
                map.Length(50);
                map.NotNullable(true);
            });
            Property<String>(x => x.Abreviatura, map =>
            {
                map.Column("ABREVIATURA");
                map.Length(20);
                map.NotNullable(true);
            });
            Property<String>(x => x.Descripcion, map =>
            {
                map.Column("DESCRIPCION");
                map.Length(200);
                map.NotNullable(false);
            });
            Property<Char>(x => x.Estado, map =>
            {
                map.Column("ESTADO");
                map.Length(1);
                map.NotNullable(true);
            });
            //Bag(x => x.Modulos, bag => {
            //    bag.Key(k => k.Column(col => col.Name("ID_SISTEMA")));
            //}, a => a.OneToMany());

            //Property<string>(x => x.Codigo,
            //    col => col.Column("CODIGO"));
            //Property<string>(x => x.Nombre,
            //    col => col.Column("NOMBRE"));
            //Property<string>(x => x.Abreviatura,
            //    col => col.Column("ABREVIATURA"));
            //Property<string>(x => x.Descripcion,
            //    col => col.Column("DESCRIPCION"));
            //Property<char>(x => x.Estado,
            //    col => col.Column("ESTADO"));
        }
    }
}