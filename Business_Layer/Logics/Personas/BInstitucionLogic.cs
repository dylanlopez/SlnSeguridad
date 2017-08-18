using Business_Layer.Logics.Personas;
using Domain_Layer.Dtos.Personas;
using Domain_Layer.Queries;
using System;
using System.Collections.Generic;

namespace Business_Layer.Logics
{
    public partial class BLogic : IBInstitucionLogic
    {
        public int Actualizar(DInstitucionDto dto)
        {
            try
            {
                _intitucionQuery = new DQuery();
                return _intitucionQuery.Actualizar(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DInstitucionDto Buscar(DInstitucionDto dto)
        {
            try
            {
                _intitucionQuery = new DQuery();
                return _intitucionQuery.Buscar(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Insertar(DInstitucionDto dto)
        {
            try
            {
                _intitucionQuery = new DQuery();
                return _intitucionQuery.Insertar(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<DInstitucionDto> Listar(DInstitucionDto dto)
        {
            try
            {
                _intitucionQuery = new DQuery();
                return _intitucionQuery.Listar(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}