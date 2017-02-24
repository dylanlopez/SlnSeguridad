using Business_Layer.Logics.Sistemas;
using Domain_Layer.Dtos;
using Domain_Layer.Queries;
using System;
using System.Collections.Generic;

namespace Business_Layer.Logics
{
    public partial class BLogic : IBSistemaLogic
    {
        public List<DSistemaDto> Listar(DSistemaDto dto)
        {
            List<DSistemaDto> list = null;
            try
            {
                _sistemaQuery = new DQuery();
                list = _sistemaQuery.Listar(dto);
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}