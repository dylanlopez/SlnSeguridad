﻿using Business_Layer.Logics.Personas;
using Domain_Layer.Dtos.Personas;
using Domain_Layer.Queries;
using System;
using System.Collections.Generic;

namespace Business_Layer.Logics
{
    public partial class BLogic : IBPerfilLogic
    {
        public int Actualizar(DPerfilDto dto)
        {
            try
            {
                _perfilQuery = new DQuery();
                return _perfilQuery.Actualizar(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Insertar(DPerfilDto dto)
        {
            try
            {
                _perfilQuery = new DQuery();
                return _perfilQuery.Insertar(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<DPerfilDto> Listar(DPerfilDto dto)
        {
            try
            {
                _perfilQuery = new DQuery();
                return _perfilQuery.Listar(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}