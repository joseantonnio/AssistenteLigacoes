using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Referencia MySQL
using MySql.Data.MySqlClient;

namespace AssistenteLigacoes
{
    class Conexao
    {

        private string host;

        public Conexao()
        {
            this.host = "localhost";
        }

        public string Host
        {
            get { return host; }
        }

        public MySqlConnection conecta()
        {

            // Cria a conexão com o MySQL
            MySqlConnection conexao = new MySqlConnection("server="+Host+";User Id=root;database=assistente_ligacoes; password=rootpass");
            return conexao;

        }

        public MySqlCommand comando(string codigo, MySqlConnection conexao)
        {

            // Busca usuário e senha no banco de dados
            MySqlCommand exec = new MySqlCommand(codigo, conexao);
            return exec;

        }

    }
}
