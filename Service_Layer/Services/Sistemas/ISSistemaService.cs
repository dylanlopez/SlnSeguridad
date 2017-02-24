using Domain_Layer.Dtos;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Service_Layer.Services.Sistemas
{
    [ServiceContract]
    public interface ISSistemaService
    {
        [OperationContract]
        [WebInvoke(Method = "GET",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "ListarSistemas/")]
        List<DSistemaDto> Listar();
    }
}
