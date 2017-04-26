using Domain_Layer.Dtos.Personas;
using Entity_Layer.Entities.Personas;
using System.Collections.Generic;

namespace Domain_Layer.Converters.Personas
{
    /// <summary>
    /// Here is the Converter class DPerfilUsuarioRolConverter.
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    internal static class DPerfilUsuarioRolConverter
    {
        /// <summary>
        /// Method for convert entity class EPerfilUsuarioRol to DTO class DPerfilUsuarioRolDto.
        /// </summary>
        /// <param name="entity">The entity class EPerfilUsuarioRol.</param>
        /// <returns></returns>
        internal static DPerfilUsuarioRolDto ToDto(EPerfilUsuarioRol entity)
        {
            var dto = new DPerfilUsuarioRolDto();
            dto.Id = entity.Id;
            dto.Activo = entity.Activo;
            dto.Perfil = DPerfilConverter.ToDto(entity.Perfil);
            dto.Usuario = DUsuarioConverter.ToDto(entity.Usuario);
            dto.Rol = DRolConverter.ToDto(entity.Rol);
            return dto;
        }

        /// <summary>
        /// Method for convert list of entities classes EPerfilUsuarioRol to list of DTOs classes DPerfilUsuarioRolDto.
        /// </summary>
        /// <param name="entities">The list of entities classes EPerfilUsuarioRol.</param>
        /// <returns></returns>
        internal static List<DPerfilUsuarioRolDto> ToDtos(IList<EPerfilUsuarioRol> entities)
        {
            var dtos = new List<DPerfilUsuarioRolDto>();
            foreach (var entity in entities)
            {
                var dto = ToDto(entity);
                dtos.Add(dto);
            }
            return dtos;
        }

        /// <summary>
        /// Method for convert DTO class DPerfilUsuarioRolDto to entity class EPerfilUsuarioRol.
        /// </summary>
        /// <param name="dto">The DTO class DPerfilUsuarioRolDto.</param>
        /// <returns></returns>
        internal static EPerfilUsuarioRol ToEntity(DPerfilUsuarioRolDto dto)
        {
            var entity = new EPerfilUsuarioRol();
            entity.Id = dto.Id;
            entity.Activo = dto.Activo;
            entity.Perfil = DPerfilConverter.ToEntity(dto.Perfil);
            entity.Usuario = DUsuarioConverter.ToEntity(dto.Usuario);
            entity.Rol = DRolConverter.ToEntity(dto.Rol);
            return entity;
        }
    }
}