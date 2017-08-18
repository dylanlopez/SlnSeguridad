using Entity_Layer.Entities.Personas;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Configuration;

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
            string schemaSeguridad = ConfigurationManager.AppSettings["Schema"].ToString();
            Schema(schemaSeguridad);
            Table("SEGTV_PERSONA");
            Id<Int32>(
                x => x.Numero,
                map => {
                    map.Column("NU_PERSONA");
                });
            Property<String>(
                x => x.TipoDocumento,
                map => {
                    map.Column("IN_DOC_NACIMIENTO");
                    map.Length(10);
                    map.NotNullable(true);
                });
            Property<String>(
                x => x.NumeroDocumento,
                map => {
                    map.Column("NU_DOC_NACIMIENTO");
                    map.Length(10);
                    map.NotNullable(true);
                });
            Property<String>(
                x => x.ApellidoPaterno, 
                map => {
                    map.Column("NO_APELLIDO_PATERNO");
                    map.Length(50);
                    map.NotNullable(true);
                });
            Property<String>(
                x => x.ApellidoMaterno, 
                map => {
                    map.Column("NO_APELLIDO_MATERNO");
                    map.Length(50);
                    map.NotNullable(true);
                });
            Property<String>(
                x => x.Nombres,
                map => {
                    map.Column("NO_NOMBRE");
                    map.Length(100);
                    map.NotNullable(true);
                });
        }
    }
}