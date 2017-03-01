using Business_Layer.Logics.Personas;
using Domain_Layer.Dtos.Personas;
using Domain_Layer.Queries;
using System;
using System.Collections.Generic;

namespace Business_Layer.Logics
{
    public partial class BLogic : IBPersonaLogic
    {
        public int Actualizar(DPersonaDto dto)
        {
            try
            {
                _personaQuery = new DQuery();
                return _personaQuery.Actualizar(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
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
        public int Eliminar(DPersonaDto dto)
        {
            try
            {
                _personaQuery = new DQuery();
                return _personaQuery.Eliminar(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Insertar(DPersonaDto dto)
        {
            try
            {
                _personaQuery = new DQuery();
                return _personaQuery.Insertar(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<DPersonaDto> Listar(DPersonaDto dto)
        {
            try
            {
                _personaQuery = new DQuery();
                return _personaQuery.Listar(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}