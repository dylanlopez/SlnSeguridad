using Business_Layer.Logics.Sistemas;
using Domain_Layer.Dtos.Sistemas;
using Domain_Layer.Queries;
using System;
using System.Collections.Generic;

namespace Business_Layer.Logics
{
    public partial class BLogic : IBSistemaLogic
    {
        public int Actualizar(DSistemaDto dto)
        {
            try
            {
                _sistemaQuery = new DQuery();
                return _sistemaQuery.Actualizar(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DSistemaDto Buscar(DSistemaDto dto)
        {
            try
            {
                _sistemaQuery = new DQuery();
                return _sistemaQuery.Buscar(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Insertar(DSistemaDto dto)
        {
            try
            {
                _sistemaQuery = new DQuery();
                return _sistemaQuery.Insertar(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<DSistemaDto> Listar(DSistemaDto dto)
        {
            try
            {
                _sistemaQuery = new DQuery();
                return _sistemaQuery.Listar(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}