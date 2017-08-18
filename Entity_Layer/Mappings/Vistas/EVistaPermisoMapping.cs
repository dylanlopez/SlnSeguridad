using Entity_Layer.Entities.Vistas;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Configuration;

namespace Entity_Layer.Mappings.Vistas
{
    public class EVistaPermisoMapping : ClassMapping<EVistaPermiso>
    {
        public EVistaPermisoMapping()
        {
            string schemaSeguridad = ConfigurationManager.AppSettings["Schema"].ToString();
            Schema(schemaSeguridad);
            Table("SEGVI_PERMISO");
            Mutable(false);
            Lazy(false);
            //Id<String>(
            //    x => x.Usuario,
            //    map =>
            //    {
            //        map.Column("US_USUARIO");
            //        map.Length(100);
            //    });
            ComposedId(map =>
            {
                map.Property(x => x.IdPerfil);
                map.Property(x => x.Usuario);
                map.Property(x => x.IdRol);
                map.Property(x => x.IdSistema);
                map.Property(x => x.IdModulo);
                map.Property(x => x.IdMenu);
                map.Property(x => x.IdOpcion);
            });
            Property<Int32>(
                x => x.IdPerfil,
                map => {
                    map.Column("ID_PERFIL");
                });
            Property<String>(
                x => x.NombrePerfil,
                map => {
                    map.Column("NO_PERFIL");
                    map.Length(50);
                });
            Property<String>(
                x => x.Usuario,
                map =>
                {
                    map.Column("US_USUARIO");
                    map.Length(100);
                });
            Property<String>(
                x => x.Contrasena,
                map => {
                    map.Column("US_CONTRASENA");
                    map.Length(256);
                });
            Property<String>(
                x => x.ApellidoPaterno,
                map => {
                    map.Column("NO_APELLIDO_PATERNO");
                    map.Length(50);
                });
            Property<String>(
                x => x.ApellidoMaterno,
                map => {
                    map.Column("NO_APELLIDO_MATERNO");
                    map.Length(50);
                });
            Property<String>(
                x => x.Nombres,
                map => {
                    map.Column("NO_NOMBRE");
                    map.Length(100);
                });
            Property<String>(
                x => x.Ubigeo,
                map => {
                    map.Column("UBIGEO");
                    map.Length(6);
                });
            Property<Int32>(
                x => x.CodigoVersion,
                map => {
                    map.Column("CO_VERSION");
                });
            Property<String>(
                x => x.Email,
                map => {
                    map.Column("NO_EMAIL");
                    map.Length(200);
                });
            Property<Char>(
                x => x.Caduca,
                map => {
                    map.Column("IN_CADUCA");
                    map.Length(1);
                });
            Property<DateTime>(
                x => x.FechaUltimoCambio,
                map => {
                    map.Column("FE_ULTIMOCAMBIO");
                });
            Property<Int32>(
                x => x.PeriodoCaducidad,
                map => {
                    map.Column("NU_PERIODO_CADUCIDAD");
                });
            Property<Char>(
                x => x.PrimeraVez,
                map => {
                    map.Column("IN_PRIMERA_VEZ");
                    map.Length(1);
                });
            Property<Int32>(
                x => x.IdRol,
                map => {
                    map.Column("ID_ROL");
                });
            Property<String>(
                x => x.NombreRol,
                map => {
                    map.Column("NO_ROL");
                    map.Length(50);
                });
            Property<Int32>(
                x => x.IdSistema,
                map => {
                    map.Column("ID_SISTEMA");
                });
            Property<String>(
                x => x.CodigoSistema,
                map => {
                    map.Column("CO_SISTEMA");
                    map.Length(2);
                });
            Property<String>(
                x => x.AbreviaturaSistema,
                map =>
                {
                    map.Column("NO_ABREVIATURA");
                    map.Length(20);
                });
            Property<String>(
                x => x.NombreSistema,
                map =>
                {
                    map.Column("NO_SISTEMA");
                    map.Length(50);
                });
            Property<String>(
                x => x.RutaLogica,
                map => {
                    map.Column("DE_RUTA_LOGICA");
                    map.Length(200);
                });
            Property<Int32>(
                x => x.IdModulo,
                map => {
                    map.Column("ID_MODULO");
                });
            Property<String>(
                x => x.CodigoModulo,
                map => {
                    map.Column("CO_MODULO");
                    map.Length(4);
                });
            Property<String>(
                x => x.NombreModulo,
                map =>
                {
                    map.Column("NO_MODULO");
                    map.Length(50);
                });
            Property<Int32>(
                x => x.IdMenu,
                map => {
                    map.Column("ID_MENU");
                });
            Property<String>(
                x => x.CodigoMenu,
                map => {
                    map.Column("CO_MENU");
                    map.Length(7);
                });
            Property<String>(
                x => x.NombreMenu,
                map =>
                {
                    map.Column("NO_MENU");
                    map.Length(50);
                });
            Property<String>(
                x => x.MenuRuta,
                map => {
                    map.Column("DE_RUTA");
                    map.Length(200);
                });
            Property<Int32>(
                x => x.IdOpcion,
                map => {
                    map.Column("ID_OPCION");
                });
            Property<String>(
                x => x.NombreOpcion,
                map =>
                {
                    map.Column("NO_OPCION");
                    map.Length(50);
                });
            Property<String>(
                x => x.ControlAsociado,
                map => {
                    map.Column("NO_CONTROL_ASOC");
                    map.Length(50);
                });
            Property<Char>(
                x => x.Visible,
                map => {
                    map.Column("IN_VISIBLE");
                    map.Length(1);
                });
        }
    }
}