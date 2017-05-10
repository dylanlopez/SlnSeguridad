using Entity_Layer.Entities.Personas;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;

namespace Entity_Layer.Mappings.Personas
{
    /// <summary>
    /// Here is the mapping class ERolMapping, on which entity-class mapping is performed using the NHibernate ClassMapping. Here
    /// ROL table is mapped over ERol entity class.
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    /// <seealso cref="NHibernate.Mapping.ByCode.Conformist.ClassMapping{Entity_Layer.Entities.Sistemas.ERol}" />
    public class ERolMapping : ClassMapping<ERol>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ERolMapping"/> class.
        /// </summary>
        public ERolMapping()
        {
            //Schema("ES_SEGURIDAD");
            Table("SEGTM_ROL");
            Id<Int32>(
                x => x.Id,
                map => {
                    map.Column("ID_ROL");
                    map.Generator(
                        Generators.Sequence,
                        seq => seq.Params(new
                        {
                            //schema = "ES_SEGURIDAD",
                            sequence = "SEQ_ROL"
                        }));
                });
            Property<String>(
                x => x.Nombre, 
                map => {
                    map.Column("NO_ROL");
                    map.Length(50);
                    map.NotNullable(true);
                    map.UniqueKey("UK_ROL_01");
                });
            Property<String>(
                x => x.Descripcion, 
                map => {
                    map.Column("DE_DESCRIPCION");
                    map.Length(200);
                    map.NotNullable(false);
                });
        }
    }
}