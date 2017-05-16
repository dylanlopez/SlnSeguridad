using Entity_Layer.Entities.Vistas;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;

namespace Entity_Layer.Mappings.Vistas
{
    public class EVistaPermisoMapping : ClassMapping<EVistaPermiso>
    {
        public EVistaPermisoMapping()
        {
            //Schema("ES_SEGURIDAD");
            Table("SEGVI_PERMISO");
            Mutable(false);
            //Id<String>(
            //    x => x.Usuario,
            //    map =>
            //    {
            //        map.Column("US_USUARIO");
            //        map.Length(100);
            //    });
            ComposedId(map =>
            {
                map.Property(x => x.Usuario);
                map.Property(x => x.NombreSistema);
                map.Property(x => x.NombreModulo);
                map.Property(x => x.NombreMenu);
                map.Property(x => x.NombreOpcion);
            });
            Property<String>(
                x => x.Usuario,
                map =>
                {
                    map.Column("US_USUARIO");
                    map.Length(100);
                });
            Property<String>(
                x => x.NombrePerfil,
                map => {
                    map.Column("NO_PERFIL");
                    map.Length(50);
                });
            //Property<String>(
            //    x => x.Usuario,
            //    map =>
            //    {
            //        map.Column("US_USUARIO");
            //        map.Length(100);
            //        map.NotNullable(true);
            //    });
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
            Property<String>(
                x => x.NombreRol,
                map => {
                    map.Column("NO_ROL");
                    map.Length(50);
                });
            Property<String>(
                x => x.CodigoSistema,
                map => {
                    map.Column("CO_SISTEMA");
                    map.Length(2);
                });
            Property<String>(
                x => x.NombreSistema,
                map =>
                {
                    map.Column("NO_SISTEMA");
                    map.Length(50);
                });
            //Id<String>(
            //    x => x.NombreSistema,
            //    map =>
            //    {
            //        map.Column("NO_SISTEMA");
            //        map.Length(50);
            //    });
            Property<String>(
                x => x.RutaLogica,
                map => {
                    map.Column("DE_RUTA_LOGICA");
                    map.Length(200);
                });
            Property<String>(
                x => x.NombreModulo,
                map =>
                {
                    map.Column("NO_MODULO");
                    map.Length(50);
                });
            //Id<String>(
            //    x => x.NombreModulo,
            //    map =>
            //    {
            //        map.Column("NO_MODULO");
            //        map.Length(50);
            //    });
            Property<String>(
                x => x.MenuRuta,
                map => {
                    map.Column("DE_RUTA");
                    map.Length(200);
                });
            Property<String>(
                x => x.NombreMenu,
                map =>
                {
                    map.Column("NO_MENU");
                    map.Length(50);
                });
            //Id<String>(
            //    x => x.NombreMenu,
            //    map =>
            //    {
            //        map.Column("NO_MENU");
            //        map.Length(50);
            //    });
            Property<String>(
                x => x.NombreOpcion,
                map =>
                {
                    map.Column("NO_OPCION");
                    map.Length(50);
                });
            //Id<String>(
            //    x => x.NombreOpcion,
            //    map =>
            //    {
            //        map.Column("NO_OPCION");
            //        map.Length(50);
            //    });
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