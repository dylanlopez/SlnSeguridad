using Domain_Layer.Dtos.Personas;
using System.Collections.Generic;

namespace Domain_Layer.Queries.Personas
{
    /// <summary>
    /// Here is the interface to that partial class DQuery implement CRUD operations for entity class ESistemaPerfil
    /// </summary>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <v1.0>
    /// <author>Dylan Lopez, dlopez@midis.gob.pe</author>
    /// <description>Initial version</description>
    /// </v1.0>
    public interface IDSistemaPerfilQuery
    {
        /// <summary>
        /// Update the specified entity class ESistemaPerfil.
        /// </summary>
        /// <param name="dto">The dto class DSistemaPerfilDto.</param>
        /// <returns></returns>
        int Actualizar(DSistemaPerfilDto dto);

        /// <summary>
        /// Insert the specified entity class ESistemaPerfil.
        /// </summary>
        /// <param name="dto">The dto class DSistemaPerfilDto.</param>
        /// <returns></returns>
        int Insertar(DSistemaPerfilDto dto);

        /// <summary>
        /// List the specified entities classes ESistemaPerfil filter with params.
        /// </summary>
        /// <param name="dto">The dto class DSistemaPerfilDto.</param>
        /// <returns></returns>
        List<DSistemaPerfilDto> Listar(DSistemaPerfilDto dto);
    }
}