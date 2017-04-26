using Business_Layer.Utils;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using Service_Layer.Models.Personas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Interface_Layer_API
{
    public class MyAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private UsuarioModel _model;
        private DataContractJsonSerializer _jsonSerializer;
        private BRestOperation _restOperation;

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated(); // 
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            _model = new UsuarioModel();
            _model.Usuario = context.UserName;
            _model.Contrasena = context.Password;
            var dataToSend = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_model));
            using (_restOperation = new BRestOperation())
            {
                //var stream = _restOperation.Post("http://localhost/SeguridadService/Services/SPersonasService.svc/BuscarUsuario/", dataToSend);
                var stream = _restOperation.Post("http://localhost:55291/Services/SPersonasService.svc/BuscarUsuario/", dataToSend);
                _jsonSerializer = new DataContractJsonSerializer(typeof(UsuarioModel));
                _model = (UsuarioModel)_jsonSerializer.ReadObject(stream);
            }
            identity.AddClaim(new Claim(ClaimTypes.Role, "admin"));
            identity.AddClaim(new Claim("username", _model.Usuario));
            identity.AddClaim(new Claim(ClaimTypes.Name, _model.ApellidoPaterno + _model.ApellidoMaterno + _model.Nombres));
            context.Validated(identity);

            //if (context.UserName == "admin" && context.Password == "admin")
            //{
            //    identity.AddClaim(new Claim(ClaimTypes.Role, "admin"));
            //    identity.AddClaim(new Claim("username", "admin"));
            //    identity.AddClaim(new Claim(ClaimTypes.Name, "Sourav Mondal"));
            //    context.Validated(identity);
            //}
            //else if (context.UserName == "user" && context.Password == "user")
            //{
            //    identity.AddClaim(new Claim(ClaimTypes.Role, "user"));
            //    identity.AddClaim(new Claim("username", "user"));
            //    identity.AddClaim(new Claim(ClaimTypes.Name, "Suresh Sha"));
            //    context.Validated(identity);
            //}
            //else
            //{
            //    context.SetError("invalid_grant", "Provided username and password is incorrect");
            //    return;
            //}
        }
    }
}