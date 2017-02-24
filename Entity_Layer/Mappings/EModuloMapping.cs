using Entity_Layer.Entities;
using NHibernate.Mapping.ByCode.Conformist;

namespace Entity_Layer.Mappings
{
    public class EModuloMapping : ClassMapping<EModulo>
    {
        public EModuloMapping()
        {
            Schema("ES_SEGURIDAD");
            Table("MODULO");
            Id<int>(x => x.Id, col => col.Column("ID_MODULO"));
            Property<string>(x => x.Codigo,
                map =>
                {
                    map.Column("CODIGO");
                    map.Length(4);
                    map.NotNullable(true);
                });
            Property<string>(x => x.Nombre, map =>
            {
                map.Column("NOMBRE");
                map.Length(50);
                map.NotNullable(true);
            });
            Property<string>(x => x.Abreviatura, map =>
            {
                map.Column("ABREVIATURA");
                map.Length(20);
                map.NotNullable(true);
            });
            Property<string>(x => x.Descripcion, map =>
            {
                map.Column("DESCRIPCION");
                map.Length(200);
                map.NotNullable(false);
            });
            Property<char>(x => x.Estado, map =>
            {
                map.Column("ESTADO");
                map.Length(1);
                map.NotNullable(true);
            });
            ManyToOne(x => x.Sistema, map =>
            {
                map.Column("ID_SISTEMA");
                map.Update(false);
                map.Insert(false);
            });
        }
    }
}