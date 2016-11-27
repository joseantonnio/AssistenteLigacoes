using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

// Referencia MySQL
using MySql.Data.MySqlClient;

namespace AssistenteLigacoes
{
    public class Ramal : Telefone
    {
        public int numero;
        public int status;
        public bool ativo;
        public int responsavel;
        public int ultima;

        public Ramal(int prefixo, int sufixo, int id) : base (prefixo)
        {

            this.numero = sufixo;
            this.status = 0;
            this.ativo = false;
            this.responsavel = 0;

            DataTable busca = conexao.busca("SELECT * FROM ramais WHERE responsavel = " + id + " AND prefixo = " + prefixo + " AND numero = " + numero + " LIMIT 1", "ramais", conexao);

            // Percorre os resultados
            foreach (DataRow row in busca.Rows)
            {

                this.status = int.Parse(row["status"].ToString());
                this.ativo = bool.Parse(row["ativo"].ToString());
                this.responsavel = id;

            }


        }

        public int Numero { set { numero = value; } get { return numero; } }
        public int Status { set { status = value; } get { return status; } }
        public bool Ativo { set { ativo = value; } get { return ativo; } }
        public int Responsavel { set { responsavel = value; } get { return responsavel; } }
        public string PrefixoMask {
            get {
                string convertido = prefixo.ToString();
                string ddd = new string(convertido.Take(2).ToArray());
                string digitos = new string(convertido.Reverse().Take(4).Reverse().ToArray());
                return "("+ddd+") "+digitos;
            }
        }

        // Metodo Busca Ramais
        public DataTable BuscaRamais(int id, bool todos)
        {

            if (todos)
                return conexao.busca("SELECT * FROM ramais WHERE prefixo = " + prefixo, "ramais", conexao);
            else
                return conexao.busca("SELECT * FROM ramais WHERE responsavel = " + id + " AND prefixo = " + prefixo, "ramais", conexao);

        }

        //Método Busca Ligacoes
        public DataTable BuscaLigacoes(bool ultima, string num = "", string tipo = "", string de = "", string ate= "")
        {

            string sql;

            if (ultima)
            {
                sql = "SELECT * FROM chamadas WHERE telefone = " + prefixo + " AND ramal = " + numero + " ORDER BY c_id DESC LIMIT 1";
            }
            else
            {

                if (num == "" && tipo == "" && de == "" && ate == "")
                {
                    sql = "SELECT * FROM chamadas WHERE telefone = " + prefixo + " AND ramal = " + numero;
                }
                else
                {
                    sql = "SELECT * FROM chamadas WHERE telefone = " + prefixo;

                    if (num != "")
                        sql += " AND ramal = " + num;

                    if (tipo != "")
                        sql += " AND tipo = " + tipo;

                    if (de != "")
                        sql += " AND inicio > DATE('" + de + "')";

                    if (de != "" && ate != "")
                        sql += " AND";

                    if (ate != "")
                        sql += " fim < DATE('" + ate + "')";

                }

            }
                

            return conexao.busca(sql, "ramais", conexao);

        }

        //Método Busca Origem 
        public void BuscaOrigem()
        {

        }


        //Método Busca Destino
        public void BuscaDestino()
        {

        }

        public bool AtualizarStatus(int novo)
        {
            if (ativo)
            {

                conexao.comando("UPDATE ramais SET status = " + novo + " WHERE numero = " + numero + " AND prefixo = " + prefixo + " AND responsavel = " + responsavel).ExecuteNonQuery();
                return true;

            }

            return false;
            
        }

        public void RegistrarAcesso()
        {
            
            conexao.comando("UPDATE ramais SET ultimo_acesso = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' WHERE numero = " + numero + " AND prefixo = " + prefixo + " AND responsavel = " + responsavel).ExecuteNonQuery();

        }

        public bool InserirObservacao(string observacao)
        {

            int exec = conexao.comando("UPDATE chamadas SET observacoes = '" + observacao + "' WHERE c_id = " + ultima).ExecuteNonQuery();

            if (exec < 1)
            {
                return false;
            } else
            {
                return true;
            }

        }

    }
}