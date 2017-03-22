using Domain_Layer.Dtos.Sistemas;
using Interface_Layer.Models.Sistemas;
using System.Collections.Generic;

namespace Service_Layer.Converters.Sistemas
{
    internal static class SSistemaConverter
    {
        internal static SistemaModel ToModel(DSistemaDto dto)
        {
            var model = new SistemaModel();
            model.Id = dto.Id;
            model.Codigo = dto.Codigo;
            model.Nombre = dto.Nombre;
            model.Abreviatura = dto.Abreviatura;
            model.Descripcion = dto.Descripcion;
            model.Estado = dto.Estado;
            return model;
        }

        internal static List<SistemaModel> ToModels(IList<DSistemaDto> dtos)
        {
            var models = new List<SistemaModel>();
            foreach (var dto in dtos)
            {
                var model = ToModel(dto);
                models.Add(model);
            }
            return models;
        }

        internal static DSistemaDto ToDto(SistemaModel model)
        {
            var dto = new DSistemaDto();
            dto.Id = model.Id;
            dto.Codigo = model.Codigo;
            dto.Nombre = model.Nombre;
            dto.Abreviatura = model.Abreviatura;
            if (!string.IsNullOrEmpty(model.Descripcion))
            {
                dto.Descripcion = model.Descripcion;
            }
            dto.Estado = model.Estado;
            return dto;
        }
    }
}