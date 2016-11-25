using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

// Metro Framework
using MetroFramework.Forms;

namespace AssistenteLigacoes
{
    public partial class FormPrincipal : MetroForm
    {

        // Declara uma variavel para armazenar o FormAutenticacao
        private FormAutenticacao anterior;

        
        public FormPrincipal(FormAutenticacao formulario, Usuario dados)
        {

            // Inicializa o FormPrincipal
            InitializeComponent();

            // A variavel Autentica recebe o FormAutenticacao que estava aberto
            anterior = formulario;

            // Define um path para criar a imagem que irá sobrepor o avatar
            GraphicsPath path = new GraphicsPath();

            // Cria um circulo
            path.AddEllipse(0, 0, avatarusuario.Width, avatarusuario.Height);

            // Define o circulo como as regiões do avatar
            avatarusuario.Region = new Region(path);

            // Carrega os dados do usuário no formulário
            try
            {
                avatarusuario.Image = Image.FromStream(dados.avatar);
            }
            catch (ArgumentException e)
            {
                e = null;
            }
            nomeusuario.Text = dados.nome;

            // Limpa campos
            tabramal.Hide();

            // Verifica se é admin, caso não for destroi os acessos para áreas protegidas
            if (!dados.admin)
            {
                adminrelatorios.Dispose();
                toolStripMenuItem1.Dispose();
                adminconfiguracoes.Dispose();
                toolStripMenuItem6.Dispose();
                segurancaToolStripMenuItem.Dispose();
            }

            // Busca ramais do usuário
            Ramal ramais = new Ramal();

            List<List<string>> busca = ramais.BuscaRamais(dados.id);

            var r = 0;

        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void FormPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {

            // Ao fechar o FormPrincipal, o FormAutentica é restaurado
            anterior.Show();

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

        private void chamadasToolStripMenuItem_Click(object sender, EventArgs e)
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
            tabramal.Visible = true;

        }
    }
}
