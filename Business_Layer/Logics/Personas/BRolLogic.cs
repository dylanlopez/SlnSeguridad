using Business_Layer.Logics.Personas;
using Domain_Layer.Dtos.Personas;
using Domain_Layer.Queries;
using System;
using System.Collections.Generic;

namespace Business_Layer.Logics
{
    public partial class BLogic : IBRolLogic
    {
        public int Actualizar(DRolDto dto)
        {
            try
            {
                _rolQuery = new DQuery();
                return _rolQuery.Actualizar(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DRolDto Buscar(DRolDto dto)
        {
            try
            {
                _rolQuery = new DQuery();
                return _rolQuery.Buscar(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Eliminar(DRolDto dto)
        {
            try
            {
                _rolQuery = new DQuery();
                return _rolQuery.Eliminar(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Insertar(DRolDto dto)
        {
            try
            {
                _rolQuery = new DQuery();
                return _rolQuery.Insertar(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<DRolDto> Listar(DRolDto dto)
        {
            try
            {
                _rolQuery = new DQuery();
                return _rolQuery.Listar(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}