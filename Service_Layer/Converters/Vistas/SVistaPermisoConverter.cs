using Business_Layer.Utils;
using Domain_Layer.Dtos.Vistas;
using Service_Layer.Models.Vistas;
using System.Collections.Generic;

namespace Service_Layer.Converters.Vistas
{
    internal static class SVistaPermisoConverter
    {
        private static BEncrypt _encrypt;
        private static BDecrypt _decrypt;

        internal static VistaPermisoResponse ToModel(DVistaPermisoDto dto)
        {
            _decrypt = new BDecrypt();
            var response = new VistaPermisoResponse();
            response.NombrePerfil = dto.NombrePerfil;
            response.Usuario = dto.Usuario;
            if (!string.IsNullOrEmpty(dto.Contrasena))
            {
                _decrypt.TextToDecrypt = dto.Contrasena;
                _decrypt.Decrypt256();
                response.Contrasena = _decrypt.TextDecrypted;
            }
            //response.Contrasena = dto.Contrasena;
            response.ApellidoPaterno = dto.ApellidoPaterno;
            response.ApellidoMaterno = dto.ApellidoMaterno;
            response.Nombres = dto.Nombres;
            response.Ubigeo = dto.Ubigeo;
            response.CodigoVersion = dto.CodigoVersion;
            response.Email = dto.Email;
            response.NombreRol = dto.NombreRol;
            response.CodigoSistema = dto.CodigoSistema;
            response.NombreSistema = dto.NombreSistema;
            response.NombreModulo = dto.NombreModulo;
            response.NombreMenu = dto.NombreMenu;
            response.NombreOpcion = dto.NombreOpcion;
            response.ControlAsociado = dto.ControlAsociado;
            response.Visible = dto.Visible;
            return response;
        }

        internal static List<VistaPermisoResponse> ToModels(IList<DVistaPermisoDto> dtos)
        {
            var responses = new List<VistaPermisoResponse>();
            foreach (var dto in dtos)
            {
                var response = ToModel(dto);
                responses.Add(response);
            }
            return responses;
        }

        internal static DVistaPermisoDto ToDto(VistaPermisoRequest request)
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