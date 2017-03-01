using Domain_Layer.Dtos.Sistemas;
using System.Collections.Generic;

namespace Domain_Layer.Queries.Sistemas
{
    /// <summary>
    /// Here is the interface to that partial class DQuery implement CRUD operations for entity class ESistema
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    public interface IDSistemaQuery
    {
        /// <summary>
        /// Update the specified entity class ESistema.
        /// </summary>
        /// <param name="dto">The dto class DSistemaDto.</param>
        /// <returns></returns>
        int Actualizar(DSistemaDto dto);

        /// <summary>
        /// Search the specified entity class ESistema filter by Id.
        /// </summary>
        /// <param name="dto">The dto class DSistemaDto.</param>
        /// <returns></returns>
        DSistemaDto Buscar(DSistemaDto dto);

        /// <summary>
        /// Insert the specified entity class ESistema.
        /// </summary>
        /// <param name="dto">The dto class DSistemaDto.</param>
        /// <returns></returns>
        int Insertar(DSistemaDto dto);

        /// <summary>
        /// List the specified entities classes ESistema filter with params.
        /// </summary>
        /// <param name="dto">The dto class DSistemaDto.</param>
        /// <returns></returns>
        List<DSistemaDto> Listar(DSistemaDto dto);
    }
}