using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

// Referencia MySQL
using MySql.Data.MySqlClient;

// MetroFramework
using MetroFramework.Forms;

namespace AssistenteLigacoes
{
    public partial class FormAutenticacao : MetroForm
    {

        // Declara variaveis de conexão com o MySQL
        private MySqlConnection conexao;

        // Declara uma variavel para verificar se o usuário é admin ou não
        private bool isAdmin = false;

        public FormAutenticacao()
        {
            // Inicializa o FormAutenticacao
            InitializeComponent();
        }

        private void useradmin_CheckedChanged(object sender, EventArgs e)
        {
            // Altera a variavel isAdmin para verdadeiro
            isAdmin = true;
        }

        private void userdefault_CheckedChanged(object sender, EventArgs e)
        {
            // Altera a variavel isAdmin para falso
            isAdmin = false;
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

        private void metroButton1_Click(object sender, EventArgs e)
        {

            // Verifica se campos foram preenchidos
            if (username.Text == "")
            {

                // Altera a cor para vermelho, informa o erro e exibe
                status.ForeColor = Color.OrangeRed;
                status.Text = "Digite o seu usuário...";
                status.Visible = true;

                // Finaliza a execução do evento
                return;

            }

            // Verifica se campos foram preenchidos
            if (password.Text == "")
            {

                // Altera a cor para vermelho, informa o erro e exibe
                status.ForeColor = Color.OrangeRed;
                status.Text = "Digite sua senha...";
                status.Visible = true;

                // Finaliza a execução do evento
                return;

            }

            // Armazena o usuário e senha em variáveis
            string u = username.Text;
            string p = gerarSHA256(password.Text);

            // Busca usuário e senha no banco de dados
            MySqlCommand comando = new MySqlCommand("SELECT nome, admin FROM usuarios WHERE usuario = '" + u + "' AND senha = '" + p + "'", conexao);

            // Executa a busca
            MySqlDataReader busca = comando.ExecuteReader();

            // Verifica se o usuário passa na autenticação
            if (busca.HasRows)
            {
                // Limpa o usuário e senha
                username.Text = "";
                password.Text = "";

                // Oculta a mensagem de status
                status.Visible = false;

                // Oculta o FormAutenticacao
                Hide();

                // Pega a permissão do usuário
                busca.Read();
                bool permissao = busca.GetBoolean(busca.GetOrdinal("admin"));

                // Limpa a busca
                busca.Close();

                // Verifica se é administrador
                if (permissao && isAdmin)
                {
                    MessageBox.Show("Usuário terá permissões de administrador!");
                }

                // Inicializa e exibe o FormPrincipal
                FormPrincipal Principal = new FormPrincipal(this);
                Principal.Show();

            }
            else
            {
                    
                // Altera a cor para vermelho, informa o erro e exibe
                status.ForeColor = Color.OrangeRed;
                status.Text = "Usuário e senha incorretos.";
                status.Visible = true;

                // Limpa a busca
                busca.Close();

                return;

            }
        }

        private void FormAutenticacao_Load(object sender, EventArgs e)
        {

            // Define string de conexão
            conexao = Conexao.conecta();

            // Abre conexão
            try
            {
                conexao.Open();
            }
            catch
            {
                MessageBox.Show("Não foi possível conectar ao banco de dados! Entre em contato com o suporte.");
            }
        }

        private void FormAutenticacao_FormClosing(object sender, FormClosingEventArgs e)
        {
            conexao.Close();
        }
    }
}
