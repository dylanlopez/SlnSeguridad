using Domain_Layer.Dtos.Personas;
using Entity_Layer.Entities.Personas;
using System.Collections.Generic;

namespace Domain_Layer.Converters.Personas
{
    /// <summary>
    /// Here is the Converter class DPersonaConverter.
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    internal static class DPersonaConverter
    {
        /// <summary>
        /// Method for convert entity class EPersona to DTO class DPersonaDto.
        /// </summary>
        /// <param name="entity">The entity class EPersona.</param>
        /// <returns></returns>
        internal static DPersonaDto ToDto(EPersona entity)
        {
            var dto = new DPersonaDto();
            dto.Id = entity.Id;
            dto.Nombre = entity.Nombre;
            dto.NumeroDocumento = entity.NumeroDocumento;
            dto.Tipo = entity.Tipo;
            dto.TipoDocumentoPersona = DTipoDocumentoPersonaConverter.ToDto(entity.TipoDocumentoPersona);
            return dto;
        }

        /// <summary>
        /// Method for convert list of entities classes EPersona to list of DTOs classes DPersonaDto.
        /// </summary>
        /// <param name="entities">The list of entities classes EPersona.</param>
        /// <returns></returns>
        internal static List<DPersonaDto> ToDtos(IList<EPersona> entities)
        {
            var dtos = new List<DPersonaDto>();
            foreach (var entity in entities)
            {
                var dto = ToDto(entity);
                dtos.Add(dto);
            }
            return dtos;
        }

        /// <summary>
        /// Method for convert DTO class DPersonaDto to entity class EPersona.
        /// </summary>
        /// <param name="dto">The DTO class DPersonaDto.</param>
        /// <returns></returns>
        internal static EPersona ToEntity(DPersonaDto dto)
        {
            var entity = new EPersona();
            entity.Id = dto.Id;
            entity.Nombre = dto.Nombre.ToUpper();
            entity.NumeroDocumento = dto.NumeroDocumento.ToUpper();
            entity.Tipo = dto.Tipo;
            entity.TipoDocumentoPersona = DTipoDocumentoPersonaConverter.ToEntity(dto.TipoDocumentoPersona);
            return entity;
        }
    }
}