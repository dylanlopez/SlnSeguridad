using Domain_Layer.Dtos.Sistemas;
using Service_Layer.Models.Sistemas;
using System.Collections.Generic;

namespace Service_Layer.Converters.Sistemas
{
    public class SMenuOpcionConverter
    {
        internal static MenuOpcionModel ToModel(DMenuOpcionDto dto)
        {
            var model = new MenuOpcionModel();
            model.Id = dto.Id;
            model.Estado = dto.Estado;
            model.Visible = dto.Visible;
            model.Menu = SMenuConverter.ToModel(dto.Menu);
            model.Opcion = SOpcionConverter.ToModel(dto.Opcion);
            return model;
        }

        internal static List<MenuOpcionModel> ToModels(IList<DMenuOpcionDto> dtos)
        {
            var models = new List<MenuOpcionModel>();
            foreach (var dto in dtos)
            {
                var model = ToModel(dto);
                models.Add(model);
            }
            return models;
        }

        internal static DMenuOpcionDto ToDto(MenuOpcionModel model)
        {
            var dto = new DMenuOpcionDto();
            dto.Id = model.Id;
            dto.Estado = model.Estado;
            dto.Visible = model.Visible;
            dto.Menu = SMenuConverter.ToDto(model.Menu);
            if(model.Opcion != null)
            {
                dto.Opcion = SOpcionConverter.ToDto(model.Opcion);
            }
            return dto;
        }
    }
}