using Domain_Layer.Dtos.Personas;
using Service_Layer.Models.Personas;
using System.Collections.Generic;

namespace Service_Layer.Converters.Personas
{
    internal static class SPerfilUsuarioRolConverter
    {
        internal static PerfilUsuarioRolModel ToModel(DPerfilUsuarioRolDto dto)
        {
            var model = new PerfilUsuarioRolModel();
            model.Id = dto.Id;
            model.Estado = dto.Estado;
            model.Perfil = SPerfilConverter.ToModel(dto.Perfil);
            model.Usuario = SUsuarioConverter.ToModel(dto.Usuario);
            model.Rol = SRolConverter.ToModel(dto.Rol);
            return model;
        }

        internal static List<PerfilUsuarioRolModel> ToModels(IList<DPerfilUsuarioRolDto> dtos)
        {
            var models = new List<PerfilUsuarioRolModel>();
            foreach (var dto in dtos)
            {
                var model = ToModel(dto);
                models.Add(model);
            }
            return models;
        }

        internal static DPerfilUsuarioRolDto ToDto(PerfilUsuarioRolModel model)
        {
            var dto = new DPerfilUsuarioRolDto();
            dto.Id = model.Id;
            dto.Estado = model.Estado;
            dto.Perfil = SPerfilConverter.ToDto(model.Perfil);
            dto.Usuario = SUsuarioConverter.ToDto(model.Usuario);
            dto.Rol = SRolConverter.ToDto(model.Rol);
            return dto;
        }
    }
}