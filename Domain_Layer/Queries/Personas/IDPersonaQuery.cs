using Domain_Layer.Dtos.Personas;
using System.Collections.Generic;

namespace Domain_Layer.Queries.Personas
{
    /// <summary>
    /// Here is the interface to that partial class DQuery implement CRUD operations for entity class EPersona
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
public interface IDPersonaQuery
    {
        /// <summary>
        /// Update the specified entity class EPersona.
        /// </summary>
        /// <param name="dto">The dto class DPersonaDto.</param>
        /// <returns></returns>
        int Actualizar(DPersonaDto dto);

        /// <summary>
        /// Search the specified entity class EPersona filter by Id.
        /// </summary>
        /// <param name="dto">The dto class DPersonaDto.</param>
        /// <returns></returns>
        DPersonaDto Buscar(DPersonaDto dto);

        /// <summary>
        /// Delete the specified entity class EPersona.
        /// </summary>
        /// <param name="dto">The dto class DPersonaDto.</param>
        /// <returns></returns>
        int Eliminar(DPersonaDto dto);

        /// <summary>
        /// Insert the specified entity class EPersona.
        /// </summary>
        /// <param name="dto">The dto class DPersonaDto.</param>
        /// <returns></returns>
        int Insertar(DPersonaDto dto);

        /// <summary>
        /// List the specified entities classes EPersona filter with params.
        /// </summary>
        /// <param name="dto">The dto class DPersonaDto.</param>
        /// <returns></returns>
        List<DPersonaDto> Listar(DPersonaDto dto);
    }
}