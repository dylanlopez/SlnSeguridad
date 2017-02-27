using Business_Layer.Logics.Sistemas;
using Domain_Layer.Dtos.Sistemas;
using Domain_Layer.Queries;
using System;
using System.Collections.Generic;

namespace Business_Layer.Logics
{
    public partial class BLogic : IBMenuLogic
    {
        public int Actualizar(DMenuDto dto)
        {
            try
            {
                _menuQuery = new DQuery();
                return _menuQuery.Actualizar(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DMenuDto Buscar(DMenuDto dto)
        {
            try
            {
                _menuQuery = new DQuery();
                return _menuQuery.Buscar(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Eliminar(DMenuDto dto)
        {
            try
            {
                _menuQuery = new DQuery();
                return _menuQuery.Eliminar(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Insertar(DMenuDto dto)
        {
            try
            {
                _menuQuery = new DQuery();
                return _menuQuery.Insertar(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<DMenuDto> Listar(DMenuDto dto)
        {
            try
            {
                _menuQuery = new DQuery();
                return _menuQuery.Listar(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}