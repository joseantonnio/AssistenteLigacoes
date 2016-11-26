using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using UITimer = System.Windows.Forms.Timer;
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
        private UITimer verificador;

        private void verificador_Tick(object sender, EventArgs e)
        {
            if (ramal != null)
            {
                var thread = new Thread(verificaRamal);
                thread.Start();
            }

        }


        public FormPrincipal(FormAutenticacao formulario, Usuario dados)
        {

            verificador = new UITimer();
            verificador.Tick += new EventHandler(verificador_Tick);
            verificador.Interval = 2000; // in miliseconds
            verificador.Start();

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

        private void verificaRamal()
        {

            // Busca ramal do usuário
            ramal = new Ramal(ramal.prefixo, ramal.numero, dados.id);

            // Se estiver rodando em uma thread, atualiza por meio do Invoker
            if (numerotelefone.InvokeRequired)
            {

                numerotelefone.BeginInvoke((MethodInvoker)delegate () { numerotelefone.Text = ramal.prefixo.ToString(); });
                numeroramal.BeginInvoke((MethodInvoker)delegate () { numeroramal.Text = ramal.numero.ToString(); });
                ramaloperadora.BeginInvoke((MethodInvoker)delegate () { ramaloperadora.Text = ramal.Operadora; });
                telefonecompleto.BeginInvoke((MethodInvoker)delegate () { telefonecompleto.Text = ramal.prefixoMask + "-" + ramal.numero.ToString(); });
                ramaltipo.BeginInvoke((MethodInvoker)delegate () { ramaltipo.Text = (ramal.tipo == 2) ? "Fixo" : "Móvel"; });
                ramalcidade.BeginInvoke((MethodInvoker)delegate () { ramalcidade.Text = ramal.Cidade; });
                ramalestado.BeginInvoke((MethodInvoker)delegate () { ramalestado.Text = ramal.Uf; });

                statusramal.BeginInvoke((MethodInvoker)delegate () {

                    switch (ramal.status)
                    {

                        case 0:

                            statusramal.Text = "Desligado";
                            statusramal.ForeColor = Color.DarkRed;
                            break;

                        case 1:
                            statusramal.Text = "Disponível";
                            statusramal.ForeColor = Color.LightGreen;
                            break;

                        case 2:
                            statusramal.Text = "Ausente";
                            statusramal.ForeColor = Color.Orange;
                            break;

                        case 3:
                            statusramal.Text = "Pausado";
                            statusramal.ForeColor = Color.OrangeRed;
                            break;

                        default:
                            statusramal.Text = "Desconhecido";
                            statusramal.ForeColor = Color.Gray;
                            break;

                    }

                });

                // Busca ultima chamada
                DataTable ultima = ramal.BuscaLigacoes(true);

                // Percorre os resultados
                foreach (DataRow row in ultima.Rows)
                {

                    int tipo = int.Parse(row["tipo"].ToString());
                    iniciochamada.BeginInvoke((MethodInvoker)delegate () { iniciochamada.Text = row["inicio"].ToString(); });
                    fimchamada.BeginInvoke((MethodInvoker)delegate () { fimchamada.Text = row["fim"].ToString(); });
                    string telefone = row["destino"].ToString();
                    string pre;

                    if (telefone.Length > 10)
                        pre = new string(telefone.Take(7).ToArray());
                    else
                        pre = new string(telefone.Take(6).ToArray());

                    string ddd = new string(pre.Take(2).ToArray());
                    string num = new string(pre.Reverse().Take(4).Reverse().ToArray());
                    string ram = new string(telefone.Reverse().Take(4).Reverse().ToArray());

                    telefoneligacao.BeginInvoke((MethodInvoker)delegate () { telefoneligacao.Text = "(" + ddd + ")" + num + "-" + ram; });

                    Telefone info = new Telefone(int.Parse(pre));

                    operadoradestino.BeginInvoke((MethodInvoker)delegate () { operadoradestino.Text = info.Operadora; });
                    cidadedestino.BeginInvoke((MethodInvoker)delegate () { cidadedestino.Text = info.Cidade; });
                    estadodestino.BeginInvoke((MethodInvoker)delegate () { estadodestino.Text = info.Uf; });

                    statusligacao.BeginInvoke((MethodInvoker)delegate () {
                        switch (tipo)
                        {

                            case 0:
                                statusligacao.Text = "Perdida";
                                statusligacao.ForeColor = Color.OrangeRed;
                                break;

                            case 1:
                                statusligacao.Text = "Recebida";
                                statusligacao.ForeColor = Color.SteelBlue;
                                break;

                            case 2:
                                statusligacao.Text = "Realizada";
                                statusligacao.ForeColor = Color.Green;
                                break;

                            default:
                                statusligacao.Text = "Desconhecido";
                                statusligacao.ForeColor = Color.Gray;
                                break;

                        }

                    });

                }

            }
            // Se não está sendo executado por uma thread
            else
            {

                numerotelefone.Text = ramal.prefixo.ToString();
                numeroramal.Text = ramal.numero.ToString();
                ramaloperadora.Text = ramal.Operadora;
                telefonecompleto.Text = ramal.prefixoMask + "-" + ramal.numero.ToString();
                ramaltipo.Text = (ramal.tipo == 2) ? "Fixo" : "Móvel";
                ramalcidade.Text = ramal.Cidade;
                ramalestado.Text = ramal.Uf;

                switch (ramal.status)
                {

                    case 0:
                        statusramal.Text = "Desligado";
                        statusramal.ForeColor = Color.DarkRed;
                        break;

                    case 1:
                        statusramal.Text = "Disponível";
                        statusramal.ForeColor = Color.LightGreen;
                        break;

                    case 2:
                        statusramal.Text = "Ausente";
                        statusramal.ForeColor = Color.Orange;
                        break;

                    case 3:
                        statusramal.Text = "Pausado";
                        statusramal.ForeColor = Color.OrangeRed;
                        break;

                    default:
                        statusramal.Text = "Desconhecido";
                        statusramal.ForeColor = Color.Gray;
                        break;

                }

                // Busca ultima chamada
                DataTable ultima = ramal.BuscaLigacoes(true);

                // Percorre os resultados
                foreach (DataRow row in ultima.Rows)
                {

                    int tipo = int.Parse(row["tipo"].ToString());
                    iniciochamada.Text = row["inicio"].ToString();
                    fimchamada.Text = row["fim"].ToString();
                    string telefone = row["destino"].ToString();
                    string pre;

                    if (telefone.Length > 10)
                        pre = new string(telefone.Take(7).ToArray());
                    else
                        pre = new string(telefone.Take(6).ToArray());

                    string ddd = new string(pre.Take(2).ToArray());
                    string num = new string(pre.Reverse().Take(4).Reverse().ToArray());
                    string ram = new string(telefone.Reverse().Take(4).Reverse().ToArray());

                    telefoneligacao.Text = "(" + ddd + ")" + num + "-" + ram;

                    Telefone info = new Telefone(int.Parse(pre));

                    operadoradestino.Text = info.Operadora;
                    cidadedestino.Text = info.Cidade;
                    estadodestino.Text = info.Uf;

                    switch (tipo)
                    {

                        case 0:
                            statusligacao.Text = "Perdida";
                            statusligacao.ForeColor = Color.OrangeRed;
                            break;

                        case 1:
                            statusligacao.Text = "Recebida";
                            statusligacao.ForeColor = Color.SteelBlue;
                            break;

                        case 2:
                            statusligacao.Text = "Realizada";
                            statusligacao.ForeColor = Color.Green;
                            break;

                        default:
                            statusligacao.Text = "Desconhecido";
                            statusligacao.ForeColor = Color.Gray;
                            break;

                    }

                }

            }

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
            ramal = new Ramal(prefixo, selecionado, dados.id);

            // Altera as propriedades dos itens
            labellogin.Visible = true;
            labelstatus.Visible = true;
            statusramal.Visible = true;
            tabramal.Visible = true;

            // Alterando valor das labels
            labellogin.Text = "Ramal autenticado em " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();

            verificaRamal();

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
            Ramal ramal = new Ramal(prefixo, 0, dados.id);
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
