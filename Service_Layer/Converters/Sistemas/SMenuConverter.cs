﻿using Domain_Layer.Dtos.Sistemas;
using Service_Layer.Models.Sistemas;
using System.Collections.Generic;
using System.Configuration;

namespace Service_Layer.Converters.Sistemas
{
    public class SMenuConverter
    {
        internal static MenuModel ToModel(DMenuDto dto)
        {
            var model = new MenuModel();
            model.Id = dto.Id;
            model.Codigo = dto.Codigo;
            model.Nombre = dto.Nombre;
            model.Ruta = ConfigurationManager.AppSettings["WebPath"].ToString() + dto.Ruta;
            model.Descripcion = dto.Descripcion;
            model.Activo = dto.Activo;
            model.Modulo = SModuloConverter.ToModel(dto.Modulo);
            return model;
        }

        internal static List<MenuModel> ToModels(IList<DMenuDto> dtos)
        {
            var models = new List<MenuModel>();
            foreach (var dto in dtos)
            {
                var model = ToModel(dto);
                models.Add(model);
            }
            return models;
        }

        internal static DMenuDto ToDto(MenuModel model)
        {
            var dto = new DMenuDto();
            dto.Id = model.Id;
            dto.Codigo = model.Codigo;
            dto.Nombre = model.Nombre;
            dto.Ruta = model.Ruta;
            if (!string.IsNullOrEmpty(model.Descripcion))
            {
                dto.Descripcion = model.Descripcion;
            }
            dto.Activo = model.Activo;
            dto.Modulo = SModuloConverter.ToDto(model.Modulo);
            return dto;
        }
    }
}