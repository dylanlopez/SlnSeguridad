using Domain_Layer.Dtos.Personas;
using System.Collections.Generic;

namespace Domain_Layer.Queries.Personas
{
    /// <summary>
    /// Here is the interface to that partial class DQuery implement CRUD operations for entity class EMenuRol
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    public interface IDMenuRolQuery
    {
        /// <summary>
        /// Delete the specified entity class EMenuRol.
        /// </summary>
        /// <param name="dto">The dto class DMenuRolDto.</param>
        /// <returns></returns>
        int Eliminar(DMenuRolDto dto);

        /// <summary>
        /// Insert the specified entity class EMenuRol.
        /// </summary>
        /// <param name="dto">The dto class DMenuRolDto.</param>
        /// <returns></returns>
        int Insertar(DMenuRolDto dto);

        /// <summary>
        /// List the specified entities classes EMenuRol filter with params.
        /// </summary>
        /// <param name="dto">The dto class DMenuRolDto.</param>
        /// <returns></returns>
        List<DMenuRolDto> Listar(DMenuRolDto dto);
    }
}