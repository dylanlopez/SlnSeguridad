using Business_Layer.Logics.Personas;
using Domain_Layer.Dtos.Personas;
using Domain_Layer.Queries;
using System;
using System.Collections.Generic;

namespace Business_Layer.Logics
{
    public partial class BLogic : IBPersonaLogic
    {
        public DPersonaDto Buscar(DPersonaDto dto)
        {
            try
            {
                _personaQuery = new DQuery();
                return _personaQuery.Buscar(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}