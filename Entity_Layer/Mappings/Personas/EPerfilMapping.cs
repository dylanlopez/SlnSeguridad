using Entity_Layer.Entities.Personas;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Configuration;

namespace Entity_Layer.Mappings.Personas
{
    /// <summary>
    /// Here is the mapping class EPerfilMapping, on which entity-class mapping is performed using the NHibernate ClassMapping. Here
    /// SEGTM_PERFIL table is mapped over EPerfil entity class.
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    /// <seealso cref="NHibernate.Mapping.ByCode.Conformist.ClassMapping{Entity_Layer.Entities.Sistemas.EPerfil}" />
    public class EPerfilMapping : ClassMapping<EPerfil>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EPerfilMapping"/> class.
        /// </summary>
        public EPerfilMapping()
        {
            string schemaSeguridad = ConfigurationManager.AppSettings["Schema"].ToString();
            Schema(schemaSeguridad);
            Table("SEGTM_PERFIL");
            Id<Int32>(
                x => x.Id,
                map => {
                    map.Column("ID_PERFIL");
                    map.Generator(
                        Generators.Sequence,
                        seq => seq.Params(new
                        {
                            schema = schemaSeguridad,
                            sequence = "SEQ_PERFIL"
                        }));
                });
            Property<String>(
                x => x.Nombre,
                map => {
                    map.Column("NO_PERFIL");
                    map.Length(50);
                    map.NotNullable(true);
                    map.UniqueKey("UK_PERFIL_01");
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
