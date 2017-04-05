using AutoMapper;
using Business_Layer.Logics;
using Business_Layer.Logics.Sistemas;
using Domain_Layer.Dtos.Sistemas;
using Logging_Layer;
using Service_Layer.Converters.Sistemas;
using Service_Layer.Models.Sistemas;
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

        private IBOpcionLogic _opcionLogic;
        private IBMenuOpcionLogic _menuOpcionLogic;
        private Loggin _logger;

        public SSistemasServices()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<SistemaModel, DSistemaDto>();
                config.CreateMap<DSistemaDto, SistemaModel>();
                config.CreateMap<ModuloModel, DModuloDto>();
                config.CreateMap<DModuloDto, ModuloModel>();
                config.CreateMap<MenuModel, DMenuDto>();
                config.CreateMap<DMenuDto, MenuModel>();
            });
        }

        #region Sistema
        public int ActualizarSistema(SistemaModel model)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando ActualizarSistema");
                _sistemaLogic = new BLogic();
                var dto = SSistemaConverter.ToDto(model);
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
        public SistemaModel BuscarSistema(SistemaModel model)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando BuscarSistema");
                _sistemaLogic = new BLogic();
                var dto = SSistemaConverter.ToDto(model);
                var resp = SSistemaConverter.ToModel(_sistemaLogic.Buscar(dto));
                ModuloModel moduloModel = new ModuloModel();
                moduloModel.Sistema = resp;
                resp.Modulos = ListarModulos(moduloModel);
                return resp;
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
        public int InsertarSistema(SistemaModel model)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando InsertarSistema");
                _sistemaLogic = new BLogic();
                var dto = SSistemaConverter.ToDto(model);
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
        public List<SistemaModel> ListarSistemas(SistemaModel model)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando ListarSistemas");
                _sistemaLogic = new BLogic();
                var dto = SSistemaConverter.ToDto(model);
                var resp = SSistemaConverter.ToModels(_sistemaLogic.Listar(dto));
                ModuloModel moduloModel;
                foreach (var item in resp)
                {
                    moduloModel = new ModuloModel();
                    moduloModel.Sistema = item;
                    item.Modulos = ListarModulos(moduloModel);
                }
                return resp;
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
        public int ActualizarModulo(ModuloModel model)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando ActualizarModulo");
                _moduloLogic = new BLogic();
                var dto = SModuloConverter.ToDto(model);
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
        public ModuloModel BuscarModulo(ModuloModel model)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando BuscarModulo");
                _moduloLogic = new BLogic();
                var dto = SModuloConverter.ToDto(model);
                var resp = SModuloConverter.ToModel(_moduloLogic.Buscar(dto));
                MenuModel menuModel = new MenuModel();
                menuModel.Modulo = resp;
                resp.Menus = ListarMenus(menuModel);
                return resp;
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
        public int InsertarModulo(ModuloModel model)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando InsertarModulo");
                _moduloLogic = new BLogic();
                var dto = SModuloConverter.ToDto(model);
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
        public List<ModuloModel> ListarModulos(ModuloModel model)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando ListarModulos");
                _moduloLogic = new BLogic();
                var dto = SModuloConverter.ToDto(model);
                var resp = SModuloConverter.ToModels(_moduloLogic.Listar(dto));
                MenuModel menuModel;
                foreach (var item in resp)
                {
                    menuModel = new MenuModel();
                    menuModel.Modulo = item;
                    item.Menus = ListarMenus(menuModel);
                }
                return resp;
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
        public int ActualizarMenu(MenuModel model)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando ActualizarMenu");
                _menuLogic = new BLogic();
                var dto = SMenuConverter.ToDto(model);
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
        public MenuModel BuscarMenu(MenuModel model)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando BuscarMenu");
                _menuLogic = new BLogic();
                var dto = SMenuConverter.ToDto(model);
                var resp = SMenuConverter.ToModel(_menuLogic.Buscar(dto));
                return resp;
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
        public int EliminarMenu(MenuModel model)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando EliminarMenu");
                _menuLogic = new BLogic();
                var dto = SMenuConverter.ToDto(model);
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
        public int InsertarMenu(MenuModel model)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando InsertarMenu");
                _menuLogic = new BLogic();
                var dto = SMenuConverter.ToDto(model);
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
        public List<MenuModel> ListarMenus(MenuModel model)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando ListarMenus");
                _menuLogic = new BLogic();
                var dto = SMenuConverter.ToDto(model);
                var resp = SMenuConverter.ToModels(_menuLogic.Listar(dto));
                return resp;
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

        #region Opcion
        public int ActualizarOpcion(OpcionModel model)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando ActualizarOpcion");
                _opcionLogic = new BLogic();
                var dto = SOpcionConverter.ToDto(model);
                return _opcionLogic.Actualizar(dto);
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
        public OpcionModel BuscarOpcion(OpcionModel model)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando BuscarOpcion");
                _opcionLogic = new BLogic();
                var dto = SOpcionConverter.ToDto(model);
                var resp = SOpcionConverter.ToModel(_opcionLogic.Buscar(dto));
                return resp;
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
        public int EliminarOpcion(OpcionModel model)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando EliminarMenu");
                _opcionLogic = new BLogic();
                var dto = SOpcionConverter.ToDto(model);
                return _opcionLogic.Insertar(dto);
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
        public int InsertarOpcion(OpcionModel model)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando InsertarOpcion");
                _opcionLogic = new BLogic();
                var dto = SOpcionConverter.ToDto(model);
                return _opcionLogic.Insertar(dto);
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
        public List<OpcionModel> ListarOpciones(OpcionModel model)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando ListarOpciones");
                _opcionLogic = new BLogic();
                var dto = SOpcionConverter.ToDto(model);
                var resp = SOpcionConverter.ToModels(_opcionLogic.Listar(dto));
                return resp;
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

        #region MenuOpcion
        public int ActualizarMenuOpcion(MenuOpcionModel model)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando ActualizarMenuOpcion");
                _menuOpcionLogic = new BLogic();
                var dto = SMenuOpcionConverter.ToDto(model);
                return _menuOpcionLogic.Actualizar(dto);
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
        public MenuOpcionModel BuscarMenuOpcion(MenuOpcionModel model)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando BuscarMenuOpcion");
                _menuOpcionLogic = new BLogic();
                var dto = SMenuOpcionConverter.ToDto(model);
                var resp = SMenuOpcionConverter.ToModel(_menuOpcionLogic.Buscar(dto));
                return resp;
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
        public int EliminarMenuOpcion(MenuOpcionModel model)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando EliminarMenuOpcion");
                _menuOpcionLogic = new BLogic();
                var dto = SMenuOpcionConverter.ToDto(model);
                return _menuOpcionLogic.Insertar(dto);
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
        public int InsertarMenuOpcion(MenuOpcionModel model)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando InsertarMenuOpcion");
                _menuOpcionLogic = new BLogic();
                var dto = SMenuOpcionConverter.ToDto(model);
                return _menuOpcionLogic.Insertar(dto);
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
        public List<MenuOpcionModel> ListarMenuOpciones(MenuOpcionModel model)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando ListarMenuOpciones");
                _menuOpcionLogic = new BLogic();
                var dto = SMenuOpcionConverter.ToDto(model);
                var resp = SMenuOpcionConverter.ToModels(_menuOpcionLogic.Listar(dto));
                return resp;
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