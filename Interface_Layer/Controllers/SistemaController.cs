using AutoMapper;
using Domain_Layer.Dtos.Sistemas;
using Interface_Layer.App_Start;
using Interface_Layer.Models;
using Interface_Layer.Models.Sistemas;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web.Http;

namespace Interface_Layer.Controllers
{
    public class SistemaController : ApiController
    {
        private DSistemaDto _dtoSistema;
        //private DModuloDto _dtoModulo;
        //private byte[] _dataToSend;
        private DataContractJsonSerializer _jsonSerializer;
        //private SistemaModel _sistemaModel;

        public SistemaController()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<SistemaModel, DSistemaDto>();
                //config.CreateMap<DSistemaDto, SistemaModel>();
                config.CreateMap<ModuloModel, DModuloDto>();
            });
        }

        [HttpPut]
        public void ActualizarSistema(DSistemaDto model)
        {
            int response;
            //_dtoSistema = new DSistemaDto();
            //_dtoSistema = Mapper.Map<DSistemaDto>(model);

            _dtoSistema = model;
            //_dtoSistema.Id = postParam.Id;
            var dataToSend = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_dtoSistema));
            var stream = RestOperation.Post("http://localhost:55291/Services/SSistemasServices.svc/ActualizarSistema/", dataToSend);
            _jsonSerializer = new DataContractJsonSerializer(typeof(int));
            response = (int)_jsonSerializer.ReadObject(stream);
        }

        [HttpPost]
        public SistemaModel BuscarSistema(PassParameter postParam)
        {
            SistemaModel response;
            if (GlobalVariables.sistemaModel != null)
            {
                return GlobalVariables.sistemaModel;
            }
            _dtoSistema = new DSistemaDto();
            _dtoSistema.Id = postParam.Id;
            var dataToSend = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_dtoSistema));
            var stream = RestOperation.Post("http://localhost:55291/Services/SSistemasServices.svc/BuscarSistema/", dataToSend);
            _jsonSerializer = new DataContractJsonSerializer(typeof(SistemaModel));
            response = (SistemaModel)_jsonSerializer.ReadObject(stream);
            response.Modulos = GetModulosFromSistema(Mapper.Map<DSistemaDto>(response));
            GlobalVariables.sistemaModel = response;
            return response;
        }

        [HttpPost]
        public void InsertarSistema(DSistemaDto model)
        {
            int response;
            _dtoSistema = model;
            var dataToSend = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_dtoSistema));
            var stream = RestOperation.Post("http://localhost:55291/Services/SSistemasServices.svc/InsertarSistema/", dataToSend);
            _jsonSerializer = new DataContractJsonSerializer(typeof(int));
            response = (int)_jsonSerializer.ReadObject(stream);
        }

        [HttpPost]
        public IEnumerable<SistemaModel> ListarSistemas()
        {
            List<SistemaModel> response;
            _dtoSistema = new DSistemaDto();
            var dataToSend = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_dtoSistema));
            var stream = RestOperation.Post("http://localhost:55291/Services/SSistemasServices.svc/ListarSistemas/", dataToSend);
            _jsonSerializer = new DataContractJsonSerializer(typeof(List<SistemaModel>));
            response = (List<SistemaModel>)_jsonSerializer.ReadObject(stream);
            return response;
        }

        private List<ModuloModel> GetModulosFromSistema(DSistemaDto dtoSistema)
        {
            DModuloDto dtoModulo = new DModuloDto();
            List<ModuloModel> modulosModels;
            dtoModulo.Sistema = dtoSistema;
            var dataToSend = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(dtoModulo));
            var stream = RestOperation.Post("http://localhost:55291/Services/SSistemasServices.svc/ListarModulos/", dataToSend);
            _jsonSerializer = new DataContractJsonSerializer(typeof(List<ModuloModel>));
            modulosModels = (List<ModuloModel>)_jsonSerializer.ReadObject(stream);
            foreach (var moduloModel in modulosModels)
            {
                moduloModel.Menus = GetMenusFromModulo(Mapper.Map<DModuloDto>(moduloModel));
            }
            return modulosModels;
        }
        private List<MenuModel> GetMenusFromModulo(DModuloDto dtoModulo)
        {
            DMenuDto dtoMenu = new DMenuDto();
            List<MenuModel> menusModels;
            dtoMenu.Modulo = dtoModulo;
            var dataToSend = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(dtoMenu));
            var stream = RestOperation.Post("http://localhost:55291/Services/SSistemasServices.svc/ListarMenus/", dataToSend);
            _jsonSerializer = new DataContractJsonSerializer(typeof(List<MenuModel>));
            menusModels = (List<MenuModel>)_jsonSerializer.ReadObject(stream);
            return menusModels;
        }
    }
}