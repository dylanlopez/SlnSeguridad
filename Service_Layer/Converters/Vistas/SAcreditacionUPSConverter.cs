using Business_Layer.Utils;
using Domain_Layer.Dtos.Vistas;
using Service_Layer.Models.Vistas;
using System.Collections.Generic;
using System.Linq;

namespace Service_Layer.Converters.Vistas
{
    internal static class SAcreditacionUPSConverter
    {
        private static BEncrypt _encrypt;
        private static List<VistaPermisoModel> modelsPermisos = null;
        //private static List<VistaSistemaModel> modelsSistemas = null;
        //private static List<VistaModuloModel> modelsModulos = null;
        //private static List<VistaMenuModel> modelsMenus = null;
        //private static List<VistaOpcionModel> modelsOpciones = null;
        
        //private static BDecrypt _decrypt;

        //internal static VistaPermisoModel ToModel(DVistaPermisoDto dto)
        //{
        //    var result = new VistaPermisoModel();
        //    _decrypt = new BDecrypt();
        //    result.NombrePerfil = dto.NombrePerfil;
        //    result.Usuario = dto.Usuario;
        //    if (!string.IsNullOrEmpty(dto.Contrasena))
        //    {
        //        _decrypt.TextToDecrypt = dto.Contrasena;
        //        _decrypt.Decrypt256();
        //        result.Contrasena = _decrypt.TextDecrypted;
        //    }
        //    //response.Contrasena = dto.Contrasena;
        //    result.ApellidoPaterno = dto.ApellidoPaterno;
        //    result.ApellidoMaterno = dto.ApellidoMaterno;
        //    result.Nombres = dto.Nombres;
        //    result.Ubigeo = dto.Ubigeo;
        //    result.CodigoVersion = dto.CodigoVersion;
        //    result.Email = dto.Email;
        //    result.NombreRol = dto.NombreRol;
        //    result.CodigoSistema = dto.CodigoSistema;
        //    result.NombreSistema = dto.NombreSistema;
        //    result.RutaLogica = dto.RutaLogica;
        //    result.NombreModulo = dto.NombreModulo;
        //    result.NombreMenu = dto.NombreMenu;
        //    result.MenuRuta = dto.MenuRuta;
        //    result.NombreOpcion = dto.NombreOpcion;
        //    result.ControlAsociado = dto.ControlAsociado;
        //    result.Visible = dto.Visible;
        //    result.PrimeraVez = dto.PrimeraVez;
        //    return result;
        //}

        private static VistaPermisoModel ToModelPermiso(DVistaPermisoDto dto, IList<DVistaPermisoDto> dtos)
        {
            var modelPermiso = new VistaPermisoModel();
            modelPermiso.IdPerfil = dto.IdPerfil;
            modelPermiso.NombrePerfil = dto.NombrePerfil;
            modelPermiso.Usuario = dto.Usuario;
            modelPermiso.IdRol = dto.IdRol;
            modelPermiso.NombreRol = dto.NombreRol;
            modelPermiso.Sistemas = ToModelsSistemas(modelPermiso.IdPerfil, modelPermiso.Usuario, modelPermiso.IdRol, dtos);
            return modelPermiso;
        }
        private static VistaSistemaModel ToModelSistema(int idPerfil, string usuario, int idRol, DVistaPermisoDto dto, 
                                                        IList<DVistaPermisoDto> dtos)
        {
            var modelSistema = new VistaSistemaModel();
            modelSistema.IdSistema = dto.IdSistema;
            modelSistema.CodigoSistema = dto.CodigoSistema;
            modelSistema.NombreSistema = dto.NombreSistema;
            modelSistema.RutaLogica = dto.RutaLogica;
            modelSistema.Modulos = ToModelsModulos(idPerfil, usuario, idRol, modelSistema.IdSistema, dtos);
            return modelSistema;
        }
        private static VistaModuloModel ToModelModulo(int idPerfil, string usuario, int idRol, int idSistema, 
                                                       DVistaPermisoDto dto, IList<DVistaPermisoDto> dtos)
        {
            var modelModulo = new VistaModuloModel();
            modelModulo.IdModulo = dto.IdModulo;
            modelModulo.CodigoModulo = dto.CodigoModulo;
            modelModulo.NombreModulo = dto.NombreModulo;
            modelModulo.Menus = ToModelsMenus(idPerfil, usuario, idRol, idSistema, modelModulo.IdModulo, dtos);
            return modelModulo;
        }
        public static VistaMenuModel ToModelMenu(int idPerfil, string usuario, int idRol, int idSistema,
                                                 int idModulo, DVistaPermisoDto dto, IList<DVistaPermisoDto> dtos)
        {
            var modelMenu = new VistaMenuModel();
            modelMenu.IdMenu = dto.IdMenu;
            modelMenu.Codigomenu = dto.CodigoMenu;
            modelMenu.NombreMenu = dto.NombreMenu;
            modelMenu.MenuRuta = dto.MenuRuta;
            modelMenu.Opciones = ToModelsOpciones(idPerfil, usuario, idRol, idSistema, idModulo, modelMenu.IdMenu, dtos);
            return modelMenu;
        }
        public static VistaOpcionModel ToModelOpcion(DVistaPermisoDto dto)
        {
            var modelOpcion = new VistaOpcionModel();
            modelOpcion.NombreOpcion = dto.NombreOpcion;
            modelOpcion.ControlAsociado = dto.ControlAsociado;
            modelOpcion.Visible = dto.Visible;
            return modelOpcion;
        }

