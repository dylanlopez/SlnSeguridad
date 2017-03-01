using Domain_Layer.Dtos.Personas;
using System.Collections.Generic;

namespace Domain_Layer.Queries.Personas
{
    /// <summary>
    /// Here is the interface to that partial class DQuery implement CRUD operations for entity class ERol
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    public interface IDRolQuery
    {
        /// <summary>
        /// Update the specified entity class ERol.
        /// </summary>
        /// <param name="dto">The dto class DRolDto.</param>
        /// <returns></returns>
        int Actualizar(DRolDto dto);

        /// <summary>
        /// Search the specified entity class ERol filter by Id.
        /// </summary>
        /// <param name="dto">The dto class DRolDto.</param>
        /// <returns></returns>
        DRolDto Buscar(DRolDto dto);

        /// <summary>
        /// Insert the specified entity class ERol.
        /// </summary>
        /// <param name="dto">The dto class DRolDto.</param>
        /// <returns></returns>
        int Eliminar(DRolDto dto);

        /// <summary>
        /// Insert the specified entity class ERol.
        /// </summary>
        /// <param name="dto">The dto class DRolDto.</param>
        /// <returns></returns>
        int Insertar(DRolDto dto);

        /// <summary>
        /// List the specified entities classes ERol filter with params.
        /// </summary>
        /// <param name="dto">The dto class DRolDto.</param>
        /// <returns></returns>
        List<DRolDto> Listar(DRolDto dto);
    }
}