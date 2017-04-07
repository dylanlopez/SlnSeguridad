using Entity_Layer.Entities.Personas;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;

namespace Entity_Layer.Mappings.Personas
{
    /// <summary>
    /// Here is the mapping class EPersonaMapping, on which entity-class mapping is performed using the NHibernate ClassMapping. Here
    /// PERSONA table is mapped over EPersona entity class.
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    /// <seealso cref="NHibernate.Mapping.ByCode.Conformist.ClassMapping{Entity_Layer.Entities.Sistemas.EPersona}" />
    public class EPersonaMapping : ClassMapping<EPersona>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EPersonaMapping"/> class.
        /// </summary>
        public EPersonaMapping()
        {
            Schema("ES_SEGURIDAD");
            Table("SEGTV_PERSONA");
            Id<String>(
                x => x.NumeroDocumento,
                map => {
                    map.Column("ID_PERSONA");
                });
            Property<String>(
                x => x.ApellidoPaterno, 
                map => {
                    map.Column("NO_PERSONA");
                    map.Length(50);
                    map.NotNullable(true);
                });
            Property<String>(
                x => x.ApellidoMaterno, 
                map => {
                    map.Column("NU_DOCUMENTO");
                    map.Length(15);
                    map.NotNullable(true);
                    map.UniqueKey("UK_PERSONA_01");
                });
            Property<String>(
                x => x.Nombres,
                map => {
                    map.Column("DE_DIRECCION");
                    map.Length(255);
                    map.NotNullable(false);
                });
        }
    }
}