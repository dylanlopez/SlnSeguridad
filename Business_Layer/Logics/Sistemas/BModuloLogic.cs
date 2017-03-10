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
    public partial class BLogic : IBModuloLogic
    {
        public int Actualizar(DModuloDto dto)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _moduloQuery = new DQuery();
                return _moduloQuery.Actualizar(dto);
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
        public DModuloDto Buscar(DModuloDto dto)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _moduloQuery = new DQuery();
                return _moduloQuery.Buscar(dto);
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
        public int Insertar(DModuloDto dto)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _moduloQuery = new DQuery();
                return _moduloQuery.Insertar(dto);
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
        public List<DModuloDto> Listar(DModuloDto dto)
        {
            if (_logger == null)
            {
                _logger = new Loggin(MethodBase.GetCurrentMethod(), new StackTrace());
            }
            try
            {
                _moduloQuery = new DQuery();
                return _moduloQuery.Listar(dto);
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