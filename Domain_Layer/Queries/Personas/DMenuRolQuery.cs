using Domain_Layer.Converters.Personas;
using Domain_Layer.Dtos.Personas;
using Domain_Layer.Queries.Personas;
using Entity_Layer.Entities.Personas;
using NHibernate;
using System;
using System.Collections.Generic;


namespace Domain_Layer.Queries
{
    public partial class DQuery : IDMenuRolQuery
    {
        public int Eliminar(DMenuRolDto dto)
        {
            try
            {
                using (_sessionMidis = _sessionFactoryMidis.OpenSession())
                {
                    using (_transactionMidis = _sessionMidis.BeginTransaction())
                    {
                        _sessionMidis.Delete(DMenuRolConverter.ToEntity(dto));
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
        public int Insertar(DMenuRolDto dto)
        {
            try
            {
                using (_sessionMidis = _sessionFactoryMidis.OpenSession())
                {
                    using (_transactionMidis = _sessionMidis.BeginTransaction())
                    {
                        _sessionMidis.Save(DMenuRolConverter.ToEntity(dto));
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
        public List<DMenuRolDto> Listar(DMenuRolDto dto)
        {
            List<DMenuRolDto> list = null;
            try
            {
                using (_sessionMidis = _sessionFactoryMidis.OpenSession())
                {
                    using (_transactionMidis = _sessionMidis.BeginTransaction())
                    {
                        IQuery query = _sessionMidis.CreateQuery("FROM EMenuRol x " +
                                                                 "WHERE x.Menu.Id = COALESCE(:p_IdMenu, x.Menu.Id) " +
                                                                 "AND x.Rol.Id = COALESCE(:p_IdRol, x.Rol.Id) ");
                        if (dto.Menu.Id != 0)
                        {
                            query.SetParameter("p_IdMenu", dto.Menu.Id);
                        }
                        else
                        {
                            query.SetParameter("p_IdMenu", null, NHibernateUtil.Int32);
                        }
                        if (dto.Rol.Id != 0)
                        {
                            query.SetParameter("p_IdRol", dto.Rol.Id);
                        }
                        else
                        {
                            query.SetParameter("p_IdRol", null, NHibernateUtil.Int32);
                        }
                        var result = query.List<EMenuRol>();
                        if (result != null)
                        {
                            list = DMenuRolConverter.ToDtos(result);
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