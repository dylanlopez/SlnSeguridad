using Entity_Layer.Mappings.Sistemas;
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
    public class DConfigureHibernate
    {
        private static string _connection;
        public static Configuration NHConfiguration;
        public static ISessionFactory SessionFactoryMidis { get; set; }

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
        public static Configuration ConfigureNHibernate()
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
        public static HbmMapping GetMappings()
        {
            try
            {
                var mapper = new ModelMapper();
                //mapper.AddMappings(Assembly.GetAssembly(typeof(ESistema)).GetExportedTypes());
                mapper.AddMapping<ESistemaMapping>();
                mapper.AddMapping<EModuloMapping>();
                mapper.AddMapping<EMenuMapping>();
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