using Domain_Layer.Dtos.Personas;
using System.Collections.Generic;

namespace Domain_Layer.Queries.Personas
{
    /// <summary>
    /// Here is the interface to that partial class DQuery implement CRUD operations for entity class EUsuarioRol
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    public interface IDUsuarioRolQuery
    {
        /// <summary>
        /// Insert the specified entity class EUsuarioRol.
        /// </summary>
        /// <param name="dto">The dto class DUsuarioRolDto.</param>
        /// <returns></returns>
        int Eliminar(DUsuarioRolDto dto);

        /// <summary>
        /// Insert the specified entity class EUsuarioRol.
        /// </summary>
        /// <param name="dto">The dto class DUsuarioRolDto.</param>
        /// <returns></returns>
        int Insertar(DUsuarioRolDto dto);

        /// <summary>
        /// List the specified entities classes EUsuarioRol filter with params.
        /// </summary>
        /// <param name="dto">The dto class DUsuarioRolDto.</param>
        /// <returns></returns>
        List<DUsuarioRolDto> Listar(DUsuarioRolDto dto);
    }
}