using Domain_Layer.Dtos.Personas;
using Entity_Layer.Entities.Personas;
using System.Collections.Generic;

namespace Domain_Layer.Converters.Personas
{
    /// <summary>
    /// Here is the Converter class DInstitucionConverter.
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    internal static class DInstitucionConverter
    {
        /// <summary>
        /// Method for convert entity class EInstitucion to DTO class DInstitucionDto.
        /// </summary>
        /// <param name="entity">The entity class EInstitucion.</param>
        /// <returns></returns>
        internal static DInstitucionDto ToDto(EInstitucion entity)
        {
            var dto = new DInstitucionDto();
            dto.Id = entity.Id;
            dto.Nombre = entity.Nombre;
            dto.NombreCorto = entity.NombreCorto;
            dto.Direccion = entity.Direccion;
            dto.Activo = entity.Activo;
            dto.TipoInstitucion = DTipoInstitucionConverter.ToDto(entity.TipoInstitucion);
            return dto;
        }

        /// <summary>
        /// Method for convert list of entities classes EInstitucion to list of DTOs classes DInstitucionDto.
        /// </summary>
        /// <param name="entities">The list of entities classes EInstitucion.</param>
        /// <returns></returns>
        internal static List<DInstitucionDto> ToDtos(IList<EInstitucion> entities)
        {
            var dtos = new List<DInstitucionDto>();
            foreach (var entity in entities)
            {
                var dto = ToDto(entity);
                dtos.Add(dto);
            }
            return dtos;
        }

        /// <summary>
        /// Method for convert DTO class DInstitucionDto to entity class EInstitucion.
        /// </summary>
        /// <param name="dto">The DTO class DInstitucionDto.</param>
        /// <returns></returns>
        internal static EInstitucion ToEntity(DInstitucionDto dto)
        {
            var entity = new EInstitucion();
            entity.Id = dto.Id;
            entity.Nombre = dto.Nombre.ToUpper();
            entity.NombreCorto = dto.NombreCorto.ToUpper();
            if (!string.IsNullOrEmpty(dto.Direccion))
            {
                entity.Direccion = dto.Direccion.ToUpper();
            }
            else
            {
                entity.Direccion = string.Empty;
            }
            entity.Activo = dto.Activo;
            entity.TipoInstitucion = DTipoInstitucionConverter.ToEntity(dto.TipoInstitucion);
            return entity;
        }
    }
}