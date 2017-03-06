using Domain_Layer.Dtos.Sistemas;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Service_Layer.Services.Sistemas
{
    [ServiceContract]
    public interface ISMenuService
    {
        [OperationContract]
        [WebInvoke(Method = "GET",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "ListarMenus/")]
        List<DMenuDto> Listar();
    }
}
