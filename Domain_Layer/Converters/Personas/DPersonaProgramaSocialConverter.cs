using Domain_Layer.Dtos.Personas;
using Entity_Layer.Entities.Personas;
using System.Collections.Generic;

namespace Domain_Layer.Converters.Personas
{
    /// <summary>
    /// Here is the Converter class DPersonaProgramaSocialConverter.
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    internal static class DPersonaProgramaSocialConverter
    {
        /// <summary>
        /// Method for convert entity class EPersonaProgramaSocial to DTO class DPersonaProgramaSocialDto.
        /// </summary>
        /// <param name="entity">The entity class EPersonaProgramaSocial.</param>
        /// <returns></returns>
        internal static DPersonaProgramaSocialDto ToDto(EPersonaProgramaSocial entity)
        {
            var dto = new DPersonaProgramaSocialDto();
            dto.Id = entity.Id;
            dto.Persona = DPersonaConverter.ToDto(entity.Persona);
            dto.ProgramaSocial = DProgramaSocialConverter.ToDto(entity.ProgramaSocial);
            return dto;
        }

        /// <summary>
        /// Method for convert list of entities classes EPersonaProgramaSocial to list of DTOs classes DPersonaProgramaSocialDto.
        /// </summary>
        /// <param name="entities">The list of entities classes EPersonaProgramaSocial.</param>
        /// <returns></returns>
        internal static List<DPersonaProgramaSocialDto> ToDtos(IList<EPersonaProgramaSocial> entities)
        {
            var dtos = new List<DPersonaProgramaSocialDto>();
            foreach (var entity in entities)
            {
                var dto = ToDto(entity);
                dtos.Add(dto);
            }
            return dtos;
        }

        /// <summary>
        /// Method for convert DTO class DPersonaProgramaSocialDto to entity class EPersonaProgramaSocial.
        /// </summary>
        /// <param name="dto">The DTO class DPersonaProgramaSocialDto.</param>
        /// <returns></returns>
        internal static EPersonaProgramaSocial ToEntity(DPersonaProgramaSocialDto dto)
        {
            var entity = new EPersonaProgramaSocial();
            entity.Id = dto.Id;
            entity.Persona = DPersonaConverter.ToEntity(dto.Persona);
            entity.ProgramaSocial = DProgramaSocialConverter.ToEntity(dto.ProgramaSocial);
            return entity;
        }
    }
}