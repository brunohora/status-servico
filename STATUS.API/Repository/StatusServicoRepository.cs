using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using STATUS.API.Interfaces;
using STATUS.API.Models;
using System.Collections.Generic;
using System.Linq;

namespace STATUS.API.Repository
{
    public class StatusServicoRepository : IStatusServicoRepository
    {
        private readonly BaseContext _context;
        public StatusServicoRepository()
        {
            _context = new BaseContext();
        }
        public bool Salvar(StatusServico status)
        {
            _context.StatusServico.Add(status);
            return _context.SaveChanges() > 0;
        }

        public bool SalvarLista(List<StatusServico> listaStatus)
        {
            _context.StatusServico.AddRange(listaStatus);
            return _context.SaveChanges() > 0;
        }

        public List<ServicosCompartilhados> BuscarServicosCompartilhadosPorEstado(string uf)
        {
            var query = "buscarServicosCompartilhadosPorEstado @UF";
            var parametro = new SqlParameter("@UF", uf);

            return _context.ServicoCompartilhado
                .FromSqlRaw(query, parametro)
                .ToList();
        }

        public List<StatusServico> BuscarStatusAtualServicoPorEstadoEData(string uf, string data)
        {
            var query = "buscarStatusServicosPorEstadoEData @UF, @DATA";
            
            var parametros = new SqlParameter[]
            {
                new SqlParameter("@UF", uf),
                new SqlParameter("@DATA", data),
            };

            return _context.StatusServico
                .FromSqlRaw(query, parametros)
                .ToList();
        }

        public List<StatusServico> BuscarHistoricoCompletoStatusServico()
        {
            return _context.StatusServico.ToList();
        }
    }
}
