//using AutoMapper;
using Business_Layer.Logics;
using Business_Layer.Logics.Personas;
using Business_Layer.Logics.Vistas;
using Domain_Layer.Dtos.Personas;
using Domain_Layer.Dtos.Vistas;
using Logging_Layer;
using Service_Layer.Converters.Personas;
using Service_Layer.Converters.Vistas;
using Service_Layer.Models.Personas;
using Service_Layer.Models.Vistas;
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
        private IBPerfilLogic _perfilLogic;
        private IBSistemaPerfilLogic _sistemaPerfilLogic;
        private IBRolLogic _rolLogic;
        private IBPerfilUsuarioRolLogic _perfilUsuarioRolLogic;
        private IBPermisoLogic _permisoLogic;
        private IBVistaPermisoQuery _vistaPermisoQuery;
        private Loggin _logger;

        public SPersonasService()
        {
            //Mapper.Initialize(config =>
            //{
            //    //config.CreateMap<TipoDocumentoPersonaModel, DTipoDocumentoPersonaDto>();
            //    //config.CreateMap<DTipoDocumentoPersonaDto, TipoDocumentoPersonaModel>();
            //    config.CreateMap<PersonaModel, DPersonaDto>();
            //    config.CreateMap<DPersonaDto, PersonaModel>();
            //    config.CreateMap<UsuarioModel, DUsuarioDto>();
            //    config.CreateMap<DUsuarioDto, UsuarioModel>();
            //    config.CreateMap<RolModel, DRolDto>();
            //    config.CreateMap<DRolDto, RolModel>();
            //});
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
                //var dto = Mapper.Map<DPersonaDto>(model);
                var dto = SPersonaConverter.ToDto(model);
                //var resp = Mapper.Map<PersonaModel>(_personaLogic.Buscar(dto));
                //var resp = SPersonaConverter.ToModel(_personaLogic.Buscar(dto));
                var person = _personaLogic.Buscar(dto);
                PersonaModel resp = null;
                if (person != null)
                {
                    resp = SPersonaConverter.ToModel(person);
                }
                else
                {
                    resp = new PersonaModel();
                }
                //return _personaLogic.Buscar(dto);
                return resp;
            }
            catch (Exception ex)
            {
                _logger.WriteErrorLog(ex);
                //throw ex;
                return null;
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
                if (ex.InnerException != null)
                {
                    return ex.InnerException.HResult;
                }
                //throw ex;
                return 0;
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
                //throw ex;
                return null;
            }
            finally
            {
                _logger = null;
            }
        }
        public UsuarioModel BuscarUsuarioPorUsuario(UsuarioModel model)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando BuscarUsuarioPorUsuario");
                _usuarioLogic = new BLogic();
                var dto = SUsuarioConverter.ToDto(model);
                //var resp = SUsuarioConverter.ToModel(_usuarioLogic.BuscarPorUsuario(dto));
                var user = _usuarioLogic.BuscarPorUsuario(dto);
                UsuarioModel resp = null;
                if (user != null)
                {
                    resp = SUsuarioConverter.ToModel(user);
                }
                else
                {
                    resp = new UsuarioModel();
                }
                return resp;
            }
            catch (Exception ex)
            {
                _logger.WriteErrorLog(ex);
                //throw ex;
                return null;
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
                //throw ex;
                return 0;
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
                if (ex.InnerException != null)
                {
                    return ex.InnerException.HResult;
                }
                //throw ex;
                return 0;
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
                //throw ex;
                return null;
            }
            finally
            {
                _logger = null;
            }
        }
        #endregion

        #region Perfil
        public int ActualizarPerfil(PerfilModel model)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando ActualizarPerfil");
                _perfilLogic = new BLogic();
                var dto = SPerfilConverter.ToDto(model);
                return _perfilLogic.Actualizar(dto);
            }
            catch (Exception ex)
            {
                _logger.WriteErrorLog(ex);
                if (ex.InnerException != null)
                {
                    return ex.InnerException.HResult;
                }
                //throw ex;
                return 0;
            }
            finally
            {
                _logger = null;
            }
        }
        public int InsertarPerfil(PerfilModel model)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando InsertarPerfil");
                _perfilLogic = new BLogic();
                var dto = SPerfilConverter.ToDto(model);
                return _perfilLogic.Insertar(dto);
            }
            catch (Exception ex)
            {
                _logger.WriteErrorLog(ex);
                if (ex.InnerException != null)
                {
                    return ex.InnerException.HResult;
                }
                //throw ex;
                return 0;
            }
            finally
            {
                _logger = null;
            }
        }
        public List<PerfilModel> ListarPerfiles(PerfilModel model)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando ListarPerfiles");
                _perfilLogic = new BLogic();
                var dto = SPerfilConverter.ToDto(model);
                var resp = SPerfilConverter.ToModels(_perfilLogic.Listar(dto));
                return resp;
            }
            catch (Exception ex)
            {
                _logger.WriteErrorLog(ex);
                //throw ex;
                return null;
            }
            finally
            {
                _logger = null;
            }
        }
        #endregion

        #region SistemaPerfil
        public int ActualizarSistemaPerfil(SistemaPerfilModel model)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando ActualizarRol");
                _sistemaPerfilLogic = new BLogic();
                var dto = SSistemaPerfilConvert.ToDto(model);
                return _sistemaPerfilLogic.Actualizar(dto);
            }
            catch (Exception ex)
            {
                _logger.WriteErrorLog(ex);
                if (ex.InnerException != null)
                {
                    return ex.InnerException.HResult;
                }
                //throw ex;
                return 0;
            }
            finally
            {
                _logger = null;
            }
        }
        public int InsertarSistemaPerfil(SistemaPerfilModel model)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando InsertarRol");
                _sistemaPerfilLogic = new BLogic();
                var dto = SSistemaPerfilConvert.ToDto(model);
                return _sistemaPerfilLogic.Insertar(dto);
            }
            catch (Exception ex)
            {
                _logger.WriteErrorLog(ex);
                if (ex.InnerException != null)
                {
                    return ex.InnerException.HResult;
                }
                //throw ex;
                return 0;
            }
            finally
            {
                _logger = null;
            }
        }
        public List<SistemaPerfilModel> ListarSistemasPerfiles(SistemaPerfilModel model)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando ListarRoles");
                _sistemaPerfilLogic = new BLogic();
                var dto = SSistemaPerfilConvert.ToDto(model);
                var resp = SSistemaPerfilConvert.ToModels(_sistemaPerfilLogic.Listar(dto));
                return resp;
            }
            catch (Exception ex)
            {
                _logger.WriteErrorLog(ex);
                return null;
                //throw ex;
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
                var dto = SRolConverter.ToDto(model);
                return _rolLogic.Actualizar(dto);
            }
            catch (Exception ex)
            {
                _logger.WriteErrorLog(ex);
                if (ex.InnerException != null)
                {
                    return ex.InnerException.HResult;
                }
                //throw ex;
                return 0;
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
                var dto = SRolConverter.ToDto(model);
                var resp = SRolConverter.ToModel(_rolLogic.Buscar(dto));
                return resp;
            }
            catch (Exception ex)
            {
                _logger.WriteErrorLog(ex);
                //throw ex;
                return null;
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
                var dto = SRolConverter.ToDto(model);
                return _rolLogic.Insertar(dto);
            }
            catch (Exception ex)
            {
                _logger.WriteErrorLog(ex);
                //throw ex;
                return 0;
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
                var dto = SRolConverter.ToDto(model);
                return _rolLogic.Insertar(dto);
            }
            catch (Exception ex)
            {
                _logger.WriteErrorLog(ex);
                if (ex.InnerException != null)
                {
                    return ex.InnerException.HResult;
                }
                //throw ex;
                return 0;
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
                var dto = SRolConverter.ToDto(model);
                var resp = SRolConverter.ToModels(_rolLogic.Listar(dto));
                return resp;
            }
            catch (Exception ex)
            {
                _logger.WriteErrorLog(ex);
                //throw ex;
                return null;
            }
            finally
            {
                _logger = null;
            }
        }
        #endregion

        #region PerfilUsuarioRol
        public int ActualizarPerfilUsuarioRol(PerfilUsuarioRolModel model)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando ActualizarPerfilUsuarioRol");
                _perfilUsuarioRolLogic = new BLogic();
                var dto = SPerfilUsuarioRolConverter.ToDto(model);
                return _perfilUsuarioRolLogic.Actualizar(dto);
            }
            catch (Exception ex)
            {
                _logger.WriteErrorLog(ex);
                if (ex.InnerException != null)
                {
                    return ex.InnerException.HResult;
                }
                //throw ex;
                return 0;
            }
            finally
            {
                _logger = null;
            }
        }
        public int InsertarPerfilUsuarioRol(PerfilUsuarioRolModel model)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando InsertarPerfilUsuarioRol");
                _perfilUsuarioRolLogic = new BLogic();
                var dto = SPerfilUsuarioRolConverter.ToDto(model);
                return _perfilUsuarioRolLogic.Insertar(dto);
            }
            catch (Exception ex)
            {
                _logger.WriteErrorLog(ex);
                if (ex.InnerException != null)
                {
                    return ex.InnerException.HResult;
                }
                //throw ex;
                return 0;
            }
            finally
            {
                _logger = null;
            }
        }
        public List<PerfilUsuarioRolModel> ListarPerfilesUsuariosRoles(PerfilUsuarioRolModel model)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando ListarPerfilesUsuariosRoles");
                _perfilUsuarioRolLogic = new BLogic();
                var dto = SPerfilUsuarioRolConverter.ToDto(model);
                var resp = SPerfilUsuarioRolConverter.ToModels(_perfilUsuarioRolLogic.Listar(dto));
                //var rolesusersprofiles = _perfilUsuarioRolLogic.Listar(dto);
                //List<PerfilUsuarioRolModel> resp = null;
                //if (user != null)
                //{
                //    resp = SUsuarioConverter.ToModel(user);
                //}
                //else
                //{
                //    resp = new UsuarioModel();
                //}
                return resp;
            }
            catch (Exception ex)
            {
                _logger.WriteErrorLog(ex);
                //throw ex;
                return null;
            }
            finally
            {
                _logger = null;
            }
        }
        #endregion

        #region Permiso
        public int ActualizarPermiso(PermisoModel model)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando ActualizarPermiso");
                _permisoLogic = new BLogic();
                var dto = SPermisoConverter.ToDto(model);
                return _permisoLogic.Actualizar(dto);
            }
            catch (Exception ex)
            {
                _logger.WriteErrorLog(ex);
                if (ex.InnerException != null)
                {
                    return ex.InnerException.HResult;
                }
                //throw ex;
                return 0;
            }
            finally
            {
                _logger = null;
            }
        }
        public int EliminarPermiso(PermisoModel model)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando EliminarPermiso");
                _permisoLogic = new BLogic();
                var dto = SPermisoConverter.ToDto(model);
                return _permisoLogic.Insertar(dto);
            }
            catch (Exception ex)
            {
                _logger.WriteErrorLog(ex);
                //throw ex;
                return 0;
            }
            finally
            {
                _logger = null;
            }
        }
        public int InsertarPermiso(PermisoModel model)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando InsertarPermiso");
                _permisoLogic = new BLogic();
                var dto = SPermisoConverter.ToDto(model);
                return _permisoLogic.Insertar(dto);
            }
            catch (Exception ex)
            {
                _logger.WriteErrorLog(ex);
                if (ex.InnerException != null)
                {
                    return ex.InnerException.HResult;
                }
                //throw ex;
                return 0;
            }
            finally
            {
                _logger = null;
            }
        }
        public List<PermisoModel> ListarPermisos(PermisoModel model)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando ListarPermisos");
                _permisoLogic = new BLogic();
                var dto = SPermisoConverter.ToDto(model);
                var resp = SPermisoConverter.ToModels(_permisoLogic.Listar(dto));
                return resp;
            }
            catch (Exception ex)
            {
                _logger.WriteErrorLog(ex);
                //throw ex;
                return null;
            }
            finally
            {
                _logger = null;
            }
        }
        #endregion

        #region Acreditacion
        public List<VistaPermisoResponse> AcreditacionUPS(VistaPermisoRequest request)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando AcreditacionUP");
                _vistaPermisoQuery = new BLogic();
                var dto = SVistaPermisoConverter.ToDto(request);
                var resp = SVistaPermisoConverter.ToModels(_vistaPermisoQuery.Listar(dto));
                return resp;
            }
            catch (Exception ex)
            {
                _logger.WriteErrorLog(ex);
                //throw ex;
                return null;
            }
            finally
            {
                _logger = null;
            }
        }
        #endregion
    }
}