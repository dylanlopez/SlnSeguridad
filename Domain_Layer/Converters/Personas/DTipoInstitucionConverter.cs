using Domain_Layer.Dtos.Personas;
using Entity_Layer.Entities.Personas;
using System.Collections.Generic;

namespace Domain_Layer.Converters.Personas
{
    /// <summary>
    /// Here is the Converter class DTipoInstitucionConverter.
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    internal static class DTipoInstitucionConverter
    {
        /// <summary>
        /// Method for convert entity class ETipoInstitucion to DTO class DTipoInstitucionDto.
        /// </summary>
        /// <param name="entity">The entity class ETipoInstitucion.</param>
        /// <returns></returns>
        internal static DTipoInstitucionDto ToDto(ETipoInstitucion entity)
        {
            var dto = new DTipoInstitucionDto();
            dto.Id = entity.Id;
            dto.Nombre = entity.Nombre;
            dto.Descripcion = entity.Descripcion;
            dto.Activo = entity.Activo;
            return dto;
        }

        /// <summary>
        /// Method for convert list of entities classes ETipoInstitucion to list of DTOs classes DTipoInstitucionDto.
        /// </summary>
        /// <param name="entities">The list of entities classes ETipoInstitucion.</param>
        /// <returns></returns>
        internal static List<DTipoInstitucionDto> ToDtos(IList<ETipoInstitucion> entities)
        {
            var dtos = new List<DTipoInstitucionDto>();
            foreach (var entity in entities)
            {
                var dto = ToDto(entity);
                dtos.Add(dto);
            }
            return dtos;
        }

        /// <summary>
        /// Method for convert DTO class DTipoInstitucionDto to entity class ETipoInstitucion.
        /// </summary>
        /// <param name="dto">The DTO class DTipoInstitucionDto.</param>
        /// <returns></returns>
        internal static ETipoInstitucion ToEntity(DTipoInstitucionDto dto)
        {
            var entity = new ETipoInstitucion();
            entity.Id = dto.Id;           
            entity.Nombre = dto.Nombre.ToUpper();
            if (!string.IsNullOrEmpty(dto.Descripcion))
            {
                entity.Descripcion = dto.Descripcion.ToUpper();
            }
            else
            {
                entity.Descripcion = string.Empty;
            }
            entity.Activo = dto.Activo;
            return entity;
        }
    }
}