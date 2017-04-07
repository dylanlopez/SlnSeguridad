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
            model.NumeroDocumento = dto.NumeroDocumento;
            model.ApellidoPaterno = dto.ApellidoPaterno;
            model.ApellidoMaterno = dto.ApellidoMaterno;
            model.Nombres = dto.Nombres;
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
    }
}