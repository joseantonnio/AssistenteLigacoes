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
        private string usuario;
        public string banco;
        private string senha;

        public Conexao(string banco)
        {
            this.host = "localhost";
            this.usuario = "root";
            this.senha = "rootpass";
            this.banco = banco;
        }

        public string Host { get { return host; } }
        public string Usuario { get { return usuario; } }
        public string Banco { set { banco = value; } get { return banco; } }
        public string Senha { get { return senha; } }


        public MySqlConnection conecta()
        {

            // Cria a conexão com o MySQL
            MySqlConnection conexao = new MySqlConnection("server="+Host+";User Id="+Usuario+";database="+Banco+"; password="+Senha);
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
