using Entity_Layer.Entities.Personas;
using Entity_Layer.Entities.Sistemas;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;

namespace Entity_Layer.Mappings.Personas
{
    /// <summary>
    /// Here is the mapping class EPerfilMapping, on which entity-class mapping is performed using the NHibernate ClassMapping. Here
    /// SEGTM_SISTEMA_PERFIL table is mapped over ESistemaPerfil entity class.
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    /// <seealso cref="NHibernate.Mapping.ByCode.Conformist.ClassMapping{Entity_Layer.Entities.Sistemas.ESistemaPerfil}" />
    public class ESistemaPerfilMapping : ClassMapping<ESistemaPerfil>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ESistemaPerfilMapping"/> class.
        /// </summary>
        public ESistemaPerfilMapping()
        {
            //Schema("ES_SEGURIDAD");
            Table("SEGTM_SISTEMA_PERFIL");
            Id<Int32>(
                x => x.Id,
                map => {
                    map.Column("ID_SISTEMA_PERFIL");
                    map.Generator(
                        Generators.Sequence,
                        seq => seq.Params(new
                        {
                            //schema = "ES_SEGURIDAD",
                            sequence = "SEQ_SISTEMA_PERFIL"
                        }));
                });
            Property<Char>(
                x => x.Activo,
                map => {
                    map.Column("IN_ACTIVO");
                    map.Length(1);
                    map.NotNullable(true);
                });
            ManyToOne<ESistema>(
                x => x.Sistema,
                map => {
                    map.Column("ID_SISTEMA");
                    map.NotNullable(true);
                    map.Update(true);
                    map.Insert(true);
                    map.ForeignKey("FK_SISTEMA_PERFIL_01");
                    map.UniqueKey("UK_SISTEMA_PERFIL_01");
                });
            ManyToOne<EPerfil>(
                x => x.Perfil,
                map => {
                    map.Column("ID_PERFIL");
                    map.NotNullable(true);
                    map.Update(true);
                    map.Insert(true);
                    map.ForeignKey("FK_SISTEMA_PERFIL_02");
                    map.UniqueKey("UK_SISTEMA_PERFIL_01");
                });
        }
    }
}
