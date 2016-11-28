using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Collections;

// MetroFramework
using MetroFramework.Forms;

// Utiliza Interop do Excel
using Microsoft.Office.Interop.Excel;

// Importar JSON
using System.Net;
using Newtonsoft.Json;

namespace AssistenteLigacoes
{
    public partial class RelatorioChamadas : MetroForm
    {

        StringFormat strFormat; // Formata as linhas
        ArrayList arrColumnLefts = new ArrayList(); // Salva a coordenada esquerda das colunas
        ArrayList arrColumnWidths = new ArrayList(); // Salva a largura das colunas
        int iCellHeight = 0; // Pega a altura da célula do grid
        int iTotalWidth = 0; // Pega o tamanho total do grid
        int iRow = 0; // Conta as linhas
        int iCount = 0; // Contador Genérico
        bool bFirstPage = false; // Informa se é a primeira página que está sendo impressa
        bool bNewPage = false; // Informa se é uma nova página que está sendo impressa
        int iHeaderHeight = 0; //  Pega a altura do cabeçalho

        Usuario dados;
        Ramal ramal;

        public RelatorioChamadas(Usuario u, Ramal r)
        {

            // Armazena os dados do usuaário e ramal
            dados = u;
            ramal = r;   

            // Inicializa o RelatorioChamadas
            InitializeComponent();
        }

