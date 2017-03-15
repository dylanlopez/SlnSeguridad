using Entity_Layer.Entities.Sistemas;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;

namespace Entity_Layer.Mappings.Sistemas
{
    /// <summary>
    /// Here is the mapping class ESistemaMapping, on which entity-class mapping is performed using the NHibernate ClassMapping. Here
    /// SISTEMA table is mapped over ESistema entity class.
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    /// <seealso cref="NHibernate.Mapping.ByCode.Conformist.ClassMapping{Entity_Layer.Entities.Sistemas.ESistema}" />
    public class ESistemaMapping : ClassMapping<ESistema>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ESistemaMapping"/> class.
        /// </summary>
        public ESistemaMapping()
        {
            Schema("ES_SEGURIDAD");
            Table("SEGTM_SISTEMA");
            Id<Int32>(
                x => x.Id, 
                map => {
                    map.Column("ID_SISTEMA");
                    map.Generator(
                        Generators.Sequence, 
                        seq => seq.Params(new{
                            schema = "ES_SEGURIDAD",
                            sequence = "SEQ_SISTEMA"
                        }));
                });
            Property<String>(
                x => x.Codigo,
                map => {
                    map.Column("CO_SISTEMA");
                    map.Length(2);
                    map.NotNullable(true);
                    map.UniqueKey("UK_SISTEMA_01");
                });
            Property<String>(
                x => x.Nombre, 
                map => {
                    map.Column("NO_SISTEMA");
                    map.Length(50);
                    map.NotNullable(true);
                });
            Property<String>(
                x => x.Abreviatura, 
                map => {
                    map.Column("NO_ABREVIATURA");
                    map.Length(20);
                    map.NotNullable(true);
                });
            Property<String>(
                x => x.Descripcion, 
                map => {
                    map.Column("DE_DESCRIPCION");
                    map.Length(200);
                    map.NotNullable(false);
                });
            Property<Char>(
                x => x.Estado, 
                map => {
                    map.Column("IN_ACTIVO");
                    map.Length(1);
                    map.NotNullable(true);
                });
            //Bag(p => p.Modulos, map => map.Key(k => k.Column("ID_SISTEMA")), ce => ce.OneToMany());

            //Bag(x => x.Modulos,
            //    map =>
            //    {
            //        map.Inverse(true);
            //        map.Cascade(Cascade.All);
            //        map.Key(k => k.Column("ID_SISTEMA"));
            //    });
            //Bag(p => p.Districts, map => map.Key(k => k.Column("ProvinceId")), ce => ce.OneToMany());
        }
    }
}