using AutoMapper;
using Business_Layer.Logics;
using Business_Layer.Logics.Sistemas;
using Domain_Layer.Dtos.Sistemas;
using Interface_Layer.Models.Sistemas;
using Logging_Layer;
using Service_Layer.Converters.Sistemas;
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
                var dto = Mapper.Map<DSistemaDto>(model);
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
                var dto = Mapper.Map<DSistemaDto>(model);
                var resp = Mapper.Map<SistemaModel>(_sistemaLogic.Buscar(dto));
                //dto = _sistemaLogic.Buscar(dto);
                //model = Mapper.Map<SistemaModel>(dto);
                ModuloModel moduloModel = new ModuloModel();
                moduloModel.Sistema = resp;
                resp.Modulos = ListarModulos(moduloModel);
                //model.Modulos
                //model = _sistemaLogic.Buscar(dtoSistema);
                //return _sistemaLogic.Buscar(model);
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
                var dto = Mapper.Map<DSistemaDto>(model);
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
                //var dto = Mapper.Map<DSistemaDto>(model);
                var dto = SSistemaConverter.ToDto(model);
                //var resp = Mapper.Map<List<SistemaModel>>(_sistemaLogic.Listar(dto));
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
                var dto = Mapper.Map<DModuloDto>(model);
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
                //var dto = Mapper.Map<DModuloDto>(model);
                var dto = Mapper.Map<DModuloDto>(model);
                var resp = Mapper.Map<ModuloModel>(_moduloLogic.Buscar(dto));
                //dto = _moduloLogic.Buscar(dto);
                //model = Mapper.Map<ModuloModel>(dto);
                MenuModel menuModel = new MenuModel();
                menuModel.Modulo = resp;
                resp.Menus = ListarMenus(menuModel);
                //return _moduloLogic.Buscar(dto);
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
                var dto = Mapper.Map<DModuloDto>(model);
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
                //var dto = Mapper.Map<DModuloDto>(model);
                //return _moduloLogic.Listar(dto);
                //var dto = Mapper.Map<DModuloDto>(model);
                var dto = SModuloConverter.ToDto(model);
                //var resp = Mapper.Map<List<ModuloModel>>(_moduloLogic.Listar(dto));
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
                var dto = Mapper.Map<DMenuDto>(model);
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
                var dto = Mapper.Map<DMenuDto>(model);
                var resp = Mapper.Map<MenuModel>(_menuLogic.Buscar(dto));
                //return _menuLogic.Buscar(dto);
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
                var dto = Mapper.Map<DMenuDto>(model);
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
                var dto = Mapper.Map<DMenuDto>(model);
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
                //var dto = Mapper.Map<DMenuDto>(model);
                var dto = SMenuConverter.ToDto(model);
                //var resp = Mapper.Map<List<MenuModel>>(_menuLogic.Listar(dto));
                var resp = SMenuConverter.ToModels(_menuLogic.Listar(dto));
                //return _menuLogic.Listar(dto);
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