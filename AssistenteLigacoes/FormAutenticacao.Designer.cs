namespace AssistenteLigacoes
{
    partial class FormAutenticacao
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAutenticacao));
            this.userlabel = new System.Windows.Forms.Label();
            this.username = new System.Windows.Forms.TextBox();
            this.passlabel = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.status = new System.Windows.Forms.Label();
            this.entrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // userlabel
            // 
            this.userlabel.AutoSize = true;
            this.userlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.userlabel.Location = new System.Drawing.Point(14, 84);
            this.userlabel.Name = "userlabel";
            this.userlabel.Size = new System.Drawing.Size(68, 20);
            this.userlabel.TabIndex = 0;
            this.userlabel.Text = "Usuário:";
            // 
            // username
            // 
            this.username.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.username.Location = new System.Drawing.Point(88, 78);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(361, 29);
            this.username.TabIndex = 1;
            // 
            // passlabel
            // 
            this.passlabel.AutoSize = true;
            this.passlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.passlabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.passlabel.Location = new System.Drawing.Point(14, 132);
            this.passlabel.Name = "passlabel";
            this.passlabel.Size = new System.Drawing.Size(60, 20);
            this.passlabel.TabIndex = 2;
            this.passlabel.Text = "Senha:";
            // 
            // password
            // 
            this.password.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.password.Location = new System.Drawing.Point(88, 126);
            this.password.Name = "password";
            this.password.PasswordChar = '•';
            this.password.Size = new System.Drawing.Size(361, 29);
            this.password.TabIndex = 3;
            this.password.Enter += new System.EventHandler(this.password_Enter);
            this.password.KeyDown += new System.Windows.Forms.KeyEventHandler(this.password_KeyDown);
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.status.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.status.Location = new System.Drawing.Point(15, 188);
            this.status.Name = "status";
            this.status.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.status.Size = new System.Drawing.Size(170, 17);
            this.status.TabIndex = 8;
            this.status.Text = "[[MENSAGEM DE ERRO]]";
            this.status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.status.Visible = false;
            // 
            // entrar
            // 
            this.entrar.Location = new System.Drawing.Point(371, 180);
            this.entrar.Name = "entrar";
            this.entrar.Size = new System.Drawing.Size(78, 32);
            this.entrar.TabIndex = 9;
            this.entrar.Text = "Entrar";
            this.entrar.Click += new System.EventHandler(this.entrar_Click);
            // 
            // FormAutenticacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(472, 235);
            this.Controls.Add(this.entrar);
            this.Controls.Add(this.status);
            this.Controls.Add(this.password);
            this.Controls.Add(this.passlabel);
            this.Controls.Add(this.username);
            this.Controls.Add(this.userlabel);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAutenticacao";
            this.Resizable = false;
            this.Text = "Autenticação";
            this.Theme = MetroFramework.MetroThemeStyle.Light;
            this.Activated += new System.EventHandler(this.FormAutenticacao_Activated);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label userlabel;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.Label passlabel;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.Button entrar;
    }
}

