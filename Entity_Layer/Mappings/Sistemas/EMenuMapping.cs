using Entity_Layer.Entities.Sistemas;
using NHibernate.Mapping.ByCode.Conformist;
using System;

namespace Entity_Layer.Mappings.Sistemas
{
    public class EMenuMapping : ClassMapping<EMenu>
    {
        public EMenuMapping()
        {
            Schema("ES_SEGURIDAD");
            Table("MENU");
            Id<Int32>(x => x.Id, col => col.Column("ID_MODULO"));
            Property<String>(x => x.Codigo,
                map =>
                {
                    map.Column("CODIGO");
                    map.Length(7);
                    map.NotNullable(true);
                });
            Property<String>(x => x.Nombre, map =>
            {
                map.Column("NOMBRE");
                map.Length(50);
                map.NotNullable(true);
            });
            Property<String>(x => x.Ruta, map =>
            {
                map.Column("RUTA");
                map.Length(200);
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
            ManyToOne<EModulo>(x => x.Modulo, map =>
            {
                map.Column("ID_MODULO");
                map.Update(false);
                map.Insert(false);
            });
        }
    }
}