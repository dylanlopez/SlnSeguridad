﻿using Domain_Layer.Dtos.Personas;
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
            if(model.Id != null)
            {
                dto.Id = model.Id;
            }
            if (!string.IsNullOrEmpty(model.Nombre))
            {
                dto.Nombre = model.Nombre;
            }
            if (!string.IsNullOrEmpty(model.Descripcion))
            {
                dto.Descripcion = model.Descripcion.ToUpper();
            }
            return dto;
        }
    }
}