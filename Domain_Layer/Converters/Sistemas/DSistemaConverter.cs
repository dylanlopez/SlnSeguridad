using Domain_Layer.Dtos.Sistemas;
using Entity_Layer.Entities.Sistemas;
using System.Collections.Generic;

namespace Domain_Layer.Converters.Sistemas
{
    /// <summary>
    /// Here is the Converter class DSistemaConverter.
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    internal static class DSistemaConverter
    {
        /// <summary>
        /// Method for convert entity class ESistema to DTO class DSistemaDto.
        /// </summary>
        /// <param name="entity">The entity class ESistema.</param>
        /// <returns></returns>
        internal static DSistemaDto ToDto(ESistema entity)
        {
            var dto = new DSistemaDto();
            dto.Id = entity.Id;
            dto.Codigo = entity.Codigo;
            dto.Nombre = entity.Nombre;
            dto.Abreviatura = entity.Abreviatura;
            dto.Activo = entity.Activo;
            dto.Descripcion = entity.Descripcion;
            dto.NombreServidor = entity.NombreServidor;
            dto.IPServidor = entity.IPServidor;
            dto.RutaFisica = entity.RutaFisica;
            dto.RutaLogica = entity.RutaLogica;
            return dto;
        }

        /// <summary>
        /// Method for convert list of entities classes ESistema to list of DTOs classes DSistemaDto.
        /// </summary>
        /// <param name="entities">The list of entities classes ESistema.</param>
        /// <returns></returns>
        internal static List<DSistemaDto> ToDtos(IList<ESistema> entities)
        {
            var dtos = new List<DSistemaDto>();
            foreach(var entity in entities)
            {
                var dto = ToDto(entity);
                dtos.Add(dto);
            }
            return dtos;
        }

        /// <summary>
        /// Method for convert DTO class DSistemaDto to entity class ESistema.
        /// </summary>
        /// <param name="dto">The DTO class DSistemaDto.</param>
        /// <returns></returns>
        internal static ESistema ToEntity(DSistemaDto dto)
        {
            var entity = new ESistema();
            entity.Id = dto.Id;
            entity.Codigo = dto.Codigo.ToUpper();
            entity.Nombre = dto.Nombre.ToUpper();
            entity.Abreviatura = dto.Abreviatura.ToUpper();
            entity.Activo = dto.Activo;
            if (!string.IsNullOrEmpty(dto.Descripcion))
            {
                entity.Descripcion = dto.Descripcion.ToUpper();
            }
            else
            {
                entity.Descripcion = string.Empty;
            }
            if (!string.IsNullOrEmpty(dto.NombreServidor))
            {
                entity.NombreServidor = dto.NombreServidor;
            }
            else
            {
                entity.NombreServidor = string.Empty;
            }
            if (!string.IsNullOrEmpty(dto.IPServidor))
            {
                entity.IPServidor = dto.IPServidor;
            }
            else
            {
                entity.IPServidor = string.Empty;
            }
            if (!string.IsNullOrEmpty(dto.RutaFisica))
            {
                entity.RutaFisica = dto.RutaFisica;
            }
            else
            {
                entity.RutaFisica = string.Empty;
            }
            if (!string.IsNullOrEmpty(dto.RutaLogica))
            {
                entity.RutaLogica = dto.RutaLogica;
            }
            else
            {
                entity.RutaLogica = string.Empty;
            }
            return entity;
        }
    }
}