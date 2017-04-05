using Domain_Layer.Dtos.Sistemas;
using System.Collections.Generic;

namespace Domain_Layer.Queries.Sistemas
{
    /// <summary>
    /// Here is the interface to that partial class DQuery implement CRUD operations for entity class EMenuOpcion
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    public interface IDMenuOpcionQuery
    {
        /// <summary>
        /// Update the specified entity class EMenuOpcion.
        /// </summary>
        /// <param name="dto">The dto class DMenuOpcionDto.</param>
        /// <returns></returns>
        int Actualizar(DMenuOpcionDto dto);

        /// <summary>
        /// Search the specified entity class EMenuOpcion filter by Id.
        /// </summary>
        /// <param name="dto">The dto class DMenuOpcionDto.</param>
        /// <returns></returns>
        DMenuOpcionDto Buscar(DMenuOpcionDto dto);

        /// <summary>
        /// Insert the specified entity class EMenuOpcion.
        /// </summary>
        /// <param name="dto">The dto class DMenuOpcionDto.</param>
        /// <returns></returns>
        int Eliminar(DMenuOpcionDto dto);

        /// <summary>
        /// Insert the specified entity class EMenuOpcion.
        /// </summary>
        /// <param name="dto">The dto class DMenuOpcionDto.</param>
        /// <returns></returns>
        int Insertar(DMenuOpcionDto dto);

        /// <summary>
        /// List the specified entities classes EMenuOpcion filter with params.
        /// </summary>
        /// <param name="dto">The dto class DMenuOpcionDto.</param>
        /// <returns></returns>
        List<DMenuOpcionDto> Listar(DMenuOpcionDto dto);
    }
}