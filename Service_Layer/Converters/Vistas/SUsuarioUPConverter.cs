using Business_Layer.Utils;
using Domain_Layer.Dtos.Personas;
using Service_Layer.Models.Vistas;

namespace Service_Layer.Converters.Vistas
{
    internal static class SUsuarioUPConverter
    {
        private static BEncrypt _encrypt;

        internal static DUsuarioDto ToDto(string usuario, string contrasena)
        {
            _encrypt = new BEncrypt();
            var dto = new DUsuarioDto();
            dto.Usuario = usuario;
            if (!string.IsNullOrEmpty(contrasena))
            {
                _encrypt.TextToEncrypt = contrasena;
                _encrypt.Encrypt256();
                dto.Contrasena = _encrypt.TextEncrypted;
            }
            return dto;
        }
    }
}