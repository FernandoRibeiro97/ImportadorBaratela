namespace ImportadorBaratela.Formularios
{
    partial class FormParametros
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
            this.ckbEanVazioInsereId = new System.Windows.Forms.CheckBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgTributacoes = new System.Windows.Forms.DataGridView();
            this.lblDgTributacoes = new System.Windows.Forms.Label();
            this.valorCSV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sittrib = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codPDV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aliquota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reducao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTributacoes)).BeginInit();
            this.SuspendLayout();
            // 
            // ckbEanVazioInsereId
            // 
            this.ckbEanVazioInsereId.AutoSize = true;
            this.ckbEanVazioInsereId.Checked = true;
            this.ckbEanVazioInsereId.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbEanVazioInsereId.Location = new System.Drawing.Point(31, 36);
            this.ckbEanVazioInsereId.Name = "ckbEanVazioInsereId";
            this.ckbEanVazioInsereId.Size = new System.Drawing.Size(193, 17);
            this.ckbEanVazioInsereId.TabIndex = 0;
            this.ckbEanVazioInsereId.Text = "Ean vazio considerar ID do produto";
            this.ckbEanVazioInsereId.UseVisualStyleBackColor = true;
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnSalvar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSalvar.Location = new System.Drawing.Point(1135, 12);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(197, 38);
            this.btnSalvar.TabIndex = 1;
            this.btnSalvar.Text = "Salvar Alterações";
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ckbEanVazioInsereId);
            this.groupBox1.Location = new System.Drawing.Point(12, 67);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1320, 184);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fixos";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblDgTributacoes);
            this.groupBox2.Controls.Add(this.dgTributacoes);
            this.groupBox2.Location = new System.Drawing.Point(12, 257);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1320, 281);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Condicionais";
            // 
            // dgTributacoes
            // 
            this.dgTributacoes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTributacoes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.valorCSV,
            this.sittrib,
            this.valor,
            this.codPDV,
            this.aliquota,
            this.reducao});
            this.dgTributacoes.Location = new System.Drawing.Point(6, 44);
            this.dgTributacoes.Name = "dgTributacoes";
            this.dgTributacoes.Size = new System.Drawing.Size(643, 131);
            this.dgTributacoes.TabIndex = 0;
            // 
            // lblDgTributacoes
            // 
            this.lblDgTributacoes.AutoSize = true;
            this.lblDgTributacoes.Location = new System.Drawing.Point(3, 28);
            this.lblDgTributacoes.Name = "lblDgTributacoes";
            this.lblDgTributacoes.Size = new System.Drawing.Size(162, 13);
            this.lblDgTributacoes.TabIndex = 1;
            this.lblDgTributacoes.Text = "Adicione ou edite as Tributações";
            // 
            // valorCSV
            // 
            this.valorCSV.HeaderText = "CSV";
            this.valorCSV.Name = "valorCSV";
            // 
            // sittrib
            // 
            this.sittrib.HeaderText = "SitTrib";
            this.sittrib.Name = "sittrib";
            // 
            // valor
            // 
            this.valor.HeaderText = "Valor";
            this.valor.Name = "valor";
            // 
            // codPDV
            // 
            this.codPDV.HeaderText = "CodPDV";
            this.codPDV.Name = "codPDV";
            // 
            // aliquota
            // 
            this.aliquota.HeaderText = "Alíquota";
            this.aliquota.Name = "aliquota";
            // 
            // reducao
            // 
            this.reducao.HeaderText = "Redução";
            this.reducao.Name = "reducao";
            // 
            // FormParametros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1344, 729);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSalvar);
            this.Name = "FormParametros";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Configuração de Parâmetros";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormParametros_FormClosing);
            this.Load += new System.EventHandler(this.FormParametros_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTributacoes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox ckbEanVazioInsereId;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblDgTributacoes;
        private System.Windows.Forms.DataGridView dgTributacoes;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorCSV;
        private System.Windows.Forms.DataGridViewTextBoxColumn sittrib;
        private System.Windows.Forms.DataGridViewTextBoxColumn valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn codPDV;
        private System.Windows.Forms.DataGridViewTextBoxColumn aliquota;
        private System.Windows.Forms.DataGridViewTextBoxColumn reducao;
    }
}