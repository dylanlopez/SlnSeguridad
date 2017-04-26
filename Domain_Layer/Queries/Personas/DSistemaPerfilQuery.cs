using Domain_Layer.Converters.Personas;
using Domain_Layer.Dtos.Personas;
using Domain_Layer.Queries.Personas;
using Entity_Layer.Entities.Personas;
using NHibernate;
using System;
using System.Collections.Generic;

namespace Domain_Layer.Queries
{
    public partial class DQuery : IDSistemaPerfilQuery
    {
        public int Actualizar(DSistemaPerfilDto dto)
        {
            try
            {
                using (_sessionMidis = _sessionFactoryMidis.OpenSession())
                {
                    using (_transactionMidis = _sessionMidis.BeginTransaction())
                    {
                        _sessionMidis.Update(DSistemaPerfilConverter.ToEntity(dto));
                        _transactionMidis.Commit();
                        return dto.Id;
                    }
                }
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
                using (_sessionMidis = _sessionFactoryMidis.OpenSession())
                {
                    using (_transactionMidis = _sessionMidis.BeginTransaction())
                    {
                        _sessionMidis.Save(DSistemaPerfilConverter.ToEntity(dto));
                        _sessionMidis.Flush();
                        _transactionMidis.Commit();
                        return dto.Id;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<DSistemaPerfilDto> Listar(DSistemaPerfilDto dto)
        {
            List<DSistemaPerfilDto> list = null;
            try
            {
                using (_sessionMidis = _sessionFactoryMidis.OpenSession())
                {
                    using (_transactionMidis = _sessionMidis.BeginTransaction())
                    {
                        IQuery query = _sessionMidis.CreateQuery("FROM ESistemaPerfil x " +
                                                                 "WHERE x.Sistema.Id = COALESCE(:p_IdSistema, x.Sistema.Id) " +
                                                                 "AND x.Perfil.Id = COALESCE(:p_IdPerfil, x.Perfil.Id) " +
                                                                 "ORDER BY x.Sistema.Nombre, x.Perfil.Nombre ");
                        if (dto.Sistema.Id != 0)
                        {
                            query.SetParameter("p_IdSistema", dto.Sistema.Id);
                        }
                        else
                        {
                            query.SetParameter("p_IdSistema", null, NHibernateUtil.Int32);
                        }
                        if (dto.Perfil.Id != 0)
                        {
                            query.SetParameter("p_IdPerfil", dto.Perfil.Id);
                        }
                        else
                        {
                            query.SetParameter("p_IdPerfil", null, NHibernateUtil.Int32);
                        }
                        var result = query.List<ESistemaPerfil>();
                        if (result != null)
                        {
                            list = DSistemaPerfilConverter.ToDtos(result);
                        }
                        return list;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}