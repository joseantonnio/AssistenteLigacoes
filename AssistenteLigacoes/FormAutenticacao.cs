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
using System.IO;

// Referencia MySQL
using MySql.Data.MySqlClient;

// MetroFramework
using MetroFramework.Forms;

using System.Runtime.InteropServices;

namespace AssistenteLigacoes
{
    public partial class FormAutenticacao : MetroForm
    {

        // Declara variavel do usuario
        Usuario dados;

        public FormAutenticacao()
        {
            // Inicializa o FormAutenticacao
            InitializeComponent();

            this.Focus();
        
        }

        private void entrar_Click(object sender, EventArgs e)
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

                // Inicializa e exibe o FormPrincipal
                FormPrincipal Principal = new FormPrincipal(this, dados);
                Principal.Show();

            }
            else
            {
                    
                // Altera a cor para vermelho, informa o erro e exibe
                status.ForeColor = Color.OrangeRed;
                status.Text = "Usuário e/ou senha incorretos ou não existem.";
                status.Visible = true;

                return;

            }
        }

        private void password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                entrar_Click(this, new EventArgs());
            }

        }

        private void FormAutenticacao_Activated(object sender, EventArgs e)
        {
            username.Focus();
        }

        private void password_Enter(object sender, EventArgs e)
        {
            password.SelectAll();
        }
    }
}
