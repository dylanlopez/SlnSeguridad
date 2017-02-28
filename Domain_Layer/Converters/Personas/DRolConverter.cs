using Domain_Layer.Dtos.Personas;
using Entity_Layer.Entities.Personas;
using System.Collections.Generic;

namespace Domain_Layer.Converters.Personas
{
    /// <summary>
    /// Here is the Converter class DRolConverter.
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    internal static class DRolConverter
    {
        /// <summary>
        /// Method for convert entity class ERol to DTO class DRolDto.
        /// </summary>
        /// <param name="entity">The entity class ERol.</param>
        /// <returns></returns>
        internal static DRolDto ToDto(ERol entity)
        {
            var dto = new DRolDto();
            dto.Id = entity.Id;
            dto.Nombre = entity.Nombre;
            dto.Descripcion = entity.Descripcion;
            dto.Estado = entity.Estado;
            return dto;
        }

        /// <summary>
        /// Method for convert list of entities classes ERol to list of DTOs classes DRolDto.
        /// </summary>
        /// <param name="entities">The list of entities classes ERol.</param>
        /// <returns></returns>
        internal static List<DRolDto> ToDtos(IList<ERol> entities)
        {
            var dtos = new List<DRolDto>();
            foreach (var entity in entities)
            {
                var dto = ToDto(entity);
                dtos.Add(dto);
            }
            return dtos;
        }

        /// <summary>
        /// Method for convert DTO class DRolDto to entity class ERol.
        /// </summary>
        /// <param name="dto">The DTO class DRolDto.</param>
        /// <returns></returns>
        internal static ERol ToEntity(DRolDto dto)
        {
            var entity = new ERol();
            entity.Id = dto.Id;
            entity.Nombre = dto.Nombre;
            entity.Descripcion = dto.Descripcion;
            entity.Estado = dto.Estado;
            return entity;
        }
    }
}