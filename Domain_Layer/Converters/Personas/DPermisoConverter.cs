using Domain_Layer.Converters.Sistemas;
using Domain_Layer.Dtos.Personas;
using Entity_Layer.Entities.Personas;
using System;
using System.Collections.Generic;

namespace Domain_Layer.Converters.Personas
{
    /// <summary>
    /// Here is the Converter class DPermisoConverter.
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    internal static class DPermisoConverter
    {
        /// <summary>
        /// Method for convert entity class EPermiso to DTO class DPermisoDto.
        /// </summary>
        /// <param name="entity">The entity class EPermiso.</param>
        /// <returns></returns>
        internal static DPermisoDto ToDto(EPermiso entity)
        {
            var dto = new DPermisoDto();
            dto.Id = entity.Id;
            dto.FechaAlta = entity.FechaAlta.ToString();
            dto.Estado = entity.Estado;
            dto.PerfilUsuarioRol = DPerfilUsuarioRolConverter.ToDto(entity.PerfilUsuarioRol);
            dto.MenuOpcion = DMenuOpcionConverter.ToDto(entity.MenuOpcion);
            return dto;
        }

        /// <summary>
        /// Method for convert list of entities classes EPerfilUsuarioRol to list of DTOs classes EPermiso.
        /// </summary>
        /// <param name="entities">The list of entities classes EPerfilUsuarioRol.</param>
        /// <returns></returns>
        internal static List<DPermisoDto> ToDtos(IList<EPermiso> entities)
        {
            var dtos = new List<DPermisoDto>();
            foreach (var entity in entities)
            {
                var dto = ToDto(entity);
                dtos.Add(dto);
            }
            return dtos;
        }

        /// <summary>
        /// Method for convert DTO class DPermisoDto to entity class EPermiso.
        /// </summary>
        /// <param name="dto">The DTO class DPermisoDto.</param>
        /// <returns></returns>
        internal static EPermiso ToEntity(DPermisoDto dto)
        {
            var entity = new EPermiso();
            entity.Id = dto.Id;
            entity.FechaAlta = Convert.ToDateTime(dto.FechaAlta);
            entity.Estado = dto.Estado;
            entity.PerfilUsuarioRol = DPerfilUsuarioRolConverter.ToEntity(dto.PerfilUsuarioRol);
            entity.MenuOpcion = DMenuOpcionConverter.ToEntity(dto.MenuOpcion);
            return entity;
        }
    }
}