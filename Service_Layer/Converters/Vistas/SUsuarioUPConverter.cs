using Business_Layer.Utils;
using Domain_Layer.Dtos.Personas;
using Service_Layer.Models.Vistas;
using System;

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
            string dia = DateTime.Now.Day.ToString();
            string mes = DateTime.Now.Month.ToString();
            string anho = DateTime.Now.Year.ToString();
            if (dia.Length < 2)
            {
                dia = "0" + dia;
            }
            if (mes.Length < 2)
            {
                mes = "0" + mes;
            }
            dto.FechaUltimoCambio = string.Format("{0}/{1}/{2}", dia, mes, anho);
            return dto;
        }

        internal static DUsuarioDto ToDto(string usuario)
        {
            var dto = new DUsuarioDto();
            dto.Usuario = usuario;
            //dto.HaIngresado = haIngresado;
            return dto;
        }
    }
}