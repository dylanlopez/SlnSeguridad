using Domain_Layer.Dtos.Sistemas;
using Service_Layer.Models.Sistemas;
using System.Collections.Generic;

namespace Service_Layer.Converters.Sistemas
{
    internal static class SSistemaConverter
    {
        internal static SistemaModel ToModel(DSistemaDto dto)
        {
            var model = new SistemaModel();
            model.Id = dto.Id;
            model.Codigo = dto.Codigo;
            model.Nombre = dto.Nombre;
            model.Abreviatura = dto.Abreviatura;
            model.Activo = dto.Activo;
            model.Descripcion = dto.Descripcion;
            model.NombreServidor = dto.NombreServidor;
            model.IPServidor = dto.IPServidor;
            model.RutaFisica = dto.RutaFisica;
            model.RutaLogica = dto.RutaLogica;
            return model;
        }

        internal static List<SistemaModel> ToModels(IList<DSistemaDto> dtos)
        {
            var models = new List<SistemaModel>();
            foreach (var dto in dtos)
            {
                var model = ToModel(dto);
                models.Add(model);
            }
            return models;
        }

        internal static DSistemaDto ToDto(SistemaModel model)
        {
            var dto = new DSistemaDto();
            dto.Id = model.Id;
            dto.Codigo = model.Codigo;
            dto.Nombre = model.Nombre;
            dto.Abreviatura = model.Abreviatura;
            dto.Activo = model.Activo;
            if (!string.IsNullOrEmpty(model.Descripcion))
            {
                dto.Descripcion = model.Descripcion;
            }
            if (!string.IsNullOrEmpty(model.NombreServidor))
            {
                dto.NombreServidor = model.NombreServidor;
            }
            if (!string.IsNullOrEmpty(model.IPServidor))
            {
                dto.IPServidor = model.IPServidor;
            }
            if (!string.IsNullOrEmpty(model.RutaFisica))
            {
                dto.RutaFisica = model.RutaFisica;
            }
            if (!string.IsNullOrEmpty(model.RutaLogica))
            {
                dto.RutaLogica = model.RutaLogica;
            }
            return dto;
        }
    }
}