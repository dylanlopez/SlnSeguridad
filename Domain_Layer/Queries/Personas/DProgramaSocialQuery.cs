using Domain_Layer.Converters.Personas;
using Domain_Layer.Dtos.Personas;
using Domain_Layer.Queries.Personas;
using Entity_Layer.Entities.Personas;
using NHibernate;
using System;
using System.Collections.Generic;

namespace Domain_Layer.Queries
{
    public partial class DQuery : IDProgramaSocialQuery
    {
        public int Actualizar(DProgramaSocialDto dto)
        {
            try
            {
                using (_sessionMidis = _sessionFactoryMidis.OpenSession())
                {
                    using (_transactionMidis = _sessionMidis.BeginTransaction())
                    {
                        _sessionMidis.Update(DProgramaSocialConverter.ToEntity(dto));
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
        public DProgramaSocialDto Buscar(DProgramaSocialDto dto)
        {
            DProgramaSocialDto item = null;
            try
            {
                using (_sessionMidis = _sessionFactoryMidis.OpenSession())
                {
                    using (_transactionMidis = _sessionMidis.BeginTransaction())
                    {
                        IQuery query = _sessionMidis.CreateQuery("FROM EProgramaSocial x " +
                                                                 "WHERE x.Id = :p_Id " +
                                                                 "OR x.Codigo = :p_Codigo");
                        query.SetParameter("p_Id", dto.Id);
                        query.SetParameter("p_Codigo", dto.Codigo);
                        var result = query.List<EProgramaSocial>();
                        if (result != null)
                        {
                            if (result.Count > 0)
                            {
                                item = DProgramaSocialConverter.ToDto(result[0]);
                            }
                        }
                        return item;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Eliminar(DProgramaSocialDto dto)
        {
            try
            {
                using (_sessionMidis = _sessionFactoryMidis.OpenSession())
                {
                    using (_transactionMidis = _sessionMidis.BeginTransaction())
                    {
                        _sessionMidis.Delete(DProgramaSocialConverter.ToEntity(dto));
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
        public int Insertar(DProgramaSocialDto dto)
        {
            try
            {
                using (_sessionMidis = _sessionFactoryMidis.OpenSession())
                {
                    using (_transactionMidis = _sessionMidis.BeginTransaction())
                    {
                        _sessionMidis.Save(DProgramaSocialConverter.ToEntity(dto));
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
        public List<DProgramaSocialDto> Listar(DProgramaSocialDto dto)
        {
            List<DProgramaSocialDto> list = null;
            try
            {
                using (_sessionMidis = _sessionFactoryMidis.OpenSession())
                {
                    using (_transactionMidis = _sessionMidis.BeginTransaction())
                    {
                        IQuery query = _sessionMidis.CreateQuery("FROM EProgramaSocial x " +
                                                                 "WHERE x.Estado = COALESCE(:p_Estado, x.Estado) ");
                        if (dto.Estado != '\0')
                        {
                            query.SetParameter("p_Estado", dto.Estado);
                        }
                        else
                        {
                            query.SetParameter("p_Estado", null, NHibernateUtil.Character);
                        }
                        var result = query.List<EProgramaSocial>();
                        if (result != null)
                        {
                            list = DProgramaSocialConverter.ToDtos(result);
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