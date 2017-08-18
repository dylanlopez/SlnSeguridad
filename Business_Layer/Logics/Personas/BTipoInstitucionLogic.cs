using Business_Layer.Logics.Personas;
using Domain_Layer.Dtos.Personas;
using Domain_Layer.Queries;
using System;
using System.Collections.Generic;

namespace Business_Layer.Logics
{
    public partial class BLogic : IBTipoInstitucionLogic
    {
        public int Actualizar(DTipoInstitucionDto dto)
        {
            try
            {
                _tipoInstitucionQuery = new DQuery();
                return _tipoInstitucionQuery.Actualizar(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DTipoInstitucionDto Buscar(DTipoInstitucionDto dto)
        {
            try
            {
                _tipoInstitucionQuery = new DQuery();
                return _tipoInstitucionQuery.Buscar(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Insertar(DTipoInstitucionDto dto)
        {
            try
            {
                _tipoInstitucionQuery = new DQuery();
                return _tipoInstitucionQuery.Insertar(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<DTipoInstitucionDto> Listar(DTipoInstitucionDto dto)
        {
            try
            {
                _tipoInstitucionQuery = new DQuery();
                return _tipoInstitucionQuery.Listar(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}