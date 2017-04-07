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
        /// Search the specified entity class EPersona filter by Id.
        /// </summary>
        /// <param name="dto">The dto class DPersonaDto.</param>
        /// <returns></returns>
        DPersonaDto Buscar(DPersonaDto dto);
    }
}