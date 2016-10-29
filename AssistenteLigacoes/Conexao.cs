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

        public static MySqlConnection conecta()
        {

            // Cria a conexão com o MySQL
            MySqlConnection conexao = new MySqlConnection("server=localhost;User Id=root;database=assistente_ligacoes; password=rootpass");

            return conexao;

        }

    }
}
