using Domain_Layer.Dtos.Personas;
using Service_Layer.Models.Personas;
using System.Collections.Generic;

namespace Service_Layer.Converters.Personas
{
    internal static class SUsuarioConverter
    {
        internal static UsuarioModel ToModel(DUsuarioDto dto)
        {
            var model = new UsuarioModel();
            model.Id = dto.Id;
            model.Usuario = dto.Usuario;
            model.Contrasena = dto.Contrasena;
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
            var dto = new DUsuarioDto();
            dto.Id = model.Id;
            dto.Usuario = model.Usuario;
            dto.Contrasena = model.Contrasena;
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