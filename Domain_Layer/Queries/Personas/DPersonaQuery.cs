using Domain_Layer.Converters.Personas;
using Domain_Layer.Dtos.Personas;
using Domain_Layer.Queries.Personas;
using Entity_Layer.Entities.Personas;
using NHibernate;
using System;
using System.Collections.Generic;

namespace Domain_Layer.Queries
{
    public partial class DQuery : IDPersonaQuery
    {
        public int Actualizar(DPersonaDto dto)
        {
            try
            {
                using (_sessionMidis = _sessionFactoryMidis.OpenSession())
                {
                    using (_transactionMidis = _sessionMidis.BeginTransaction())
                    {
                        _sessionMidis.Update(DPersonaConverter.ToEntity(dto));
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
        public DPersonaDto Buscar(DPersonaDto dto)
        {
            DPersonaDto item = null;
            try
            {
                using (_sessionMidis = _sessionFactoryMidis.OpenSession())
                {
                    using (_transactionMidis = _sessionMidis.BeginTransaction())
                    {
                        IQuery query = _sessionMidis.CreateQuery("FROM EPersona x " +
                                                                 "WHERE x.Id = :p_Id " +
                                                                 "OR x.NumeroDocumento = :p_NumeroDocumento");
                        query.SetParameter("p_Id", dto.Id);
                        query.SetParameter("p_NumeroDocumento", dto.NumeroDocumento);
                        var result = query.List<EPersona>();
                        if (result != null)
                        {
                            if (result.Count > 0)
                            {
                                item = DPersonaConverter.ToDto(result[0]);
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
        public int Eliminar(DPersonaDto dto)
        {
            try
            {
                using (_sessionMidis = _sessionFactoryMidis.OpenSession())
                {
                    using (_transactionMidis = _sessionMidis.BeginTransaction())
                    {
                        _sessionMidis.Delete(DPersonaConverter.ToEntity(dto));
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
        public int Insertar(DPersonaDto dto)
        {
            try
            {
                using (_sessionMidis = _sessionFactoryMidis.OpenSession())
                {
                    using (_transactionMidis = _sessionMidis.BeginTransaction())
                    {
                        _sessionMidis.Save(DPersonaConverter.ToEntity(dto));
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
        public List<DPersonaDto> Listar(DPersonaDto dto)
        {
            List<DPersonaDto> list = null;
            try
            {
                using (_sessionMidis = _sessionFactoryMidis.OpenSession())
                {
                    using (_transactionMidis = _sessionMidis.BeginTransaction())
                    {
                        IQuery query = _sessionMidis.CreateQuery("FROM EPersona x " +
                                                                 "WHERE x.Tipo = COALESCE(:p_Tipo, x.Tipo) " +
                                                                 "AND x.Nombre LIKE CONCAT('%', COALESCE(:p_Nombre, x.Nombre), '%') " +
                                                                 "AND x.TipoDocumentoPersona.Id = COALESCE(:p_IdTipoDocumentoPersona, x.TipoDocumentoPersona.Id)");
                        if (dto.Tipo != '\0')
                        {
                            query.SetParameter("p_Tipo", dto.Tipo);
                        }
                        else
                        {
                            query.SetParameter("p_Tipo", null, NHibernateUtil.Character);
                        }
                        if (!dto.Nombre.Equals(String.Empty))
                        {
                            query.SetParameter("p_Nombre", dto.Nombre.ToUpper());
                        }
                        else
                        {
                            query.SetParameter("p_Nombre", null, NHibernateUtil.String);
                        }
                        if (dto.TipoDocumentoPersona.Id != 0)
                        {
                            query.SetParameter("p_IdTipoDocumentoPersona", dto.TipoDocumentoPersona.Id);
                        }
                        else
                        {
                            query.SetParameter("p_IdTipoDocumentoPersona", null, NHibernateUtil.Int32);
                        }
                        var result = query.List<EPersona>();
                        if (result != null)
                        {
                            list = DPersonaConverter.ToDtos(result);
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