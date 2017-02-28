using Entity_Layer.Entities.Personas;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;

namespace Entity_Layer.Mappings.Personas
{
    /// <summary>
    /// Here is the mapping class ETipoDocumentoPersonaMapping, on which entity-class mapping is performed using the NHibernate ClassMapping. Here
    /// TIPO_DOCUMENTO_PERSONA table is mapped over ETipoDocumentoPersona entity class.
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    /// <seealso cref="NHibernate.Mapping.ByCode.Conformist.ClassMapping{Entity_Layer.Entities.Sistemas.ETipoDocumentoPersona}" />
    public class ETipoDocumentoPersonaMapping : ClassMapping<ETipoDocumentoPersona>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ETipoDocumentoPersonaMapping"/> class.
        /// </summary>
        public ETipoDocumentoPersonaMapping()
        {
            Schema("ES_SEGURIDAD");
            Table("TIPO_DOCUMENTO_PERSONA");
            Id<Int32>(
                x => x.Id,
                map => {
                    map.Column("ID_TIPO_DOCUMENTO_PERSONA");
                    map.Generator(
                        Generators.Sequence,
                        seq => seq.Params(new
                        {
                            schema = "ES_SEGURIDAD",
                            sequence = "SEQ_TIPO_DOCUMENTO_PERSONA"
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
        }
    }
}