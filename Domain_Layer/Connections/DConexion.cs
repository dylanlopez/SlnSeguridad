using Oracle.ManagedDataAccess.Client;
using System.Configuration;

namespace Domain_Layer.Connections
{
    public static class DConexion
    {
        private static OracleConnection _conexionMidis;

        public static OracleConnection ConexionMidis
        {
            get
            {
                if (_conexionMidis == null)
                {
                    _conexionMidis = new OracleConnection();
                    _conexionMidis.ConnectionString = ConfigurationManager.ConnectionStrings["DBMIDIS"].ConnectionString;
                }
                return _conexionMidis;
            }
        }
    }
}