using Domain_Layer.Dtos.Personas;
using Service_Layer.Models.Personas;
using System.Collections.Generic;

namespace Service_Layer.Converters.Personas
{
    internal static class STipoInstitucionConverter
    {
        internal static TipoInstitucionModel ToModel(DTipoInstitucionDto dto)
        {
            var model = new TipoInstitucionModel();
            model.Id = dto.Id;
            model.Nombre = dto.Nombre;
            model.Descripcion = dto.Descripcion;
            model.Activo = dto.Activo;
            return model;
        }

        internal static List<TipoInstitucionModel> ToModels(IList<DTipoInstitucionDto> dtos)
        {
            var models = new List<TipoInstitucionModel>();
            foreach (var dto in dtos)
            {
                var model = ToModel(dto);
                models.Add(model);
            }
            return models;
        }

        internal static DTipoInstitucionDto ToDto(TipoInstitucionModel model)
        {
            var dto = new DTipoInstitucionDto();
            if (model.Id != null)
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
            if (model.Activo != null)
            {
                dto.Activo = model.Activo;
            }
            return dto;
        }
    }
}