using Entity_Layer.Entities.Personas;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;

namespace Entity_Layer.Mappings.Personas
{
    /// <summary>
    /// Here is the mapping class EPersonaProgramaSocialMapping, on which entity-class mapping is performed using the NHibernate ClassMapping. Here
    /// PERSONA_PROGRAMA_SOCIAL table is mapped over EPersonaProgramaSocial entity class.
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    /// <seealso cref="NHibernate.Mapping.ByCode.Conformist.ClassMapping{Entity_Layer.Entities.Sistemas.EPersonaProgramaSocial}" />
    public class EPersonaProgramaSocialMapping : ClassMapping<EPersonaProgramaSocial>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EPersonaProgramaSocialMapping"/> class.
        /// </summary>
        public EPersonaProgramaSocialMapping()
        {
            Schema("ES_SEGURIDAD");
            Table("PERSONA_PROGRAMA_SOCIAL");
            Id<Int32>(
                x => x.Id,
                map => {
                    map.Column("ID_PERSONA_PROGRAMA_SOCIAL");
                    map.Generator(
                        Generators.Sequence,
                        seq => seq.Params(new
                        {
                            schema = "ES_SEGURIDAD",
                            sequence = "SEQ_PERSONA_PROGRAMA_SOCIAL"
                        }));
                });
            ManyToOne<EPersona>(
                x => x.Persona, 
                map => {
                    map.Column("ID_PERSONA");
                    map.NotNullable(true);
                    map.Update(false);
                    map.Insert(false);
                });
            ManyToOne<EProgramaSocial>(
                x => x.ProgramaSocial, 
                map => {
                    map.Column("ID_PROGRAMA_SOCIAL");
                    map.NotNullable(true);
                    map.Update(false);
                    map.Insert(false);
                });
        }
    }
}