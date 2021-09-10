using NSoup;
using NSoup.Nodes;
using NSoup.Select;
using STATUS.API.Models;
using STATUS.API.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STATUS.API.Utils
{
    public class NSoupService
    {
        public List<StatusServicoResult> ConsultarDisponibilidadeServico()
        {
            Document doc = NSoupClient
                .Connect("http://www.nfe.fazenda.gov.br/portal/disponibilidade.aspx")
                .Get();

            Element dataTable = doc.Select("table.tabelaListagemDados").FirstOrDefault();
            var listaStatus = this.ConsultarDadosStatus(dataTable);

            return listaStatus;
        }

        public List<StatusServicoResult> ConsultarDadosStatus(Element dataTable)
        {
            Elements headers = dataTable.Select("th");

            int qtdColunas = headers.Count();
            string[] cabecalhoTabela = new String[qtdColunas];
            string[] dados = new String[qtdColunas];

            for (int i = 0; i < qtdColunas; i++)
            {
                cabecalhoTabela[i] = headers[i].Text();
            }

            Elements linhas = dataTable.Select("tr");
            List<StatusServicoResult> listaStatus = new List<StatusServicoResult>();
            int qtdLinhas = linhas.Count();

            for (int i = 1; i < qtdLinhas; i++)
            {
                Elements dadosDaLinha = linhas[i].Select("td");

                for (int j = 0; j < qtdColunas; j++)
                {
                    Element td = dadosDaLinha[j];
                    string img = td.Select("img").Attr("src");
                    dados[j] = string.IsNullOrEmpty(img) ? td.Text() : img;
                }

                StatusServicoResult statusServico = new StatusServicoResult(dados);
                listaStatus.Add(statusServico);
            }

            return listaStatus;
        }
    }
}
