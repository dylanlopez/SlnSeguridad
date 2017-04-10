using Domain_Layer.Dtos.Personas;
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
            model.Estado = dto.Estado;
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
            dto.Estado = model.Estado;
            dto.Sistema = SSistemaConverter.ToDto(model.Sistema);
            dto.Perfil = SPerfilConverter.ToDto(model.Perfil);
            return dto;
        }
    }
}