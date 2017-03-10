using Domain_Layer.Configurations;
using Domain_Layer.Connections;
using Logging_Layer;
using NHibernate;
using System;
using System.Diagnostics;
using System.Reflection;

namespace Domain_Layer.Queries
{
    /// <summary>
    /// Here is partial class DQuery
    /// </summary>
    /// <seealso cref="Domain_Layer.Queries.Sistemas.IDMenuQuery" />
    /// <seealso cref="Domain_Layer.Queries.Sistemas.IDModuloQuery" />
    /// <seealso cref="Domain_Layer.Queries.Sistemas.IDSistemaQuery" />
    /// <seealso cref="Domain_Layer.Queries.Personas.IDProgramaSocialQuery" />
    /// <seealso cref="Domain_Layer.Queries.Personas.IDTipoDocumentoPersonaQuery" />
    /// <seealso cref="Domain_Layer.Queries.Personas.IDPersonaQuery" />
    /// <seealso cref="Domain_Layer.Queries.Personas.IDPersonaProgramaSocialQuery" />
    /// <seealso cref="Domain_Layer.Queries.Personas.IDUsuarioQuery" />
    /// <seealso cref="Domain_Layer.Queries.Personas.IDRolQuery" />
    /// <seealso cref="Domain_Layer.Queries.Personas.IDUsuarioRolQuery" />
    /// <seealso cref="Domain_Layer.Queries.Personas.IDMenuRolQuery" />
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    public partial class DQuery
    {
        private static string _connection;
        private static ISessionFactory _sessionFactoryMidis;
        private static ISession _sessionMidis;
        private static ITransaction _transactionMidis;
        private Loggin _logger;

        public DQuery()
        {
            if(_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _connection = DConexion.ConexionMidis.ConnectionString;
                DConfigureHibernate.Setup(_connection);
                _sessionFactoryMidis = DConfigureHibernate.SessionFactoryMidis;
            }
            catch(Exception ex)
            {
                _logger.WriteErrorLog(ex);
            }
            finally
            {
                _logger = null;
            }
        }
    }
}