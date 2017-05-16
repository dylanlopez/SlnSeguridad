using Business_Layer.Utils;
using Domain_Layer.Dtos.Vistas;
using Service_Layer.Models.Vistas;
using System.Collections.Generic;

namespace Service_Layer.Converters.Vistas
{
    internal static class SAcreditacionUPSConverter
    {
        private static BEncrypt _encrypt;
        private static BDecrypt _decrypt;

        internal static VistaPermisoModel ToModel(DVistaPermisoDto dto)
        {
            var result = new VistaPermisoModel();
            _decrypt = new BDecrypt();
            result.NombrePerfil = dto.NombrePerfil;
            result.Usuario = dto.Usuario;
            if (!string.IsNullOrEmpty(dto.Contrasena))
            {
                _decrypt.TextToDecrypt = dto.Contrasena;
                _decrypt.Decrypt256();
                result.Contrasena = _decrypt.TextDecrypted;
            }
            //response.Contrasena = dto.Contrasena;
            result.ApellidoPaterno = dto.ApellidoPaterno;
            result.ApellidoMaterno = dto.ApellidoMaterno;
            result.Nombres = dto.Nombres;
            result.Ubigeo = dto.Ubigeo;
            result.CodigoVersion = dto.CodigoVersion;
            result.Email = dto.Email;
            result.NombreRol = dto.NombreRol;
            result.CodigoSistema = dto.CodigoSistema;
            result.NombreSistema = dto.NombreSistema;
            result.RutaLogica = dto.RutaLogica;
            result.NombreModulo = dto.NombreModulo;
            result.NombreMenu = dto.NombreMenu;
            result.MenuRuta = dto.MenuRuta;
            result.NombreOpcion = dto.NombreOpcion;
            result.ControlAsociado = dto.ControlAsociado;
            result.Visible = dto.Visible;
            return result;
        }

        //internal static AcreditacionUPSResponse ToModels(IList<DVistaPermisoDto> dtos)
        internal static List<VistaPermisoModel> ToModels(IList<DVistaPermisoDto> dtos)
        {
            var models = new List<VistaPermisoModel>();
            foreach (var dto in dtos)
            {
                var model = ToModel(dto);
                models.Add(model);
            }
            return models;
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