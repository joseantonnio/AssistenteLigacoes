using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
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

        public Ramal(int prefixo = 0, int ramal = 0) : base (prefixo)
        {

            this.numero = ramal;
         
        }

        public int Numero { set { numero = value; } get { return numero; } }
        public int Status { set { status = value; } get { return status; } }
        public bool Ativo { set { ativo = value; } get { return ativo; } }
        public int Responsavel { set { responsavel = value; } get { return responsavel; } }

        // Metodo Busca Ramais
        public List<List<string>> BuscaRamais(int id)
        {

            List<List<string>> list = new List<List<string>>();
            List<string> registro = new List<string>();

            MySqlDataReader busca = conexao.comando("SELECT * FROM ramais WHERE responsavel = " + id, conecta).ExecuteReader();

            if (busca.HasRows)
            {

                var c = 0;

                while (busca.Read())
                {
                    registro.Add(busca["numero"].ToString());
                    registro.Add(busca["prefixo"].ToString());
                    registro.Add(busca["status"].ToString());
                    registro.Add(busca["ativo"].ToString());
                    registro.Add(busca["responsavel"].ToString());
                    c++;
                }

                for (var i = 0; i < c; i++)
                {

                    for(var k = 0; k < busca.FieldCount; k++)
                    {

                    }

                }

            }

            // Limpa a busca
            busca.Close();

            return list;

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