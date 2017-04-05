using Domain_Layer.Dtos.Sistemas;
using System.Collections.Generic;

namespace Domain_Layer.Queries.Sistemas
{
    /// <summary>
    /// Here is the interface to that partial class DQuery implement CRUD operations for entity class EOpcion
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    public interface IDOpcionQuery
    {
        /// <summary>
        /// Update the specified entity class EOpcion.
        /// </summary>
        /// <param name="dto">The dto class DOpcionDto.</param>
        /// <returns></returns>
        int Actualizar(DOpcionDto dto);

        /// <summary>
        /// Search the specified entity class EOpcion filter by Id.
        /// </summary>
        /// <param name="dto">The dto class DOpcionDto.</param>
        /// <returns></returns>
        DOpcionDto Buscar(DOpcionDto dto);

        /// <summary>
        /// Insert the specified entity class EOpcion.
        /// </summary>
        /// <param name="dto">The dto class DOpcionDto.</param>
        /// <returns></returns>
        int Eliminar(DOpcionDto dto);

        /// <summary>
        /// Insert the specified entity class EOpcion.
        /// </summary>
        /// <param name="dto">The dto class DOpcionDto.</param>
        /// <returns></returns>
        int Insertar(DOpcionDto dto);

        /// <summary>
        /// List the specified entities classes EOpcion filter with params.
        /// </summary>
        /// <param name="dto">The dto class DOpcionDto.</param>
        /// <returns></returns>
        List<DOpcionDto> Listar(DOpcionDto dto);
    }
}