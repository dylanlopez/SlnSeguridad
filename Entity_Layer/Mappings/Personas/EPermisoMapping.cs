using Entity_Layer.Entities.Personas;
using Entity_Layer.Entities.Sistemas;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;

namespace Entity_Layer.Mappings.Personas
{
    /// <summary>
    /// Here is the mapping class EPermisoMapping, on which entity-class mapping is performed using the NHibernate ClassMapping. Here
    /// SEGTV_PERMISO table is mapped over EPermiso entity class.
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    /// <seealso cref="NHibernate.Mapping.ByCode.Conformist.ClassMapping{Entity_Layer.Entities.Sistemas.EPermiso}" />
    public class EPermisoMapping : ClassMapping<EPermiso>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EPermisoMapping"/> class.
        /// </summary>
        public EPermisoMapping()
        {
            Schema("ES_SEGURIDAD");
            Table("SEGTV_PERMISO");
            Id<Int32>(
                x => x.Id,
                map => {
                    map.Column("ID_PERMISO");
                    map.Generator(
                        Generators.Sequence,
                        seq => seq.Params(new
                        {
                            schema = "ES_SEGURIDAD",
                            sequence = "SEQ_PERFIL_USUARIO_ROL"
                        }));
                });
            Property<DateTime>(
                x => x.FechaAlta,
                map => {
                    map.Column("FE_ALTA");
                    map.NotNullable(true);
                });
            Property<Char>(
                x => x.Activo,
                map => {
                    map.Column("IN_ACTIVO");
                    map.Length(1);
                    map.NotNullable(true);
                });
            ManyToOne<EPerfilUsuarioRol>(
                x => x.PerfilUsuarioRol,
                map => {
                    map.Column("ID_PERFIL_USUARIO_ROL");
                    map.NotNullable(true);
                    map.Update(true);
                    map.Insert(true);
                    map.ForeignKey("FK_PERMISO_01");
                    map.UniqueKey("UK_PERMISO_01");
                });
            ManyToOne<EMenuOpcion>(
                x => x.MenuOpcion,
                map => {
                    map.Column("ID_MENU_OPCION");
                    map.NotNullable(true);
                    map.Update(true);
                    map.Insert(true);
                    map.ForeignKey("FK_PERMISO_02");
                    map.UniqueKey("UK_PERMISO_01");
                });
        }
    }
}