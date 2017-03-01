using Business_Layer.Logics.Personas;
using Domain_Layer.Dtos.Personas;
using Domain_Layer.Queries;
using System;
using System.Collections.Generic;

namespace Business_Layer.Logics
{
    public partial class BLogic : IBMenuRolLogic
    {
        public int Eliminar(DMenuRolDto dto)
        {
            try
            {
                _menuRolQuery = new DQuery();
                return _menuRolQuery.Eliminar(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Insertar(DMenuRolDto dto)
        {
            try
            {
                _menuRolQuery = new DQuery();
                return _menuRolQuery.Insertar(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<DMenuRolDto> Listar(DMenuRolDto dto)
        {
            try
            {
                _menuRolQuery = new DQuery();
                return _menuRolQuery.Listar(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}