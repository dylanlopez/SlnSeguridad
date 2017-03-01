using Domain_Layer.Dtos.Sistemas;
using System.Collections.Generic;

namespace Domain_Layer.Queries.Sistemas
{
    /// <summary>
    /// Here is the interface to that partial class DQuery implement CRUD operations for entity class EModulo
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    public interface IDModuloQuery
    {
        /// <summary>
        /// Update the specified entity class EModulo.
        /// </summary>
        /// <param name="dto">The dto class DModuloDto.</param>
        /// <returns></returns>
        int Actualizar(DModuloDto dto);

        /// <summary>
        /// Search the specified entity class EModulo filter by Id.
        /// </summary>
        /// <param name="dto">The dto class DModuloDto.</param>
        /// <returns></returns>
        DModuloDto Buscar(DModuloDto dto);

        /// <summary>
        /// Insert the specified entity class EModulo.
        /// </summary>
        /// <param name="dto">The dto class DModuloDto.</param>
        /// <returns></returns>
        int Insertar(DModuloDto dto);

        /// <summary>
        /// List the specified entities classes EModulo filter with params.
        /// </summary>
        /// <param name="dto">The dto class DModuloDto.</param>
        /// <returns></returns>
        List<DModuloDto> Listar(DModuloDto dto);
    }
}