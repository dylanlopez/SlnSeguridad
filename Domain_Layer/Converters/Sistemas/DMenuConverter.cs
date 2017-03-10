using Domain_Layer.Dtos.Sistemas;
using Entity_Layer.Entities.Sistemas;
using System.Collections.Generic;

namespace Domain_Layer.Converters.Sistemas
{
    /// <summary>
    /// Here is the Converter class DMenuConverter.
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    internal static class DMenuConverter
    {
        /// <summary>
        /// Method for convert entity class EMenu to DTO class DMenuDto.
        /// </summary>
        /// <param name="entity">The entity class EMenu.</param>
        /// <returns></returns>
        internal static DMenuDto ToDto(EMenu entity)
        {
            var dto = new DMenuDto();
            dto.Id = entity.Id;
            dto.Codigo = entity.Codigo;
            dto.Nombre = entity.Nombre;
            dto.Ruta = entity.Ruta;
            dto.Descripcion = entity.Descripcion;
            dto.Estado = entity.Estado;
            dto.Modulo = DModuloConverter.ToDto(entity.Modulo);
            return dto;
        }

        /// <summary>
        /// Method for convert list of entities classes EMenu to list of DTOs classes DMenuDto.
        /// </summary>
        /// <param name="entities">The list of entities classes EMenu.</param>
        /// <returns></returns>
        internal static List<DMenuDto> ToDtos(IList<EMenu> entities)
        {
            var dtos = new List<DMenuDto>();
            foreach (var entity in entities)
            {
                var dto = ToDto(entity);
                dtos.Add(dto);
            }
            return dtos;
        }

        /// <summary>
        /// Method for convert DTO class DMenuDto to entity class EMenu.
        /// </summary>
        /// <param name="dto">The DTO class DMenuDto.</param>
        /// <returns></returns>
        internal static EMenu ToEntity(DMenuDto dto)
        {
            var entity = new EMenu();
            entity.Id = dto.Id;
            entity.Codigo = dto.Codigo.ToUpper();
            entity.Nombre = dto.Nombre.ToUpper();
            entity.Ruta = dto.Ruta;
            entity.Descripcion = dto.Descripcion.ToUpper();
            entity.Estado = dto.Estado;
            entity.Modulo = DModuloConverter.ToEntity(dto.Modulo);
            return entity;
        }
    }
}