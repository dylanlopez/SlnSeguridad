using Entity_Layer.Entities.Personas;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;

namespace Entity_Layer.Mappings.Personas
{
    /// <summary>
    /// Here is the mapping class EPerfilUsuarioRolMapping, on which entity-class mapping is performed using the NHibernate ClassMapping. Here
    /// SEGTV_PERFIL_USUARIO_ROL table is mapped over EPerfilUsuarioRol entity class.
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    /// <seealso cref="NHibernate.Mapping.ByCode.Conformist.ClassMapping{Entity_Layer.Entities.Sistemas.EPerfilUsuarioRol}" />
    public class EPerfilUsuarioRolMapping : ClassMapping<EPerfilUsuarioRol>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EPerfilUsuarioRolMapping"/> class.
        /// </summary>
        public EPerfilUsuarioRolMapping()
        {
            //Schema("ES_SEGURIDAD");
            Table("SEGTV_PERFIL_USUARIO_ROL");
            Id<Int32>(
                x => x.Id,
                map => {
                    map.Column("ID_PERFIL_USUARIO_ROL");
                    map.Generator(
                        Generators.Sequence,
                        seq => seq.Params(new
                        {
                            //schema = "ES_SEGURIDAD",
                            sequence = "SEQ_PERFIL_USUARIO_ROL"
                        }));
                });
            Property<Char>(
                x => x.Activo,
                map => {
                    map.Column("IN_ACTIVO");
                    map.Length(1);
                    map.NotNullable(true);
                });
            ManyToOne<EPerfil>(
                x => x.Perfil,
                map => {
                    map.Column("ID_PERFIL");
                    map.NotNullable(true);
                    map.Update(true);
                    map.Insert(true);
                    map.ForeignKey("FK_PERFIL_USUARIO_ROL_01");
                    map.UniqueKey("UK_PERFIL_USUARIO_ROL_01");
                });
            ManyToOne<EUsuario>(
                x => x.Usuario,
                map => {
                    map.Column("ID_USUARIO");
                    map.NotNullable(true);
                    map.Update(true);
                    map.Insert(true);
                    map.ForeignKey("FK_PERFIL_USUARIO_ROL_02");
                    map.UniqueKey("UK_PERFIL_USUARIO_ROL_01");
                });
            ManyToOne<ERol>(
                x => x.Rol,
                map => {
                    map.Column("ID_ROL");
                    map.NotNullable(true);
                    map.Update(true);
                    map.Insert(true);
                    map.ForeignKey("FK_PERFIL_USUARIO_ROL_03");
                    map.UniqueKey("UK_PERFIL_USUARIO_ROL_01");
                });
        }
    }
}