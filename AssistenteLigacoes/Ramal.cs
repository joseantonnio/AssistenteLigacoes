using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssistenteLigacoes
{
    class Ramal : Telefone
    {
        public int numero;
        public int status;
        public bool ativo;
        public int responsavel;

        public Ramal(int prefixo) : base (prefixo)
        {  
         
        }

        public int Numero { set { numero = value; } get { return numero; } }
        public int Status { set { status = value; } get { return status; } }
        public bool Ativo { set { ativo = value; } get { return ativo; } }
        public int Responsavel { set { responsavel = value; } get { return responsavel; } }

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

    }
}