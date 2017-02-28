using Entity_Layer.Entities.Personas;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;

namespace Entity_Layer.Mappings.Personas
{
    /// <summary>
    /// Here is the mapping class EProgramaSocialMapping, on which entity-class mapping is performed using the NHibernate ClassMapping. Here
    /// PROGRAMA_SOCIAL table is mapped over EProgramaSocial entity class.
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    /// <seealso cref="NHibernate.Mapping.ByCode.Conformist.ClassMapping{Entity_Layer.Entities.Sistemas.EProgramaSocial}" />
    public class EProgramaSocialMapping : ClassMapping<EProgramaSocial>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EProgramaSocialMapping"/> class.
        /// </summary>
        public EProgramaSocialMapping()
        {
            Schema("ES_SEGURIDAD");
            Table("PROGRAMA_SOCIAL");
            Id<Int32>(
                x => x.Id,
                map => {
                    map.Column("ID_MODULO");
                    map.Generator(
                        Generators.Sequence,
                        seq => seq.Params(new
                        {
                            schema = "ES_SEGURIDAD",
                            sequence = "SEQ_PROGRAMA_SOCIAL"
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
                x => x.Descripcion, 
                map => {
                    map.Column("DESCRIPCION");
                    map.Length(200);
                    map.NotNullable(false);
                });
            Property<String>(
                x => x.Alcance, 
                map => {
                    map.Column("ALCANCE");
                    map.Length(2);
                    map.NotNullable(true);
                });
            Property<Char>(
                x => x.Estado, 
                map => {
                    map.Column("ESTADO");
                    map.Length(1);
                    map.NotNullable(true);
                });
        }
    }
}