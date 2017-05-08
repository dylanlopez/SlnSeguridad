using System;

namespace Entity_Layer.Entities.Vistas
{
    public class EVistaPermiso
    {
        /// <summary>
        /// Gets or sets the NombrePerfil, correspond to table field NO_PERFIL.
        /// </summary>
        /// <value>
        /// set a value to the NombrePerfil.
        /// </value>
        public virtual String NombrePerfil { get; set; }

        /// <summary>
        /// Gets or sets the Usuario, correspond to table field US_USUARIO.
        /// </summary>
        /// <value>
        /// set a value to the Usuario.
        /// </value>
        public virtual String Usuario { get; set; }

        /// <summary>
        /// Gets or sets the Contrasena, correspond to table field US_CONTRASENA.
        /// </summary>
        /// <value>
        /// set a value to the Contrasena.
        /// </value>
        public virtual String Contrasena { get; set; }

        /// <summary>
        /// Gets or sets the ApellidoPaterno, correspond to table field NO_APELLIDO_PATERNO.
        /// </summary>
        /// <value>
        /// set a value to the ApellidoPaterno.
        /// </value>
        public virtual String ApellidoPaterno { get; set; }

        /// <summary>
        /// Gets or sets the ApellidoMaterno, correspond to table field NO_APELLIDO_MATERNO.
        /// </summary>
        /// <value>
        /// set a value to the ApellidoMaterno.
        /// </value>
        public virtual String ApellidoMaterno { get; set; }

        /// <summary>
        /// Gets or sets the Nombres, correspond to table field NO_NOMBRE.
        /// </summary>
        /// <value>
        /// set a value to the Nombres.
        /// </value>
        public virtual String Nombres { get; set; }

        /// <summary>
        /// Gets or sets the Ubigeo, correspond to table field UBIGEO.
        /// </summary>
        /// <value>
        /// set a value to the Ubigeo.
        /// </value>
        public virtual String Ubigeo { get; set; }

        /// <summary>
        /// Gets or sets the CodigoVersion, correspond to table field CO_VERSION.
        /// </summary>
        /// <value>
        /// set a value to the CodigoVersion.
        /// </value>
        public virtual Int32 CodigoVersion { get; set; }

        /// <summary>
        /// Gets or sets the Email, correspond to table field NO_EMAIL.
        /// </summary>
        /// <value>
        /// set a value to the Email.
        /// </value>
        public virtual String Email { get; set; }

        /// <summary>
        /// Gets or sets the NombreRol, correspond to table field NO_ROL.
        /// </summary>
        /// <value>
        /// set a value to the NombreRol.
        /// </value>
        public virtual String NombreRol { get; set; }

        /// <summary>
        /// Gets or sets the CodigoSistema, correspond to table field CO_SISTEMA.
        /// </summary>
        /// <value>
        /// set a value to the CodigoSistema.
        /// </value>
        public virtual String CodigoSistema { get; set; }

        /// <summary>
        /// Gets or sets the NombreSistema, correspond to table field NO_SISTEMA.
        /// </summary>
        /// <value>
        /// set a value to the NombreSistema.
        /// </value>
        public virtual String NombreSistema { get; set; }

        /// <summary>
        /// Gets or sets the NombreModulo, correspond to table field NO_MODULO.
        /// </summary>
        /// <value>
        /// set a value to the NombreModulo.
        /// </value>
        public virtual String NombreModulo { get; set; }

        /// <summary>
        /// Gets or sets the NombreMenu, correspond to table field NO_MENU.
        /// </summary>
        /// <value>
        /// set a value to the NombreMenu.
        /// </value>
        public virtual String NombreMenu { get; set; }

        /// <summary>
        /// Gets or sets the NombreOpcion, correspond to table field NO_OPCION.
        /// </summary>
        /// <value>
        /// set a value to the NombreOpcion.
        /// </value>
        public virtual String NombreOpcion { get; set; }

        /// <summary>
        /// Gets or sets the ControlAsociado, correspond to table field NO_CONTROL_ASOC.
        /// </summary>
        /// <value>
        /// set a value to the ControlAsociado.
        /// </value>
        public virtual String ControlAsociado { get; set; }

        /// <summary>
        /// Gets or sets the Visible, correspond to table field IN_VISIBLE.
        /// </summary>
        /// <value>
        /// set a value to the Visible.
        /// </value>
        public virtual Char Visible { get; set; }
    }
}