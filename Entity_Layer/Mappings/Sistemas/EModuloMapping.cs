using Entity_Layer.Entities.Sistemas;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Configuration;

namespace Entity_Layer.Mappings.Sistemas
{
    /// <summary>
    /// Here is the mapping class <see cref="EModuloMapping"/>, on which entity-class mapping is performed using the NHibernate ClassMapping. Here
    /// SEGTM_MODULO table is mapped over <see cref="EModulo"/> entity class.
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    /// <v2.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Include fields of database changes</description>
    /// </v2.0>
    /// <seealso cref="NHibernate.Mapping.ByCode.Conformist.ClassMapping{Entity_Layer.Entities.Sistemas.EModulo}" />
    public class EModuloMapping : ClassMapping<EModulo>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EModuloMapping"/> class.
        /// </summary>
        public EModuloMapping()
        {
            string schemaSeguridad = ConfigurationManager.AppSettings["Schema"].ToString();
            Schema(schemaSeguridad);
            Table("SEGTM_MODULO");
            Id<Int32>(
                x => x.Id,
                map => {
                    map.Column("ID_MODULO");
                    map.Generator(
                        Generators.Sequence,
                        seq => seq.Params(new
                        {
                            schema = schemaSeguridad,
                            sequence = "SEQ_MODULO"
                        }));
                });
            Property<String>(
                x => x.Codigo,
                map => {
                    map.Column("CO_MODULO");
                    map.Length(4);
                    map.NotNullable(true);
                    map.UniqueKey("UK_MODULO_01");
                });
            Property<String>(
                x => x.Nombre, 
                map => {
                    map.Column("NO_MODULO");
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
            Property<Char>(
                x => x.Activo,
                map => {
                    map.Column("IN_ACTIVO");
                    map.Length(1);
                    map.NotNullable(true);
                });
            Property<String>(
                x => x.Descripcion, 
                map => {
                    map.Column("DE_DESCRIPCION");
                    map.Length(200);
                    map.NotNullable(false);
                });
            ManyToOne<ESistema>(
                x => x.Sistema, 
                map => {
                    map.Column("ID_SISTEMA");
                    map.NotNullable(true);
                    map.Update(true);
                    map.Insert(true);
                    map.ForeignKey("FK_MODULO_01");
                });
        }
    }
}