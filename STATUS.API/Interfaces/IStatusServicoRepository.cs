using STATUS.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STATUS.API.Interfaces
{
    public interface IStatusServicoRepository
    {
        bool SalvarLista(List<StatusServico> listaStatus);
        bool Salvar(StatusServico status);
        List<ServicosCompartilhados> BuscarServicosCompartilhadosPorEstado(string uf);
        List<StatusServico> BuscarStatusAtualServicoPorEstadoEData(string uf, string data);
        List<StatusServico> BuscarHistoricoCompletoStatusServico();
    }
}
