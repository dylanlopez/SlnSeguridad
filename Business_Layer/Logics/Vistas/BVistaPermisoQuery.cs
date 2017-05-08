using Business_Layer.Logics.Vistas;
using Domain_Layer.Dtos.Vistas;
using Domain_Layer.Queries;
using System;
using System.Collections.Generic;

namespace Business_Layer.Logics
{
    public partial class BLogic : IBVistaPermisoQuery
    {
        public List<DVistaPermisoDto> Listar(DVistaPermisoDto dto)
        {
            try
            {
                _vistaPermisoQuery = new DQuery();
                return _vistaPermisoQuery.Listar(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}