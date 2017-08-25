using Business_Layer.Logics.Personas;
using Domain_Layer.Dtos.Personas;
using Domain_Layer.Queries;
using System;
using System.Collections.Generic;

namespace Business_Layer.Logics        
{
    public partial class BLogic : IBPermisoLogic
    {
        public int Actualizar(DPermisoDto dto)
        {
            try
            {
                _permisoQuery = new DQuery();
                return _permisoQuery.Actualizar(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Eliminar(DPermisoDto dto)
        {
            try
            {
                _permisoQuery = new DQuery();
                return _permisoQuery.Eliminar(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Insertar(DPermisoDto dto)
        {
            try
            {
                _permisoQuery = new DQuery();
                return _permisoQuery.Insertar(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<DPermisoDto> Listar(DPermisoDto dto)
        {
            try
            {
                _permisoQuery = new DQuery();
                return _permisoQuery.Listar(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}