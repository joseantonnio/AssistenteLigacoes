using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

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

        public MySqlConnection inicia;

        public Conexao(string banco)
        {

            this.host = "localhost";
            this.usuario = "root";
            this.senha = "rootpass";
            this.banco = banco;

            inicia = new MySqlConnection("server=" + Host + ";User Id=" + Usuario + ";database=" + Banco + "; password=" + Senha); 

            // Abre conexão
            try
            {
                inicia.Open();
            }
            catch
            {
                MessageBox.Show("Não foi possível conectar o banco de dados.", "Erro de conexão", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

        }

        public string Host { get { return host; } }
        public string Usuario { get { return usuario; } }
        public string Banco { set { banco = value; } get { return banco; } }
        public string Senha { get { return senha; } }

        public MySqlCommand comando(string codigo)
        {

            // Busca usuário e senha no banco de dados
            MySqlCommand exec = new MySqlCommand(codigo, inicia);
            return exec;

        }

        public DataTable busca(string consulta, string nome, Conexao conexao)
        {

            DataTable results = new DataTable(nome);

            using (MySqlDataReader busca = conexao.comando(consulta).ExecuteReader())
                results.Load(busca);

            return results;

        }

    }
}
