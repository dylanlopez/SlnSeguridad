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
        private IBTipoInstitucionLogic _tipoInstitucionLogic;
        private IBInstitucionLogic _institucionLogic;
        private IBUsuarioLogic _usuarioLogic;
        private IBPerfilLogic _perfilLogic;
        private IBSistemaPerfilLogic _sistemaPerfilLogic;
        private IBRolLogic _rolLogic;
        private IBPerfilUsuarioRolLogic _perfilUsuarioRolLogic;
        private IBPermisoLogic _permisoLogic;
        private IBVistaPermisoQuery _vistaPermisoLogic;
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

        #region TipoInstitucion
        public int ActualizarTipoInstitucion(TipoInstitucionModel model)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando ActualizarTipoInstitucion");
                _tipoInstitucionLogic = new BLogic();
                var dto = STipoInstitucionConverter.ToDto(model);
                return _tipoInstitucionLogic.Actualizar(dto);
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
        public TipoInstitucionModel BuscarTipoInstitucion(TipoInstitucionModel model)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando BuscarTipoInstitucion");
                _tipoInstitucionLogic = new BLogic();
                var dto = STipoInstitucionConverter.ToDto(model);
                var resp = STipoInstitucionConverter.ToModel(_tipoInstitucionLogic.Buscar(dto));
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
        public int InsertarTipoInstitucion(TipoInstitucionModel model)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando InsertarTipoInstitucion");
                _tipoInstitucionLogic = new BLogic();
                var dto = STipoInstitucionConverter.ToDto(model);
                return _tipoInstitucionLogic.Insertar(dto);
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
        public List<TipoInstitucionModel> ListarTipoInstituciones(TipoInstitucionModel model)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando ListarTiposInstitucion");
                _tipoInstitucionLogic = new BLogic();
                var dto = STipoInstitucionConverter.ToDto(model);
                var resp = STipoInstitucionConverter.ToModels(_tipoInstitucionLogic.Listar(dto));
                return resp;
            }
            catch (Exception ex)
            {
                _logger.WriteErrorLog(ex);
                return null;
            }
            finally
            {
                _logger = null;
            }
        }
        #endregion

        #region Institucion
        public int ActualizarInstitucion(InstitucionModel model)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando ActualizarInstitucion");
                _institucionLogic = new BLogic();
                var dto = SInstitucionConverter.ToDto(model);
                return _institucionLogic.Actualizar(dto);
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
        public InstitucionModel BuscarInstitucion(InstitucionModel model)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando BuscarInstitucion");
                _institucionLogic = new BLogic();
                var dto = SInstitucionConverter.ToDto(model);
                var resp = SInstitucionConverter.ToModel(_institucionLogic.Buscar(dto));
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
        public int InsertarInstitucion(InstitucionModel model)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando InsertarInstitucion");
                _institucionLogic = new BLogic();
                var dto = SInstitucionConverter.ToDto(model);
                return _institucionLogic.Insertar(dto);
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
        public List<InstitucionModel> ListarInstituciones(InstitucionModel model)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando ListarInstituciones");
                _institucionLogic = new BLogic();
                var dto = SInstitucionConverter.ToDto(model);
                var resp = SInstitucionConverter.ToModels(_institucionLogic.Listar(dto));
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
        public UsuarioUPResponse ActualizarContrasenaUsuarioUP(UsuarioUPRequest request)
        {
            UsuarioUPResponse response = new UsuarioUPResponse();
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando ActualizarContrasenaUsuarioUP");
                if (string.IsNullOrEmpty(request.Usuario))
                {
                    response.Codigo = "0101";
                    response.Descripcion = "No se puede ingresar un usuario en blanco";
                    return response;
                }
                if (request.Usuario.Length != 8)
                {
                    response.Codigo = "0102";
                    response.Descripcion = "El usuario es un DNI de 8 digitos";
                    return response;
                }
                if (string.IsNullOrEmpty(request.ContrasenaAnterior) || string.IsNullOrEmpty(request.ContrasenaNueva))
                {
                    response.Codigo = "0203";
                    response.Descripcion = "No se puede ingresar la contraseña anterior y nueva en blanco";
                    return response;
                }
                if (string.IsNullOrEmpty(request.ContrasenaAnterior))
                {
                    response.Codigo = "0201";
                    response.Descripcion = "No se puede ingresar la contraseña anterior en blanco";
                    return response;
                }
                if (string.IsNullOrEmpty(request.ContrasenaNueva))
                {
                    response.Codigo = "0202";
                    response.Descripcion = "No se puede ingresar la contraseña nueva en blanco";
                    return response;
                }
                if (request.ContrasenaNueva.Equals(request.ContrasenaAnterior))
                {
                    response.Codigo = "0204";
                    response.Descripcion = "La contraseña nueva es igual a la contraseña anterior";
                    return response;
                }
                _usuarioLogic = new BLogic();
                var dto = SUsuarioUPConverter.ToDto(request.Usuario, request.ContrasenaAnterior);
                //var resp = SUsuarioConverter.ToModel(_usuarioLogic.BuscarPorUsuario(dto));
                var user = _usuarioLogic.Buscar(dto);
                if (user != null)
                {
                    dto = SUsuarioUPConverter.ToDto(request.Usuario, request.ContrasenaNueva);
                    int resp = _usuarioLogic.ActualizarContrasena(dto);
                    //if(user.Caduca == 'S')
                    //{
                    //    var fechaUltimoCambio = Convert.ToDateTime(user.FechaUltimoCambio);
                    //    var fechaActual = DateTime.Now;
                    //    TimeSpan ts = fechaActual - fechaUltimoCambio;
                    //    int diferencia = ts.Days;
                    //    int periodoCaducidad = user.PeriodoCaducidad;
                    //    if(diferencia > periodoCaducidad)
                    //    {
                    //        response.Codigo = "0001";
                    //        response.Descripcion = string.Format("Actualizado correctamente. Su contraseña ya expiró hace {0} días", diferencia - periodoCaducidad);
                    //    }
                    //    else
                    //    {
                    //        var dif = periodoCaducidad - diferencia;
                    //        if(dif < 8)
                    //        {
                    //            response.Codigo = "0002";
                    //            response.Descripcion = string.Format("Actualizado correctamente. Su contraseña expirará dentro de {0} días", periodoCaducidad - diferencia);
                    //        }
                    //    }
                    //}
                }
                else
                {
                    response.Codigo = "0301";
                    //response.Descripcion = string.Format("No se puede cambiar el usuario y contraseña del usuario porque no se puede encontrar el usuario. Verifique el usuario({0}) y contraseña({1})", request.Usuario, request.ContrasenaAnterior);
                    response.Descripcion = string.Format("No se puede cambiar el usuario y contraseña del usuario porque no se puede encontrar el usuario. Verifique el usuario({0}) y contraseña", request.Usuario);
                }
                return response;
            }
            catch (Exception ex)
            {
                _logger.WriteErrorLog(ex);
                //throw ex;
                response.Codigo = "9998";
                response.Descripcion = "Error al comunicarse con la base de datos";
                return response; 
                //return null;
            }
            finally
            {
                _logger = null;
            }
        }
        public UsuarioUPResponse ActualizarHaIngresadoUsuarioU(UsuarioURequest request)
        {
            UsuarioUPResponse response = new UsuarioUPResponse();
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando ActualizarHaIngresadoUsuarioU");
                if (string.IsNullOrEmpty(request.Usuario))
                {
                    response.Codigo = "0101";
                    response.Descripcion = "No se puede ingresar un usuario en blanco";
                    return response;
                }
                if (request.Usuario.Length != 8)
                {
                    response.Codigo = "0102";
                    response.Descripcion = "El usuario es un DNI de 8 digitos";
                    return response;
                }
                //if (request.HaIngresado == '\0')
                //{
                //    response.Codigo = "0201";
                //    response.Descripcion = "No se puede ingresar el estado en blanco";
                //    return response;
                //}
                _usuarioLogic = new BLogic();
                var dto = SUsuarioUPConverter.ToDto(request.Usuario);
                var user = _usuarioLogic.BuscarPorUsuario(dto);
                if (user != null)
                {
                    if (user.UnicoIngreso == 'S')
                    {
                        int resp = _usuarioLogic.ActualizarEstado(user);
                    }
                }
                return response;
            }
            catch (Exception ex)
            {
                _logger.WriteErrorLog(ex);
                //throw ex;
                response.Codigo = "9998";
                response.Descripcion = "Error al comunicarse con la base de datos";
                return response;
                //return null;
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
        public AcreditacionUPSResponse AcreditacionUPS(AcreditacionUPSRequest request)
        {
            AcreditacionUPSResponse response = new AcreditacionUPSResponse();
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _logger.WriteInfoLog("iniciando AcreditacionUP");
                if (string.IsNullOrEmpty(request.Usuario))
                {
                    response.Codigo = "0101";
                    response.Descripcion = "No se puede ingresar un usuario en blanco";
                    response.PrimeraVez = 'X';
                    return response;
                }
                if (request.Usuario.Length != 8) //TEST
                {
                    response.Codigo = "0102";
                    response.Descripcion = "El usuario es un DNI de 8 digitos";
                    response.PrimeraVez = 'X';
                    return response;
                }
                if (string.IsNullOrEmpty(request.Contrasena))
                {
                    response.Codigo = "0201";
                    response.Descripcion = "No se puede ingresar una contraseña en blanco";
                    response.PrimeraVez = 'X';
                    return response;
                }
                string[] caracteres = { "<", ">", "'", "{", "}", "[", "]", "\"" };
                foreach (string caracter in caracteres)
                {
                    if (request.Contrasena.Contains(caracter))
                    {
                        response.Codigo = "0202";
                        response.Descripcion = string.Format("No se puede ingresar caracteres especiales en la contraseña. Ingreso {0}", caracter);
                        response.PrimeraVez = 'X';
                        return response;
                    }
                }
                if (string.IsNullOrEmpty(request.CodigoSistema))
                {
                    response.Codigo = "0301";
                    response.Descripcion = "No se puede ingresar un código de sistema en blanco";
                    response.PrimeraVez = 'X';
                    return response;
                }
                _usuarioLogic = new BLogic();
                var dtoUsuario = SUsuarioUPConverter.ToDto(request.Usuario);
                var user = _usuarioLogic.BuscarPorUsuario(dtoUsuario);
                if (user != null)
                {
                    dtoUsuario = SUsuarioUPConverter.ToDto(request.Usuario, request.Contrasena);
                    user = _usuarioLogic.Buscar(dtoUsuario);
                    if (user != null)
                    {
                        _vistaPermisoLogic = new BLogic();
                        var dto = SAcreditacionUPSConverter.ToDto(request);
                        var resp = _vistaPermisoLogic.Listar(dto);
                        if (resp != null)
                        {
                            if (resp.Count > 0)
                            {
                                response.Usuario = resp[0].Usuario;
                                //response.Contrasena = resp[0].Contrasena;
                                response.ApellidoPaterno = resp[0].ApellidoPaterno;
                                response.ApellidoMaterno = resp[0].ApellidoMaterno;
                                response.Nombres = resp[0].Nombres;
                                response.Ubigeo = resp[0].Ubigeo;
                                response.CodigoVersion = resp[0].CodigoVersion;
                                response.Email = resp[0].Email;
                                response.PrimeraVez = resp[0].PrimeraVez;
                                response.TipoInstitucion = resp[0].TipoInstitucion;
                                response.Institucion = resp[0].Institucion;
                                response.InstitucionCorto = resp[0].InstitucionCorto;
                                response.Result = SAcreditacionUPSConverter.ToModels(resp);
                                if (user.UnicoIngreso == 'S')
                                {
                                    var resp2 = _usuarioLogic.ActualizarEstado(user);
                                }
                                if (user.Caduca == 'S')
                                {
                                    var fechaUltimoCambio = Convert.ToDateTime(user.FechaUltimoCambio);
                                    var fechaActual = DateTime.Now;
                                    TimeSpan ts = fechaActual - fechaUltimoCambio;
                                    int diferencia = ts.Days;
                                    int periodoCaducidad = user.PeriodoCaducidad;
                                    if (diferencia > periodoCaducidad)
                                    {
                                        response.Codigo = "0001";
                                        response.Descripcion = string.Format("Ok. Su contraseña ya expiró hace {0} días", diferencia - periodoCaducidad);
                                    }
                                    else
                                    {
                                        var dif = periodoCaducidad - diferencia;
                                        if (dif < 8)
                                        {
                                            response.Codigo = "0002";
                                            response.Descripcion = string.Format("Ok. Su contraseña expirará dentro de {0} días", periodoCaducidad - diferencia);
                                        }
                                    }
                                }
                                //dtoUsuario = SUsuarioUPConverter.ToDto(request.Usuario, request.Contrasena);
                                //user = _usuarioLogic.Buscar(dtoUsuario);
                                //if (user != null)
                                //{
                                //    if (user.UnicoIngreso == 'S')
                                //    {
                                //        var resp2 = _usuarioLogic.ActualizarEstado(user);
                                //    }
                                //    if (user.Caduca == 'S')
                                //    {
                                //        var fechaUltimoCambio = Convert.ToDateTime(user.FechaUltimoCambio);
                                //        var fechaActual = DateTime.Now;
                                //        TimeSpan ts = fechaActual - fechaUltimoCambio;
                                //        int diferencia = ts.Days;
                                //        int periodoCaducidad = user.PeriodoCaducidad;
                                //        if (diferencia > periodoCaducidad)
                                //        {
                                //            response.Codigo = "0001";
                                //            response.Descripcion = string.Format("Ok. Su contraseña ya expiró hace {0} días", diferencia - periodoCaducidad);
                                //        }
                                //        else
                                //        {
                                //            var dif = periodoCaducidad - diferencia;
                                //            if (dif < 8)
                                //            {
                                //                response.Codigo = "0002";
                                //                response.Descripcion = string.Format("Ok. Su contraseña expirará dentro de {0} días", periodoCaducidad - diferencia);
                                //            }
                                //        }
                                //    }
                                //}
                            }
                            else
                            {
                                response.Codigo = "9997";
                                response.Descripcion = "No devuelve ningún registro";
                                response.PrimeraVez = 'X';
                                return response;
                            }
                        }
                        else
                        {
                            response.Codigo = "9997";
                            response.Descripcion = "No devuelve ningún registro";
                            response.PrimeraVez = 'X';
                            return response;
                        }
                    }
                    else
                    {
                        response.Codigo = "9996";
                        response.Descripcion = "La contraseña ingresada no está registrada en la base de datos";
                        response.PrimeraVez = 'X';
                        return response;
                    }
                }
                else
                {
                    response.Codigo = "9995";
                    response.Descripcion = "El Usuario ingresado no está registrado en la base de datos";
                    response.PrimeraVez = 'X';
                    return response;
                }
                //var resp = SAcreditacionUPSConverter.ToModels(_vistaPermisoQuery.Listar(dto));
                return response;
            }
            catch (Exception ex)
            {
                _logger.WriteErrorLog(ex);
                //throw ex;
                response.Codigo = "9998";
                response.Descripcion = "Error al comunicarse con la base de datos";
                response.PrimeraVez = 'X';
                return response;
                //return null;
            }
            finally
            {
                _logger = null;
            }
        }
        #endregion
    }
}