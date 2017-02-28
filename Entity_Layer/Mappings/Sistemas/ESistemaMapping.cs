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
            Table("SISTEMA");
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
                    map.Column("CODIGO");
                    map.Length(2);
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
        }
    }
}