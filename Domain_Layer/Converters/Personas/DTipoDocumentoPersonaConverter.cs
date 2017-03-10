using Domain_Layer.Dtos.Personas;
using Entity_Layer.Entities.Personas;
using System.Collections.Generic;

namespace Domain_Layer.Converters.Personas
{
    /// <summary>
    /// Here is the Converter class DTipoDocumentoPersonaConverter.
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    internal static class DTipoDocumentoPersonaConverter
    {
        /// <summary>
        /// Method for convert entity class ETipoDocumentoPersona to DTO class DTipoDocumentoPersonaDto.
        /// </summary>
        /// <param name="entity">The entity class ETipoDocumentoPersona.</param>
        /// <returns></returns>
        internal static DTipoDocumentoPersonaDto ToDto(ETipoDocumentoPersona entity)
        {
            var dto = new DTipoDocumentoPersonaDto();
            dto.Id = entity.Id;
            dto.Codigo = entity.Codigo;
            dto.Nombre = entity.Nombre;
            dto.Descripcion = entity.Descripcion;
            return dto;
        }

        /// <summary>
        /// Method for convert list of entities classes ETipoDocumentoPersona to list of DTOs classes DTipoDocumentoPersonaDto.
        /// </summary>
        /// <param name="entities">The list of entities classes ETipoDocumentoPersona.</param>
        /// <returns></returns>
        internal static List<DTipoDocumentoPersonaDto> ToDtos(IList<ETipoDocumentoPersona> entities)
        {
            var dtos = new List<DTipoDocumentoPersonaDto>();
            foreach (var entity in entities)
            {
                var dto = ToDto(entity);
                dtos.Add(dto);
            }
            return dtos;
        }

        /// <summary>
        /// Method for convert DTO class DTipoDocumentoPersonaDto to entity class ETipoDocumentoPersona.
        /// </summary>
        /// <param name="dto">The DTO class DTipoDocumentoPersonaDto.</param>
        /// <returns></returns>
        internal static ETipoDocumentoPersona ToEntity(DTipoDocumentoPersonaDto dto)
        {
            var entity = new ETipoDocumentoPersona();
            entity.Id = dto.Id;
            entity.Codigo = dto.Codigo.ToUpper();
            entity.Nombre = dto.Nombre.ToUpper();
            entity.Descripcion = dto.Descripcion.ToUpper();
            return entity;
        }
    }
}