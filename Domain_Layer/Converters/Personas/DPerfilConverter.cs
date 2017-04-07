using Domain_Layer.Dtos.Personas;
using Entity_Layer.Entities.Personas;
using System.Collections.Generic;

namespace Domain_Layer.Converters.Personas
{
    /// <summary>
    /// Here is the Converter class DPerfilConverter.
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    internal static class DPerfilConverter
    {
        /// <summary>
        /// Method for convert entity class EPerfil to DTO class DPerfilDto.
        /// </summary>
        /// <param name="entity">The entity class EPerfil.</param>
        /// <returns></returns>
        internal static DPerfilDto ToDto(EPerfil entity)
        {
            var dto = new DPerfilDto();
            dto.Id = entity.Id;
            dto.Nombre = entity.Nombre;
            dto.Descripcion = entity.Descripcion;
            return dto;
        }

        /// <summary>
        /// Method for convert list of entities classes EPerfil to list of DTOs classes DPerfilDto.
        /// </summary>
        /// <param name="entities">The list of entities classes EPerfil.</param>
        /// <returns></returns>
        internal static List<DPerfilDto> ToDtos(IList<EPerfil> entities)
        {
            var dtos = new List<DPerfilDto>();
            foreach (var entity in entities)
            {
                var dto = ToDto(entity);
                dtos.Add(dto);
            }
            return dtos;
        }

        /// <summary>
        /// Method for convert DTO class DPerfilDto to entity class EPerfil.
        /// </summary>
        /// <param name="dto">The DTO class DPerfilDto.</param>
        /// <returns></returns>
        internal static EPerfil ToEntity(DPerfilDto dto)
        {
            var entity = new EPerfil();
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
            return entity;
        }
    }
}