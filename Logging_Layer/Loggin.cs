using log4net;
using System;
using System.Diagnostics;
using System.Reflection;

namespace Logging_Layer
{
    public class Loggin
    {
        public readonly ILog LoggerClient;
        private readonly string _currentFullPath;
        private readonly string _currentAssemblyName;
        private readonly string _currentClassName;
        private readonly string _currentMathodName;

        public Loggin(MethodBase mb, StackTrace st)
        {
            try
            {
                log4net.Config.XmlConfigurator.Configure();
                _currentAssemblyName = mb.ReflectedType.Assembly.GetName().Name;
                //_currentClassName = mb.ReflectedType.Name;
                if(mb.ReflectedType.GetInterfaces().Length > 0)
                {
                    _currentClassName = mb.ReflectedType.Name + "(" + mb.ReflectedType.GetInterfaces()[0] + ")";
                }
                else
                {
                    _currentClassName = mb.ReflectedType.Name;
                }
                _currentMathodName = st.GetFrame(1).GetMethod().Name;
                _currentFullPath = _currentAssemblyName + "." + _currentClassName + "." + _currentMathodName;
                LoggerClient = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            }
            catch(Exception ex)
            {
                throw (ex);
            }
        }

        public void WriteInfoLog(string message)
        {
            try
            {
                LoggerClient.Info(_currentFullPath + " - " + message);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void WriteDebugLog(string message)
        {
            try
            {
                LoggerClient.Debug(_currentFullPath + " - " + message);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void WriteErrorLog(Exception exception)
        {
            try
            {
                var composite = _currentFullPath + " - " + "Ocurrio un error, generandose la siguiente excepcion: " + exception.Message + ".";
                if(exception.InnerException != null)
                {
                    composite = composite + " Junto a la excepcion interna: " + exception.InnerException.Message + ".";
                }
                LoggerClient.Error(composite);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}