        private bool verificaData(string data, bool input = false)
        {

            // Pega apenas os números da data
            string conteudo = Regex.Match(data, @"\d+").Value;

            // Verifica se é uma data válida
            DateTime converte;
            if (!DateTime.TryParse(data, out converte) && (conteudo != "" || input))
            {

                // Se foi enviado por um TextBox
                if (!input)
                    MessageBox.Show("A data informada não é válida!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            return true;

        }

        private void RelatorioChamadas_Load(object sender, EventArgs e)
        {

            // Se for usuário normal, oculta a opção ramal
            if (!dados.admin)
            {
                ramalconsulta.Items.Add(ramal.numero);
            } else
            {

                // Busca todos ramais
                System.Data.DataTable busca = ramal.BuscaRamais(0, true);

                // Limpa o combo
                ramalconsulta.Items.Clear();

                // Percorre os resultados
                foreach (DataRow row in busca.Rows)
                {

                    bool ativo = bool.Parse(row["ativo"].ToString());

                    if (ativo)
                        ramalconsulta.Items.Add(row["numero"]);

                }
            }

        }

        private void dataInicial_Enter(object sender, EventArgs e)
        {

            // Torna o calendário visivel
            calendariode.Visible = true;

        }

        private void dataInicial_Leave(object sender, EventArgs e)
        {

            // Torna o calendário invisivel
            calendariode.Visible = false;

            // Verifica se a data inicial não é válida e limpa o campo
            if (!verificaData(dataInicial.Text))
                dataInicial.Text = "";

        }

        private void dataFinal_Enter(object sender, EventArgs e)
        {

            // Torna o calendário visivel
            calendarioate.Visible = true;

        }

        private void dataFinal_Leave(object sender, EventArgs e)
        {

            // Torna o calendário invisivel
            calendarioate.Visible = false;

            // Verifica se a data final não é válida e limpa o campo
            if (!verificaData(dataFinal.Text))
                dataFinal.Text = "";

        }

        private void calendarioate_DateChanged(object sender, DateRangeEventArgs e)
        {

            // Coloca a data selecionada no calendario no TextBox
            dataFinal.Text = calendarioate.SelectionRange.End.ToString();

        }

        private void calendariode_DateChanged(object sender, DateRangeEventArgs e)
        {

            // Coloca a data selecionada no calendario no TextBox
            dataInicial.Text = calendariode.SelectionRange.End.ToString();

        }

        private void relatoriobuscar_Click(object sender, EventArgs e)
        {

            // Declara variaveis
            string inicial = "";
            string final = "";
            string tipo = tipochamada.SelectedIndex.ToString();
            string numero = ramalconsulta.GetItemText(ramalconsulta.SelectedItem);

            if (numero == "")
            {
                MessageBox.Show("Selecione um ramal para buscar o relatório!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Verifica se as datas não são válidas
            if (!verificaData(dataInicial.Text, true))
            {
                MessageBox.Show("As datas informadas não são válidas!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dataInicial.Text = "";
                dataFinal.Text = "";
                return;
            }

            if (!atevazio.Checked)
            {

                if (!verificaData(dataFinal.Text, true))
                {
                    MessageBox.Show("As datas informadas não são válidas!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dataInicial.Text = "";
                    dataFinal.Text = "";
                    return;
                }
                else
                {

                    // Converte as datas para DateTime
                    inicial = DateTime.Parse(dataInicial.Text).ToString("yyyy-MM-dd HH:mm:ss");
                    final = DateTime.Parse(dataFinal.Text).ToString("yyyy-MM-dd HH:mm:ss");

                    // Compara as datas
                    int compara = DateTime.Compare(DateTime.Parse(inicial), DateTime.Parse(final));

                    if (compara > 0)
                    {
                        MessageBox.Show("A data final não pode ser menor que a data inicial!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                }

            }
            else
            {

                // Converte as datas para DateTime
                inicial = DateTime.Parse(dataInicial.Text).ToString("yyyy-MM-dd HH:mm:ss");

            }


            // Verifica se o tipo de relatório foi selecionado
            if (tipochamada.SelectedItem == null)
            {
                MessageBox.Show("Escolha o tipo de relatório que deseja!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Busca os dados selecionados
            conteudorelatorio.DataSource = ramal.BuscaLigacoes(false, numero, tipo, inicial, final);

            // Renomeia colunas
            conteudorelatorio.Columns[0].HeaderText = "ID";
            conteudorelatorio.Columns[1].HeaderText = "Inicio";
            conteudorelatorio.Columns[2].HeaderText = "Fim";
            conteudorelatorio.Columns[3].HeaderText = "Finalizada";
            conteudorelatorio.Columns[4].HeaderText = "Telefone";
            conteudorelatorio.Columns[5].HeaderText = "Ramal";
            conteudorelatorio.Columns[6].HeaderText = "Tipo";
            conteudorelatorio.Columns[7].HeaderText = "Destino";
            conteudorelatorio.Columns[8].HeaderText = "Observações";

        }

        private void imprimerelatorio_Click(object sender, EventArgs e)
        {

            // Verifica se existe alguma coisa no relatório
            if (conteudorelatorio.Rows.Count > 1)
            {

                // Altera a orientação da impressão
                printrelatorio.DefaultPageSettings.Landscape = true;

                // Abre o preview da impressão
                previewrelatorio.Document = printrelatorio;
                previewrelatorio.ShowDialog();

            }
            else
            {
                MessageBox.Show("Você não pode imprimir um relatório em branco.", "Impressão cancelada", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
        }

        private void printrelatorio_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

            // Inicializa impressão
            try
            {

                // Reseta as variáveis de impressão
                strFormat = new StringFormat();
                strFormat.Alignment = StringAlignment.Near;
                strFormat.LineAlignment = StringAlignment.Center;
                strFormat.Trimming = StringTrimming.EllipsisCharacter;
                arrColumnLefts.Clear();
                arrColumnWidths.Clear();
                iCellHeight = 0;
                iTotalWidth = 0;
                iRow = 0;
                iCount = 0;
                bFirstPage = true;
                bNewPage = true;
                iHeaderHeight = 0;

                // Realiza um laço para calcular lagura total
                foreach (DataGridViewColumn dgvGridCol in conteudorelatorio.Columns)
                {
                    // Largura total é igual a soma da largura de cada coluna
                    iTotalWidth += dgvGridCol.Width;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void salvarelatorio_Click(object sender, EventArgs e)
        {
            // Verifica se possui alguma linha no relatório além do cabeçalho
            if (conteudorelatorio.Rows.Count > 0)
            {

                // Cria o objeto do Excel
                Microsoft.Office.Interop.Excel.Application XcelApp = new Microsoft.Office.Interop.Excel.Application();

                // Tenta gerar o arquivo
                try
                {

                    // Cria um arquivo em branco
                    XcelApp.Application.Workbooks.Add(Type.Missing);

                    // Realiza um laço no cabeçalho
                    for (int i = 1; i < conteudorelatorio.Columns.Count + 1; i++)
                    {
                        XcelApp.Cells[1, i] = conteudorelatorio.Columns[i - 1].HeaderText;
                    }

                    // Realiza um laço duplo no conteúdo
                    for (int i = 0; i < conteudorelatorio.Rows.Count; i++)
                    {
                        for (int j = 0; j < conteudorelatorio.Columns.Count; j++)
                        {
                            XcelApp.Cells[i + 2, j + 1] = conteudorelatorio.Rows[i].Cells[j].Value.ToString();
                        }
                    }

                    // Executa comando para o tamanho das colunas não ficar bugado
                    XcelApp.Columns.AutoFit();

                    // Abre o Excel para o usuário
                    XcelApp.Visible = true;
                }

                // Caso o try não funcionar
                catch (Exception ex)
                {
                    MessageBox.Show("Erro : " + ex.Message);
                    XcelApp.Quit();
                }
            }
            else
            {
                MessageBox.Show("Você não pode gerar um arquivo com um relatório em branco.", "Impossível continuar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void printrelatorio_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            // Realiza a impressão
            try
            {
                // Define a margem esquerda
                int iLeftMargin = e.MarginBounds.Left;
                // Define a margem do topo
                int iTopMargin = e.MarginBounds.Top;
                // Verifica se precisa imprimir mais páginas
                bool bMorePagesToPrint = false;
                int iTmpWidth = 0;

                // Se for a primeira página
                if (bFirstPage)
                {
                    // Realiza um laço nas colunas do grid
                    foreach (DataGridViewColumn GridCol in conteudorelatorio.Columns)
                    {

                        // Calcula a largura
                        iTmpWidth = (int)(Math.Floor((double)((double)GridCol.Width /
                            (double)iTotalWidth * (double)iTotalWidth *
                            ((double)e.MarginBounds.Width / (double)iTotalWidth))));

                        // Calcula a altura do cabeçalho
                        iHeaderHeight = (int)(e.Graphics.MeasureString(GridCol.HeaderText,
                            GridCol.InheritedStyle.Font, iTmpWidth).Height) + 11;

                        // Salva os valores nas globais
                        arrColumnLefts.Add(iLeftMargin);
                        arrColumnWidths.Add(iTmpWidth);
                        iLeftMargin += iTmpWidth;

                    }
                }

                // Faz um laço enquanto as todas as linhas não forem impressas
                while (iRow <= conteudorelatorio.Rows.Count - 1)
                {

                    // Armazena a linha atual
                    DataGridViewRow GridRow = conteudorelatorio.Rows[iRow];

                    // Pega a altura da celula
                    iCellHeight = GridRow.Height + 5;
                    int iCount = 0;

                    // Verifica se a página consegue armazenar mais linhas
                    if (iTopMargin + iCellHeight >= e.MarginBounds.Height + e.MarginBounds.Top)
                    {
                        bNewPage = true;
                        bFirstPage = false;
                        bMorePagesToPrint = true;
                        break;
                    }
                    else
                    {

                        // Cria uma nova página
                        if (bNewPage)
                        {
                            // Desenha o cabeçalho
                            e.Graphics.DrawString(this.Text + " " + tipochamada.Text + " do Ramal " + ramalconsulta.Text + " de " + dataInicial.Text + " até " + dataFinal.Text + ".",
                                new System.Drawing.Font(conteudorelatorio.Font, FontStyle.Bold),
                                Brushes.Black, e.MarginBounds.Left,
                                e.MarginBounds.Top - e.Graphics.MeasureString(this.Text + " - " + tipochamada.Text,
                                new System.Drawing.Font(conteudorelatorio.Font, FontStyle.Bold),
                                e.MarginBounds.Width).Height - 13);

                            String dataAtual = DateTime.Now.ToLongDateString() + " " +
                                DateTime.Now.ToShortTimeString();

                            // Desenha a data
                            e.Graphics.DrawString(dataAtual,
                                new System.Drawing.Font(conteudorelatorio.Font, FontStyle.Bold), Brushes.Black,
                                e.MarginBounds.Left +
                                (e.MarginBounds.Width - e.Graphics.MeasureString(dataAtual,
                                new System.Drawing.Font(conteudorelatorio.Font, FontStyle.Bold),
                                e.MarginBounds.Width).Width),
                                e.MarginBounds.Top - e.Graphics.MeasureString(this.Text + " " + tipochamada.Text + " do Ramal " + ramalconsulta.Text + " de " + dataInicial.Text + " até " + dataFinal.Text + ".",
                                new System.Drawing.Font(new System.Drawing.Font(conteudorelatorio.Font, FontStyle.Bold),
                                FontStyle.Bold), e.MarginBounds.Width).Height - 13);

                            // Desenha as colunas                
                            iTopMargin = e.MarginBounds.Top;
                            foreach (DataGridViewColumn GridCol in conteudorelatorio.Columns)
                            {
                                e.Graphics.FillRectangle(new SolidBrush(Color.LightGray),
                                    new System.Drawing.Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight));

                                e.Graphics.DrawRectangle(Pens.Black,
                                    new System.Drawing.Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight));

                                e.Graphics.DrawString(GridCol.HeaderText,
                                    GridCol.InheritedStyle.Font,
                                    new SolidBrush(GridCol.InheritedStyle.ForeColor),
                                    new RectangleF((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight), strFormat);
                                iCount++;
                            }
                            bNewPage = false;
                            iTopMargin += iHeaderHeight;
                        }

                        // Define o contado para zero
                        iCount = 0;

                        // Desenha o conteúdo das colunas               
                        foreach (DataGridViewCell Cel in GridRow.Cells)
                        {
                            if (Cel.Value != null)
                            {
                                e.Graphics.DrawString(Cel.Value.ToString(),
                                    Cel.InheritedStyle.Font,
                                    new SolidBrush(Cel.InheritedStyle.ForeColor),
                                    new RectangleF((int)arrColumnLefts[iCount],
                                    (float)iTopMargin,
                                    (int)arrColumnWidths[iCount], (float)iCellHeight),
                                    strFormat);
                            }

                            // Desenha as bordas das celulas
                            e.Graphics.DrawRectangle(Pens.Black,
                                new System.Drawing.Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                (int)arrColumnWidths[iCount], iCellHeight));
                            iCount++;
                        }
                    }
                    iRow++;
                    iTopMargin += iCellHeight;
                }

                // Se tem mais linhas, adiciona uma nova páginaa
                if (bMorePagesToPrint)
                    e.HasMorePages = true;
                else
                    e.HasMorePages = false;
            }

            // Se der alguma coisa errada ao realizar a impressão
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
            }

        }

        private void atevazio_CheckStateChanged(object sender, EventArgs e)
        {

            if (atevazio.Checked)
            {
                dataFinal.Enabled = false;
                dataFinal.Text = "";
            }
            else
            {
                dataFinal.Enabled = true;
            }

        }
    }

}
