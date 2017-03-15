using Entity_Layer.Entities.Personas;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;

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
            Schema("ES_SEGURIDAD");
            Table("SEGTV_PERSONA");
            Id<Int32>(
                x => x.Id,
                map => {
                    map.Column("ID_PERSONA");
                    map.Generator(
                        Generators.Sequence,
                        seq => seq.Params(new
                        {
                            schema = "ES_SEGURIDAD",
                            sequence = "SEQ_PERSONA"
                        }));
                });
            Property<String>(
                x => x.Nombre, 
                map => {
                    map.Column("NO_PERSONA");
                    map.Length(100);
                    map.NotNullable(true);
                });
            Property<String>(
                x => x.NumeroDocumento, 
                map => {
                    map.Column("NU_DOCUMENTO");
                    map.Length(15);
                    map.NotNullable(true);
                    map.UniqueKey("UK_PERSONA_01");
                });
            Property<String>(
                x => x.Direccion,
                map => {
                    map.Column("DE_DIRECCION");
                    map.Length(255);
                    map.NotNullable(false);
                });
            Property<String>(
                x => x.Telefono,
                map => {
                    map.Column("DE_TELEFONO");
                    map.Length(15);
                    map.NotNullable(false);
                });
            Property<String>(
                x => x.Celular,
                map => {
                    map.Column("DE_CELULAR");
                    map.Length(15);
                    map.NotNullable(false);
                });
            Property<String>(
                x => x.Email,
                map => {
                    map.Column("DE_EMAIL");
                    map.Length(50);
                    map.NotNullable(false);
                });
            Property<Char>(
                x => x.Tipo, 
                map => {
                    map.Column("IN_TIPO");
                    map.Length(1);
                    map.NotNullable(true);
                });
            Property<Char>(
                x => x.Ambito,
                map => {
                    map.Column("IN_AMBITO");
                    map.Length(1);
                    map.NotNullable(true);
                });
            ManyToOne<ETipoDocumentoPersona>(
                x => x.TipoDocumentoPersona, 
                map => {
                    map.Column("ID_TIPO_DOCUMENTO_PERSONA");
                    map.NotNullable(true);
                    map.Update(true);
                    map.Insert(true);
                    map.ForeignKey("FK_PERSONA_01");
                    map.UniqueKey("UK_PERSONA_01");
                });
        }
    }
}