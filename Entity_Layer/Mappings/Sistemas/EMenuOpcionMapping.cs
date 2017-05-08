using Entity_Layer.Entities.Sistemas;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;

namespace Entity_Layer.Mappings.Sistemas
{
    /// <summary>
    /// Here is the mapping class <see cref="EMenuOpcionMapping"/>, on which entity-class mapping is performed using the NHibernate ClassMapping. Here
    /// SEGTM_OPCION table is mapped over <see cref="EMenuOpcion"/> entity class.
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    /// <seealso cref="NHibernate.Mapping.ByCode.Conformist.ClassMapping{Entity_Layer.Entities.Sistemas.EMenuOpcion}" />
    public class EMenuOpcionMapping : ClassMapping<EMenuOpcion>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EMenuOpcionMapping"/> class.
        /// </summary>
        public EMenuOpcionMapping()
        {
            //Schema("ES_SEGURIDAD");
            Table("SEGTM_MENU_OPCION");
            Id<Int32>(
                x => x.Id,
                map => {
                    map.Column("ID_MENU_OPCION");
                    map.Generator(
                        Generators.Sequence,
                        seq => seq.Params(new
                        {
                            //schema = "ES_SEGURIDAD",
                            sequence = "SEQ_MENU_OPCION"
                        }));
                });
            Property<Char>(
                x => x.Activo,
                map => {
                    map.Column("IN_ACTIVO");
                    map.Length(1);
                    map.NotNullable(true);
                });
            Property<Char>(
                x => x.Visible,
                map => {
                    map.Column("IN_VISIBLE");
                    map.Length(1);
                    map.NotNullable(true);
                });
            ManyToOne<EMenu>(
                x => x.Menu,
                map => {
                    map.Column("ID_MENU");
                    map.NotNullable(true);
                    map.Update(true);
                    map.Insert(true);
                    map.ForeignKey("FK_MENU_OPCION_01");
                });
            ManyToOne<EOpcion>(
                x => x.Opcion,
                map => {
                    map.Column("ID_OPCION");
                    map.NotNullable(true);
                    map.Update(true);
                    map.Insert(true);
                    map.ForeignKey("FK_MENU_OPCION_02");
                });
        }
    }
}