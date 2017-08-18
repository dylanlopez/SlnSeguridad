using Entity_Layer.Entities.Sistemas;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Configuration;

namespace Entity_Layer.Mappings.Sistemas
{
    /// <summary>
    /// Here is the mapping class <see cref="EOpcionMapping"/>, on which entity-class mapping is performed using the NHibernate ClassMapping. Here
    /// SEGTM_OPCION table is mapped over <see cref="EOpcion"/> entity class.
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    /// <seealso cref="NHibernate.Mapping.ByCode.Conformist.ClassMapping{Entity_Layer.Entities.Sistemas.EOpcion}" />
    public class EOpcionMapping : ClassMapping<EOpcion>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EOpcionMapping"/> class.
        /// </summary>
        public EOpcionMapping()
        {
            string schemaSeguridad = ConfigurationManager.AppSettings["Schema"].ToString();
            Schema(schemaSeguridad);
            Table("SEGTM_OPCION");
            Id<Int32>(
                x => x.Id,
                map => {
                    map.Column("ID_OPCION");
                    map.Generator(
                        Generators.Sequence,
                        seq => seq.Params(new
                        {
                            schema = schemaSeguridad,
                            sequence = "SEQ_OPCION"
                        }));
                });
            Property<String>(
                x => x.Nombre,
                map => {
                    map.Column("NO_OPCION");
                    map.Length(50);
                    map.NotNullable(true);
                });
            Property<String>(
                x => x.NombreControlAsociado,
                map => {
                    map.Column("NO_CONTROL_ASOC");
                    map.Length(50);
                    map.NotNullable(true);
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