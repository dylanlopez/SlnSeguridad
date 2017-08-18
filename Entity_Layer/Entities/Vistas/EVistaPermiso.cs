using System;

namespace Entity_Layer.Entities.Vistas
{
    public class EVistaPermiso
    {
        /// <summary>
        /// Gets or sets the IdPerfil, correspond to table field ID_PERFIL.
        /// </summary>
        /// <value>
        /// set a value to the IdPerfil.
        /// </value>
        public virtual Int32 IdPerfil { get; set; }

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
        /// Gets or sets the Caduca, correspond to table field IN_CADUCA.
        /// </summary>
        /// <value>
        /// set a value to the Caduca.
        /// </value>
        public virtual Char Caduca { get; set; }

        /// <summary>
        /// Gets or sets the FechaUltimoCambio, correspond to table field FE_ULTIMOCAMBIO.
        /// </summary>
        /// <value>
        /// set a value to the FechaUltimoCambio.
        /// </value>
        public virtual DateTime FechaUltimoCambio { get; set; }

        /// <summary>
        /// Gets or sets the PeriodoCaducidad, correspond to table field NU_PERIODO_CADUCIDAD.
        /// </summary>
        /// <value>
        /// set a value to the PeriodoCaducidad.
        /// </value>
        public virtual Int32 PeriodoCaducidad { get; set; }

        /// <summary>
        /// Gets or sets the PrimeraVez, correspond to table field IN_PRIMERA_VEZ.
        /// </summary>
        /// <value>
        /// set a value to the PrimeraVez.
        /// </value>
        public virtual Char PrimeraVez { get; set; }

        /// <summary>
        /// Gets or sets the IdRol, correspond to table field ID_ROL.
        /// </summary>
        /// <value>
        /// set a value to the IdRol.
        /// </value>
        public virtual Int32 IdRol { get; set; }

        /// <summary>
        /// Gets or sets the NombreRol, correspond to table field NO_ROL.
        /// </summary>
        /// <value>
        /// set a value to the NombreRol.
        /// </value>
        public virtual String NombreRol { get; set; }

        /// <summary>
        /// Gets or sets the IdSistema, correspond to table field ID_SISTEMA.
        /// </summary>
        /// <value>
        /// set a value to the IdSistema.
        /// </value>
        public virtual Int32 IdSistema { get; set; }

        /// <summary>
        /// Gets or sets the CodigoSistema, correspond to table field CO_SISTEMA.
        /// </summary>
        /// <value>
        /// set a value to the CodigoSistema.
        /// </value>
        public virtual String CodigoSistema { get; set; }

        /// <summary>
        /// Gets or sets the AbreviaturaSistema, correspond to table field NO_ABREVIATURA.
        /// </summary>
        /// <value>
        /// set a value to the AbreviaturaSistema.
        /// </value>
        public virtual String AbreviaturaSistema { get; set; }

        /// <summary>
        /// Gets or sets the NombreSistema, correspond to table field NO_SISTEMA.
        /// </summary>
        /// <value>
        /// set a value to the NombreSistema.
        /// </value>
        public virtual String NombreSistema { get; set; }

        /// <summary>
        /// Gets or sets the RutaLogica, correspond to table field DE_RUTA_LOGICA.
        /// </summary>
        /// <value>
        /// set a value to the RutaLogica.
        /// </value>
        public virtual String RutaLogica { get; set; }

        /// <summary>
        /// Gets or sets the IdModulo, correspond to table field ID_MODULO.
        /// </summary>
        /// <value>
        /// set a value to the IdModulo.
        /// </value>
        public virtual Int32 IdModulo { get; set; }

        /// <summary>
        /// Gets or sets the CodigoModulo, correspond to table field CO_MODULO.
        /// </summary>
        /// <value>
        /// set a value to the CodigoModulo.
        /// </value>
        public virtual String CodigoModulo { get; set; }

        /// <summary>
        /// Gets or sets the NombreModulo, correspond to table field NO_MODULO.
        /// </summary>
        /// <value>
        /// set a value to the NombreModulo.
        /// </value>
        public virtual String NombreModulo { get; set; }

        /// <summary>
        /// Gets or sets the IdMenu, correspond to table field ID_MENU.
        /// </summary>
        /// <value>
        /// set a value to the IdMenu.
        /// </value>
        public virtual Int32 IdMenu { get; set; }

        /// <summary>
        /// Gets or sets the CodigoMenu, correspond to table field CO_MENU.
        /// </summary>
        /// <value>
        /// set a value to the CodigoMenu.
        /// </value>
        public virtual String CodigoMenu { get; set; }

        /// <summary>
        /// Gets or sets the NombreMenu, correspond to table field NO_MENU.
        /// </summary>
        /// <value>
        /// set a value to the NombreMenu.
        /// </value>
        public virtual String NombreMenu { get; set; }

        /// <summary>
        /// Gets or sets the MenuRuta, correspond to table field DE_RUTA.
        /// </summary>
        /// <value>
        /// set a value to the MenuRuta.
        /// </value>
        public virtual String MenuRuta { get; set; }

        /// <summary>
        /// Gets or sets the IdOpcion, correspond to table field ID_OPCION.
        /// </summary>
        /// <value>
        /// set a value to the IdOpcion.
        /// </value>
        public virtual Int32 IdOpcion { get; set; }

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

        public override bool Equals(object obj)
        {
            var other = obj as EVistaPermiso;

            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return IdPerfil == other.IdPerfil && Usuario == other.Usuario && IdRol == other.IdRol &&
                IdSistema == other.IdSistema && IdModulo == other.IdModulo && IdMenu == other.IdMenu &&
                IdOpcion == other.IdOpcion;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = GetType().GetHashCode();
                hash = (hash * 31) ^ IdPerfil.GetHashCode();
                hash = (hash * 31) ^ Usuario.GetHashCode();
                hash = (hash * 31) ^ IdRol.GetHashCode();
                hash = (hash * 31) ^ IdSistema.GetHashCode();
                hash = (hash * 31) ^ IdModulo.GetHashCode();
                hash = (hash * 31) ^ IdMenu.GetHashCode();
                hash = (hash * 31) ^ IdOpcion.GetHashCode();
                return hash;
            }
        }
    }
}