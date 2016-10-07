using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssistenteLigacoes
{
    class Ramal : Telefone
    {
        private int sufixo;
        private string dataInicio;
        private string dataFim;

        public Ramal (int sufixo, string dataInicio, string dataFim, int ddd, int prefixo) : base(ddd, prefixo)
        {
            this.sufixo = sufixo;
            this.dataInicio = dataInicio;
            this.dataFim = dataFim;
    
        }


        public int Sufixo
        {
            get { return sufixo; }
            set { sufixo = value; }
        }

        public string DataInicio
        {
            get { return dataInicio; }
            set { dataInicio = value; }
        }

        public string DataFim
        {
            get { return dataFim; }
            set { dataFim = value; }
        }



        //Método Autentica Usuario
        public void AutenticaUsuario()
        {

        }

        //Método Desliga Usuario
        public void DesligaUsuario()
        {

        }

        //Método Busca Ligacoes
        public void BuscaLigacoes()
        {

        }

        //Método Busca Origem 
        public void BuscaOrigem()
        {

        }


        //Método Busca Destino
        public void buscaDestino()
        {

        }


        public override string ToString()
        {
            return "(" + Ddd + ")" + Prefixo + "-" + Sufixo + " Data Inicio: " + DataInicio+ "Data Final : " + DataFim ;
        }
    }
}
