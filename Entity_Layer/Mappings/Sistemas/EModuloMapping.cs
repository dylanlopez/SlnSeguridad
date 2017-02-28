using Entity_Layer.Entities.Sistemas;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;

namespace Entity_Layer.Mappings.Sistemas
{
    /// <summary>
    /// Here is the mapping class EModuloMapping, on which entity-class mapping is performed using the NHibernate ClassMapping. Here
    /// MODULO table is mapped over EModulo entity class.
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    /// <seealso cref="NHibernate.Mapping.ByCode.Conformist.ClassMapping{Entity_Layer.Entities.Sistemas.EModulo}" />
    public class EModuloMapping : ClassMapping<EModulo>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EModuloMapping"/> class.
        /// </summary>
        public EModuloMapping()
        {
            Schema("ES_SEGURIDAD");
            Table("MODULO");
            Id<Int32>(
                x => x.Id,
                map => {
                    map.Column("ID_MODULO");
                    map.Generator(
                        Generators.Sequence,
                        seq => seq.Params(new
                        {
                            schema = "ES_SEGURIDAD",
                            sequence = "SEQ_MODULO"
                        }));
                });
            Property<String>(
                x => x.Codigo,
                map => {
                    map.Column("CODIGO");
                    map.Length(4);
                    map.NotNullable(true);
                });
            Property<String>(
                x => x.Nombre, 
                map => {
                    map.Column("NOMBRE");
                    map.Length(50);
                    map.NotNullable(true);
                });
            Property<String>(
                x => x.Abreviatura, 
                map => {
                    map.Column("ABREVIATURA");
                    map.Length(20);
                    map.NotNullable(true);
                });
            Property<String>(
                x => x.Descripcion, 
                map => {
                    map.Column("DESCRIPCION");
                    map.Length(200);
                    map.NotNullable(false);
                });
            Property<Char>(
                x => x.Estado, 
                map => {
                    map.Column("ESTADO");
                    map.Length(1);
                    map.NotNullable(true);
                });
            ManyToOne<ESistema>(
                x => x.Sistema, 
                map => {
                    map.Column("ID_SISTEMA");
                    map.NotNullable(true);
                    map.Update(false);
                    map.Insert(false);
                });
        }
    }
}