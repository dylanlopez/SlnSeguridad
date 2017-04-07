using AutoMapper;
using Business_Layer.Logics;
using Business_Layer.Logics.Personas;
using Domain_Layer.Dtos.Personas;
using Logging_Layer;
using Service_Layer.Converters.Personas;
using Service_Layer.Models.Personas;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace Service_Layer.Services
{
    public class SPersonasService : ISPersonasService
    {
        private IBPersonaLogic _personaLogic;
        private IBUsuarioLogic _usuarioLogic;
        private IBRolLogic _rolLogic;
        private Loggin _logger;

        public SPersonasService()
        {
            Mapper.Initialize(config =>
            {
                //config.CreateMap<TipoDocumentoPersonaModel, DTipoDocumentoPersonaDto>();
                //config.CreateMap<DTipoDocumentoPersonaDto, TipoDocumentoPersonaModel>();
                config.CreateMap<PersonaModel, DPersonaDto>();
                config.CreateMap<DPersonaDto, PersonaModel>();
                config.CreateMap<UsuarioModel, DUsuarioDto>();
                config.CreateMap<DUsuarioDto, UsuarioModel>();
                config.CreateMap<RolModel, DRolDto>();
                config.CreateMap<DRolDto, RolModel>();
            });
        }

        #region Persona
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
                var dto = SUsuarioConverter.ToDto(model);
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
                var dto = SUsuarioConverter.ToDto(model);
                var resp = SUsuarioConverter.ToModel(_usuarioLogic.Buscar(dto));
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
                var dto = SUsuarioConverter.ToDto(model);
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
                var dto = SUsuarioConverter.ToDto(model);
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
                _logger.WriteInfoLog("iniciando ListarUsuarios");
                _usuarioLogic = new BLogic();
                var dto = SUsuarioConverter.ToDto(model);
                var resp = SUsuarioConverter.ToModels(_usuarioLogic.Listar(dto));
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
                //var dto = Mapper.Map<DRolDto>(model);
                var dto = SRolConverter.ToDto(model);
                //var resp = Mapper.Map<List<RolModel>>(_rolLogic.Listar(dto));
                var resp = SRolConverter.ToModels(_rolLogic.Listar(dto));
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
    }
}