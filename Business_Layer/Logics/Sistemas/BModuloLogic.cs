using Business_Layer.Logics.Sistemas;
using Domain_Layer.Dtos;
using Domain_Layer.Queries;
using System;
using System.Collections.Generic;

namespace Business_Layer.Logics
{
    public partial class BLogic : IBModuloLogic
    {
        public List<DModuloDto> Listar(DModuloDto dto)
        {
            List<DModuloDto> list = null;
            try
            {
                _moduloQuery = new DQuery();
                list = _moduloQuery.Listar(dto);
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}