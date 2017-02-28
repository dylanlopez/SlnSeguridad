using Oracle.ManagedDataAccess.Client;
using System.Configuration;

namespace Domain_Layer.Connections
{
    /// <summary>
    /// Here the connection class DConexion, actually works only with Oracle Database.
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version works only with Oracle Database</description>
    /// </v1.0>
    public static class DConexion
    {
        /// <summary>
        /// The Oracle connection to MIDIS.
        /// </summary>
        private static OracleConnection _conexionMidis;

        /// <summary>
        /// Gets the Oracle connection to MIDIS, if it isn't initialize, it must load from web.config.
        /// </summary>
        /// <value>
        /// This property hasn't setter.
        /// </value>
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