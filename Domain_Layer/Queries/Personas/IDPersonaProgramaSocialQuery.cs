using Domain_Layer.Dtos.Personas;
using System.Collections.Generic;

namespace Domain_Layer.Queries.Personas
{
    /// <summary>
    /// Here is the interface to that partial class DQuery implement CRUD operations for entity class EPersonaProgramaSocial
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    public interface IDPersonaProgramaSocialQuery
    {
        /// <summary>
        /// Delete the specified entity class EPersonaProgramaSocial.
        /// </summary>
        /// <param name="dto">The dto class DPersonaProgramaSocialDto.</param>
        /// <returns></returns>
        int Eliminar(DPersonaProgramaSocialDto dto);

        /// <summary>
        /// Insert the specified entity class EPersonaProgramaSocial.
        /// </summary>
        /// <param name="dto">The dto class DPersonaProgramaSocialDto.</param>
        /// <returns></returns>
        int Insertar(DPersonaProgramaSocialDto dto);

        /// <summary>
        /// List the specified entities classes EPersonaProgramaSocial filter with params.
        /// </summary>
        /// <param name="dto">The dto class DPersonaProgramaSocialDto.</param>
        /// <returns></returns>
        List<DPersonaProgramaSocialDto> Listar(DPersonaProgramaSocialDto dto);
    }
}