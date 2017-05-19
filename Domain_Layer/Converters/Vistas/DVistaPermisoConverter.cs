using Domain_Layer.Dtos.Vistas;
using Entity_Layer.Entities.Vistas;
using System.Collections.Generic;

namespace Domain_Layer.Converters.Vistas
{
    internal static class DVistaPermisoConverter
    {
        internal static DVistaPermisoDto ToDto(EVistaPermiso entity)
        {
            var dto = new DVistaPermisoDto();
            dto.IdPerfil = entity.IdPerfil;
            dto.NombrePerfil = entity.NombrePerfil;
            dto.Usuario = entity.Usuario;
            dto.Contrasena = entity.Contrasena;
            dto.ApellidoPaterno = entity.ApellidoPaterno;
            dto.ApellidoMaterno = entity.ApellidoMaterno;
            dto.Nombres = entity.Nombres;
            dto.Ubigeo = entity.Ubigeo;
            dto.CodigoVersion = entity.CodigoVersion;
            dto.Email = entity.Email;
            dto.Caduca = entity.Caduca;
            dto.FechaUltimoCambio = entity.FechaUltimoCambio;
            dto.PeriodoCaducidad = entity.PeriodoCaducidad;
            dto.PrimeraVez = entity.PrimeraVez;
            dto.IdRol = entity.IdRol;
            dto.NombreRol = entity.NombreRol;
            dto.IdSistema = entity.IdSistema;
            dto.CodigoSistema = entity.CodigoSistema;
            dto.NombreSistema = entity.NombreSistema;
            dto.RutaLogica = entity.RutaLogica;
            dto.IdModulo = entity.IdModulo;
            dto.CodigoModulo = entity.CodigoModulo;
            dto.NombreModulo = entity.NombreModulo;
            dto.IdMenu = entity.IdMenu;
            dto.CodigoMenu = entity.CodigoMenu;
            dto.NombreMenu = entity.NombreMenu;
            dto.MenuRuta = entity.MenuRuta;
            dto.NombreOpcion = entity.NombreOpcion;
            dto.ControlAsociado = entity.ControlAsociado;
            dto.Visible = entity.Visible;
            return dto;
        }

        internal static List<DVistaPermisoDto> ToDtos(IList<EVistaPermiso> entities)
        {
            var dtos = new List<DVistaPermisoDto>();
            foreach (var entity in entities)
            {
                var dto = ToDto(entity);
                dtos.Add(dto);
            }
            return dtos;
        }
    }
}