using Domain_Layer.Dtos.Sistemas;
using Entity_Layer.Entities.Sistemas;
using System.Collections.Generic;

namespace Domain_Layer.Converters.Sistemas
{
    /// <summary>
    /// Here is the Converter class DModuloConverter.
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    internal static class DModuloConverter
    {
        /// <summary>
        /// Method for convert entity class EModulo to DTO class DModuloDto.
        /// </summary>
        /// <param name="entity">The entity class EModulo.</param>
        /// <returns></returns>
        internal static DModuloDto ToDto(EModulo entity)
        {
            var dto = new DModuloDto();
            dto.Id = entity.Id;
            dto.Codigo = entity.Codigo;
            dto.Nombre = entity.Nombre;
            dto.Abreviatura = entity.Abreviatura;
            dto.Descripcion = entity.Descripcion;
            dto.Estado = entity.Estado;
            dto.Sistema = DSistemaConverter.ToDto(entity.Sistema);
            return dto;
        }

        /// <summary>
        /// Method for convert list of entities classes EModulo to list of DTOs classes DModuloDto.
        /// </summary>
        /// <param name="entities">The list of entities classes EModulo.</param>
        /// <returns></returns>
        internal static List<DModuloDto> ToDtos(IList<EModulo> entities)
        {
            var dtos = new List<DModuloDto>();
            foreach (var entity in entities)
            {
                var dto = ToDto(entity);
                dtos.Add(dto);
            }
            return dtos;
        }

        /// <summary>
        /// Method for convert DTO class DModuloDto to entity class EModulo.
        /// </summary>
        /// <param name="dto">The DTO class DModuloDto.</param>
        /// <returns></returns>
        internal static EModulo ToEntity(DModuloDto dto)
        {
            var entity = new EModulo();
            entity.Id = dto.Id;
            entity.Codigo = dto.Codigo.ToUpper();
            entity.Nombre = dto.Nombre.ToUpper();
            entity.Abreviatura = dto.Abreviatura.ToUpper();
            //if(dto.Descripcion == null){
            //    dto.Descripcion = string.Empty;
            //}
            entity.Descripcion = dto.Descripcion.ToUpper();
            entity.Estado = dto.Estado;
            entity.Sistema = DSistemaConverter.ToEntity(dto.Sistema);
            return entity;
        }
    }
}