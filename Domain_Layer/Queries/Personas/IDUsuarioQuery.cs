using Domain_Layer.Dtos.Personas;
using System.Collections.Generic;

namespace Domain_Layer.Queries.Personas
{
    /// <summary>
    /// Here is the interface to that partial class DQuery implement CRUD operations for entity class EUsuario
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    public interface IDUsuarioQuery
    {
        /// <summary>
        /// Update the specified entity class EUsuario.
        /// </summary>
        /// <param name="dto">The dto class DUsuarioDto.</param>
        /// <returns></returns>
        int Actualizar(DUsuarioDto dto);

        /// <summary>
        /// Search the specified entity class EUsuario filter by Id.
        /// </summary>
        /// <param name="dto">The dto class DUsuarioDto.</param>
        /// <returns></returns>
        DUsuarioDto Buscar(DUsuarioDto dto);

        /// <summary>
        /// Insert the specified entity class EUsuario.
        /// </summary>
        /// <param name="dto">The dto class DUsuarioDto.</param>
        /// <returns></returns>
        int Eliminar(DUsuarioDto dto);

        /// <summary>
        /// Insert the specified entity class EUsuario.
        /// </summary>
        /// <param name="dto">The dto class DUsuarioDto.</param>
        /// <returns></returns>
        int Insertar(DUsuarioDto dto);

        /// <summary>
        /// List the specified entities classes EUsuario filter with params.
        /// </summary>
        /// <param name="dto">The dto class DUsuarioDto.</param>
        /// <returns></returns>
        List<DUsuarioDto> Listar(DUsuarioDto dto);
    }
}