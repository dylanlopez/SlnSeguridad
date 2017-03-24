using Domain_Layer.Dtos.Personas;
using Service_Layer.Models.Personas;
using System.Collections.Generic;

namespace Service_Layer.Converters.Personas
{
    internal static class SUsuarioRolConverter
    {
        internal static UsuarioRolModel ToModel(DUsuarioRolDto dto)
        {
            var model = new UsuarioRolModel();
            model.Id = dto.Id;
            model.Usuario = SUsuarioConverter.ToModel(dto.Usuario);
            model.Rol = SRolConverter.ToModel(dto.Rol);
            return model;
        }

        internal static List<UsuarioRolModel> ToModels(IList<DUsuarioRolDto> dtos)
        {
            var models = new List<UsuarioRolModel>();
            foreach (var dto in dtos)
            {
                var model = ToModel(dto);
                models.Add(model);
            }
            return models;
        }

        internal static DUsuarioRolDto ToDto(UsuarioRolModel model)
        {
            var dto = new DUsuarioRolDto();
            dto.Id = model.Id;
            dto.Usuario = SUsuarioConverter.ToDto(model.Usuario);
            dto.Rol = SRolConverter.ToDto(model.Rol);
            return dto;
        }
    }
}