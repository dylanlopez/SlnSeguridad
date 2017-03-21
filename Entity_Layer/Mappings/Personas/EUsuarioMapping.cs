using Entity_Layer.Entities.Personas;
using NHibernate;
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
            Table("SEGTV_USUARIO");
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
                    map.Column("US_USUARIO");
                    map.Length(100);
                    map.NotNullable(true);
                    map.UniqueKey("UK_USUARIO_01");
                });
            Property<String>(
                x => x.Contrasena, 
                map => {
                    map.Column("US_CONTRASENA");
                    map.Length(256);
                    map.NotNullable(true);
                });
            Property<Char>(
                x => x.Caduca, 
                map => {
                    map.Column("IN_CADUCA");
                    map.Length(1);
                    map.NotNullable(true);
                });
            Property<Int32>(
                x => x.PeriodoCaducidad, 
                map => {
                    map.Column("NU_PERIODO_CADUCIDAD");
                    map.NotNullable(true);
                });
            Property<DateTime>(
                x => x.FechaUltimoCambio, 
                map => {
                    map.Column("FE_ULTIMOCAMBIO");
                    //map.Type(NHibernateUtil.Date);
                    map.NotNullable(true);
                });
            Property<Char>(
                x => x.UnicoIngreso,
                map => {
                    map.Column("IN_UNICO_INGRESO");
                    map.Length(1);
                    map.NotNullable(true);
                });
            Property<Char>(
                x => x.HaIngresado,
                map => {
                    map.Column("IN_HA_INGRESADO");
                    map.Length(1);
                    map.NotNullable(true);
                });
            Property<Char>(
                x => x.OtrosLogeos,
                map => {
                    map.Column("IN_OTROS_LOGEOS");
                    map.Length(1);
                    map.NotNullable(true);
                });
            Property<Char>(
                x => x.Tipo, 
                map => {
                    map.Column("IN_TIPO");
                    map.Length(1);
                    map.NotNullable(true);
                });
            Property<Char>(
                x => x.Estado, 
                map => {
                    map.Column("IN_ACTIVO");
                    map.Length(1);
                    map.NotNullable(true);
                });
            //OneToOne<EPersona>(
            //    x => x.Persona, 
            //    map => {
            //        //map.ForeignKey("FK_USUARIO_01");
            //        map.PropertyReference(typeof(EPersona).GetPropertyOrFieldMatchingName("ID_PERSONA"));
            //    });
            ManyToOne<EPersona>(
                x => x.Persona,
                map => {
                    map.Column("ID_PERSONA");
                    map.NotNullable(true);
                    map.Update(true);
                    map.Insert(true);
                    map.ForeignKey("FK_USUARIO_01");
                });
        }
    }
}