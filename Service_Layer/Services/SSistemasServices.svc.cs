using Business_Layer.Logics;
using Business_Layer.Logics.Sistemas;
using Domain_Layer.Dtos.Sistemas;
using Logging_Layer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace Service_Layer.Services
{
    public class SSistemasServices : ISSistemasServices
    {
        private IBTipoDocumentoPersona _sistemaLogic;
        private IBModuloLogic _moduloLogic;
        private IBMenuLogic _menuLogic;
        private Loggin _logger;

        #region Sistema
        public int ActualizarSistema(DSistemaDto dto)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando ActualizarSistema");
                _sistemaLogic = new BLogic();
                return _sistemaLogic.Actualizar(dto);
            }
            catch(Exception ex)
            {
                _logger.WriteErrorLog(ex);
                throw ex;
            }
            finally
            {
                _logger = null;
            }
        }
        public DSistemaDto BuscarSistema(DSistemaDto dto)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando BuscarSistema");
                _sistemaLogic = new BLogic();
                return _sistemaLogic.Buscar(dto);
            }
            catch (Exception ex)
            {
                _logger.WriteErrorLog(ex);
                throw ex;
            }
            finally
            {
                _logger = null;
            }
        }
        public int InsertarSistema(DSistemaDto dto)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando InsertarSistema");
                _sistemaLogic = new BLogic();
                return _sistemaLogic.Insertar(dto);
            }
            catch (Exception ex)
            {
                _logger.WriteErrorLog(ex);
                throw ex;
            }
            finally
            {
                _logger = null;
            }
        }
        public List<DSistemaDto> ListarSistemas(DSistemaDto dto)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando ListarSistemas");
                _sistemaLogic = new BLogic();
                return _sistemaLogic.Listar(dto);
            }
            catch (Exception ex)
            {
                _logger.WriteErrorLog(ex);
                throw ex;
            }
            finally
            {
                _logger = null;
            }
        }
        #endregion

        #region Modulo
        public int ActualizarModulo(DModuloDto dto)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando ActualizarModulo");
                _moduloLogic = new BLogic();
                return _moduloLogic.Actualizar(dto);
            }
            catch (Exception ex)
            {
                _logger.WriteErrorLog(ex);
                throw ex;
            }
            finally
            {
                _logger = null;
            }
        }
        public DModuloDto BuscarModulo(DModuloDto dto)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando BuscarModulo");
                _moduloLogic = new BLogic();
                return _moduloLogic.Buscar(dto);
            }
            catch (Exception ex)
            {
                _logger.WriteErrorLog(ex);
                throw ex;
            }
            finally
            {
                _logger = null;
            }
        }
        public int InsertarModulo(DModuloDto dto)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando InsertarModulo");
                _moduloLogic = new BLogic();
                return _moduloLogic.Insertar(dto);
            }
            catch (Exception ex)
            {
                _logger.WriteErrorLog(ex);
                throw ex;
            }
            finally
            {
                _logger = null;
            }
        }
        public List<DModuloDto> ListarModulos(DModuloDto dto)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando ListarModulos");
                _moduloLogic = new BLogic();
                return _moduloLogic.Listar(dto);
            }
            catch (Exception ex)
            {
                _logger.WriteErrorLog(ex);
                throw ex;
            }
            finally
            {
                _logger = null;
            }
        }
        #endregion

        #region Menu
        public int ActualizarMenu(DMenuDto dto)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando ActualizarMenu");
                _menuLogic = new BLogic();
                return _menuLogic.Actualizar(dto);
            }
            catch (Exception ex)
            {
                _logger.WriteErrorLog(ex);
                throw ex;
            }
            finally
            {
                _logger = null;
            }
        }
        public DMenuDto BuscarMenu(DMenuDto dto)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando BuscarMenu");
                _menuLogic = new BLogic();
                return _menuLogic.Buscar(dto);
            }
            catch (Exception ex)
            {
                _logger.WriteErrorLog(ex);
                throw ex;
            }
            finally
            {
                _logger = null;
            }
        }
        public int EliminarMenu(DMenuDto dto)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando EliminarMenu");
                _menuLogic = new BLogic();
                return _menuLogic.Insertar(dto);
            }
            catch (Exception ex)
            {
                _logger.WriteErrorLog(ex);
                throw ex;
            }
            finally
            {
                _logger = null;
            }
        }
        public int InsertarMenu(DMenuDto dto)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando InsertarMenu");
                _menuLogic = new BLogic();
                return _menuLogic.Insertar(dto);
            }
            catch (Exception ex)
            {
                _logger.WriteErrorLog(ex);
                throw ex;
            }
            finally
            {
                _logger = null;
            }
        }
        public List<DMenuDto> ListarMenus(DMenuDto dto)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando ListarMenus");
                _menuLogic = new BLogic();
                return _menuLogic.Listar(dto);
            }
            catch (Exception ex)
            {
                _logger.WriteErrorLog(ex);
                throw ex;
            }
            finally
            {
                _logger = null;
            }
        }
        #endregion
    }
}