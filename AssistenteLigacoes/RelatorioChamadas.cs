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

// MetroFramework
using MetroFramework.Forms;

// Utiliza Interop do Excel
using Microsoft.Office.Interop.Excel;

namespace AssistenteLigacoes
{
    public partial class RelatorioChamadas : MetroForm
    {
        public RelatorioChamadas()
        {
            // Inicializa o RelatorioChamadas
            InitializeComponent();
        }

        private bool verificaData(string data, bool input = false)
        {

            // Pega apenas os números da data
            string conteudo = Regex.Match(data, @"\d+").Value;

            // Verifica se é uma data válida
            DateTime converte;
            if (!DateTime.TryParse(data, out converte) && (conteudo != "" || input) )
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

            // Verifica se as datas não são válidas
            if (!verificaData(dataInicial.Text, true) || !verificaData(dataFinal.Text, true))
            {
                MessageBox.Show("As datas informadas não são válidas!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dataInicial.Text = "";
                dataFinal.Text = "";
                return;
            }

            // Verifica se o ramal está em branco ou incorreto
            if (ramalconsulta.Text == "" || ramalconsulta.TextLength != 4)
            {
                MessageBox.Show("Preencha o ramal corretamente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Verifica se o tipo de relatório foi selecionado
            if (tipochamada.SelectedItem == null)
            {
                MessageBox.Show("Escolha o tipo de relatório que deseja!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Converte as datas para DateTime
            DateTime inicial = DateTime.Parse(dataInicial.Text);
            DateTime final = DateTime.Parse(dataFinal.Text);

            // Compara as datas
            int compara = DateTime.Compare(inicial, final);

            if (compara > 0)
            {
                MessageBox.Show("A data final não pode ser menor que a data inicial!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void imprimerelatorio_Click(object sender, EventArgs e)
        {
            previewrelatorio.Document = printrelatorio;
            previewrelatorio.ShowDialog();
        }

        private void printrelatorio_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                // Calculating Total Widths
                int iTotalWidth = 0;
                foreach (DataGridViewColumn dgvGridCol in conteudorelatorio.Columns)
                {
                    iTotalWidth += dgvGridCol.Width;
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void salvarelatorio_Click(object sender, EventArgs e)
        {

            Microsoft.Office.Interop.Excel.Application XcelApp = new Microsoft.Office.Interop.Excel.Application();

            if (conteudorelatorio.Rows.Count > 0)
            {
                try
                {
                    XcelApp.Application.Workbooks.Add(Type.Missing);
                    for (int i = 1; i < conteudorelatorio.Columns.Count + 1; i++)
                    {
                        XcelApp.Cells[1, i] = conteudorelatorio.Columns[i - 1].HeaderText;
                    }
                    //
                    for (int i = 0; i < conteudorelatorio.Rows.Count - 1; i++)
                    {
                        for (int j = 0; j < conteudorelatorio.Columns.Count; j++)
                        {
                            XcelApp.Cells[i + 2, j + 1] = conteudorelatorio.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                    //
                    XcelApp.Columns.AutoFit();
                    //
                    XcelApp.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro : " + ex.Message);
                    XcelApp.Quit();
                }
            }

        }
    }
}
