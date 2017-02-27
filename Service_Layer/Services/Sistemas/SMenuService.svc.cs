using Business_Layer.Logics;
using Business_Layer.Logics.Sistemas;
using Domain_Layer.Dtos.Sistemas;
using System;
using System.Collections.Generic;

namespace Service_Layer.Services.Sistemas
{
    public class SMenuService : ISMenuService
    {
        private IBMenuLogic _menuLogic;

        public List<DMenuDto> Listar()
        {
            List<DMenuDto> list = null;
            try
            {
                _menuLogic = new BLogic();
                list = _menuLogic.Listar(new DMenuDto());
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}