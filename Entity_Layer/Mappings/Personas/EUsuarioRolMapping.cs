using Entity_Layer.Entities.Personas;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;

namespace Entity_Layer.Mappings.Personas
{
    /// <summary>
    /// Here is the mapping class EUsuarioRolMapping, on which entity-class mapping is performed using the NHibernate ClassMapping. Here
    /// USUARIO_ROL table is mapped over EUsuarioRol entity class.
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    /// <seealso cref="NHibernate.Mapping.ByCode.Conformist.ClassMapping{Entity_Layer.Entities.Sistemas.EUsuarioRol}" />
    public class EUsuarioRolMapping : ClassMapping<EUsuarioRol>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EUsuarioRolMapping"/> class.
        /// </summary>
        public EUsuarioRolMapping()
        {
            Schema("ES_SEGURIDAD");
            Table("SEGTV_USUARIO_ROL");
            Id<Int32>(
                x => x.Id,
                map => {
                    map.Column("ID_USUARIO_ROL");
                    map.Generator(
                        Generators.Sequence,
                        seq => seq.Params(new
                        {
                            schema = "ES_SEGURIDAD",
                            sequence = "SEQ_USUARIO_ROL"
                        }));
                });
            ManyToOne<EUsuario>(
                x => x.Usuario, 
                map => {
                    map.Column("ID_USUARIO");
                    map.NotNullable(true);
                    map.Update(false);
                    map.Insert(true);
                    map.ForeignKey("FK_USUARIO_ROL_01");
                });
            ManyToOne<ERol>(
                x => x.Rol, 
                map => {
                    map.Column("ID_ROL");
                    map.NotNullable(true);
                    map.Update(false);
                    map.Insert(true);
                    map.ForeignKey("FK_USUARIO_ROL_02");
                });
        }
    }
}