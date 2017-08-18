using Domain_Layer.Dtos.Personas;
using Entity_Layer.Entities.Personas;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Domain_Layer.Converters.Personas
{
    /// <summary>
    /// Here is the Converter class DUsuarioConverter.
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    internal static class DUsuarioConverter
    {
        /// <summary>
        /// Method for convert entity class EUsuario to DTO class DUsuarioDto.
        /// </summary>
        /// <param name="entity">The entity class EUsuario.</param>
        /// <returns></returns>
        internal static DUsuarioDto ToDto(EUsuario entity)
        {
            var dto = new DUsuarioDto();
            dto.Id = entity.Id;
            dto.Usuario = entity.Usuario;
            dto.Contrasena = entity.Contrasena;
            dto.ApellidoPaterno = entity.ApellidoPaterno;
            dto.ApellidoMaterno = entity.ApellidoMaterno;
            dto.Nombres = entity.Nombres;
            dto.Caduca = entity.Caduca;
            dto.PeriodoCaducidad = entity.PeriodoCaducidad;
            //dto.FechaUltimoCambio = entity.FechaUltimoCambio.ToShortDateString();
            dto.FechaUltimoCambio = entity.FechaUltimoCambio.ToString();
            //dto.FechaUltimoCambio = entity.FechaUltimoCambio;
            dto.Ubigeo = entity.Ubigeo;
            dto.CodigoVersion = entity.CodigoVersion;
            dto.PrimeraVez = entity.PrimeraVez;
            dto.UnicoIngreso = entity.UnicoIngreso;
            dto.HaIngresado = entity.HaIngresado;
            dto.OtrosLogeos = entity.OtrosLogeos;
            dto.Tipo = entity.Tipo;
            dto.Activo = entity.Activo;
            dto.Email = entity.Email;
            if (entity.Institucion != null)
            {
                dto.Institucion = DInstitucionConverter.ToDto(entity.Institucion);
            }
            return dto;
        }

        /// <summary>
        /// Method for convert list of entities classes EUsuario to list of DTOs classes DUsuarioDto.
        /// </summary>
        /// <param name="entities">The list of entities classes EUsuario.</param>
        /// <returns></returns>
        internal static List<DUsuarioDto> ToDtos(IList<EUsuario> entities)
        {
            var dtos = new List<DUsuarioDto>();
            foreach (var entity in entities)
            {
                var dto = ToDto(entity);
                dtos.Add(dto);
            }
            return dtos;
        }

        /// <summary>
        /// Method for convert DTO class DUsuarioDto to entity class EUsuario.
        /// </summary>
        /// <param name="dto">The DTO class DUsuarioDto.</param>
        /// <returns></returns>
        internal static EUsuario ToEntity(DUsuarioDto dto)
        {
            var entity = new EUsuario();
            entity.Id = dto.Id;
            entity.Usuario = dto.Usuario;
            entity.Contrasena = dto.Contrasena;
            entity.ApellidoPaterno = dto.ApellidoPaterno.ToUpper();
            entity.ApellidoMaterno = dto.ApellidoMaterno.ToUpper();
            entity.Nombres = dto.Nombres.ToUpper();
            entity.Caduca = dto.Caduca;
            entity.PeriodoCaducidad = dto.PeriodoCaducidad;
            if (!string.IsNullOrEmpty(dto.FechaUltimoCambio))
            {
                //entity.FechaUltimoCambio = Convert.ToDateTime(dto.FechaUltimoCambio);
                //var dia = 
                //dto.FechaUltimoCambio = dto.FechaUltimoCambio.Substring(0, 3);
                dto.FechaUltimoCambio = dto.FechaUltimoCambio.Substring(0, 10);
                entity.FechaUltimoCambio = DateTime.ParseExact(dto.FechaUltimoCambio, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            entity.Ubigeo = dto.Ubigeo;
            entity.CodigoVersion = dto.CodigoVersion;
            //entity.FechaUltimoCambio = dto.FechaUltimoCambio;
            entity.PrimeraVez = dto.PrimeraVez;
            entity.UnicoIngreso = dto.UnicoIngreso;
            entity.HaIngresado = dto.HaIngresado;
            entity.OtrosLogeos = dto.OtrosLogeos;
            entity.Tipo = dto.Tipo;
            entity.Activo = dto.Activo;
            entity.Email = dto.Email;
            if (dto.Institucion != null)
            {
                entity.Institucion = DInstitucionConverter.ToEntity(dto.Institucion);
            }
            return entity;
        }
    }
}