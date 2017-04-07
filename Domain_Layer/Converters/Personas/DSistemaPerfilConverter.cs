using Domain_Layer.Converters.Sistemas;
using Domain_Layer.Dtos.Personas;
using Entity_Layer.Entities.Personas;
using System.Collections.Generic;

namespace Domain_Layer.Converters.Personas
{
    /// <summary>
    /// Here is the Converter class DSistemaPerfilConverter.
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    internal static class DSistemaPerfilConverter
    {
        /// <summary>
        /// Method for convert entity class ESistemaPerfil to DTO class DSistemaPerfilDto.
        /// </summary>
        /// <param name="entity">The entity class ESistemaPerfil.</param>
        /// <returns></returns>
        internal static DSistemaPerfilDto ToDto(ESistemaPerfil entity)
        {
            var dto = new DSistemaPerfilDto();
            dto.Id = entity.Id;
            dto.Estado = entity.Estado;
            dto.Sistema = DSistemaConverter.ToDto(entity.Sistema);
            dto.Perfil = DPerfilConverter.ToDto(entity.Perfil);
            return dto;
        }

        /// <summary>
        /// Method for convert list of entities classes ESistemaPerfil to list of DTOs classes DSistemaPerfilDto.
        /// </summary>
        /// <param name="entities">The list of entities classes ESistemaPerfil.</param>
        /// <returns></returns>
        internal static List<DSistemaPerfilDto> ToDtos(IList<ESistemaPerfil> entities)
        {
            var dtos = new List<DSistemaPerfilDto>();
            foreach (var entity in entities)
            {
                var dto = ToDto(entity);
                dtos.Add(dto);
            }
            return dtos;
        }

        /// <summary>
        /// Method for convert DTO class DSistemaPerfilDto to entity class ESistemaPerfil.
        /// </summary>
        /// <param name="dto">The DTO class DSistemaPerfilDto.</param>
        /// <returns></returns>
        internal static ESistemaPerfil ToEntity(DSistemaPerfilDto dto)
        {
            var entity = new ESistemaPerfil();
            entity.Id = dto.Id;
            entity.Estado = dto.Estado;
            entity.Sistema = DSistemaConverter.ToEntity(dto.Sistema);
            entity.Perfil = DPerfilConverter.ToEntity(dto.Perfil);
            return entity;
        }
    }
}