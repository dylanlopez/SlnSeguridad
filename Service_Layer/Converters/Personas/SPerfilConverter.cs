using Domain_Layer.Dtos.Personas;
using Service_Layer.Models.Personas;
using System.Collections.Generic;

namespace Service_Layer.Converters.Personas
{
    internal static class SPerfilConverter
    {
        internal static PerfilModel ToModel(DPerfilDto dto)
        {
            var model = new PerfilModel();
            model.Id = dto.Id;
            model.Nombre = dto.Nombre;
            model.Descripcion = dto.Descripcion;
            return model;
        }

        internal static List<PerfilModel> ToModels(IList<DPerfilDto> dtos)
        {
            var models = new List<PerfilModel>();
            foreach (var dto in dtos)
            {
                var model = ToModel(dto);
                models.Add(model);
            }
            return models;
        }

        internal static DPerfilDto ToDto(PerfilModel model)
        {
            var dto = new DPerfilDto();
            dto.Id = model.Id;
            dto.Nombre = model.Nombre.ToUpper();
            if (!string.IsNullOrEmpty(model.Descripcion))
            {
                dto.Descripcion = model.Descripcion.ToUpper();
            }
            return dto;
        }
    }
}