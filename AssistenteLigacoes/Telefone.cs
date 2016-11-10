using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssistenteLigacoes
{
    class Telefone
    {

        public Telefone()
        {
            
        }

        // Atributos do JSON
        public int prefixo { get; set; }
        public string cidade { get; set; }
        public string uf { get; set; }
        public string operadora { get; set; }
        public int tipo { get; set; }
        public string pais { get; set; }

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

        // Busca prefixo na Anatel
        public void consultaJson()
        {

        }


        public override string ToString()
        {
            return Convert.ToString(prefixo);
        }

    }
}
