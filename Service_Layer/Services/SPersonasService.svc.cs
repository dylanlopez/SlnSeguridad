using AutoMapper;
using Business_Layer.Logics;
using Business_Layer.Logics.Personas;
using Domain_Layer.Dtos.Personas;
using Logging_Layer;
using Service_Layer.Models.Personas;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace Service_Layer.Services
{
    public class SPersonasService : ISPersonasService
    {
        private IBTipoDocumentoPersonaLogic _tipoDocumentoPersonaLogic;
        private IBPersonaLogic _personaLogic;
        private IBUsuarioLogic _usuarioLogic;
        private IBRolLogic _rolLogic;
        private IBUsuarioRolLogic _usuarioRolLogic;
        private IBMenuRolLogic _menuRolLogic;
        private Loggin _logger;

        public SPersonasService()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<TipoDocumentoPersonaModel, DTipoDocumentoPersonaDto>();
                config.CreateMap<DTipoDocumentoPersonaDto, TipoDocumentoPersonaModel>();
                config.CreateMap<PersonaModel, DPersonaDto>();
                config.CreateMap<DPersonaDto, PersonaModel>();
                config.CreateMap<UsuarioModel, DUsuarioDto>();
                config.CreateMap<DUsuarioDto, UsuarioModel>();
                config.CreateMap<RolModel, DRolDto>();
                config.CreateMap<DRolDto, RolModel>();
                config.CreateMap<UsuarioRolModel, DUsuarioRolDto>();
                config.CreateMap<DUsuarioRolDto, UsuarioRolModel>();
                config.CreateMap<MenuRolModel, DMenuRolDto>();
                config.CreateMap<DMenuRolDto, MenuRolModel>();
            });
        }

        #region TipoDocumentoPersona
        public TipoDocumentoPersonaModel BuscarTipoDocumentoPersona(TipoDocumentoPersonaModel model)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando BuscarTipoDocumentoPersona");
                _tipoDocumentoPersonaLogic = new BLogic();
                var dto = Mapper.Map<DTipoDocumentoPersonaDto>(model);
                var resp = Mapper.Map<TipoDocumentoPersonaModel>(_tipoDocumentoPersonaLogic.Buscar(dto));
                //return _tipoDocumentoPersonaLogic.Buscar(dto);
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
        public List<TipoDocumentoPersonaModel> ListarTipoDocumentoPersona(TipoDocumentoPersonaModel model)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando ListarTipoDocumentoPersona");
                _tipoDocumentoPersonaLogic = new BLogic();
                var dto = Mapper.Map<DTipoDocumentoPersonaDto>(model);
                var resp = Mapper.Map<List<TipoDocumentoPersonaModel>>(_tipoDocumentoPersonaLogic.Listar(dto));
                //return _tipoDocumentoPersonaLogic.Listar(dto);
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

        #region Persona
        public int ActualizarPersona(PersonaModel model)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando ActualizarPersona");
                _personaLogic = new BLogic();
                var dto = Mapper.Map<DPersonaDto>(model);
                return _personaLogic.Actualizar(dto);
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
        public PersonaModel BuscarPersona(PersonaModel model)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando BuscarPersona");
                _personaLogic = new BLogic();
                var dto = Mapper.Map<DPersonaDto>(model);
                var resp = Mapper.Map<PersonaModel>(_personaLogic.Buscar(dto));
                //return _personaLogic.Buscar(dto);
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
        public int EliminarPersona(PersonaModel model)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando EliminarPersona");
                _personaLogic = new BLogic();
                var dto = Mapper.Map<DPersonaDto>(model);
                return _personaLogic.Insertar(dto);
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
        public int InsertarPersona(PersonaModel model)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando InsertarPersona");
                _personaLogic = new BLogic();
                var dto = Mapper.Map<DPersonaDto>(model);
                return _personaLogic.Insertar(dto);
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
        public List<PersonaModel> ListarPersonas(PersonaModel model)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando ListarPersonas");
                _personaLogic = new BLogic();
                var dto = Mapper.Map<DPersonaDto>(model);
                var resp = Mapper.Map<List<PersonaModel>>(_personaLogic.Listar(dto));
                //return _personaLogic.Listar(dto);
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

        #region Usuario
        public int ActualizarUsuario(UsuarioModel model)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando ActualizarUsuario");
                _usuarioLogic = new BLogic();
                var dto = Mapper.Map<DUsuarioDto>(model);
                return _usuarioLogic.Actualizar(dto);
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
        public UsuarioModel BuscarUsuario(UsuarioModel model)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando BuscarUsuario");
                _usuarioLogic = new BLogic();
                var dto = Mapper.Map<DUsuarioDto>(model);
                var resp = Mapper.Map<UsuarioModel>(_usuarioLogic.Buscar(dto));
                //return _usuarioLogic.Buscar(dto);
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
        public int EliminarUsuario(UsuarioModel model)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando EliminarUsuario");
                _usuarioLogic = new BLogic();
                var dto = Mapper.Map<DUsuarioDto>(model);
                return _usuarioLogic.Insertar(dto);
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
        public int InsertarUsuario(UsuarioModel model)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando InsertarUsuario");
                _usuarioLogic = new BLogic();
                var dto = Mapper.Map<DUsuarioDto>(model);
                return _usuarioLogic.Insertar(dto);
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
        public List<UsuarioModel> ListarUsuarios(UsuarioModel model)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                //UsuarioModel model = new UsuarioModel();
                _logger.WriteInfoLog("iniciando ListarUsuarios");
                _usuarioLogic = new BLogic();
                var dto = Mapper.Map<DUsuarioDto>(model);
                var resp = Mapper.Map<List<UsuarioModel>>(_usuarioLogic.Listar(dto));
                //return _usuarioLogic.Listar(dto);
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

        #region Rol
        public int ActualizarRol(RolModel model)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando ActualizarRol");
                _rolLogic = new BLogic();
                var dto = Mapper.Map<DRolDto>(model);
                return _rolLogic.Actualizar(dto);
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
        public RolModel BuscarRol(RolModel model)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando BuscarRol");
                _rolLogic = new BLogic();
                var dto = Mapper.Map<DRolDto>(model);
                var resp = Mapper.Map<RolModel>(_rolLogic.Buscar(dto));
                //return _rolLogic.Buscar(dto);
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
        public int EliminarRol(RolModel model)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando EliminarRol");
                _rolLogic = new BLogic();
                var dto = Mapper.Map<DRolDto>(model);
                return _rolLogic.Insertar(dto);
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
        public int InsertarRol(RolModel model)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando InsertarRol");
                _rolLogic = new BLogic();
                var dto = Mapper.Map<DRolDto>(model);
                return _rolLogic.Insertar(dto);
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
        public List<RolModel> ListarRoles(RolModel model)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando ListarRoles");
                _rolLogic = new BLogic();
                var dto = Mapper.Map<DRolDto>(model);
                var resp = Mapper.Map<List<RolModel>>(_rolLogic.Listar(dto));
                //return _rolLogic.Listar(dto);
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

        #region UsuarioRol
        public int EliminarUsuarioRol(UsuarioRolModel model)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando EliminarUsuarioRol");
                _usuarioRolLogic = new BLogic();
                var dto = Mapper.Map<DUsuarioRolDto>(model);
                return _usuarioRolLogic.Insertar(dto);
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
        public int InsertarUsuarioRol(UsuarioRolModel model)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando InsertarUsuarioRol");
                _usuarioRolLogic = new BLogic();
                var dto = Mapper.Map<DUsuarioRolDto>(model);
                return _usuarioRolLogic.Insertar(dto);
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
        public List<UsuarioRolModel> ListarUsuariosRoles(UsuarioRolModel model)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando ListarUsuariosRoles");
                _usuarioRolLogic = new BLogic();
                var dto = Mapper.Map<DUsuarioRolDto>(model);
                var resp = Mapper.Map<List<UsuarioRolModel>>(_usuarioRolLogic.Listar(dto));
                //return _usuarioRolLogic.Listar(dto);
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

        #region MenuRol
        public int EliminarMenuRol(MenuRolModel model)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando EliminarMenuRol");
                _menuRolLogic = new BLogic();
                var dto = Mapper.Map<DMenuRolDto>(model);
                return _menuRolLogic.Insertar(dto);
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
        public int InsertarMenuRol(MenuRolModel model)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando InsertarMenuRol");
                _menuRolLogic = new BLogic();
                var dto = Mapper.Map<DMenuRolDto>(model);
                return _menuRolLogic.Insertar(dto);
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
        public List<MenuRolModel> ListarMenusRoles(MenuRolModel model)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando ListarMenusRoles");
                _menuRolLogic = new BLogic();
                var dto = Mapper.Map<DMenuRolDto>(model);
                var resp = Mapper.Map<List<MenuRolModel>>(_menuRolLogic.Listar(dto));
                //return _menuRolLogic.Listar(dto);
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