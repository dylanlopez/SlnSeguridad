using Domain_Layer.Configurations;
using Domain_Layer.Connections;
using NHibernate;

namespace Domain_Layer.Queries
{
    public partial class DQuery
    {
        private static string _connection;
        private static ISessionFactory _sessionFactoryMidis;
        private static ISession _sessionMidis;
        private static ITransaction _transactionMidis;

        public DQuery()
        {
            _connection = DConexion.ConexionMidis.ConnectionString;
            DConfigureHibernate.Setup(_connection);
            _sessionFactoryMidis = DConfigureHibernate.SessionFactoryMidis;
        }
    }
}