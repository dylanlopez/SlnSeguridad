using Business_Layer.Logics.Personas;
using Domain_Layer.Dtos.Personas;
using Domain_Layer.Queries;
using System;
using System.Collections.Generic;

namespace Business_Layer.Logics
{
    public partial class BLogic : IBProgramaSocialLogic
    {
        public int Actualizar(DProgramaSocialDto dto)
        {
            try
            {
                _programaSocialQuery = new DQuery();
                return _programaSocialQuery.Actualizar(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DProgramaSocialDto Buscar(DProgramaSocialDto dto)
        {
            try
            {
                _programaSocialQuery = new DQuery();
                return _programaSocialQuery.Buscar(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Eliminar(DProgramaSocialDto dto)
        {
            try
            {
                _programaSocialQuery = new DQuery();
                return _programaSocialQuery.Eliminar(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Insertar(DProgramaSocialDto dto)
        {
            try
            {
                _programaSocialQuery = new DQuery();
                return _programaSocialQuery.Insertar(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<DProgramaSocialDto> Listar(DProgramaSocialDto dto)
        {
            try
            {
                _programaSocialQuery = new DQuery();
                return _programaSocialQuery.Listar(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}