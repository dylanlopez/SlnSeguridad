using Domain_Layer.Dtos.Sistemas;
using Entity_Layer.Entities.Sistemas;
using System.Collections.Generic;

namespace Domain_Layer.Converters.Sistemas
{
    internal static class DMenuConverter
    {
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
        internal static EMenu ToEntity(DMenuDto dto)
        {
            var entity = new EMenu();
            entity.Id = dto.Id;
            entity.Codigo = dto.Codigo;
            entity.Nombre = dto.Nombre;
            entity.Ruta = dto.Ruta;
            entity.Descripcion = dto.Descripcion;
            entity.Estado = dto.Estado;
            entity.Modulo = DModuloConverter.ToEntity(dto.Modulo);
            return entity;
        }
    }
}