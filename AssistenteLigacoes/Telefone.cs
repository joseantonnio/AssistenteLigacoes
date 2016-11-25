using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

// Importar JSON
using System.Net;
using Newtonsoft.Json;

// Referencia MySQL
using MySql.Data.MySqlClient;

namespace AssistenteLigacoes
{
    class Telefone
    {

        public int prefixo;
        public string cidade;
        public string uf;
        public string operadora;
        public int tipo;
        public string pais;

        protected Conexao conexao;
        protected MySqlConnection conecta;

        public Telefone(int prefixo)
        {

            this.prefixo = prefixo;

            conexao = new Conexao("assistente_ligacoes");
            conecta = conexao.conecta();

            // Abre conexão
            try
            {
                conecta.Open();
            }
            catch
            {
                MessageBox.Show("Não foi possível conectar o banco de dados.", "Erro de conexão", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            MySqlDataReader busca = conexao.comando("SELECT * FROM telefones WHERE prefixo = " + Prefixo, conecta).ExecuteReader();

            if (busca.HasRows)
            {

                // Faz o download dos dados JSON
                var json = new WebClient().DownloadString("https://raw.githubusercontent.com/joseantonnio/AssistenteLigacoes/master/Anatel/prefixos.json");

                // Armazena os dados em uma array de saída
                var saida = JsonConvert.DeserializeObject<List<JSONResult>>(json);

                // Cria um laço para percorrer os dados
                foreach (JSONResult s in saida)
                {

                    if (s.prefixo == prefixo.ToString())
                    {
                        // Converte de UTF8 para String
                        byte[] bytes = Encoding.Default.GetBytes(s.cidade);
                        s.cidade = Encoding.UTF8.GetString(bytes);

                        // Adiciona os dados no grid
                        this.cidade = s.cidade;
                        this.uf = s.uf;
                        this.operadora = s.operadora;
                        this.tipo = s.tipo;
                        this.pais = s.pais;
                    }

                }
            }

            // Limpa a busca
            busca.Close();

        }

        public int Prefixo { set { prefixo = value; } get { return prefixo; } }
        public string Cidade { set { cidade = value; } get { return cidade; } }
        public string Uf { set { uf = value; } get { return uf; } }
        public string Operadora { set { operadora = value; } get { return operadora; } }
        public int Tipo { set { tipo = value; } get { return tipo; } }
        public string Pais { set { pais = value; } get { return pais; } }

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

    }

    class JSONResult
    {
        public string prefixo { get; set; }
        public string cidade { get; set; }
        public string uf { get; set; }
        public string operadora { get; set; }
        public int tipo { get; set; }
        public string pais { get; set; }
    }
}
