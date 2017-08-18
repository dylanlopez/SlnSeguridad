using Entity_Layer.Entities.Personas;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Configuration;

namespace Entity_Layer.Mappings.Personas
{
    /// <summary>
    /// Here is the mapping class <see cref="EInstitucionMapping"/>, on which entity-class mapping is performed using the NHibernate ClassMapping. Here
    /// SEGTV_INSTITUCION table is mapped over <see cref="EInstitucion"/> entity class.
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    /// <seealso cref="NHibernate.Mapping.ByCode.Conformist.ClassMapping{Entity_Layer.Entities.Personas.EInstitucion}" />
    public class EInstitucionMapping : ClassMapping<EInstitucion>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EInstitucionMapping"/> class.
        /// </summary>
        public EInstitucionMapping()
        {
            string schemaSeguridad = ConfigurationManager.AppSettings["Schema"].ToString();
            Schema(schemaSeguridad);
            Table("SEGTV_INSTITUCION");
            Id<Int32>(
                x => x.Id,
                map => {
                    map.Column("ID_INSTITUCION");
                    map.Generator(
                        Generators.Sequence,
                        seq => seq.Params(new
                        {
                            schema = schemaSeguridad,
                            sequence = "SEQ_INSTITUCION"
                        }));
                });
            Property<String>(
                x => x.Nombre,
                map => {
                    map.Column("NO_MODULO");
                    map.Length(50);
                    map.NotNullable(true);
                });
            Property<String>(
                x => x.Nombre,
                map => {
                    map.Column("NO_INSTITUCION");
                    map.Length(50);
                    map.NotNullable(true);
                });
            Property<String>(
                x => x.NombreCorto,
                map => {
                    map.Column("NO_INSTITUCION_CORTA");
                    map.Length(15);
                    map.NotNullable(true);
                });
            Property<String>(
                x => x.Direccion,
                map => {
                    map.Column("DE_DIRECCION");
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
            ManyToOne<ETipoInstitucion>(
                x => x.TipoInstitucion,
                map => {
                    map.Column("ID_INSTITUCION_TIPO");
                    map.NotNullable(true);
                    map.Update(true);
                    map.Insert(true);
                    map.ForeignKey("FK_INSTITUCION_01");
                });
        }
    }
}
