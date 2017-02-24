using Business_Layer.Logics;
using Business_Layer.Logics.Sistemas;
using Domain_Layer.Dtos;
using System;
using System.Collections.Generic;

namespace Service_Layer.Services.Sistemas
{
    public class SModuloService : ISModuloService
    {
        private IBModuloLogic _logic;

        public List<DModuloDto> Listar()
        {
            List<DModuloDto> list = null;
            try
            {
                _logic = new BLogic();
                list = _logic.Listar(new DModuloDto());
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
