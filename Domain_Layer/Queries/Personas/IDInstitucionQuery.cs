using Domain_Layer.Dtos.Personas;
using System.Collections.Generic;

namespace Domain_Layer.Queries.Personas
{
    /// <summary>
    /// Here is the interface to that partial class DQuery implement CRUD operations for entity class EInstitucion
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    public interface IDInstitucionQuery
    {
        /// <summary>
        /// Update the specified entity class EInstitucion.
        /// </summary>
        /// <param name="dto">The dto class DInstitucionDto.</param>
        /// <returns></returns>
        int Actualizar(DInstitucionDto dto);

        /// <summary>
        /// Search the specified entity class EInstitucion filter by Id.
        /// </summary>
        /// <param name="dto">The dto class DInstitucionDto.</param>
        /// <returns></returns>
        DInstitucionDto Buscar(DInstitucionDto dto);

        /// <summary>
        /// Insert the specified entity class EInstitucion.
        /// </summary>
        /// <param name="dto">The dto class DInstitucionDto.</param>
        /// <returns></returns>
        int Insertar(DInstitucionDto dto);

        /// <summary>
        /// List the specified entities classes EInstitucion filter with params.
        /// </summary>
        /// <param name="dto">The dto class DInstitucionDto.</param>
        /// <returns></returns>
        List<DInstitucionDto> Listar(DInstitucionDto dto);
    }
}