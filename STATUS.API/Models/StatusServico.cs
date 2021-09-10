using STATUS.API.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace STATUS.API.Models
{
    public class StatusServico
    {	
		public int Id {get; private set;}
		public string Autorizador {get;private set;}
		public bool Autorizacao4 {get;private set;}
		public bool RetornoAutorizacao4 {get;private set;}
		public bool Inutilizacao4 {get;private set;}
		public bool ConsultaProtocolo4 {get;private set;}
		public bool StatusServico4 {get;private set;}
		public string TempoMedio {get;private set;}
		public bool ConsultaCadastro4 {get;private set;}
		public bool RecepcaoEvento4 {get;private set;}
		public DateTime DataRegistro {get;private set;}

		public StatusServico() { }

        public StatusServico(string autorizador, 
            bool autorizacao4, 
            bool retornoAutorizacao4, 
            bool inutilizacao4, 
            bool consultaProtocolo4, 
            bool statusServico4, 
            string tempoMedio, 
            bool consultaCadastro4, 
            bool recepcaoEvento4)
        {
            Autorizador = autorizador;
            Autorizacao4 = autorizacao4;
            RetornoAutorizacao4 = retornoAutorizacao4;
            Inutilizacao4 = inutilizacao4;
            ConsultaProtocolo4 = consultaProtocolo4;
            StatusServico4 = statusServico4;
            TempoMedio = tempoMedio;
            ConsultaCadastro4 = consultaCadastro4;
            RecepcaoEvento4 = recepcaoEvento4;
            DataRegistro = DateTime.Now;
        }

        public static List<StatusServico> Converter(List<StatusServicoResult> listaResult)
        {
            var listaStatusServico = new List<StatusServico>();

            listaResult.ForEach(result => {
                listaStatusServico.Add(new StatusServico(
                    result.Autorizador,
                    result.Autorizacao4,
                    result.RetornoAutorizacao4,
                    result.Inutilizacao4,
                    result.ConsultaProtocolo4,
                    result.StatusServico4,
                    result.TempoMedio,
                    result.ConsultaCadastro4,
                    result.RecepcaoEvento4)
                );
            });

            return listaStatusServico;
        }

        public static List<StatusServicoResult> Converter(List<StatusServico> listaStatusServico)
        {
            var listaResult = new List<StatusServicoResult>();

            listaStatusServico.ForEach(statusServico => {
                listaResult.Add(new StatusServicoResult(
                    statusServico.Autorizador,
                    statusServico.Autorizacao4,
                    statusServico.RetornoAutorizacao4,
                    statusServico.Inutilizacao4,
                    statusServico.ConsultaProtocolo4,
                    statusServico.StatusServico4,
                    statusServico.TempoMedio,
                    statusServico.ConsultaCadastro4,
                    statusServico.RecepcaoEvento4)
                );
            });

            return listaResult;
        }
    }
}