        private static List<VistaOpcionModel> ToModelsOpciones(int idPerfil, string usuario, int idRol, int idSistema,
                                                               int idModulo, int idMenu, IList<DVistaPermisoDto> dtos)
        {
            List<VistaOpcionModel> modelsOpciones = null;
            foreach (var dto in dtos)
            {
                if (modelsOpciones == null)
                {
                    if (dto.IdPerfil == idPerfil &&
                        dto.Usuario.Equals(usuario) &&
                        dto.IdRol == idRol &&
                        dto.IdSistema == idSistema &&
                        dto.IdModulo == idModulo &&
                        dto.IdMenu == idMenu)
                    {
                        modelsOpciones = new List<VistaOpcionModel>();
                        modelsOpciones.Add(ToModelOpcion(dto));
                    }
                }
                else
                {
                    for (int i = 0; i < modelsOpciones.Count; i++)
                    {
                        VistaOpcionModel model = modelsOpciones[i];
                        if (dto.IdPerfil == idPerfil &&
                            dto.Usuario.Equals(usuario) &&
                            dto.IdRol == idRol &&
                            dto.IdSistema == idSistema &&
                            dto.IdModulo == idModulo &&
                            dto.IdMenu == idMenu &&
                            dto.IdOpcion != model.IdOpcion)
                        {
                            modelsOpciones.Add(ToModelOpcion(dto));
                        }
                    }
                }
            }
            return modelsOpciones;
        }
        private static List<VistaMenuModel> ToModelsMenus(int idPerfil, string usuario, int idRol, int idSistema, 
                                                          int idModulo, IList<DVistaPermisoDto> dtos)
        {
            List<VistaMenuModel> modelsMenus = null;
            foreach (var dto in dtos)
            {
                if (modelsMenus == null)
                {
                    if (dto.IdPerfil == idPerfil &&
                        dto.Usuario.Equals(usuario) &&
                        dto.IdRol == idRol &&
                        dto.IdSistema == idSistema &&
                        dto.IdModulo == idModulo)
                    {
                        modelsMenus = new List<VistaMenuModel>();
                        modelsMenus.Add(ToModelMenu(idPerfil, usuario, idRol, idSistema, idModulo, dto, dtos));
                    }
                }
                else
                {
                    for (int i = 0; i < modelsMenus.Count; i++)
                    {
                        VistaMenuModel model = modelsMenus[i];
                        if (dto.IdPerfil == idPerfil &&
                            dto.Usuario.Equals(usuario) &&
                            dto.IdRol == idRol &&
                            dto.IdSistema == idSistema &&
                            dto.IdModulo == idModulo &&
                            dto.IdMenu != model.IdMenu)
                        {
                            modelsMenus.Add(ToModelMenu(idPerfil, usuario, idRol, idSistema, idModulo, dto, dtos));
                        }
                    }
                }
            }
            return modelsMenus;
        }
        private static List<VistaModuloModel> ToModelsModulos(int idPerfil, string usuario, int idRol, int idSistema, 
                                                            IList<DVistaPermisoDto> dtos)
        {
            List<VistaModuloModel> modelsModulos = null;
            foreach (var dto in dtos)
            {
                if (modelsModulos == null)
                {
                    if (dto.IdPerfil == idPerfil &&
                        dto.Usuario.Equals(usuario) &&
                        dto.IdRol == idRol && 
                        dto.IdSistema == idSistema)
                    {
                        modelsModulos = new List<VistaModuloModel>();
                        modelsModulos.Add(ToModelModulo(idPerfil, usuario, idRol, idSistema,  dto, dtos));
                    }
                }
                else
                {
                    for (int i = 0; i < modelsModulos.Count; i++)
                    {
                        VistaModuloModel model = modelsModulos[i];
                        if (dto.IdPerfil == idPerfil &&
                            dto.Usuario.Equals(usuario) &&
                            dto.IdRol == idRol &&
                            dto.IdSistema == idSistema &&
                            dto.IdModulo != model.IdModulo)
                        {
                            modelsModulos.Add(ToModelModulo(idPerfil, usuario, idRol, idSistema, dto, dtos));
                        }
                    }
                }
            }
            return modelsModulos;
        }
        private static List<VistaSistemaModel> ToModelsSistemas(int idPerfil, string usuario, int idRol, IList<DVistaPermisoDto> dtos)
        {
            List<VistaSistemaModel> modelsSistemas = null;
            foreach (var dto in dtos)
            {
                if (modelsSistemas == null)
                {
                    if (dto.IdPerfil == idPerfil &&
                        dto.Usuario.Equals(usuario) &&
                        dto.IdRol == idRol)
                    {
                        modelsSistemas = new List<VistaSistemaModel>();
                        modelsSistemas.Add(ToModelSistema(idPerfil, usuario, idRol, dto, dtos));
                    }
                }
                else
                {
                    for (int i = 0; i < modelsSistemas.Count; i++)
                    {
                        VistaSistemaModel model = modelsSistemas[i];
                        if (dto.IdPerfil == idPerfil &&
                            dto.Usuario.Equals(usuario) &&
                            dto.IdRol == idRol &&
                            dto.IdSistema != model.IdSistema)
                        {
                            modelsSistemas.Add(ToModelSistema(idPerfil, usuario, idRol, dto, dtos));
                        }
                    }
                }
            }
            return modelsSistemas;
        }
        //internal static AcreditacionUPSResponse ToModels(IList<DVistaPermisoDto> dtos)
        internal static List<VistaPermisoModel> ToModels(IList<DVistaPermisoDto> dtos)
        {
            //var models = new List<VistaPermisoModel>();
            //foreach (var dto in dtos)
            //{
            //    var model = ToModel(dto);
            //    models.Add(model);
            //}
            //var models = new List<VistaPermisoModel>();
            //var modelsOpciones = new List<VistaOpcionModel>();
            bool find;
            foreach (var dto in dtos)
            {
                find = false;
                if (modelsPermisos == null)
                {
                    modelsPermisos = new List<VistaPermisoModel>();
                    modelsPermisos.Add(ToModelPermiso(dto, dtos));
                }
                else
                {
                    for (int i = 0; i < modelsPermisos.Count; i++)
                    {
                        VistaPermisoModel model = modelsPermisos[i];
                        if (dto.IdPerfil == model.IdPerfil && 
                            dto.Usuario.Equals(model.Usuario) && 
                            dto.IdRol == model.IdRol)
                        {
                            find = true;
                        }
                    }
                    if (!find)
                    {
                        modelsPermisos.Add(ToModelPermiso(dto, dtos));
                    }
                }
            }
            return modelsPermisos;
        }

        internal static DVistaPermisoDto ToDto(AcreditacionUPSRequest request)
        {
            _encrypt = new BEncrypt();
            var dto = new DVistaPermisoDto();
            dto.Usuario = request.Usuario;
            if (!string.IsNullOrEmpty(request.Contrasena))
            {
                _encrypt.TextToEncrypt = request.Contrasena;
                _encrypt.Encrypt256();
                dto.Contrasena = _encrypt.TextEncrypted;
            }
            //dto.Contrasena = request.Contrasena;
            dto.CodigoSistema = request.CodigoSistema;
            return dto;
        }
    }
}