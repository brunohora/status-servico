using STATUS.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STATUS.API.Results
{
    public class StatusServicoResult
    {
        public string Autorizador { get; set; }
        public bool Autorizacao4 { get; set; }
        public bool RetornoAutorizacao4 { get; set; }
        public bool Inutilizacao4 { get; set; }
        public bool ConsultaProtocolo4 { get; set; }
        public bool StatusServico4 { get; set; }
        public string TempoMedio { get; set; }
        public bool ConsultaCadastro4 { get; set; }
        public bool RecepcaoEvento4 { get; set; }

        public StatusServicoResult()
        {
                
        }

        public StatusServicoResult(string[] array)
        {
            Autorizador = array[0];
            Autorizacao4 = ConvertStatusImgToBoolean(array[1]);
            RetornoAutorizacao4 = ConvertStatusImgToBoolean(array[2]);
            Inutilizacao4 = ConvertStatusImgToBoolean(array[3]);
            ConsultaProtocolo4 = ConvertStatusImgToBoolean(array[4]);
            StatusServico4 = ConvertStatusImgToBoolean(array[5]);
            TempoMedio = array[6];
            ConsultaCadastro4 = ConvertStatusImgToBoolean(array[7]);
            RecepcaoEvento4 = ConvertStatusImgToBoolean(array[8]);
        }

        public StatusServicoResult(string autorizador,
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
        }

        public static bool ConvertStatusImgToBoolean(string value, string statusValue = "")
        {
            if (value.Trim().Contains("bola_verde"))
            {
                return true;
            }

            return false;
        }
    }
}
