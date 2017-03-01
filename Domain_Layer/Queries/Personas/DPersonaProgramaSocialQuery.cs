using Domain_Layer.Converters.Personas;
using Domain_Layer.Dtos.Personas;
using Domain_Layer.Queries.Personas;
using Entity_Layer.Entities.Personas;
using NHibernate;
using System;
using System.Collections.Generic;

namespace Domain_Layer.Queries
{
    public partial class DQuery : IDPersonaProgramaSocialQuery
    {
        public int Eliminar(DPersonaProgramaSocialDto dto)
        {
            try
            {
                using (_sessionMidis = _sessionFactoryMidis.OpenSession())
                {
                    using (_transactionMidis = _sessionMidis.BeginTransaction())
                    {
                        _sessionMidis.Delete(DPersonaProgramaSocialConverter.ToEntity(dto));
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
        public int Insertar(DPersonaProgramaSocialDto dto)
        {
            try
            {
                using (_sessionMidis = _sessionFactoryMidis.OpenSession())
                {
                    using (_transactionMidis = _sessionMidis.BeginTransaction())
                    {
                        _sessionMidis.Save(DPersonaProgramaSocialConverter.ToEntity(dto));
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
        public List<DPersonaProgramaSocialDto> Listar(DPersonaProgramaSocialDto dto)
        {
            List<DPersonaProgramaSocialDto> list = null;
            try
            {
                using (_sessionMidis = _sessionFactoryMidis.OpenSession())
                {
                    using (_transactionMidis = _sessionMidis.BeginTransaction())
                    {
                        IQuery query = _sessionMidis.CreateQuery("FROM EPersonaProgramaSocial x " +
                                                                 "WHERE x.Persona.Id = COALESCE(:p_IdPersona, x.Persona.Id) " +
                                                                 "AND x.ProgramaSocial.Id = COALESCE(:p_IdProgramaSocial, x.ProgramaSocial.Id) ");
                        if (dto.Persona.Id != 0)
                        {
                            query.SetParameter("p_IdPersona", dto.Persona.Id);
                        }
                        else
                        {
                            query.SetParameter("p_IdPersona", null, NHibernateUtil.Int32);
                        }
                        if (dto.ProgramaSocial.Id != 0)
                        {
                            query.SetParameter("p_IdProgramaSocial", dto.ProgramaSocial.Id);
                        }
                        else
                        {
                            query.SetParameter("p_IdProgramaSocial", null, NHibernateUtil.Int32);
                        }
                        var result = query.List<EPersonaProgramaSocial>();
                        if (result != null)
                        {
                            list = DPersonaProgramaSocialConverter.ToDtos(result);
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