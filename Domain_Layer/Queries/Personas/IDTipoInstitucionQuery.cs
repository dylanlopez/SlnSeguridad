﻿using Domain_Layer.Dtos.Personas;
using System.Collections.Generic;

namespace Domain_Layer.Queries.Personas
{
    /// <summary>
    /// Here is the interface to that partial class DQuery implement CRUD operations for entity class ETipoInstitucion
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    public interface IDTipoInstitucionQuery
    {
        /// <summary>
        /// Update the specified entity class ETipoInstitucion.
        /// </summary>
        /// <param name="dto">The dto class DTipoInstitucionDto.</param>
        /// <returns></returns>
        int Actualizar(DTipoInstitucionDto dto);

        /// <summary>
        /// Search the specified entity class ETipoInstitucion filter by Id.
        /// </summary>
        /// <param name="dto">The dto class DTipoInstitucionDto.</param>
        /// <returns></returns>
        DTipoInstitucionDto Buscar(DTipoInstitucionDto dto);

        /// <summary>
        /// Insert the specified entity class ETipoInstitucion.
        /// </summary>
        /// <param name="dto">The dto class DTipoInstitucionDto.</param>
        /// <returns></returns>
        int Insertar(DTipoInstitucionDto dto);

        /// <summary>
        /// List the specified entities classes ETipoInstitucion filter with params.
        /// </summary>
        /// <param name="dto">The dto class DTipoInstitucionDto.</param>
        /// <returns></returns>
        List<DTipoInstitucionDto> Listar(DTipoInstitucionDto dto);
    }
}