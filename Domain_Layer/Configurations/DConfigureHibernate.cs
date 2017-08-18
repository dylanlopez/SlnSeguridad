using Entity_Layer.Mappings.Personas;
using Entity_Layer.Mappings.Sistemas;
using Entity_Layer.Mappings.Vistas;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Data;

namespace Domain_Layer.Configurations
{
    /// <summary>
    /// Here is the NHibernate configure class DConfigureHibernate.
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    public class DConfigureHibernate
    {
        /// <summary>
        /// The string of connection.
        /// </summary>
        private static string _connection;

        /// <summary>
        /// The NHibernate Configuration.
        /// </summary>
        public static Configuration NHConfiguration;

        /// <summary>
        /// Gets or sets the MIDIS session factory.
        /// </summary>
        /// <value>
        /// The MIDIS session factory.
        /// </value>
        public static ISessionFactory SessionFactoryMidis { get; set; }

        /// <summary>
        /// Setups the NHibernate configuration with the specified connection and build a session factory with this.
        /// </summary>
        /// <param name="connection">The connection.</param>
        public static void Setup(string connection)
        {
            try
            {
                _connection = connection;
                NHConfiguration = ConfigureNHibernate();
                SessionFactoryMidis = NHConfiguration.BuildSessionFactory();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Configures the NHibernate establish a factory name, a dialect and a driver, also create the mappings.
        /// </summary>
        /// <returns></returns>
        private static Configuration ConfigureNHibernate()
        {
            var conf = new Configuration();
            try
            {
                conf.SessionFactoryName("MidisSession");
                conf.DataBaseIntegration(db =>
                {
                    db.Dialect<Oracle10gDialect>();
                    db.Driver<OracleClientDriver>();
                    db.KeywordsAutoImport = Hbm2DDLKeyWords.AutoQuote;
                    db.IsolationLevel = IsolationLevel.ReadCommitted;
                    db.ConnectionString = _connection;
                    db.Timeout = 10;
                });
                conf.AddDeserializedMapping(GetMappings(), "ES_SEGURIDAD");
                SchemaMetadataUpdater.QuoteTableAndColumns(conf);
                return conf;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets the model mapper from all entities from mapping classes.
        /// </summary>
        /// <returns>The model mapper</returns>
        private static HbmMapping GetMappings()
        {
            try
            {
                var mapper = new ModelMapper();
                mapper.AddMapping<ESistemaMapping>();
                mapper.AddMapping<EModuloMapping>();
                mapper.AddMapping<EMenuMapping>();
                mapper.AddMapping<EOpcionMapping>();
                mapper.AddMapping<EMenuOpcionMapping>();
                mapper.AddMapping<EUsuarioMapping>();
                mapper.AddMapping<EPerfilMapping>();
                mapper.AddMapping<ESistemaPerfilMapping>();
                mapper.AddMapping<ERolMapping>();
                mapper.AddMapping<EPerfilUsuarioRolMapping>();
                mapper.AddMapping<EPermisoMapping>();
                mapper.AddMapping<ETipoInstitucionMapping>();
                mapper.AddMapping<EInstitucionMapping>();
                mapper.AddMapping<EVistaPermisoMapping>();
                HbmMapping mapping = mapper.CompileMappingForAllExplicitlyAddedEntities();
                return mapping;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}