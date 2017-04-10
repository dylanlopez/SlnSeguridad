using Business_Layer.Logics.Personas;
using Domain_Layer.Dtos.Personas;
using Domain_Layer.Queries;
using System;
using System.Collections.Generic;

namespace Business_Layer.Logics
{
    public partial class BLogic : IBPerfilUsuarioRolLogic
    {
        public int Actualizar(DPerfilUsuarioRolDto dto)
        {
            try
            {
                _perfilUsuarioRolQuery = new DQuery();
                return _perfilUsuarioRolQuery.Actualizar(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Insertar(DPerfilUsuarioRolDto dto)
        {
            try
            {
                _perfilUsuarioRolQuery = new DQuery();
                return _perfilUsuarioRolQuery.Insertar(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<DPerfilUsuarioRolDto> Listar(DPerfilUsuarioRolDto dto)
        {
            try
            {
                _perfilUsuarioRolQuery = new DQuery();
                return _perfilUsuarioRolQuery.Listar(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}