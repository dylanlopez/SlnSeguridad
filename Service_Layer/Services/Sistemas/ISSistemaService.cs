using Domain_Layer.Dtos.Sistemas;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Service_Layer.Services.Sistemas
{
    [ServiceContract]
    public interface ISSistemaService
    {
        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "ListarSistemas/")]
        List<DSistemaDto> Listar(DSistemaDto dto);
    }
}
