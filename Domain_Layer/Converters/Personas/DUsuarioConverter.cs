using Domain_Layer.Dtos.Personas;
using Entity_Layer.Entities.Personas;
using System.Collections.Generic;

namespace Domain_Layer.Converters.Personas
{
    /// <summary>
    /// Here is the Converter class DUsuarioConverter.
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    internal static class DUsuarioConverter
    {
        /// <summary>
        /// Method for convert entity class EUsuario to DTO class DUsuarioDto.
        /// </summary>
        /// <param name="entity">The entity class EUsuario.</param>
        /// <returns></returns>
        internal static DUsuarioDto ToDto(EUsuario entity)
        {
            var dto = new DUsuarioDto();
            dto.Id = entity.Id;
            dto.Usuario = entity.Usuario;
            dto.Contrasena = entity.Contrasena;
            dto.Caduca = entity.Caduca;
            dto.PeriodoCaducidad = entity.PeriodoCaducidad;
            dto.FechaUltimoCambio = entity.FechaUltimoCambio;
            dto.UnicoIngreso = entity.UnicoIngreso;
            dto.HaIngresado = entity.HaIngresado;
            dto.Tipo = entity.Tipo;
            dto.Estado = entity.Estado;
            dto.Persona = DPersonaConverter.ToDto(entity.Persona);
            return dto;
        }

        /// <summary>
        /// Method for convert list of entities classes EUsuario to list of DTOs classes DUsuarioDto.
        /// </summary>
        /// <param name="entities">The list of entities classes EUsuario.</param>
        /// <returns></returns>
        internal static List<DUsuarioDto> ToDtos(IList<EUsuario> entities)
        {
            var dtos = new List<DUsuarioDto>();
            foreach (var entity in entities)
            {
                var dto = ToDto(entity);
                dtos.Add(dto);
            }
            return dtos;
        }

        /// <summary>
        /// Method for convert DTO class DUsuarioDto to entity class EUsuario.
        /// </summary>
        /// <param name="dto">The DTO class DUsuarioDto.</param>
        /// <returns></returns>
        internal static EUsuario ToEntity(DUsuarioDto dto)
        {
            var entity = new EUsuario();
            entity.Id = dto.Id;
            entity.Usuario = dto.Usuario;
            entity.Contrasena = dto.Contrasena;
            entity.Caduca = dto.Caduca;
            entity.PeriodoCaducidad = dto.PeriodoCaducidad;
            entity.FechaUltimoCambio = dto.FechaUltimoCambio;
            entity.UnicoIngreso = dto.UnicoIngreso;
            entity.HaIngresado = dto.HaIngresado;
            entity.Tipo = dto.Tipo;
            entity.Estado = dto.Estado;
            entity.Persona = DPersonaConverter.ToEntity(dto.Persona);
            return entity;
        }
    }
}