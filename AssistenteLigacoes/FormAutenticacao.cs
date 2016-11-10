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

        // Declara variavel do usuario
        Usuario dados;

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
            string p = password.Text;

            dados = new Usuario(u, p);

            if (dados.autenticado) {

                // Limpa o usuário e senha
                username.Text = "";
                password.Text = "";

                // Oculta a mensagem de status
                status.Visible = false;

                // Oculta o FormAutenticacao
                Hide();

                // Verifica se é administrador
                if (dados.admin && isAdmin)
                {
                    MessageBox.Show("Usuário terá permissões de administrador!");
                }

                // Inicializa e exibe o FormPrincipal
                FormPrincipal Principal = new FormPrincipal(this, dados);
                Principal.Show();

            }
            else
            {
                    
                // Altera a cor para vermelho, informa o erro e exibe
                status.ForeColor = Color.OrangeRed;
                status.Text = "Usuário e senha incorretos.";
                status.Visible = true;

                return;

            }
        }

        private void FormAutenticacao_Load(object sender, EventArgs e)
        {

        }

        private void FormAutenticacao_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
