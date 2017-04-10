using Business_Layer.Logics.Personas;
using Domain_Layer.Dtos.Personas;
using Domain_Layer.Queries;
using System;
using System.Collections.Generic;

namespace Business_Layer.Logics
{
    public partial class BLogic : IBSistemaPerfilLogic
    {
        public int Actualizar(DSistemaPerfilDto dto)
        {
            try
            {
                _sistemaPerfilQuery = new DQuery();
                return _sistemaPerfilQuery.Actualizar(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Insertar(DSistemaPerfilDto dto)
        {
            try
            {
                _sistemaPerfilQuery = new DQuery();
                return _sistemaPerfilQuery.Insertar(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<DSistemaPerfilDto> Listar(DSistemaPerfilDto dto)
        {
            try
            {
                _sistemaPerfilQuery = new DQuery();
                return _sistemaPerfilQuery.Listar(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}