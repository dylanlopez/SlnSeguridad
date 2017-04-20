using Domain_Layer.Dtos.Sistemas;
using Entity_Layer.Entities.Sistemas;
using System.Collections.Generic;

namespace Domain_Layer.Converters.Sistemas
{
    /// <summary>
    /// Here is the Converter class DMenuOpcionConverter.
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    internal static class DMenuOpcionConverter
    {
        /// <summary>
        /// Method for convert entity class EMenuOpcion to DTO class DMenuOpcionDto.
        /// </summary>
        /// <param name="entity">The entity class EMenuOpcion.</param>
        /// <returns></returns>
        internal static DMenuOpcionDto ToDto(EMenuOpcion entity)
        {
            var dto = new DMenuOpcionDto();
            dto.Id = entity.Id;
            dto.Activo = entity.Activo;
            dto.Visible = entity.Visible;
            dto.Menu = DMenuConverter.ToDto(entity.Menu);
            dto.Opcion = DOpcionConverter.ToDto(entity.Opcion);
            return dto;
        }

        /// <summary>
        /// Method for convert list of entities classes EMenuOpcion to list of DTOs classes DMenuOpcionDto.
        /// </summary>
        /// <param name="entities">The list of entities classes EMenuOpcion.</param>
        /// <returns></returns>
        internal static List<DMenuOpcionDto> ToDtos(IList<EMenuOpcion> entities)
        {
            var dtos = new List<DMenuOpcionDto>();
            foreach (var entity in entities)
            {
                var dto = ToDto(entity);
                dtos.Add(dto);
            }
            return dtos;
        }

        /// <summary>
        /// Method for convert DTO class DMenuOpcionDto to entity class EMenuOpcion.
        /// </summary>
        /// <param name="dto">The DTO class DMenuOpcionDto.</param>
        /// <returns></returns>
        internal static EMenuOpcion ToEntity(DMenuOpcionDto dto)
        {
            var entity = new EMenuOpcion();
            entity.Id = dto.Id;
            entity.Activo = dto.Activo;
            entity.Visible = dto.Visible;
            entity.Menu = DMenuConverter.ToEntity(dto.Menu);
            entity.Opcion = DOpcionConverter.ToEntity(dto.Opcion);
            return entity;
        }
    }
}