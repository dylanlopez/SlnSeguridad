using Business_Layer.Logics.Sistemas;
using Domain_Layer.Dtos.Sistemas;
using Domain_Layer.Queries;
using Logging_Layer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace Business_Layer.Logics
{
    public partial class BLogic : IBOpcionLogic
    {
        public int Actualizar(DOpcionDto dto)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _opcionQuery = new DQuery();
                return _opcionQuery.Actualizar(dto);
            }
            catch (Exception ex)
            {
                _logger.WriteErrorLog(ex);
                throw ex;
            }
            finally
            {
                _logger = null;
            }
        }
        public DOpcionDto Buscar(DOpcionDto dto)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _opcionQuery = new DQuery();
                return _opcionQuery.Buscar(dto);
            }
            catch (Exception ex)
            {
                _logger.WriteErrorLog(ex);
                throw ex;
            }
            finally
            {
                _logger = null;
            }
        }
        public int Eliminar(DOpcionDto dto)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _opcionQuery = new DQuery();
                return _opcionQuery.Eliminar(dto);
            }
            catch (Exception ex)
            {
                _logger.WriteErrorLog(ex);
                throw ex;
            }
            finally
            {
                _logger = null;
            }
        }
        public int Insertar(DOpcionDto dto)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _opcionQuery = new DQuery();
                return _opcionQuery.Insertar(dto);
            }
            catch (Exception ex)
            {
                _logger.WriteErrorLog(ex);
                throw ex;
            }
            finally
            {
                _logger = null;
            }
        }
        public List<DOpcionDto> Listar(DOpcionDto dto)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _opcionQuery = new DQuery();
                return _opcionQuery.Listar(dto);
            }
            catch (Exception ex)
            {
                _logger.WriteErrorLog(ex);
                throw ex;
            }
            finally
            {
                _logger = null;
            }
        }
    }
}