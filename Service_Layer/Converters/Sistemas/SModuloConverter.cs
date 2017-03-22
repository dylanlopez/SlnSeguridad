using Domain_Layer.Dtos.Sistemas;
using Interface_Layer.Models.Sistemas;
using System.Collections.Generic;

namespace Service_Layer.Converters.Sistemas
{
    internal static class SModuloConverter
    {
        internal static ModuloModel ToModel(DModuloDto dto)
        {
            var model = new ModuloModel();
            model.Id = dto.Id;
            model.Codigo = dto.Codigo;
            model.Nombre = dto.Nombre;
            model.Abreviatura = dto.Abreviatura;
            model.Descripcion = dto.Descripcion;
            model.Estado = dto.Estado;
            model.Sistema = SSistemaConverter.ToModel(dto.Sistema);
            return model;
        }

        internal static List<ModuloModel> ToModels(IList<DModuloDto> dtos)
        {
            var models = new List<ModuloModel>();
            foreach (var dto in dtos)
            {
                var model = ToModel(dto);
                models.Add(model);
            }
            return models;
        }

        internal static DModuloDto ToDto(ModuloModel model)
        {
            var dto = new DModuloDto();
            dto.Id = model.Id;
            dto.Codigo = model.Codigo;
            dto.Nombre = model.Nombre;
            dto.Abreviatura = model.Abreviatura;
            if (!string.IsNullOrEmpty(model.Descripcion))
            {
                dto.Descripcion = model.Descripcion;
            }
            dto.Estado = model.Estado;
            dto.Sistema = SSistemaConverter.ToDto(model.Sistema);
            return dto;
        }
    }
}