using Domain_Layer.Dtos.Personas;
using System.Collections.Generic;

namespace Domain_Layer.Queries.Personas
{
    /// <summary>
    /// Here is the interface to that partial class DQuery implement CRUD operations for entity class EPerfil
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    public interface IDPerfilQuery
    {
        /// <summary>
        /// Update the specified entity class EPerfil.
        /// </summary>
        /// <param name="dto">The dto class DPerfilDto.</param>
        /// <returns></returns>
        int Actualizar(DPerfilDto dto);

        /// <summary>
        /// Insert the specified entity class EPerfil.
        /// </summary>
        /// <param name="dto">The dto class DPerfilDto.</param>
        /// <returns></returns>
        int Insertar(DPerfilDto dto);

        /// <summary>
        /// List the specified entities classes EPerfil filter with params.
        /// </summary>
        /// <param name="dto">The dto class DPerfilDto.</param>
        /// <returns></returns>
        List<DPerfilDto> Listar(DPerfilDto dto);
    }
}