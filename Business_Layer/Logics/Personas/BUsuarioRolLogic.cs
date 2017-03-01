using Business_Layer.Logics.Personas;
using Domain_Layer.Dtos.Personas;
using Domain_Layer.Queries;
using System;
using System.Collections.Generic;

namespace Business_Layer.Logics
{
    public partial class BLogic : IBUsuarioRolLogic
    {
        public int Eliminar(DUsuarioRolDto dto)
        {
            try
            {
                _usuarioRolQuery = new DQuery();
                return _usuarioRolQuery.Eliminar(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Insertar(DUsuarioRolDto dto)
        {
            try
            {
                _usuarioRolQuery = new DQuery();
                return _usuarioRolQuery.Insertar(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<DUsuarioRolDto> Listar(DUsuarioRolDto dto)
        {
            try
            {
                _usuarioRolQuery = new DQuery();
                return _usuarioRolQuery.Listar(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}