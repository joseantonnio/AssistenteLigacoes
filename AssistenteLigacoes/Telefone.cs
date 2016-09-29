using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssistenteLigacoes
{
    class Telefone
    {   
        // Atributos 
        private int ddd;
        private int prefixo;

        public Telefone (int ddd,int prefixo)
        {
            this.ddd = ddd;
            this.prefixo = prefixo;
        }

        public int Ddd
        {
            get { return ddd; }
            set { ddd = value; }
        }

        public int Prefixo
        {
            get { return prefixo; }
            set { prefixo = value; }
        }

        //Método Recebe Ligacção
        public void RecebeLigacao()
        {

        }

        //Método Realiza Ligacção
        public void RealizaLigacao()
        {

        }

        //Método Finaliza Ligacção
        public void FinalizaLigacao()
        {

        }

        //Método Busca Geral
        public void BuscaGeral()
        {

        }


        public override string ToString()
        {
            return "(" + Ddd + ")" + prefixo +"-" ;
        }

    }
}
