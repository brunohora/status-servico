using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using STATUS.API.Interfaces;
using STATUS.API.Models;
using STATUS.API.Results;
using STATUS.API.Utils;
using System.Collections.Generic;
using System.Linq;

namespace STATUS.API.Controllers
{
    [ApiController]
    [Route("/api/[Controller]")]
    public class StatusServicoController : ControllerBase
    {
        private readonly IStatusServicoRepository _repository;
        public StatusServicoController(IStatusServicoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public List<StatusServicoResult> BuscarStatusAtualServico()
        {
            return new NSoupService().ConsultarDisponibilidadeServico();
        }

        [HttpGet("{estado}")]
        public List<StatusServicoResult> BuscarStatusAtualServicoPorEstado(string estado)
        {
            var result = new NSoupService().ConsultarDisponibilidadeServico();

            var servicos = _repository.BuscarServicosCompartilhadosPorEstado(estado);
            var listaStatus = result.Where(result => result.Autorizador.Equals(estado)).ToList();
            
            foreach (var servico in servicos)
            {
                var status = result.FirstOrDefault(result => result.Autorizador.Equals(servico.SIGLA));
                listaStatus.Add(status);
            }

            return listaStatus;
        }

        [HttpGet("{estado}/{data}")]
        public List<StatusServico> BuscarStatusAtualServicoPorEstadoEData(string estado, 
            string data)
        {
            return _repository.BuscarStatusAtualServicoPorEstadoEData(estado, data);
        }

        [HttpGet("MaiorIndisponibilidade")]
        public List<object> BuscarMaiorIndisponibilidadeServico()
        {
            var listaStatus = _repository.BuscarHistoricoCompletoStatusServico();

            var maioresIndisponibilidades = listaStatus.Where(status =>
                status.Autorizacao4.Equals(false) ||
                status.ConsultaCadastro4.Equals(false) ||
                status.ConsultaCadastro4.Equals(false) ||
                status.ConsultaProtocolo4.Equals(false) ||
                status.Inutilizacao4.Equals(false) ||
                status.RecepcaoEvento4.Equals(false) ||
                status.RetornoAutorizacao4.Equals(false) ||
                status.StatusServico4.Equals(false)
            ).ToList();

            var itensAgrupados = maioresIndisponibilidades.GroupBy(status => status.Autorizador).ToList();
            var listaObj = new List<object>();

            foreach (var item in itensAgrupados)
            {
                listaObj.Add(new { Autorizador = item.Key, Quantidade = item.Count() });
            }

            return listaObj;
        }

        [HttpPost("")]
        public ObjectResult GravarStatusAtualServico([FromBody]string content)
        {
            var listaResult = JsonConvert.DeserializeObject<List<StatusServicoResult>>(content);
            var listaStatus = StatusServico.Converter(listaResult);

            var result = _repository.SalvarLista(listaStatus);

            if (result)
            {
                return this.Created("", StatusServico.Converter(listaStatus));
            }
            else
            {
                return this.BadRequest(new { errorMessage = "Ocorreu um erro ao realizar a solicitação." });
            }
        }
    }
}
