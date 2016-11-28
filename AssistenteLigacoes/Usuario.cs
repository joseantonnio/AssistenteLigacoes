using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Data;

// Referencia MySQL
using MySql.Data.MySqlClient;

namespace AssistenteLigacoes
{
    public class Usuario
    {

        public int id;
        public string login;
        private string senha;
        public string nome;
        public bool admin;
        private byte[] img;
        public MemoryStream avatar;
        public bool autenticado;

        private Conexao conexao;

        public Usuario(string usuario, string senha)
        {

            this.login = usuario;
            this.senha = gerarSHA256(senha);
            this.autenticado = false;

            conexao = new Conexao("assistente_ligacoes");

            MySqlDataReader busca = conexao.comando("SELECT * FROM usuarios WHERE usuario = '" + Login + "' AND senha = '" + Senha + "'").ExecuteReader();

            if (busca.HasRows)
            {
                while (busca.Read())
                {
                    id = (int)busca["u_id"];
                    nome = busca["nome"].ToString();
                    admin = busca.GetBoolean(busca.GetOrdinal("admin"));

                    if (busca["avatar"] != DBNull.Value)
                    {
                        img = (byte[])busca["avatar"];
                        avatar = new MemoryStream(img);
                    } else
                        avatar = null;

                    autenticado = true;
                }
            }

            // Limpa a busca
            busca.Close();

        }

        public int Id { set { id = value;  } get { return id; } }

        public string Login { set { login = value; } get { return login; } }

        private string Senha { set { senha = value; } get { return senha; } }

        public string Nome { set { nome = value; } get { return nome; } }

        public bool Admin { set { admin = value; } get { return admin; } }

        public MemoryStream Avatar { set { avatar = value; } get { return avatar; } }

        public bool Autenticado { set { autenticado = value; } get { return autenticado; } }

        public DataTable BuscarUsuarios()
        {
            if (admin)
                return conexao.busca("SELECT * FROM usuarios ORDER BY u_id ASC", "usuarios", conexao);
            else
                return conexao.busca("SELECT * FROM usuarios WHERE u_id = "+id, "usuarios", conexao);
        }

        public static string gerarSHA256(string texto)
        {

            // Utiliza a classe SHA256 do System Security
            SHA256 sha256 = SHA256Managed.Create();

            // Converte para bytes e gera a hash
            byte[] bytes = Encoding.UTF8.GetBytes(texto);
            byte[] hash = sha256.ComputeHash(bytes);

            // Cria uma string utilizando o StringBuilder
            StringBuilder resultado = new StringBuilder();

            // Realiza um laço que percorre cada byte do hash
            for (int i = 0; i < hash.Length; i++)
            {
                // Adiciona ao resultado o valor do byte
                resultado.Append(hash[i].ToString("x2"));
            }

            // Retorna a hash
            return resultado.ToString();

        }

    }
}
