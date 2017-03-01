using Domain_Layer.Dtos.Personas;
using System.Collections.Generic;

namespace Domain_Layer.Queries.Personas
{
    /// <summary>
    /// Here is the interface to that partial class DQuery implement CRUD operations for entity class ETipoDocumentoPersona
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    public interface IDTipoDocumentoPersonaQuery
    {
        /// <summary>
        /// Search the specified entity class ETipoDocumentoPersona filter by Id.
        /// </summary>
        /// <param name="dto">The dto class DTipoDocumentoPersonaDto.</param>
        /// <returns></returns>
        DTipoDocumentoPersonaDto Buscar(DTipoDocumentoPersonaDto dto);

        /// <summary>
        /// List the specified entities classes ETipoDocumentoPersona filter with params.
        /// </summary>
        /// <param name="dto">The dto class DTipoDocumentoPersonaDto.</param>
        /// <returns></returns>
        List<DTipoDocumentoPersonaDto> Listar(DTipoDocumentoPersonaDto dto);
    }
}