using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Threading.Tasks;

// Referencia MySQL
using MySql.Data.MySqlClient;

namespace AssistenteLigacoes
{
    class Ramal : Telefone
    {
        public int numero;
        public int status;
        public bool ativo;
        public int responsavel;

        public Ramal(int prefixo, int sufixo) : base (prefixo)
        {
            this.numero = sufixo;
        }

        public int Numero { set { numero = value; } get { return numero; } }
        public int Status { set { status = value; } get { return status; } }
        public bool Ativo { set { ativo = value; } get { return ativo; } }
        public int Responsavel { set { responsavel = value; } get { return responsavel; } }
        public string prefixoMask {
            get {
                string convertido = prefixo.ToString();
                string ddd = new string(convertido.Take(2).ToArray());
                string digitos = new string(convertido.Reverse().Take(4).Reverse().ToArray());
                return "("+ddd+") "+digitos;
            }
        }

        // Metodo Busca Ramais
        public DataTable BuscaRamais(int id)
        {

            DataTable results = new DataTable("ramais");

            using (MySqlDataReader busca = conexao.comando("SELECT * FROM ramais WHERE responsavel = " + id + " AND prefixo = " + prefixo, conecta).ExecuteReader())
                results.Load(busca);

            return results;

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