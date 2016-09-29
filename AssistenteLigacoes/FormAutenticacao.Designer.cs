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
            this.userdefault = new System.Windows.Forms.RadioButton();
            this.useradmin = new System.Windows.Forms.RadioButton();
            this.status = new System.Windows.Forms.Label();
            this.entrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // userlabel
            // 
            this.userlabel.AutoSize = true;
            this.userlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.userlabel.Location = new System.Drawing.Point(11, 21);
            this.userlabel.Name = "userlabel";
            this.userlabel.Size = new System.Drawing.Size(68, 20);
            this.userlabel.TabIndex = 0;
            this.userlabel.Text = "Usuário:";
            // 
            // username
            // 
            this.username.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.username.Location = new System.Drawing.Point(85, 15);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(246, 29);
            this.username.TabIndex = 1;
            // 
            // passlabel
            // 
            this.passlabel.AutoSize = true;
            this.passlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.passlabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.passlabel.Location = new System.Drawing.Point(11, 69);
            this.passlabel.Name = "passlabel";
            this.passlabel.Size = new System.Drawing.Size(60, 20);
            this.passlabel.TabIndex = 2;
            this.passlabel.Text = "Senha:";
            // 
            // password
            // 
            this.password.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.password.Location = new System.Drawing.Point(85, 63);
            this.password.Name = "password";
            this.password.PasswordChar = '•';
            this.password.Size = new System.Drawing.Size(246, 29);
            this.password.TabIndex = 3;
            // 
            // userdefault
            // 
            this.userdefault.AutoSize = true;
            this.userdefault.Checked = true;
            this.userdefault.Location = new System.Drawing.Point(397, 35);
            this.userdefault.Name = "userdefault";
            this.userdefault.Size = new System.Drawing.Size(61, 17);
            this.userdefault.TabIndex = 5;
            this.userdefault.TabStop = true;
            this.userdefault.Text = "Usuário";
            this.userdefault.UseVisualStyleBackColor = true;
            this.userdefault.CheckedChanged += new System.EventHandler(this.userdefault_CheckedChanged);
            // 
            // useradmin
            // 
            this.useradmin.AutoSize = true;
            this.useradmin.Location = new System.Drawing.Point(370, 12);
            this.useradmin.Name = "useradmin";
            this.useradmin.Size = new System.Drawing.Size(88, 17);
            this.useradmin.TabIndex = 6;
            this.useradmin.Text = "Administrador";
            this.useradmin.UseVisualStyleBackColor = true;
            this.useradmin.CheckedChanged += new System.EventHandler(this.useradmin_CheckedChanged);
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.status.Location = new System.Drawing.Point(12, 111);
            this.status.Name = "status";
            this.status.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.status.Size = new System.Drawing.Size(133, 13);
            this.status.TabIndex = 8;
            this.status.Text = "[[MENSAGEM DE ERRO]]";
            this.status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.status.Visible = false;
            // 
            // entrar
            // 
            this.entrar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.entrar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.entrar.Image = global::AssistenteLigacoes.Properties.Resources.lock_unlock;
            this.entrar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.entrar.Location = new System.Drawing.Point(383, 92);
            this.entrar.Name = "entrar";
            this.entrar.Size = new System.Drawing.Size(77, 32);
            this.entrar.TabIndex = 7;
            this.entrar.Text = "Entrar";
            this.entrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.entrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.entrar.UseVisualStyleBackColor = false;
            this.entrar.Click += new System.EventHandler(this.entrar_Click);
            // 
            // FormAutenticacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(472, 136);
            this.Controls.Add(this.status);
            this.Controls.Add(this.entrar);
            this.Controls.Add(this.useradmin);
            this.Controls.Add(this.userdefault);
            this.Controls.Add(this.password);
            this.Controls.Add(this.passlabel);
            this.Controls.Add(this.username);
            this.Controls.Add(this.userlabel);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAutenticacao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Autenticação";
            this.Load += new System.EventHandler(this.FormAutenticacao_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label userlabel;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.Label passlabel;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.RadioButton userdefault;
        private System.Windows.Forms.RadioButton useradmin;
        private System.Windows.Forms.Button entrar;
        private System.Windows.Forms.Label status;
    }
}

