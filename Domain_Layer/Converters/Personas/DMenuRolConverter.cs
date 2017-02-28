using Domain_Layer.Converters.Sistemas;
using Domain_Layer.Dtos.Personas;
using Entity_Layer.Entities.Personas;
using System.Collections.Generic;

namespace Domain_Layer.Converters.Personas
{
    /// <summary>
    /// Here is the Converter class DMenuRolConverter.
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    internal static class DMenuRolConverter
    {
        /// <summary>
        /// Method for convert entity class EMenuRol to DTO class DMenuRolDto.
        /// </summary>
        /// <param name="entity">The entity class EMenuRol.</param>
        /// <returns></returns>
        internal static DMenuRolDto ToDto(EMenuRol entity)
        {
            var dto = new DMenuRolDto();
            dto.Id = entity.Id;
            dto.Menu = DMenuConverter.ToDto(entity.Menu);
            dto.Rol = DRolConverter.ToDto(entity.Rol);
            return dto;
        }

        /// <summary>
        /// Method for convert list of entities classes EMenuRol to list of DTOs classes DMenuRolDto.
        /// </summary>
        /// <param name="entities">The list of entities classes EMenuRol.</param>
        /// <returns></returns>
        internal static List<DMenuRolDto> ToDtos(IList<EMenuRol> entities)
        {
            var dtos = new List<DMenuRolDto>();
            foreach (var entity in entities)
            {
                var dto = ToDto(entity);
                dtos.Add(dto);
            }
            return dtos;
        }

        /// <summary>
        /// Method for convert DTO class DMenuRolDto to entity class EMenuRol.
        /// </summary>
        /// <param name="dto">The DTO class DMenuRolDto.</param>
        /// <returns></returns>
        internal static EMenuRol ToEntity(DMenuRolDto dto)
        {
            var entity = new EMenuRol();
            entity.Id = dto.Id;
            entity.Menu = DMenuConverter.ToEntity(dto.Menu);
            entity.Rol = DRolConverter.ToEntity(dto.Rol);
            return entity;
        }
    }
}