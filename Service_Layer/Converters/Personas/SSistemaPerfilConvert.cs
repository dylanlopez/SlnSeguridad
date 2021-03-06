﻿using Domain_Layer.Dtos.Personas;
using Service_Layer.Converters.Sistemas;
using Service_Layer.Models.Personas;
using System.Collections.Generic;

namespace Service_Layer.Converters.Personas
{
    internal static class SSistemaPerfilConvert
    {
        internal static SistemaPerfilModel ToModel(DSistemaPerfilDto dto)
        {
            var model = new SistemaPerfilModel();
            model.Id = dto.Id;
            model.Activo = dto.Activo;
            model.Sistema = SSistemaConverter.ToModel(dto.Sistema);
            model.Perfil = SPerfilConverter.ToModel(dto.Perfil);
            return model;
        }

        internal static List<SistemaPerfilModel> ToModels(IList<DSistemaPerfilDto> dtos)
        {
            var models = new List<SistemaPerfilModel>();
            foreach (var dto in dtos)
            {
                var model = ToModel(dto);
                models.Add(model);
            }
            return models;
        }

        internal static DSistemaPerfilDto ToDto(SistemaPerfilModel model)
        {
            var dto = new DSistemaPerfilDto();
            dto.Id = model.Id;
            dto.Activo = model.Activo;
            if (model.Sistema != null)
            {
                dto.Sistema = SSistemaConverter.ToDto(model.Sistema);
            }
            if (model.Perfil != null)
            {
                dto.Perfil = SPerfilConverter.ToDto(model.Perfil);
            }
            return dto;
        }
    }
}