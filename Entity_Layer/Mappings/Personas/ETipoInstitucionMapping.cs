using Entity_Layer.Entities.Personas;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Configuration;

namespace Entity_Layer.Mappings.Personas
{
    /// <summary>
    /// Here is the mapping class <see cref="ETipoInstitucionMapping"/>, on which entity-class mapping is performed using the NHibernate ClassMapping. Here
    /// SEGTM_INSTITUCION_TIPO table is mapped over <see cref="ETipoInstitucion"/> entity class.
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    /// <seealso cref="NHibernate.Mapping.ByCode.Conformist.ClassMapping{Entity_Layer.Entities.Personas.ETipoInstitucion}" />
    public class ETipoInstitucionMapping : ClassMapping<ETipoInstitucion>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ETipoInstitucionMapping"/> class.
        /// </summary>
        public ETipoInstitucionMapping()
        {
            string schemaSeguridad = ConfigurationManager.AppSettings["Schema"].ToString();
            Schema(schemaSeguridad);
            Table("SEGTM_INSTITUCION_TIPO");
            Id<Int32>(
                x => x.Id,
                map => {
                    map.Column("ID_INSTITUCION_TIPO");
                    map.Generator(
                        Generators.Sequence,
                        seq => seq.Params(new
                        {
                            schema = schemaSeguridad,
                            sequence = "SEQ_INSTITUCION_TIPO"
                        }));
                });
            Property<String>(
                x => x.Nombre,
                map => {
                    map.Column("NO_INSTITUCION_TIPO");
                    map.Length(50);
                    map.NotNullable(true);
                    map.UniqueKey("UK_INSTITUCION_TIPO_01");
                });
            Property<String>(
                x => x.Descripcion,
                map => {
                    map.Column("DE_DESCRIPCION");
                    map.Length(200);
                    map.NotNullable(false);
                });
            Property<Char>(
                x => x.Activo,
                map => {
                    map.Column("IN_ACTIVO");
                    map.Length(1);
                    map.NotNullable(true);
                });
        }
    }
}