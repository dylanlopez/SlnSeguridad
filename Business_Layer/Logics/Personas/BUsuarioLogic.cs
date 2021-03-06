﻿using Business_Layer.Logics.Personas;
using Domain_Layer.Dtos.Personas;
using Domain_Layer.Queries;
using System;
using System.Collections.Generic;

namespace Business_Layer.Logics
{
    public partial class BLogic : IBUsuarioLogic
    {
        public int Actualizar(DUsuarioDto dto)
        {
            try
            {
                _usuarioQuery = new DQuery();
                return _usuarioQuery.Actualizar(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int ActualizarContrasena(DUsuarioDto dto)
        {
            try
            {
                _usuarioQuery = new DQuery();
                return _usuarioQuery.ActualizarContrasena(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int ActualizarEstado(DUsuarioDto dto)
        {
            try
            {
                _usuarioQuery = new DQuery();
                if (dto.HaIngresado == 'S')
                {
                    dto.HaIngresado = 'N';
                }
                else if (dto.HaIngresado == 'N')
                {
                    dto.HaIngresado = 'S';
                }
                return _usuarioQuery.ActualizarEstado(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DUsuarioDto Buscar(DUsuarioDto dto)
        {
            try
            {
                _usuarioQuery = new DQuery();
                return _usuarioQuery.Buscar(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DUsuarioDto BuscarPorUsuario(DUsuarioDto dto)
        {
            try
            {
                _usuarioQuery = new DQuery();
                return _usuarioQuery.BuscarPorUsuario(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Eliminar(DUsuarioDto dto)
        {
            try
            {
                _usuarioQuery = new DQuery();
                return _usuarioQuery.Eliminar(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Insertar(DUsuarioDto dto)
        {
            try
            {
                _usuarioQuery = new DQuery();
                return _usuarioQuery.Insertar(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<DUsuarioDto> Listar(DUsuarioDto dto)
        {
            try
            {
                _usuarioQuery = new DQuery();
                return _usuarioQuery.Listar(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}