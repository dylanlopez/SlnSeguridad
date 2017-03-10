using Domain_Layer.Dtos.Personas;
using Entity_Layer.Entities.Personas;
using System.Collections.Generic;

namespace Domain_Layer.Converters.Personas
{
    /// <summary>
    /// Here is the Converter class DProgramaSocialConverter.
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    internal static class DProgramaSocialConverter
    {
        /// <summary>
        /// Method for convert entity class EProgramaSocial to DTO class DProgramaSocialDto.
        /// </summary>
        /// <param name="entity">The entity class EProgramaSocial.</param>
        /// <returns></returns>
        internal static DProgramaSocialDto ToDto(EProgramaSocial entity)
        {
            var dto = new DProgramaSocialDto();
            dto.Id = entity.Id;
            dto.Codigo = entity.Codigo;
            dto.Nombre = entity.Nombre;
            dto.Descripcion = entity.Descripcion;
            dto.Alcance = entity.Alcance;
            dto.Estado = entity.Estado;
            return dto;
        }

        /// <summary>
        /// Method for convert list of entities classes EProgramaSocial to list of DTOs classes DProgramaSocialDto.
        /// </summary>
        /// <param name="entities">The list of entities classes EProgramaSocial.</param>
        /// <returns></returns>
        internal static List<DProgramaSocialDto> ToDtos(IList<EProgramaSocial> entities)
        {
            var dtos = new List<DProgramaSocialDto>();
            foreach (var entity in entities)
            {
                var dto = ToDto(entity);
                dtos.Add(dto);
            }
            return dtos;
        }

        /// <summary>
        /// Method for convert DTO class DProgramaSocialDto to entity class EProgramaSocial.
        /// </summary>
        /// <param name="dto">The DTO class DProgramaSocialDto.</param>
        /// <returns></returns>
        internal static EProgramaSocial ToEntity(DProgramaSocialDto dto)
        {
            var entity = new EProgramaSocial();
            entity.Id = dto.Id;
            entity.Codigo = dto.Codigo.ToUpper();
            entity.Nombre = dto.Nombre.ToUpper();
            entity.Descripcion = dto.Descripcion.ToUpper();
            entity.Alcance = dto.Alcance;
            entity.Estado = dto.Estado;
            return entity;
        }
    }
}