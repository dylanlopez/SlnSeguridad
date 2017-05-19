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
            //Schema("ES_SEGURIDAD");
            Table("SEGTV_USUARIO");
            Id<Int32>(
                x => x.Id,
                map => {
                    map.Column("ID_USUARIO");
                    map.Generator(
                        Generators.Sequence,
                        seq => seq.Params(new
                        {
                            //schema = "ES_SEGURIDAD",
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
                    map.NotNullable(true);
                });
            Property<String>(
                x => x.Ubigeo,
                map => {
                    map.Column("UBIGEO");
                    map.Length(6);
                    map.NotNullable(true);
                });
            Property<Int32>(
                x => x.CodigoVersion,
                map => {
                    map.Column("CO_VERSION");
                    map.NotNullable(true);
                });
            Property<Char>(
                x => x.PrimeraVez,
                map => {
                    map.Column("IN_PRIMERA_VEZ");
                    map.Length(1);
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
                x => x.Activo, 
                map => {
                    map.Column("IN_ACTIVO");
                    map.Length(1);
                    map.NotNullable(true);
                });
            Property<String>(
                x => x.Email,
                map => {
                    map.Column("NO_EMAIL");
                    map.Length(200);
                    map.NotNullable(false);
                });
        }
    }
}