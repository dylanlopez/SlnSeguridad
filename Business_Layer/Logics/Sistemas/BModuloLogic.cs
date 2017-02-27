using Business_Layer.Logics.Sistemas;
using Domain_Layer.Dtos.Sistemas;
using Domain_Layer.Queries;
using System;
using System.Collections.Generic;

namespace Business_Layer.Logics
{
    public partial class BLogic : IBModuloLogic
    {
        public int Actualizar(DModuloDto dto)
        {
            try
            {
                _moduloQuery = new DQuery();
                return _moduloQuery.Actualizar(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DModuloDto Buscar(DModuloDto dto)
        {
            try
            {
                _moduloQuery = new DQuery();
                return _moduloQuery.Buscar(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Insertar(DModuloDto dto)
        {
            try
            {
                _moduloQuery = new DQuery();
                return _moduloQuery.Insertar(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<DModuloDto> Listar(DModuloDto dto)
        {
            try
            {
                _moduloQuery = new DQuery();
                return _moduloQuery.Listar(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}