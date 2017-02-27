using Domain_Layer.Dtos.Sistemas;
using Entity_Layer.Entities.Sistemas;
using System.Collections.Generic;

namespace Domain_Layer.Converters.Sistemas
{
    internal static class DModuloConverter
    {
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
        internal static EModulo ToEntity(DModuloDto dto)
        {
            var entity = new EModulo();
            entity.Id = dto.Id;
            entity.Codigo = dto.Codigo;
            entity.Nombre = dto.Nombre;
            entity.Abreviatura = dto.Abreviatura;
            entity.Descripcion = dto.Descripcion;
            entity.Estado = dto.Estado;
            entity.Sistema = DSistemaConverter.ToEntity(dto.Sistema);
            return entity;
        }
    }
}