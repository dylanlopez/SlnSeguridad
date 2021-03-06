﻿using Entity_Layer.Entities.Sistemas;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Configuration;

namespace Entity_Layer.Mappings.Sistemas
{
    /// <summary>
    /// Here is the mapping class <see cref="EMenuMapping"/>, on which entity-class mapping is performed using the NHibernate ClassMapping. Here
    /// SEGTM_MENU table is mapped over <see cref="EMenu"/> entity class.
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    /// <v2.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Include fields of database changes</description>
    /// </v2.0>
    /// <seealso cref="NHibernate.Mapping.ByCode.Conformist.ClassMapping{Entity_Layer.Entities.Sistemas.EMenu}" />
    public class EMenuMapping : ClassMapping<EMenu>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EMenuMapping"/> class.
        /// </summary>
        public EMenuMapping()
        {
            string schemaSeguridad = ConfigurationManager.AppSettings["Schema"].ToString();
            Schema(schemaSeguridad);
            Table("SEGTM_MENU");
            Id<Int32>(
                x => x.Id,
                map => {
                    map.Column("ID_MENU");
                    map.Generator(
                        Generators.Sequence,
                        seq => seq.Params(new
                        {
                            schema = schemaSeguridad,
                            sequence = "SEQ_MENU"
                        }));
                });
            Property<String>(
                x => x.Codigo,
                map => {
                    map.Column("CO_MENU");
                    map.Length(7);
                    map.NotNullable(true);
                    map.UniqueKey("UK_MENU_01");
                });
            Property<String>(
                x => x.Nombre, 
                map => {
                    map.Column("NO_MENU");
                    map.Length(50);
                    map.NotNullable(true);
                });
            Property<String>(
                x => x.Ruta, 
                map => {
                    map.Column("DE_RUTA");
                    map.Length(200);
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
                x => x.Descripcion, 
                map => {
                    map.Column("DE_DESCRIPCION");
                    map.Length(200);
                    map.NotNullable(false);
                });
            ManyToOne<EModulo>(
                x => x.Modulo, 
                map => {
                    map.Column("ID_MODULO");
                    map.NotNullable(true);
                    map.Update(true);
                    map.Insert(true);
                    map.ForeignKey("FK_MENU_01");
                });
        }
    }
}