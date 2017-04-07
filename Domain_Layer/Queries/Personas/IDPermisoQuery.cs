using Domain_Layer.Dtos.Personas;
using System.Collections.Generic;

namespace Domain_Layer.Queries.Personas
{
    /// <summary>
    /// Here is the interface to that partial class DQuery implement CRUD operations for entity class EPermiso
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    public interface IDPermisoQuery
    {
        /// <summary>
        /// Update the specified entity class EPermiso.
        /// </summary>
        /// <param name="dto">The dto class DPermisoDto.</param>
        /// <returns></returns>
        int Actualizar(DPermisoDto dto);

        /// <summary>
        /// Insert the specified entity class EPermiso.
        /// </summary>
        /// <param name="dto">The dto class DPermisoDto.</param>
        /// <returns></returns>
        int Eliminar(DPermisoDto dto);

        /// <summary>
        /// Insert the specified entity class EPermiso.
        /// </summary>
        /// <param name="dto">The dto class DPermisoDto.</param>
        /// <returns></returns>
        int Insertar(DPermisoDto dto);

        /// <summary>
        /// List the specified entities classes EPermiso filter with params.
        /// </summary>
        /// <param name="dto">The dto class DPermisoDto.</param>
        /// <returns></returns>
        List<DPermisoDto> Listar(DPermisoDto dto);
    }
}