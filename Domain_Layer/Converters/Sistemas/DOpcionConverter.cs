using Domain_Layer.Dtos.Sistemas;
using Entity_Layer.Entities.Sistemas;
using System.Collections.Generic;

namespace Domain_Layer.Converters.Sistemas
{
    /// <summary>
    /// Here is the Converter class DOpcionConverter.
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    internal static class DOpcionConverter
    {
        /// <summary>
        /// Method for convert entity class EOpcion to DTO class DOpcionDto.
        /// </summary>
        /// <param name="entity">The entity class EOpcion.</param>
        /// <returns></returns>
        internal static DOpcionDto ToDto(EOpcion entity)
        {
            var dto = new DOpcionDto();
            dto.Id = entity.Id;
            dto.Nombre = entity.Nombre;
            dto.NombreControlAsociado = entity.NombreControlAsociado;
            dto.Descripcion = entity.Descripcion;
            return dto;
        }

        /// <summary>
        /// Method for convert list of entities classes EOpcion to list of DTOs classes DOpcionDto.
        /// </summary>
        /// <param name="entities">The list of entities classes EOpcion.</param>
        /// <returns></returns>
        internal static List<DOpcionDto> ToDtos(IList<EOpcion> entities)
        {
            var dtos = new List<DOpcionDto>();
            foreach (var entity in entities)
            {
                var dto = ToDto(entity);
                dtos.Add(dto);
            }
            return dtos;
        }

        /// <summary>
        /// Method for convert DTO class DOpcionDto to entity class EOpcion.
        /// </summary>
        /// <param name="dto">The DTO class DOpcionDto.</param>
        /// <returns></returns>
        internal static EOpcion ToEntity(DOpcionDto dto)
        {
            var entity = new EOpcion();
            entity.Id = dto.Id;
            entity.Nombre = dto.Nombre.ToUpper();
            entity.NombreControlAsociado = dto.NombreControlAsociado;
            if (!string.IsNullOrEmpty(dto.Descripcion))
            {
                entity.Descripcion = dto.Descripcion.ToUpper();
            }
            else
            {
                entity.Descripcion = string.Empty;
            }
            return entity;
        }
    }
}