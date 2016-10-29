using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Metro Framework
using MetroFramework.Forms;

namespace AssistenteLigacoes
{
    public partial class FormPrincipal : MetroForm
    {

        // Declara uma variavel para armazenar o FormAutenticacao
        private FormAutenticacao Autentica;

        
        public FormPrincipal(FormAutenticacao Chamada)
        {

            // Inicializa o FormPrincipal
            InitializeComponent();

            // A variavel Autentica recebe o FormAutenticacao que estava aberto
            Autentica = Chamada;

        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void FormPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {

            // Ao fechar o FormPrincipal, o FormAutentica é restaurado
            Autentica.Show();

        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {

            // Fecha o FormPrincipal
            this.Close();

        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {

            // Cria uma caixa de dialogo para confirmar se quer sair ou não
            DialogResult pergunta = MessageBox.Show("Você realmente deseja sair?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Se o usuário clicou em Sim
            if (pergunta == DialogResult.Yes)
            {

                // Aqui vai chamar os metodos de logout e etc
                //

                // Finaliza a aplicação
                Application.Exit();

            }            
        }

        private void chamadasRealizadasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RelatorioChamadas Chamadas = new RelatorioChamadas();
            Chamadas.Show();
        }

        private void ligaçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RelatorioChamadas Chamadas = new RelatorioChamadas();
            Chamadas.Show();
        }

        private void selecionarramal_Click(object sender, EventArgs e)
        {

            // Aqui vai chamar os metodos de ramal
            selecionarramal.Image = Properties.Resources.cross;

            labellogin.Visible = true;
            labellogin.Text = "Ramal autenticado em " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
            string autenticado = DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss");

            labelstatus.Visible = true;
            combostatus.Visible = true;
            alterarstatus.Visible = true;

        }
    }
}
