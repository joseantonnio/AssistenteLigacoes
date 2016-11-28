namespace AssistenteLigacoes
{
    partial class RelatorioChamadas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RelatorioChamadas));
            this.conteudorelatorio = new System.Windows.Forms.DataGridView();
            this.labelramal = new System.Windows.Forms.Label();
            this.labelchamadas = new System.Windows.Forms.Label();
            this.tipochamada = new System.Windows.Forms.ComboBox();
            this.dataInicial = new System.Windows.Forms.MaskedTextBox();
            this.labelde = new System.Windows.Forms.Label();
            this.dataFinal = new System.Windows.Forms.MaskedTextBox();
            this.labelate = new System.Windows.Forms.Label();
            this.calendariode = new System.Windows.Forms.MonthCalendar();
            this.calendarioate = new System.Windows.Forms.MonthCalendar();
            this.relatoriobuscar = new System.Windows.Forms.Button();
            this.salvarelatorio = new System.Windows.Forms.Button();
            this.imprimerelatorio = new System.Windows.Forms.Button();
            this.printrelatorio = new System.Drawing.Printing.PrintDocument();
            this.previewrelatorio = new System.Windows.Forms.PrintPreviewDialog();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.ramalconsulta = new System.Windows.Forms.ComboBox();
            this.atevazio = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.conteudorelatorio)).BeginInit();
            this.SuspendLayout();
            // 
            // conteudorelatorio
            // 
            this.conteudorelatorio.AllowUserToAddRows = false;
            this.conteudorelatorio.AllowUserToDeleteRows = false;
            this.conteudorelatorio.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.conteudorelatorio.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.conteudorelatorio.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.conteudorelatorio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.conteudorelatorio.Location = new System.Drawing.Point(20, 110);
            this.conteudorelatorio.Margin = new System.Windows.Forms.Padding(3, 50, 3, 3);
            this.conteudorelatorio.Name = "conteudorelatorio";
            this.conteudorelatorio.ReadOnly = true;
            this.conteudorelatorio.Size = new System.Drawing.Size(1014, 398);
            this.conteudorelatorio.TabIndex = 0;
            // 
            // labelramal
            // 
            this.labelramal.AutoSize = true;
            this.labelramal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelramal.Location = new System.Drawing.Point(814, 66);
            this.labelramal.Name = "labelramal";
            this.labelramal.Size = new System.Drawing.Size(52, 17);
            this.labelramal.TabIndex = 1;
            this.labelramal.Text = "Ramal:";
            // 
            // labelchamadas
            // 
            this.labelchamadas.AutoSize = true;
            this.labelchamadas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelchamadas.Location = new System.Drawing.Point(23, 66);
            this.labelchamadas.Name = "labelchamadas";
            this.labelchamadas.Size = new System.Drawing.Size(79, 17);
            this.labelchamadas.TabIndex = 3;
            this.labelchamadas.Text = "Chamadas:";
            // 
            // tipochamada
            // 
            this.tipochamada.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tipochamada.FormattingEnabled = true;
            this.tipochamada.Items.AddRange(new object[] {
            "Perdidas",
            "Recebidas",
            "Realizadas"});
            this.tipochamada.Location = new System.Drawing.Point(108, 63);
            this.tipochamada.Name = "tipochamada";
            this.tipochamada.Size = new System.Drawing.Size(206, 24);
            this.tipochamada.TabIndex = 2;
            this.tipochamada.Text = "Selecione...";
            // 
            // dataInicial
            // 
            this.dataInicial.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataInicial.Location = new System.Drawing.Point(356, 63);
            this.dataInicial.Mask = "00/00/0000 90:00:00";
            this.dataInicial.Name = "dataInicial";
            this.dataInicial.Size = new System.Drawing.Size(171, 23);
            this.dataInicial.TabIndex = 3;
            this.dataInicial.Enter += new System.EventHandler(this.dataInicial_Enter);
            this.dataInicial.Leave += new System.EventHandler(this.dataInicial_Leave);
            // 
            // labelde
            // 
            this.labelde.AutoSize = true;
            this.labelde.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelde.Location = new System.Drawing.Point(320, 66);
            this.labelde.Name = "labelde";
            this.labelde.Size = new System.Drawing.Size(30, 17);
            this.labelde.TabIndex = 5;
            this.labelde.Text = "De:";
            // 
            // dataFinal
            // 
            this.dataFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataFinal.Location = new System.Drawing.Point(572, 63);
            this.dataFinal.Mask = "00/00/0000 90:00:00";
            this.dataFinal.Name = "dataFinal";
            this.dataFinal.Size = new System.Drawing.Size(182, 23);
            this.dataFinal.TabIndex = 4;
            this.dataFinal.Enter += new System.EventHandler(this.dataFinal_Enter);
            this.dataFinal.Leave += new System.EventHandler(this.dataFinal_Leave);
            // 
            // labelate
            // 
            this.labelate.AutoSize = true;
            this.labelate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelate.Location = new System.Drawing.Point(533, 66);
            this.labelate.Name = "labelate";
            this.labelate.Size = new System.Drawing.Size(33, 17);
            this.labelate.TabIndex = 7;
            this.labelate.Text = "Até:";
            // 
            // calendariode
            // 
            this.calendariode.Location = new System.Drawing.Point(356, 92);
            this.calendariode.Name = "calendariode";
            this.calendariode.ShowTodayCircle = false;
            this.calendariode.TabIndex = 0;
            this.calendariode.Visible = false;
            this.calendariode.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.calendariode_DateChanged);
            // 
            // calendarioate
            // 
            this.calendarioate.Location = new System.Drawing.Point(572, 92);
            this.calendarioate.MaxSelectionCount = 1;
            this.calendarioate.MinDate = new System.DateTime(2016, 1, 1, 0, 0, 0, 0);
            this.calendarioate.Name = "calendarioate";
            this.calendarioate.ShowTodayCircle = false;
            this.calendarioate.TabIndex = 0;
            this.calendarioate.Visible = false;
            this.calendarioate.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.calendarioate_DateChanged);
            // 
            // relatoriobuscar
            // 
            this.relatoriobuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.relatoriobuscar.Image = global::AssistenteLigacoes.Properties.Resources.accept;
            this.relatoriobuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.relatoriobuscar.Location = new System.Drawing.Point(972, 63);
            this.relatoriobuscar.Name = "relatoriobuscar";
            this.relatoriobuscar.Size = new System.Drawing.Size(65, 23);
            this.relatoriobuscar.TabIndex = 11;
            this.relatoriobuscar.Text = "Buscar";
            this.relatoriobuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.relatoriobuscar.UseVisualStyleBackColor = true;
            this.relatoriobuscar.Click += new System.EventHandler(this.relatoriobuscar_Click);
            // 
            // salvarelatorio
            // 
            this.salvarelatorio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.salvarelatorio.Image = global::AssistenteLigacoes.Properties.Resources.page_excel;
            this.salvarelatorio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.salvarelatorio.Location = new System.Drawing.Point(20, 514);
            this.salvarelatorio.Name = "salvarelatorio";
            this.salvarelatorio.Size = new System.Drawing.Size(73, 30);
            this.salvarelatorio.TabIndex = 12;
            this.salvarelatorio.Text = "Exportar";
            this.salvarelatorio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.salvarelatorio.UseVisualStyleBackColor = true;
            this.salvarelatorio.Click += new System.EventHandler(this.salvarelatorio_Click);
            // 
            // imprimerelatorio
            // 
            this.imprimerelatorio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.imprimerelatorio.Image = global::AssistenteLigacoes.Properties.Resources.printer;
            this.imprimerelatorio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.imprimerelatorio.Location = new System.Drawing.Point(969, 514);
            this.imprimerelatorio.Name = "imprimerelatorio";
            this.imprimerelatorio.Size = new System.Drawing.Size(65, 30);
            this.imprimerelatorio.TabIndex = 13;
            this.imprimerelatorio.Text = "Imprimir";
            this.imprimerelatorio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.imprimerelatorio.UseVisualStyleBackColor = true;
            this.imprimerelatorio.Click += new System.EventHandler(this.imprimerelatorio_Click);
            // 
            // printrelatorio
            // 
            this.printrelatorio.DocumentName = "Relatorio";
            this.printrelatorio.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printrelatorio_BeginPrint);
            this.printrelatorio.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printrelatorio_PrintPage);
            // 
            // previewrelatorio
            // 
            this.previewrelatorio.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.previewrelatorio.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.previewrelatorio.ClientSize = new System.Drawing.Size(400, 300);
            this.previewrelatorio.Enabled = true;
            this.previewrelatorio.Icon = ((System.Drawing.Icon)(resources.GetObject("previewrelatorio.Icon")));
            this.previewrelatorio.Name = "previewrelatorio";
            this.previewrelatorio.ShowIcon = false;
            this.previewrelatorio.Visible = false;
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // ramalconsulta
            // 
            this.ramalconsulta.AutoCompleteCustomSource.AddRange(new string[] {
            "Realizadas",
            "Atendidas",
            "Perdidas"});
            this.ramalconsulta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ramalconsulta.FormattingEnabled = true;
            this.ramalconsulta.Items.AddRange(new object[] {
            "Atendidas",
            "Perdidas",
            "Realizadas"});
            this.ramalconsulta.Location = new System.Drawing.Point(872, 63);
            this.ramalconsulta.Name = "ramalconsulta";
            this.ramalconsulta.Size = new System.Drawing.Size(69, 24);
            this.ramalconsulta.TabIndex = 14;
            // 
            // atevazio
            // 
            this.atevazio.AutoSize = true;
            this.atevazio.Location = new System.Drawing.Point(760, 67);
            this.atevazio.Name = "atevazio";
            this.atevazio.Size = new System.Drawing.Size(48, 17);
            this.atevazio.TabIndex = 15;
            this.atevazio.Text = "Nulo";
            this.atevazio.UseVisualStyleBackColor = true;
            this.atevazio.CheckStateChanged += new System.EventHandler(this.atevazio_CheckStateChanged);
            // 
            // RelatorioChamadas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 567);
            this.Controls.Add(this.atevazio);
            this.Controls.Add(this.ramalconsulta);
            this.Controls.Add(this.imprimerelatorio);
            this.Controls.Add(this.salvarelatorio);
            this.Controls.Add(this.relatoriobuscar);
            this.Controls.Add(this.calendarioate);
            this.Controls.Add(this.calendariode);
            this.Controls.Add(this.dataFinal);
            this.Controls.Add(this.labelate);
            this.Controls.Add(this.dataInicial);
            this.Controls.Add(this.labelde);
            this.Controls.Add(this.tipochamada);
            this.Controls.Add(this.labelchamadas);
            this.Controls.Add(this.labelramal);
            this.Controls.Add(this.conteudorelatorio);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1060, 550);
            this.Name = "RelatorioChamadas";
            this.Text = "Relatorio de Chamadas";
            this.Load += new System.EventHandler(this.RelatorioChamadas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.conteudorelatorio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView conteudorelatorio;
        private System.Windows.Forms.Label labelramal;
        private System.Windows.Forms.Label labelchamadas;
        private System.Windows.Forms.ComboBox tipochamada;
        private System.Windows.Forms.MaskedTextBox dataInicial;
        private System.Windows.Forms.Label labelde;
        private System.Windows.Forms.MaskedTextBox dataFinal;
        private System.Windows.Forms.Label labelate;
        private System.Windows.Forms.MonthCalendar calendariode;
        private System.Windows.Forms.MonthCalendar calendarioate;
        private System.Windows.Forms.Button relatoriobuscar;
        private System.Windows.Forms.Button salvarelatorio;
        private System.Windows.Forms.Button imprimerelatorio;
        private System.Drawing.Printing.PrintDocument printrelatorio;
        private System.Windows.Forms.PrintPreviewDialog previewrelatorio;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.ComboBox ramalconsulta;
        private System.Windows.Forms.CheckBox atevazio;
    }
}