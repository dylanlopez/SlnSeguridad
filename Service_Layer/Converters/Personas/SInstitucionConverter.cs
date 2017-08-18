using Domain_Layer.Dtos.Personas;
using Service_Layer.Models.Personas;
using System.Collections.Generic;

namespace Service_Layer.Converters.Personas
{
    internal static class SInstitucionConverter
    {
        internal static InstitucionModel ToModel(DInstitucionDto dto)
        {
            var model = new InstitucionModel();
            model.Id = dto.Id;
            model.Nombre = dto.Nombre;
            model.NombreCorto = dto.NombreCorto;
            model.Direccion = dto.Direccion;
            model.Activo = dto.Activo;
            model.TipoInstitucion = STipoInstitucionConverter.ToModel(dto.TipoInstitucion);
            return model;
        }

        internal static List<InstitucionModel> ToModels(IList<DInstitucionDto> dtos)
        {
            var models = new List<InstitucionModel>();
            foreach (var dto in dtos)
            {
                var model = ToModel(dto);
                models.Add(model);
            }
            return models;
        }

        internal static DInstitucionDto ToDto(InstitucionModel model)
        {
            var dto = new DInstitucionDto();
            if (model.Id != null)
            {
                dto.Id = model.Id;
            }
            if (!string.IsNullOrEmpty(model.Nombre))
            {
                dto.Nombre = model.Nombre;
            }
            if (!string.IsNullOrEmpty(model.NombreCorto))
            {
                dto.NombreCorto = model.NombreCorto;
            }
            if (!string.IsNullOrEmpty(model.Direccion))
            {
                dto.Direccion = model.Direccion.ToUpper();
            }
            if (model.Activo != null)
            {
                dto.Activo = model.Activo;
            }
            if (model.TipoInstitucion != null)
            {
                dto.TipoInstitucion = STipoInstitucionConverter.ToDto(model.TipoInstitucion);
            }
            return dto;
        }
    }
}