using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssistenteLigacoes
{
    public partial class FormAutenticacao : Form
    {

        private bool isadmin = false;

        public FormAutenticacao()
        {
            InitializeComponent();
        }

        private void FormAutenticacao_Load(object sender, EventArgs e)
        {

        }

        private void entrar_Click(object sender, EventArgs e)
        {

            string u = username.Text;
            string p = password.Text;

            if (u == "admin" && p == "admin" && isadmin == true)
            {
                status.ForeColor = System.Drawing.Color.ForestGreen;
                status.Text = "Entra como admin...";
                status.Visible = true;
            }
            else
            {

                if (u == "user" && p == "user" && isadmin == false)
                {
                    status.ForeColor = System.Drawing.Color.ForestGreen;
                    status.Text = "Entra como usuário...";
                    status.Visible = true;
                }
                else
                {
                    status.ForeColor = System.Drawing.Color.Firebrick;
                    status.Text = "Usuário e senha incorretos.";
                    status.Visible = true;
                }

            }

        }

        private void useradmin_CheckedChanged(object sender, EventArgs e)
        {
            isadmin = true;
        }

        private void userdefault_CheckedChanged(object sender, EventArgs e)
        {
            isadmin = false;
        }
    }
}
