using Domain_Layer.Dtos.Personas;
using System.Collections.Generic;

namespace Domain_Layer.Queries.Personas
{
    /// <summary>
    /// Here is the interface to that partial class DQuery implement CRUD operations for entity class EProgramaSocial
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    public interface IDProgramaSocialQuery
    {
        /// <summary>
        /// Update the specified entity class EProgramaSocial.
        /// </summary>
        /// <param name="dto">The dto class DMenuDto.</param>
        /// <returns></returns>
        int Actualizar(DProgramaSocialDto dto);

        /// <summary>
        /// Search the specified entity class EProgramaSocial filter by Id.
        /// </summary>
        /// <param name="dto">The dto class DProgramaSocialDto.</param>
        /// <returns></returns>
        DProgramaSocialDto Buscar(DProgramaSocialDto dto);

        /// <summary>
        /// Delete the specified entity class EProgramaSocial.
        /// </summary>
        /// <param name="dto">The dto class DProgramaSocialDto.</param>
        /// <returns></returns>
        int Eliminar(DProgramaSocialDto dto);

        /// <summary>
        /// Insert the specified entity class EProgramaSocial.
        /// </summary>
        /// <param name="dto">The dto class DProgramaSocialDto.</param>
        /// <returns></returns>
        int Insertar(DProgramaSocialDto dto);

        /// <summary>
        /// List the specified entities classes EProgramaSocial filter with params.
        /// </summary>
        /// <param name="dto">The dto class DProgramaSocialDto.</param>
        /// <returns></returns>
        List<DProgramaSocialDto> Listar(DProgramaSocialDto dto);
    }
}