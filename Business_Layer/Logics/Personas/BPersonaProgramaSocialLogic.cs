using Business_Layer.Logics.Personas;
using Domain_Layer.Dtos.Personas;
using Domain_Layer.Queries;
using System;
using System.Collections.Generic;

namespace Business_Layer.Logics
{
    public partial class BLogic : IBPersonaProgramaSocialLogic
    {
        public int Eliminar(DPersonaProgramaSocialDto dto)
        {
            try
            {
                _personaProgramaSocialQuery = new DQuery();
                return _personaProgramaSocialQuery.Eliminar(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Insertar(DPersonaProgramaSocialDto dto)
        {
            try
            {
                _personaProgramaSocialQuery = new DQuery();
                return _personaProgramaSocialQuery.Insertar(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<DPersonaProgramaSocialDto> Listar(DPersonaProgramaSocialDto dto)
        {
            try
            {
                _personaProgramaSocialQuery = new DQuery();
                return _personaProgramaSocialQuery.Listar(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}