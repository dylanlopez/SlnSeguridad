using Entity_Layer.Entities.Personas;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;

namespace Entity_Layer.Mappings.Personas
{
    /// <summary>
    /// Here is the mapping class EUsuarioMapping, on which entity-class mapping is performed using the NHibernate ClassMapping. Here
    /// USUARIO table is mapped over EUsuario entity class.
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    /// <seealso cref="NHibernate.Mapping.ByCode.Conformist.ClassMapping{Entity_Layer.Entities.Sistemas.EUsuario}" />
    public class EUsuarioMapping : ClassMapping<EUsuario>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EUsuarioMapping"/> class.
        /// </summary>
        public EUsuarioMapping()
        {
            Schema("ES_SEGURIDAD");
            Table("USUARIO");
            Id<Int32>(
                x => x.Id,
                map => {
                    map.Column("ID_USUARIO");
                    map.Generator(
                        Generators.Sequence,
                        seq => seq.Params(new
                        {
                            schema = "ES_SEGURIDAD",
                            sequence = "SEQ_USUARIO"
                        }));
                });
            Property<String>(
                x => x.Usuario, 
                map => {
                    map.Column("USUARIO");
                    map.Length(100);
                    map.NotNullable(true);
                });
            Property<String>(
                x => x.Contrasena, 
                map => {
                    map.Column("CONTRASENA");
                    map.Length(256);
                    map.NotNullable(true);
                });
            Property<Char>(
                x => x.Caduca, 
                map => {
                    map.Column("CADUCA");
                    map.Length(1);
                    map.NotNullable(true);
                });
            Property<Int32>(
                x => x.PeriodoCaducidad, 
                map => {
                    map.Column("PERIODO_CADUCIDAD");
                    map.NotNullable(true);
                });
            Property<DateTime>(
                x => x.FechaUltimoCambio, 
                map => {
                    map.Column("FECHA_ULTIMOCAMBIO");
                    map.NotNullable(true);
                });
            Property<Char>(
                x => x.Tipo, 
                map => {
                    map.Column("TIPO");
                    map.Length(1);
                    map.NotNullable(true);
                });
            Property<Char>(
                x => x.Estado, 
                map => {
                    map.Column("ESTADO");
                    map.Length(1);
                    map.NotNullable(true);
                });
            OneToOne<EPersona>(
                x => x.Persona, 
                map => {
                    map.PropertyReference(typeof(EPersona).GetPropertyOrFieldMatchingName("ID_PERSONA"));
                });
        }
    }
}