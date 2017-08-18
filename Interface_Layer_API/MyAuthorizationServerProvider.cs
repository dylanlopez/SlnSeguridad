using Business_Layer.Utils;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using Service_Layer.Models.Personas;
using Service_Layer.Models.Vistas;
using System;
using System.Collections.Generic;
using System.Configuration;
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
        private AcreditacionUPSRequest _request;
        private AcreditacionUPSResponse _response;
        //private UsuarioModel _model;
        private DataContractJsonSerializer _jsonSerializer;
        private BRestOperation _restOperation;

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated(); // 
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            try
            {
                var path = ConfigurationManager.AppSettings["WCFPath"].ToString();
                var codigoSistema = ConfigurationManager.AppSettings["CodigoSistema"].ToString();
                path = path + "Services/SPersonasService.svc/AcreditacionUPS/";
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                _request = new AcreditacionUPSRequest();
                _request.Usuario = context.UserName;
                _request.Contrasena = context.Password;
                _request.CodigoSistema = codigoSistema;
                var dataToSend = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_request));
                using (_restOperation = new BRestOperation())
                {
                    var stream = _restOperation.Post(path, dataToSend);
                    _jsonSerializer = new DataContractJsonSerializer(typeof(AcreditacionUPSResponse));
                    _response = (AcreditacionUPSResponse)_jsonSerializer.ReadObject(stream);
                }
                if (_response != null)
                {
                    if(_response.Codigo.Equals("0000") || _response.Codigo.Equals("0001") || _response.Codigo.Equals("0002"))
                    {
                        var nombreCompleto = string.Format("{0} {1} {2}", _response.ApellidoPaterno, _response.ApellidoMaterno, _response.Nombres);
                        identity.AddClaim(new Claim(ClaimTypes.Role, "admin"));
                        identity.AddClaim(new Claim("username", _request.Usuario));
                        identity.AddClaim(new Claim(ClaimTypes.Name, nombreCompleto));
                        context.Validated(identity);
                    }
                    else
                    {
                        var error = string.Format("{0} - {1}", _response.Codigo, _response.Descripcion);
                        context.SetError(_response.Codigo, error);
                        return;
                    }
                }
                else
                {
                    context.SetError("Error desconocido", "Verificar el log del WebService para verificar el error");
                    return;
                }
            }
            catch (Exception ex)
            {
                context.SetError("Error desconocido", "Verificar el log del WebService para verificar el error");
                return;
            }
                        

            //try
            //{
            //    var path = ConfigurationManager.AppSettings["WCFPath"].ToString();
            //    path = path + "Services/SPersonasService.svc/BuscarUsuario/";
            //    var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            //    _model = new UsuarioModel();
            //    _model.Usuario = context.UserName;
            //    _model.Contrasena = context.Password;
            //    var dataToSend = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_model));
            //    using (_restOperation = new BRestOperation())
            //    {
            //        //var stream = _restOperation.Post("http://localhost/SeguridadService/Services/SPersonasService.svc/BuscarUsuario/", dataToSend);
            //        //var stream = _restOperation.Post("http://localhost:55291/Services/SPersonasService.svc/BuscarUsuario/", dataToSend);
            //        var stream = _restOperation.Post(path, dataToSend);
            //        _jsonSerializer = new DataContractJsonSerializer(typeof(UsuarioModel));
            //        _model = (UsuarioModel)_jsonSerializer.ReadObject(stream);
            //    }
            //    if(_model != null)
            //    {
            //        identity.AddClaim(new Claim(ClaimTypes.Role, "admin"));
            //        identity.AddClaim(new Claim("username", _model.Usuario));
            //        identity.AddClaim(new Claim(ClaimTypes.Name, _model.ApellidoPaterno + _model.ApellidoMaterno + _model.Nombres));
            //        context.Validated(identity);
            //    }
            //    else
            //    {
            //        context.SetError("invalid_grant", "Provided username and password is incorrect");
            //        return;
            //    }
            //}
            //catch(Exception ex)
            //{
            //    context.SetError("invalid_grant", "Provided username and password is incorrect");
            //    return;
            //}


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