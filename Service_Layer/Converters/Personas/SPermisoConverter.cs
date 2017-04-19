using Domain_Layer.Dtos.Personas;
using Service_Layer.Converters.Sistemas;
using Service_Layer.Models.Personas;
using System.Collections.Generic;

namespace Service_Layer.Converters.Personas
{
    internal static class SPermisoConverter
    {
        internal static PermisoModel ToModel(DPermisoDto dto)
        {
            var model = new PermisoModel();
            model.Id = dto.Id;
            model.Estado = dto.Estado;
            model.FechaAlta = dto.FechaAlta;
            model.PerfilUsuarioRol = SPerfilUsuarioRolConverter.ToModel(dto.PerfilUsuarioRol);
            model.MenuOpcion = SMenuOpcionConverter.ToModel(dto.MenuOpcion);
            return model;
        }

        internal static List<PermisoModel> ToModels(IList<DPermisoDto> dtos)
        {
            var models = new List<PermisoModel>();
            foreach (var dto in dtos)
            {
                var model = ToModel(dto);
                models.Add(model);
            }
            return models;
        }

        internal static DPermisoDto ToDto(PermisoModel model)
        {
            var dto = new DPermisoDto();
            dto.Id = model.Id;
            dto.Estado = model.Estado;
            dto.FechaAlta = model.FechaAlta;
            if (model.PerfilUsuarioRol != null)
            {
                dto.PerfilUsuarioRol = SPerfilUsuarioRolConverter.ToDto(model.PerfilUsuarioRol);
            }
            if (model.MenuOpcion != null)
            {
                dto.MenuOpcion = SMenuOpcionConverter.ToDto(model.MenuOpcion);
            }
            return dto;
        }
    }
}