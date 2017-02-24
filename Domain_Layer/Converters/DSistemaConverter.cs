using Domain_Layer.Dtos;
using Entity_Layer.Entities;
using System.Collections.Generic;

namespace Domain_Layer.Converters
{
    internal static class DSistemaConverter
    {
        internal static DSistemaDto ToDto(ESistema entity)
        {
            var dto = new DSistemaDto();
            dto.Id = entity.Id;
            dto.Codigo = entity.Codigo;
            dto.Nombre = entity.Nombre;
            dto.Abreviatura = entity.Abreviatura;
            dto.Descripcion = entity.Descripcion;
            dto.Estado = entity.Estado;
            return dto;
        }
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
        internal static ESistema ToEntity(DSistemaDto dto)
        {
            var entity = new ESistema();
            entity.Id = dto.Id;
            entity.Codigo = dto.Codigo;
            entity.Nombre = dto.Nombre;
            entity.Abreviatura = dto.Abreviatura;
            entity.Descripcion = dto.Descripcion;
            entity.Estado = dto.Estado;
            return entity;
        }
    }
}