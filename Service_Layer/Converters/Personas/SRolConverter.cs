using Domain_Layer.Dtos.Personas;
using Service_Layer.Models.Personas;
using System.Collections.Generic;

namespace Service_Layer.Converters.Personas
{
    internal static class SRolConverter
    {
        internal static RolModel ToModel(DRolDto dto)
        {
            var model = new RolModel();
            model.Id = dto.Id;
            model.Nombre = dto.Nombre;
            model.Descripcion = dto.Descripcion;
            model.Estado = dto.Estado;
            return model;
        }

        internal static List<RolModel> ToModels(IList<DRolDto> dtos)
        {
            var models = new List<RolModel>();
            foreach (var dto in dtos)
            {
                var model = ToModel(dto);
                models.Add(model);
            }
            return models;
        }

        internal static DRolDto ToDto(RolModel model)
        {
            var dto = new DRolDto();
            dto.Id = model.Id;
            dto.Nombre = model.Nombre.ToUpper();
            if (!string.IsNullOrEmpty(model.Descripcion))
            {
                dto.Descripcion = model.Descripcion.ToUpper();
            }
            dto.Estado = model.Estado;
            return dto;
        }
    }
}