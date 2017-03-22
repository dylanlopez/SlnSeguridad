using Domain_Layer.Dtos.Personas;
using Service_Layer.Converters.Sistemas;
using Service_Layer.Models.Personas;
using System.Collections.Generic;

namespace Service_Layer.Converters.Personas
{
    internal static class SMenuRolConverter
    {
        internal static MenuRolModel ToModel(DMenuRolDto dto)
        {
            var model = new MenuRolModel();
            model.Id = dto.Id;
            model.Menu = SMenuConverter.ToModel(dto.Menu);
            model.Rol = SRolConverter.ToModel(dto.Rol);
            return model;
        }

        internal static List<MenuRolModel> ToModels(IList<DMenuRolDto> dtos)
        {
            var models = new List<MenuRolModel>();
            foreach (var dto in dtos)
            {
                var model = ToModel(dto);
                models.Add(model);
            }
            return models;
        }

        internal static DMenuRolDto ToDto(MenuRolModel model)
        {
            var dto = new DMenuRolDto();
            dto.Id = model.Id;
            dto.Menu = SMenuConverter.ToDto(model.Menu);
            dto.Rol = SRolConverter.ToDto(model.Rol);
            return dto;
        }
    }
}