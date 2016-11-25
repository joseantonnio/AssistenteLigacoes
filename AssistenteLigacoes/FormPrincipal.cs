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

        // Declara classes
        private Ramal ramal;
        private Usuario dados;

        
        public FormPrincipal(FormAutenticacao formulario, Usuario dados)
        {

            this.dados = dados;

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
            Telefone telefones = new Telefone(0);
            DataTable busca = telefones.BuscaTelefones();

            // Limpa o combo
            combotelefone.Items.Clear();

            // Percorre os resultados
            foreach (DataRow row in busca.Rows)
                combotelefone.Items.Add(row["prefixo"]);

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

            // Declara os valores necessários
            int prefixo = int.Parse(combotelefone.GetItemText(combotelefone.SelectedItem));
            int selecionado = int.Parse(comboramal.GetItemText(comboramal.SelectedItem));
            string autenticado = DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss");

            // Animação de loading
            selecionarramal.Image = Properties.Resources.loading;

            // Busca ramal do usuário
            ramal = new Ramal(prefixo, selecionado);

            // Altera as propriedades dos itens
            labellogin.Visible = true;
            labelstatus.Visible = true;
            combostatus.Visible = true;
            alterarstatus.Visible = true;
            tabramal.Visible = true;

            // Alterando valor das labels
            labellogin.Text = "Ramal autenticado em " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
            numerotelefone.Text = ramal.prefixo.ToString();
            numeroramal.Text = ramal.numero.ToString();
            ramaloperadora.Text = ramal.Operadora;
            telefonecompleto.Text = ramal.prefixoMask + "-" + ramal.numero.ToString();
            ramaltipo.Text = (ramal.tipo == 2)?"Fixo":"Móvel";
            ramalcidade.Text = ramal.Cidade;
            ramalestado.Text = ramal.Uf;


            // Animação de loading
            selecionarramal.Image = Properties.Resources.accept;

        }

        private void selecionartelefone_Click(object sender, EventArgs e)
        {

            // Pega o prefixo
            int prefixo = int.Parse(combotelefone.GetItemText(combotelefone.SelectedItem));

            // Animação de loading
            selecionartelefone.Image = Properties.Resources.loading;

            // Busca ramais do usuário
            Ramal ramal = new Ramal(prefixo, 0);
            DataTable busca = ramal.BuscaRamais(dados.id);

            // Altera as propriedades dos itens
            comboramal.Visible = true;
            selecionarramal.Visible = true;
            labelramalativo.Visible = true;

            // Limpa o combo
            comboramal.Items.Clear();

            // Percorre os resultados
            foreach (DataRow row in busca.Rows)
            {

                bool ativo = bool.Parse(row["ativo"].ToString());

                if (ativo)
                    comboramal.Items.Add(row["numero"]);

            }

            // Animação de loading
            selecionartelefone.Image = Properties.Resources.connect;

            // Bloqueia seleção de telefone
            if (comboramal.Items.Count < 1)
            {
                combotelefone.Enabled = true;
                selecionartelefone.Enabled = true;
            }
            else
            {
                combotelefone.Enabled = false;
                selecionartelefone.Enabled = false;
            }

        }

        private void comboramal_DropDown(object sender, EventArgs e)
        {
            comboramal.SelectedIndex = -1;
        }
    }
}
