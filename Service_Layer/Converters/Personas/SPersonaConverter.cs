using Domain_Layer.Dtos.Personas;
using Service_Layer.Models.Personas;
using System.Collections.Generic;

namespace Service_Layer.Converters.Personas
{
    internal class SPersonaConverter
    {
        internal static PersonaModel ToModel(DPersonaDto dto)
        {
            var model = new PersonaModel();
            model.Id = dto.Id;
            model.Nombre = dto.Nombre;
            model.NumeroDocumento = dto.NumeroDocumento;
            model.Direccion = dto.Direccion;
            model.Telefono = dto.Telefono;
            model.Celular = dto.Celular;
            model.Email = dto.Email;
            model.Tipo = dto.Tipo;
            model.Ambito = dto.Ambito;
            model.TipoDocumentoPersona = STipoDocumentoPersonaConverter.ToModel(dto.TipoDocumentoPersona);
            return model;
        }

        internal static List<PersonaModel> ToModels(IList<DPersonaDto> dtos)
        {
            var models = new List<PersonaModel>();
            foreach (var dto in dtos)
            {
                var model = ToModel(dto);
                models.Add(model);
            }
            return models;
        }

        internal static DPersonaDto ToDto(PersonaModel model)
        {
            var dto = new DPersonaDto();
            dto.Id = model.Id;
            dto.Nombre = model.Nombre.ToUpper();
            dto.NumeroDocumento = model.NumeroDocumento.ToUpper();
            if (!string.IsNullOrEmpty(model.Direccion))
            {
                dto.Direccion = model.Direccion.ToUpper();
            }
            if (!string.IsNullOrEmpty(model.Telefono))
            {
                dto.Telefono = model.Telefono;
            }
            if (!string.IsNullOrEmpty(model.Celular))
            {
                dto.Celular = model.Celular;
            }
            if (!string.IsNullOrEmpty(model.Email))
            {
                dto.Email = model.Email;
            }
            dto.Tipo = model.Tipo;
            dto.Ambito = model.Ambito;
            dto.TipoDocumentoPersona = STipoDocumentoPersonaConverter.ToDto(model.TipoDocumentoPersona);
            return dto;
        }
    }
}