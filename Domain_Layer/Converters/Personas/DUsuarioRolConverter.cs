using Domain_Layer.Dtos.Personas;
using Entity_Layer.Entities.Personas;
using System.Collections.Generic;

namespace Domain_Layer.Converters.Personas
{
    /// <summary>
    /// Here is the Converter class DUsuarioRolConverter.
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    internal static class DUsuarioRolConverter
    {
        /// <summary>
        /// Method for convert entity class EUsuarioRol to DTO class DUsuarioRolDto.
        /// </summary>
        /// <param name="entity">The entity class EUsuarioRol.</param>
        /// <returns></returns>
        internal static DUsuarioRolDto ToDto(EUsuarioRol entity)
        {
            var dto = new DUsuarioRolDto();
            dto.Id = entity.Id;
            dto.Usuario = DUsuarioConverter.ToDto(entity.Usuario);
            dto.Rol = DRolConverter.ToDto(entity.Rol);
            return dto;
        }

        /// <summary>
        /// Method for convert list of entities classes EUsuarioRol to list of DTOs classes DUsuarioRolDto.
        /// </summary>
        /// <param name="entities">The list of entities classes EUsuarioRol.</param>
        /// <returns></returns>
        internal static List<DUsuarioRolDto> ToDtos(IList<EUsuarioRol> entities)
        {
            var dtos = new List<DUsuarioRolDto>();
            foreach (var entity in entities)
            {
                var dto = ToDto(entity);
                dtos.Add(dto);
            }
            return dtos;
        }

        /// <summary>
        /// Method for convert DTO class DUsuarioRolDto to entity class EUsuarioRol.
        /// </summary>
        /// <param name="dto">The DTO class DUsuarioRolDto.</param>
        /// <returns></returns>
        internal static EUsuarioRol ToEntity(DUsuarioRolDto dto)
        {
            var entity = new EUsuarioRol();
            entity.Id = dto.Id;
            entity.Usuario = DUsuarioConverter.ToEntity(dto.Usuario);
            entity.Rol = DRolConverter.ToEntity(dto.Rol);
            return entity;
        }
    }
}