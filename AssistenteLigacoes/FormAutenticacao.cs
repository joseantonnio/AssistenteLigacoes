using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// MetroFramework
using MetroFramework.Forms;

namespace AssistenteLigacoes
{
    public partial class FormAutenticacao : MetroForm
    {

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

            // Armazena o usuário e senha em variáveis
            string u = username.Text;
            string p = password.Text;

            // Verifica se o usuário passa na autenticação
            if (u == "admin" && p == "admin" && isAdmin == true)
            {

                // Troca a cor, informa que logou como admin e exibe
                status.ForeColor = System.Drawing.Color.ForestGreen;
                status.Text = "Entra como admin...";
                status.Visible = true;

            }
            else
            {

                // Verifica se é um usuário comum
                if (u == "user" && p == "user" && isAdmin == false)
                {

                    // Limpa o usuário e senha
                    username.Text = "";
                    password.Text = "";

                    // Oculta a mensagem de status
                    status.Visible = false;

                    // Oculta o FormAutenticacao
                    Hide();

                    // Inicializa e exibe o FormPrincipal
                    FormPrincipal Principal = new FormPrincipal(this);
                    Principal.Show();

                }
                else
                {
                    
                    // Altera a cor para vermelho, informa o erro e exibe
                    status.ForeColor = System.Drawing.Color.OrangeRed;
                    status.Text = "Usuário e senha incorretos.";
                    status.Visible = true;

                }

            }
        }

        private void FormAutenticacao_Load(object sender, EventArgs e)
        {
            
        }
    }
}
