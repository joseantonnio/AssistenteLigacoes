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

            Clear();

            this.numero = sufixo;
            this.status = 0;
            this.ativo = false;
            this.responsavel = 0;

            DataTable busca = conexao.busca("SELECT * FROM ramais WHERE prefixo = '" + prefixo + "' AND numero = '" + numero + "'", "busca", conexao);

            // Percorre os resultados
            foreach (DataRow row in busca.Rows)
            {

                this.status = int.Parse(row["status"].ToString());
                this.ativo = bool.Parse(row["ativo"].ToString());
                this.responsavel = int.Parse(row["responsavel"].ToString());

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
                        sql += " AND inicio > '" + de + "'";

                    if (de != "" && ate != "")
                        sql += " AND";

                    if (ate != "")
                        sql += " inicio < '" + ate + "'";

                }

            }
                

            return conexao.busca(sql, "ramais", conexao);

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

        public bool InserirRamal(string t, string n, bool a, int r)
        {

            try
            {
                conexao.comando("INSERT INTO ramais (numero, prefixo, status, ativo, responsavel) VALUES (" + n + ", " + t + ", 0, " + a + ", " + r + ")").ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                return false;
            }

            return true;


        }

        public bool AtualizarRamal(string t, string n, bool a, int r)
        {

            try
            {
                conexao.comando("UPDATE ramais SET ativo = " + a + ", responsavel = " + r + " WHERE prefixo = "+t+" AND numero = "+n).ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                return false;
            }

            return true;


        }

        public bool ExcluirRamal(string t, string n)
        {

            try
            {
                conexao.comando("DELETE FROM ramais WHERE prefixo = " + t + " AND numero = " + n).ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                return false;
            }

            return true;


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

        public void Clear()
        {

            this.numero = 0;
            this.status = 0;
            this.ativo = false;
            this.responsavel = 0;
            this.ultima = 0;

    }

    }
}