using Domain_Layer.Dtos.Personas;
using System.Collections.Generic;

namespace Domain_Layer.Queries.Personas
{
    /// <summary>
    /// Here is the interface to that partial class DQuery implement CRUD operations for entity class EPerfilUsuarioRol
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    public interface IDPerfilUsuarioRolQuery
    {
        /// <summary>
        /// Update the specified entity class EPerfilUsuarioRol.
        /// </summary>
        /// <param name="dto">The dto class DPerfilUsuarioRolDto.</param>
        /// <returns></returns>
        int Actualizar(DPerfilUsuarioRolDto dto);

        /// <summary>
        /// Insert the specified entity class EPerfilUsuarioRol.
        /// </summary>
        /// <param name="dto">The dto class DPerfilUsuarioRolDto.</param>
        /// <returns></returns>
        int Insertar(DPerfilUsuarioRolDto dto);

        /// <summary>
        /// List the specified entities classes EPerfilUsuarioRol filter with params.
        /// </summary>
        /// <param name="dto">The dto class DPerfilUsuarioRolDto.</param>
        /// <returns></returns>
        List<DPerfilUsuarioRolDto> Listar(DPerfilUsuarioRolDto dto);
    }
}