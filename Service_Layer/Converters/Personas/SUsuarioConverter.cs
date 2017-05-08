using Business_Layer.Utils;
using Domain_Layer.Dtos.Personas;
using Service_Layer.Models.Personas;
using System.Collections.Generic;

namespace Service_Layer.Converters.Personas
{
    internal static class SUsuarioConverter
    {
        private static BEncrypt _encrypt;
        private static BDecrypt _decrypt;

        internal static UsuarioModel ToModel(DUsuarioDto dto)
        {
            _decrypt = new BDecrypt();
            var model = new UsuarioModel();
            model.Id = dto.Id;
            model.Usuario = dto.Usuario;
            if (!string.IsNullOrEmpty(dto.Contrasena))
            {
                _decrypt.TextToDecrypt = dto.Contrasena;
                _decrypt.Decrypt256();
                model.Contrasena = _decrypt.TextDecrypted;
            }
            model.ApellidoPaterno = dto.ApellidoPaterno;
            model.ApellidoMaterno = dto.ApellidoMaterno;
            model.Nombres = dto.Nombres;
            model.Caduca = dto.Caduca;
            model.PeriodoCaducidad = dto.PeriodoCaducidad;
            model.FechaUltimoCambio = dto.FechaUltimoCambio;
            model.Ubigeo = dto.Ubigeo;
            model.CodigoVersion = dto.CodigoVersion;
            model.UnicoIngreso = dto.UnicoIngreso;
            model.HaIngresado = dto.HaIngresado;
            model.OtrosLogeos = dto.OtrosLogeos;
            model.Tipo = dto.Tipo;
            model.Activo = dto.Activo;
            model.Email = dto.Email;
            return model;
        }

        internal static List<UsuarioModel> ToModels(IList<DUsuarioDto> dtos)
        {
            var models = new List<UsuarioModel>();
            foreach (var dto in dtos)
            {
                var model = ToModel(dto);
                models.Add(model);
            }
            return models;
        }

        internal static DUsuarioDto ToDto(UsuarioModel model)
        {
            _encrypt = new BEncrypt();
            var dto = new DUsuarioDto();
            dto.Id = model.Id;
            dto.Usuario = model.Usuario;
            if (!string.IsNullOrEmpty(model.Contrasena))
            {
                _encrypt.TextToEncrypt = model.Contrasena;
                _encrypt.Encrypt256();
                dto.Contrasena = _encrypt.TextEncrypted;
            }
            dto.ApellidoPaterno = model.ApellidoPaterno;
            dto.ApellidoMaterno = model.ApellidoMaterno;
            dto.Nombres = model.Nombres;
            dto.Caduca = model.Caduca;
            dto.PeriodoCaducidad = model.PeriodoCaducidad;
            dto.FechaUltimoCambio = model.FechaUltimoCambio;
            dto.Ubigeo = model.Ubigeo;
            dto.CodigoVersion = model.CodigoVersion;
            dto.UnicoIngreso = model.UnicoIngreso;
            dto.HaIngresado = model.HaIngresado;
            dto.OtrosLogeos = model.OtrosLogeos;
            dto.Tipo = model.Tipo;
            dto.Activo = model.Activo;
            dto.Email = model.Email;
            return dto;
        }
    }
}