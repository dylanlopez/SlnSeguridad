using Domain_Layer.Dtos.Sistemas;
using Service_Layer.Models.Sistemas;
using System.Collections.Generic;

namespace Service_Layer.Converters.Sistemas
{
    internal class SOpcionConverter
    {
        internal static OpcionModel ToModel(DOpcionDto dto)
        {
            var model = new OpcionModel();
            model.Id = dto.Id;
            model.Nombre = dto.Nombre;
            model.NombreControlAsociado = dto.NombreControlAsociado;
            model.Descripcion = dto.Descripcion;
            return model;
        }

        internal static List<OpcionModel> ToModels(IList<DOpcionDto> dtos)
        {
            var models = new List<OpcionModel>();
            foreach (var dto in dtos)
            {
                var model = ToModel(dto);
                models.Add(model);
            }
            return models;
        }

        internal static DOpcionDto ToDto(OpcionModel model)
        {
            var dto = new DOpcionDto();
            dto.Id = model.Id;
            dto.Nombre = model.Nombre;
            dto.NombreControlAsociado = model.NombreControlAsociado;
            if (!string.IsNullOrEmpty(model.Descripcion))
            {
                dto.Descripcion = model.Descripcion;
            }
            return dto;
        }
    }
}