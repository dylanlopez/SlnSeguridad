using Domain_Layer.Dtos.Personas;
using Service_Layer.Models.Personas;
using System.Collections.Generic;

namespace Service_Layer.Converters.Personas
{
    internal class STipoDocumentoPersonaConverter
    {
        internal static TipoDocumentoPersonaModel ToModel(DTipoDocumentoPersonaDto dto)
        {
            var model = new TipoDocumentoPersonaModel();
            model.Id = dto.Id;
            model.Codigo = dto.Codigo;
            model.Nombre = dto.Nombre;
            model.Descripcion = dto.Descripcion;
            return model;
        }

        internal static List<TipoDocumentoPersonaModel> ToModels(IList<DTipoDocumentoPersonaDto> dtos)
        {
            var models = new List<TipoDocumentoPersonaModel>();
            foreach (var dto in dtos)
            {
                var model = ToModel(dto);
                models.Add(model);
            }
            return models;
        }

        internal static DTipoDocumentoPersonaDto ToDto(TipoDocumentoPersonaModel model)
        {
            var dto = new DTipoDocumentoPersonaDto();
            dto.Id = model.Id;
            dto.Codigo = model.Codigo.ToUpper();
            dto.Nombre = model.Nombre.ToUpper();
            if (!string.IsNullOrEmpty(model.Descripcion))
            {
                dto.Descripcion = model.Descripcion.ToUpper();
            }
            return dto;
        }
    }
}