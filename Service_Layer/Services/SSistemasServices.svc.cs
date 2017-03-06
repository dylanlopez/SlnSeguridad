using Business_Layer.Logics;
using Business_Layer.Logics.Sistemas;
using Domain_Layer.Dtos.Sistemas;
using System;
using System.Collections.Generic;

namespace Service_Layer.Services
{
    public class SSistemasServices : ISSistemasServices
    {
        private IBSistemaLogic _sistemaLogic;
        private IBModuloLogic _moduloLogic;
        private IBMenuLogic _menuLogic;

        #region Sistema
        public int ActualizarSistema(DSistemaDto dto)
        {
            try
            {
                _sistemaLogic = new BLogic();
                return _sistemaLogic.Actualizar(dto);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public DSistemaDto BuscarSistema(DSistemaDto dto)
        {
            try
            {
                _sistemaLogic = new BLogic();
                return _sistemaLogic.Buscar(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int InsertarSistema(DSistemaDto dto)
        {
            try
            {
                _sistemaLogic = new BLogic();
                return _sistemaLogic.Insertar(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<DSistemaDto> ListarSistemas(DSistemaDto dto)
        {
            try
            {
                _sistemaLogic = new BLogic();
                return _sistemaLogic.Listar(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Modulo
        public int ActualizarModulo(DModuloDto dto)
        {
            try
            {
                _moduloLogic = new BLogic();
                return _moduloLogic.Actualizar(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DModuloDto BuscarModulo(DModuloDto dto)
        {
            try
            {
                _moduloLogic = new BLogic();
                return _moduloLogic.Buscar(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int InsertarModulo(DModuloDto dto)
        {
            try
            {
                _moduloLogic = new BLogic();
                return _moduloLogic.Insertar(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<DModuloDto> ListarModulos(DModuloDto dto)
        {
            try
            {
                _moduloLogic = new BLogic();
                return _moduloLogic.Listar(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Menu
        public int ActualizarMenu(DMenuDto dto)
        {
            try
            {
                _menuLogic = new BLogic();
                return _menuLogic.Actualizar(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DMenuDto BuscarMenu(DMenuDto dto)
        {
            try
            {
                _menuLogic = new BLogic();
                return _menuLogic.Buscar(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int EliminarMenu(DMenuDto dto)
        {
            try
            {
                _menuLogic = new BLogic();
                return _menuLogic.Insertar(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int InsertarMenu(DMenuDto dto)
        {
            try
            {
                _menuLogic = new BLogic();
                return _menuLogic.Insertar(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<DMenuDto> ListarMenus(DMenuDto dto)
        {
            try
            {
                _menuLogic = new BLogic();
                return _menuLogic.Listar(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}