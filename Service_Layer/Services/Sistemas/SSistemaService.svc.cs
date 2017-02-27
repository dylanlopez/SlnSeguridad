﻿using Business_Layer.Logics;
using Business_Layer.Logics.Sistemas;
using Domain_Layer.Dtos.Sistemas;
using System;
using System.Collections.Generic;

namespace Service_Layer.Services.Sistemas
{
    public class SSistemaService : ISSistemaService
    {
        private IBSistemaLogic _sistemaLogic;

        public List<DSistemaDto> Listar(DSistemaDto dto)
        {
            List<DSistemaDto> list = null;
            try
            {
                _sistemaLogic = new BLogic();
                list = _sistemaLogic.Listar(dto);
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
