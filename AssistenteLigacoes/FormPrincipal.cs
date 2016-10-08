using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Metroframework
using MetroFramework.Forms;

namespace AssistenteLigacoes
{
    public partial class FormPrincipal : MetroForm
    {

        private FormAutenticacao Autentica;
        public FormPrincipal(FormAutenticacao Chamada)
        {
            InitializeComponent();
            Autentica = Chamada;
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void FormPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Autentica.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult pergunta = MessageBox.Show("Você realmente deseja sair?", "Confirmação", MessageBoxButtons.YesNo);
            if (pergunta == DialogResult.Yes)
            {
                Application.Exit();
            }            
        }
    }
}
