﻿using Entity_Layer.Entities.Sistemas;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;

namespace Entity_Layer.Mappings.Sistemas
{
    /// <summary>
    /// Here is the mapping class EMenuMapping, on which entity-class mapping is performed using the NHibernate ClassMapping. Here
    /// MENU table is mapped over EMenu entity class.
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    /// <seealso cref="NHibernate.Mapping.ByCode.Conformist.ClassMapping{Entity_Layer.Entities.Sistemas.EMenu}" />
    public class EMenuMapping : ClassMapping<EMenu>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EMenuMapping"/> class.
        /// </summary>
        public EMenuMapping()
        {
            Schema("ES_SEGURIDAD");
            Table("MENU");
            Id<Int32>(
                x => x.Id,
                map => {
                    map.Column("ID_MENU");
                    map.Generator(
                        Generators.Sequence,
                        seq => seq.Params(new
                        {
                            schema = "ES_SEGURIDAD",
                            sequence = "SEQ_MENU"
                        }));
                });
            Property<String>(
                x => x.Codigo,
                map => {
                    map.Column("CODIGO");
                    map.Length(7);
                    map.NotNullable(true);
                });
            Property<String>(
                x => x.Nombre, 
                map => {
                    map.Column("NOMBRE");
                    map.Length(50);
                    map.NotNullable(true);
                });
            Property<String>(
                x => x.Ruta, 
                map => {
                    map.Column("RUTA");
                    map.Length(200);
                    map.NotNullable(true);
                });
            Property<String>(
                x => x.Descripcion, 
                map => {
                    map.Column("DESCRIPCION");
                    map.Length(200);
                    map.NotNullable(false);
                });
            Property<Char>(
                x => x.Estado, 
                map => {
                    map.Column("ESTADO");
                    map.Length(1);
                    map.NotNullable(true);
                });
            ManyToOne<EModulo>(
                x => x.Modulo, 
                map => {
                    map.Column("ID_MODULO");
                    map.NotNullable(true);
                    map.Update(false);
                    map.Insert(false);
                });
        }
    }
}