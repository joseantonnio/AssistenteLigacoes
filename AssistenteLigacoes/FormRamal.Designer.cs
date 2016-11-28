namespace AssistenteLigacoes
{
    partial class FormRamal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRamal));
            this.combotelefone = new System.Windows.Forms.ComboBox();
            this.labeltelefoneativo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.selecionartelefone = new System.Windows.Forms.Button();
            this.comboramal = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // combotelefone
            // 
            this.combotelefone.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combotelefone.FormattingEnabled = true;
            this.combotelefone.Location = new System.Drawing.Point(134, 71);
            this.combotelefone.Name = "combotelefone";
            this.combotelefone.Size = new System.Drawing.Size(108, 28);
            this.combotelefone.TabIndex = 15;
            this.combotelefone.SelectedIndexChanged += new System.EventHandler(this.combotelefone_SelectedIndexChanged);
            // 
            // labeltelefoneativo
            // 
            this.labeltelefoneativo.AutoSize = true;
            this.labeltelefoneativo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labeltelefoneativo.Location = new System.Drawing.Point(23, 74);
            this.labeltelefoneativo.Name = "labeltelefoneativo";
            this.labeltelefoneativo.Size = new System.Drawing.Size(75, 20);
            this.labeltelefoneativo.TabIndex = 14;
            this.labeltelefoneativo.Text = "Telefone:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 16;
            this.label1.Text = "Número:";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(134, 105);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 26);
            this.textBox1.TabIndex = 17;
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(134, 137);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(158, 28);
            this.comboBox1.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 20);
            this.label2.TabIndex = 18;
            this.label2.Text = "Responsavel:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(242, 112);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(50, 17);
            this.checkBox1.TabIndex = 20;
            this.checkBox1.Text = "Ativo";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // selecionartelefone
            // 
            this.selecionartelefone.Image = global::AssistenteLigacoes.Properties.Resources.accept;
            this.selecionartelefone.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.selecionartelefone.Location = new System.Drawing.Point(27, 178);
            this.selecionartelefone.Name = "selecionartelefone";
            this.selecionartelefone.Size = new System.Drawing.Size(63, 28);
            this.selecionartelefone.TabIndex = 21;
            this.selecionartelefone.Text = "Salvar";
            this.selecionartelefone.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.selecionartelefone.UseVisualStyleBackColor = true;
            this.selecionartelefone.Click += new System.EventHandler(this.selecionartelefone_Click);
            // 
            // comboramal
            // 
            this.comboramal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboramal.FormattingEnabled = true;
            this.comboramal.Location = new System.Drawing.Point(134, 104);
            this.comboramal.Name = "comboramal";
            this.comboramal.Size = new System.Drawing.Size(100, 28);
            this.comboramal.TabIndex = 22;
            this.comboramal.Visible = false;
            this.comboramal.SelectedIndexChanged += new System.EventHandler(this.comboramal_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Image = global::AssistenteLigacoes.Properties.Resources.cross;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(229, 178);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(63, 28);
            this.button1.TabIndex = 23;
            this.button1.Text = "Excluir";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormRamal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 229);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboramal);
            this.Controls.Add(this.selecionartelefone);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.combotelefone);
            this.Controls.Add(this.labeltelefoneativo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormRamal";
            this.Resizable = false;
            this.Text = "Cadastrar Ramal";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox combotelefone;
        private System.Windows.Forms.Label labeltelefoneativo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button selecionartelefone;
        private System.Windows.Forms.ComboBox comboramal;
        private System.Windows.Forms.Button button1;
    }
}