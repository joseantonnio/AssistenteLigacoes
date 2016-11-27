using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

// Importar JSON
using System.Net;
using Newtonsoft.Json;

// Referencia MySQL
using MySql.Data.MySqlClient;

namespace AssistenteLigacoes
{
    public class Telefone
    {

        public int prefixo;
        public string cidade;
        public string uf;
        public string operadora;
        public int tipo;
        public string pais;
        protected Conexao conexao;

        public Telefone(int prefixo)
        {

            this.prefixo = prefixo;
            this.cidade = "";
            this.uf = "";
            this.operadora = "";
            this.tipo = 0;
            this.pais = "";

            conexao = new Conexao("assistente_ligacoes");

            consultaJson();

        }

        public int Prefixo { set { prefixo = value; } get { return prefixo; } }
        public string Cidade { set { cidade = value; } get { return cidade.ToUpper(); } }
        public string Uf { set { uf = value; } get { return uf.ToUpper(); } }
        public string Operadora {
            set {
                operadora = value;
            }
            get {

                if (operadora.Length > 18)
                {
                    string limit = new string(operadora.Take(15).ToArray());
                    return limit.ToUpper() + "...";
                }
                else
                {
                    return operadora.ToUpper();
                }
                
            }
        }
        public int Tipo { set { tipo = value; } get { return tipo; } }
        public string Pais { set { pais = value; } get { return pais.ToUpper(); } }

        // Metodo Busca Ramais
        public DataTable BuscaTelefones()
        {

            return conexao.busca("SELECT * FROM telefones", "telefones", conexao);

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

        // Busca prefixo na Anatel
        public void consultaJson()
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
                    bytes = Encoding.Default.GetBytes(s.operadora);
                    s.operadora = Encoding.UTF8.GetString(bytes);

                    // Adiciona os dados no grid
                    this.cidade = s.cidade;
                    this.uf = s.uf;
                    this.operadora = s.operadora;
                    this.tipo = s.tipo;
                    this.pais = s.pais;
                }

            }

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
