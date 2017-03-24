using Entity_Layer.Entities.Personas;
using Entity_Layer.Entities.Sistemas;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;

namespace Entity_Layer.Mappings.Personas
{
    /// <summary>
    /// Here is the mapping class EMenuRolMapping, on which entity-class mapping is performed using the NHibernate ClassMapping. Here
    /// MENU_ROL table is mapped over EMenuRol entity class.
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    /// <seealso cref="NHibernate.Mapping.ByCode.Conformist.ClassMapping{Entity_Layer.Entities.Sistemas.EMenuRol}" />
    public class EMenuRolMapping : ClassMapping<EMenuRol>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EMenuRolMapping"/> class.
        /// </summary>
        public EMenuRolMapping()
        {
            Schema("ES_SEGURIDAD");
            Table("SEGTV_MENU_ROL");
            Id<Int32>(
                x => x.Id,
                map => {
                    map.Column("ID_MENU_ROL");
                    map.Generator(
                        Generators.Sequence,
                        seq => seq.Params(new
                        {
                            schema = "ES_SEGURIDAD",
                            sequence = "SEQ_MENU_ROL"
                        }));
                });
            ManyToOne<EMenu>(
                x => x.Menu, 
                map => {
                    map.Column("ID_MENU");
                    map.NotNullable(true);
                    map.Update(false);
                    map.Insert(true);
                    map.ForeignKey("FK_MENU_ROL_01");
                    //map.UniqueKey("FK_MENU_ROL_01");
                });
            ManyToOne<ERol>(
                x => x.Rol, 
                map => {
                    map.Column("ID_ROL");
                    map.NotNullable(true);
                    map.Update(false);
                    map.Insert(true);
                    map.ForeignKey("FK_MENU_ROL_02");
                    //map.UniqueKey("FK_MENU_ROL_02");
                });
        }
    }
}