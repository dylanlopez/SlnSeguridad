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

        private static VistaPermisoModel ToModelPermiso(DVistaPermisoDto dto, IList<DVistaPermisoDto> dtos, int index)
        {
            var modelPermiso = new VistaPermisoModel();
            modelPermiso.IdPerfil = dto.IdPerfil;
            modelPermiso.NombrePerfil = dto.NombrePerfil;
            modelPermiso.Usuario = dto.Usuario;
            modelPermiso.IdRol = dto.IdRol;
            modelPermiso.NombreRol = dto.NombreRol;
            modelPermiso.Sistemas = ToModelsSistemas(modelPermiso.IdPerfil, modelPermiso.Usuario, modelPermiso.IdRol, dtos, index);
            return modelPermiso;
        }
        private static VistaSistemaModel ToModelSistema(int idPerfil, string usuario, int idRol, DVistaPermisoDto dto, 
                                                        IList<DVistaPermisoDto> dtos, int index)
        {
            var modelSistema = new VistaSistemaModel();
            modelSistema.IdSistema = dto.IdSistema;
            modelSistema.CodigoSistema = dto.CodigoSistema;
            modelSistema.AbreviaturaSistema = dto.AbreviaturaSistema;
            modelSistema.NombreSistema = dto.NombreSistema;
            modelSistema.RutaLogica = dto.RutaLogica;
            modelSistema.Modulos = ToModelsModulos(idPerfil, usuario, idRol, modelSistema.IdSistema, dtos, index);
            return modelSistema;
        }
        private static VistaModuloModel ToModelModulo(int idPerfil, string usuario, int idRol, int idSistema, 
                                                       DVistaPermisoDto dto, IList<DVistaPermisoDto> dtos, int index)
        {
            var modelModulo = new VistaModuloModel();
            modelModulo.IdModulo = dto.IdModulo;
            modelModulo.CodigoModulo = dto.CodigoModulo;
            modelModulo.NombreModulo = dto.NombreModulo;
            modelModulo.Menus = ToModelsMenus(idPerfil, usuario, idRol, idSistema, modelModulo.IdModulo, dtos, index);
            return modelModulo;
        }
        public static VistaMenuModel ToModelMenu(int idPerfil, string usuario, int idRol, int idSistema,
                                                 int idModulo, DVistaPermisoDto dto, IList<DVistaPermisoDto> dtos, int index)
        {
            var modelMenu = new VistaMenuModel();
            modelMenu.IdMenu = dto.IdMenu;
            modelMenu.Codigomenu = dto.CodigoMenu;
            modelMenu.NombreMenu = dto.NombreMenu;
            modelMenu.MenuRuta = dto.MenuRuta;
            modelMenu.Opciones = ToModelsOpciones(idPerfil, usuario, idRol, idSistema, idModulo, modelMenu.IdMenu, dtos, index);
            return modelMenu;
        }
        public static VistaOpcionModel ToModelOpcion(DVistaPermisoDto dto)
        {
            var modelOpcion = new VistaOpcionModel();
            modelOpcion.IdOpcion = dto.IdOpcion;
            modelOpcion.NombreOpcion = dto.NombreOpcion;
            modelOpcion.ControlAsociado = dto.ControlAsociado;
            modelOpcion.Visible = dto.Visible;
            return modelOpcion;
        }

        private static List<VistaOpcionModel> ToModelsOpciones(int idPerfil, string usuario, int idRol, int idSistema,
                                                               int idModulo, int idMenu, IList<DVistaPermisoDto> dtos, 
                                                               int index)
        {
            bool find = false;
            List<VistaOpcionModel> modelsOpciones = null;
            for (int o = index; o < dtos.Count; o++)
            //foreach (var dto in dtos)
            {
                DVistaPermisoDto dto = dtos[o];
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
                            dto.IdOpcion == model.IdOpcion)
                        {
                            //dtos.Remove(dto);
                            //modelsOpciones.Add(ToModelOpcion(dto));
                            find = true;
                        }
                    }
                    if (dto.IdPerfil == idPerfil &&
                        dto.Usuario.Equals(usuario) &&
                        dto.IdRol == idRol &&
                        dto.IdSistema == idSistema &&
                        dto.IdModulo == idModulo &&
                        dto.IdMenu == idMenu)
                    {
                        if (!find)
                        {
                            modelsOpciones.Add(ToModelOpcion(dto));
                        }
                    }
                    //if (!find)
                    //{
                    //    modelsOpciones.Add(ToModelOpcion(dto));
                    //}
                }
                find = false;
            }
            return modelsOpciones;
        }
        private static List<VistaMenuModel> ToModelsMenus(int idPerfil, string usuario, int idRol, int idSistema, 
                                                          int idModulo, IList<DVistaPermisoDto> dtos, int index)
        {
            bool find = false;
            List<VistaMenuModel> modelsMenus = null;
            for (int o = index; o < dtos.Count; o++)
            //foreach (var dto in dtos)
            {
                DVistaPermisoDto dto = dtos[o];
                //find = true;
                if (modelsMenus == null)
                {
                    if (dto.IdPerfil == idPerfil &&
                        dto.Usuario.Equals(usuario) &&
                        dto.IdRol == idRol &&
                        dto.IdSistema == idSistema &&
                        dto.IdModulo == idModulo)
                    {
                        modelsMenus = new List<VistaMenuModel>();
                        modelsMenus.Add(ToModelMenu(idPerfil, usuario, idRol, idSistema, idModulo, dto, dtos, o));
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
                            dto.IdMenu == model.IdMenu)
                        {
                            //modelsMenus.Add(ToModelMenu(idPerfil, usuario, idRol, idSistema, idModulo, dto, dtos, o));
                            find = true;
                        }
                    }
                    if (dto.IdPerfil == idPerfil &&
                            dto.Usuario.Equals(usuario) &&
                            dto.IdRol == idRol &&
                            dto.IdSistema == idSistema &&
                            dto.IdModulo == idModulo)
                    {
                        if (!find)
                        {
                            modelsMenus.Add(ToModelMenu(idPerfil, usuario, idRol, idSistema, idModulo, dto, dtos, o));
                        }
                    }
                }
                find = false;
            }
            return modelsMenus;
        }
        private static List<VistaModuloModel> ToModelsModulos(int idPerfil, string usuario, int idRol, int idSistema, 
                                                            IList<DVistaPermisoDto> dtos, int index)
        {
            //bool find;
            bool find = false;
            List<VistaModuloModel> modelsModulos = null;
            for (int o = index; o < dtos.Count; o++)
            //foreach (var dto in dtos)
            {
                DVistaPermisoDto dto = dtos[o];
                //find = false;
                if (modelsModulos == null)
                {
                    if (dto.IdPerfil == idPerfil &&
                        dto.Usuario.Equals(usuario) &&
                        dto.IdRol == idRol && 
                        dto.IdSistema == idSistema)
                    {
                        modelsModulos = new List<VistaModuloModel>();
                        modelsModulos.Add(ToModelModulo(idPerfil, usuario, idRol, idSistema,  dto, dtos, o));
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
                            dto.IdModulo == model.IdModulo)
                        {
                            find = true;
                            //modelsModulos.Add(ToModelModulo(idPerfil, usuario, idRol, idSistema, dto, dtos, o));
                        }
                    }
                    if (dto.IdPerfil == idPerfil &&
                             dto.Usuario.Equals(usuario) &&
                             dto.IdRol == idRol &&
                             dto.IdSistema == idSistema)
                    {
                        if (!find)
                        {
                            modelsModulos.Add(ToModelModulo(idPerfil, usuario, idRol, idSistema, dto, dtos, o));
                        }
                    }
                }
                find = false;
            }
            return modelsModulos;
        }
        private static List<VistaSistemaModel> ToModelsSistemas(int idPerfil, string usuario, int idRol, IList<DVistaPermisoDto> dtos, int index)
        {
            //bool find;
            bool find = false;
            List<VistaSistemaModel> modelsSistemas = null;
            for (int o = index; o < dtos.Count; o++)
            //foreach (var dto in dtos)
            {
                DVistaPermisoDto dto = dtos[o];
                //find = false;
                if (modelsSistemas == null)
                {
                    if (dto.IdPerfil == idPerfil &&
                        dto.Usuario.Equals(usuario) &&
                        dto.IdRol == idRol)
                    {
                        modelsSistemas = new List<VistaSistemaModel>();
                        modelsSistemas.Add(ToModelSistema(idPerfil, usuario, idRol, dto, dtos, o));
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
                            dto.IdSistema == model.IdSistema)
                        {
                            find = true;
                            //modelsSistemas.Add(ToModelSistema(idPerfil, usuario, idRol, dto, dtos, o));
                        }
                    }
                    if (dto.IdPerfil == idPerfil &&
                            dto.Usuario.Equals(usuario) &&
                            dto.IdRol == idRol)
                    {
                        if (!find)
                        {
                            modelsSistemas.Add(ToModelSistema(idPerfil, usuario, idRol, dto, dtos, o));
                        }
                    }
                }
                find = false;
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
            //bool find = false;
            modelsPermisos = new List<VistaPermisoModel>();
            List<DVistaPermisoDto> dtos2 = (List<DVistaPermisoDto>) dtos;
            //foreach (var dto in dtos)
            for (int o = 0; o < dtos2.Count; o++)
            {
                DVistaPermisoDto dto = dtos2[o];
                find = false;
                if (modelsPermisos == null)
                {
                    modelsPermisos = new List<VistaPermisoModel>();
                    //modelsPermisos.Add(ToModelPermiso(dto, dtos));
                    //modelsPermisos.Add(ToModelPermiso(dto, dtos2));
                    modelsPermisos.Add(ToModelPermiso(dto, dtos, o));
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
                        //modelsPermisos.Add(ToModelPermiso(dto, dtos));
                        //modelsPermisos.Add(ToModelPermiso(dto, dtos2));
                        modelsPermisos.Add(ToModelPermiso(dto, dtos, o));
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