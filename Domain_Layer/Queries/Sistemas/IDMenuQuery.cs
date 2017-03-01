using Domain_Layer.Dtos.Sistemas;
using System.Collections.Generic;

namespace Domain_Layer.Queries.Sistemas
{
    /// <summary>
    /// Here is the interface to that partial class DQuery implement CRUD operations for entity class EMenu
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    public interface IDMenuQuery
    {
        /// <summary>
        /// Update the specified entity class EMenu.
        /// </summary>
        /// <param name="dto">The dto class DMenuDto.</param>
        /// <returns></returns>
        int Actualizar(DMenuDto dto);

        /// <summary>
        /// Search the specified entity class EMenu filter by Id.
        /// </summary>
        /// <param name="dto">The dto class DMenuDto.</param>
        /// <returns></returns>
        DMenuDto Buscar(DMenuDto dto);

        /// <summary>
        /// Insert the specified entity class EMenu.
        /// </summary>
        /// <param name="dto">The dto class DMenuDto.</param>
        /// <returns></returns>
        int Eliminar(DMenuDto dto);

        /// <summary>
        /// Insert the specified entity class EMenu.
        /// </summary>
        /// <param name="dto">The dto class DMenuDto.</param>
        /// <returns></returns>
        int Insertar(DMenuDto dto);

        /// <summary>
        /// List the specified entities classes EMenu filter with params.
        /// </summary>
        /// <param name="dto">The dto class DMenuDto.</param>
        /// <returns></returns>
        List<DMenuDto> Listar(DMenuDto dto);
    }
}