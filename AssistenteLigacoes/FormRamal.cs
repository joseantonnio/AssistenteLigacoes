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
    public partial class FormRamal : MetroForm
    {

        Usuario dados;
        bool edicao;

        public FormRamal(Usuario usuario, bool editar = false)
        {

            edicao = editar;

            InitializeComponent();
            dados = usuario;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            // Verifica se é para edição
            if (edicao)
            {
                this.Text = "Editar Ramal";
                checkBox1.Visible = false;
                comboBox1.Visible = false;
                textBox1.Visible = false;
                label2.Visible = false;
                label1.Visible = false;
            }

            // Busca ramais do usuário
            Telefone telefones = new Telefone(0);
            DataTable busca = telefones.BuscaTelefones();
            DataTable usuarios = dados.BuscarUsuarios();

            // Limpa o combo
            combotelefone.Items.Clear();
            comboBox1.Items.Clear();

            // Define os campos do combobox
            comboBox1.DisplayMember = "Text";
            comboBox1.ValueMember = "Value";

            // Percorre os resultados
            foreach (DataRow row in busca.Rows)
                combotelefone.Items.Add(row["prefixo"]);

            List<Object> items = new List<Object>();

            foreach (DataRow row in usuarios.Rows)
                items.Add(new { Text = row["usuario"], Value = row["u_id"] });

            comboBox1.DataSource = items;

        }

        private void selecionartelefone_Click(object sender, EventArgs e)
        {

            if (edicao)
            {

                // Declara variaveis
                bool ativo = checkBox1.Checked;
                string telefone = combotelefone.GetItemText(combotelefone.SelectedItem);
                string numero = comboramal.GetItemText(comboramal.SelectedItem);
                int responsavel = int.Parse(comboBox1.SelectedValue.ToString());

                if (telefone == "")
                {
                    MessageBox.Show("O campo telefone não pode fica em branco!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (numero == "")
                {
                    MessageBox.Show("O campo número não pode fica em branco!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (responsavel == 0)
                {
                    MessageBox.Show("O campo responsável não pode fica em branco!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Ramal atualiza = new Ramal(0, 0, 0);

                if (atualiza.AtualizarRamal(telefone, numero, ativo, responsavel))
                {
                    MessageBox.Show("Ramal atualizado com sucesso!", "Ramal atualizado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.Close();
                }
                else
                    MessageBox.Show("Não foi possível atualizar o ramal. Por favor, tente novamente...", "Encontramos um problema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {

                // Declara variaveis
                bool ativo = checkBox1.Checked;
                string telefone = combotelefone.GetItemText(combotelefone.SelectedItem);
                string numero = textBox1.Text;
                int responsavel = int.Parse(comboBox1.SelectedValue.ToString());

                if (telefone == "")
                {
                    MessageBox.Show("O campo telefone não pode fica em branco!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (numero == "")
                {
                    MessageBox.Show("O campo número não pode fica em branco!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (responsavel == 0)
                {
                    MessageBox.Show("O campo responsável não pode fica em branco!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Ramal novo = new Ramal(0, 0, 0);

                if (novo.InserirRamal(telefone, numero, ativo, responsavel))
                {
                    MessageBox.Show("Ramal cadastrado com sucesso!", "Ramal cadastrado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.Close();
                }
                else
                    MessageBox.Show("Não foi possível cadastrar o ramal. Por favor, tente novamente...", "Encontramos um problema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

        }

        private void combotelefone_SelectedIndexChanged(object sender, EventArgs e)
        {

            // Verifica se é para edição
            if (edicao)
            {

                // Pega o prefixo
                int prefixo = int.Parse(combotelefone.GetItemText(combotelefone.SelectedItem));

                // Busca ramais do usuário
                Ramal ramal = new Ramal(prefixo, 0, dados.id);
                DataTable busca = ramal.BuscaRamais(dados.id, true);

                // Altera as propriedades dos itens
                label1.Visible = true;
                comboramal.Visible = true;

                // Limpa o combo
                comboramal.Items.Clear();

                // Percorre os resultados
                foreach (DataRow row in busca.Rows)
                {

                    comboramal.Items.Add(row["numero"]);

                }


            }

        }

        private void comboramal_SelectedIndexChanged(object sender, EventArgs e)
        {

            // Verifica se é para edição
            if (edicao)
            {

                checkBox1.Visible = false;
                comboBox1.Visible = false;
                label2.Visible = false;
                button1.Visible = false;

                // Declara variaveis
                int telefone = int.Parse(combotelefone.GetItemText(combotelefone.SelectedItem));
                int numero = int.Parse(comboramal.GetItemText(comboramal.SelectedItem));

                Ramal edit = new Ramal(telefone, numero, 0);

                checkBox1.Visible = true;
                comboBox1.Visible = true;
                label2.Visible = true;
                button1.Visible = true;

                checkBox1.Checked = edit.ativo;
                comboBox1.SelectedValue = edit.responsavel;

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            // Cria uma caixa de dialogo para confirmar
            DialogResult pergunta = MessageBox.Show("Você realmente deseja excluir este ramal?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Se o usuário clicou em Sim
            if (pergunta == DialogResult.Yes)
            {

                string telefone = combotelefone.GetItemText(combotelefone.SelectedItem);
                string numero = comboramal.GetItemText(comboramal.SelectedItem);

                Ramal delete = new Ramal(0, 0, 0);

                if (delete.ExcluirRamal(telefone, numero))
                {
                    MessageBox.Show("Ramal excluído com sucesso!", "Ramal excluído", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.Close();
                }
                else
                    MessageBox.Show("Não foi possível excluir o ramal. Por favor, tente novamente...", "Encontramos um problema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

        }
    }
}
