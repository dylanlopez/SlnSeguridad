using Business_Layer.Logics.Personas;
using Logging_Layer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace Service_Layer.Services.Sistemas
{
    public class SPersonasService /*: ISPersonasService*/
    {
        private IBTipoDocumentoPersonaLogic _tipoDocumentoPersonaLogic;
        private Loggin _logger;
    }
}