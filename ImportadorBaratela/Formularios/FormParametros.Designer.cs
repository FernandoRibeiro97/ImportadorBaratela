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
            this.components = new System.ComponentModel.Container();
            this.ckbEanVazioInsereId = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblDgTributacoes = new System.Windows.Forms.Label();
            this.dgTributacoes = new System.Windows.Forms.DataGridView();
            this.valorCSV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sittrib = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codPDV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aliquota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reducao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtServidorMySQL = new System.Windows.Forms.TextBox();
            this.txtBancoMySQL = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUsuarioMySQL = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSenhaMySQL = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.txtNomeArquivoCliente = new System.Windows.Forms.TextBox();
            this.txtNomeArquivoProduto = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ckbEanVazioInsereId);
            this.groupBox1.Location = new System.Drawing.Point(12, 127);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(719, 96);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fixos";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblDgTributacoes);
            this.groupBox2.Controls.Add(this.dgTributacoes);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(12, 229);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(719, 190);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Condicionais";
            this.groupBox2.Visible = false;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Servidor MySQL";
            // 
            // txtServidorMySQL
            // 
            this.txtServidorMySQL.Location = new System.Drawing.Point(106, 12);
            this.txtServidorMySQL.Name = "txtServidorMySQL";
            this.txtServidorMySQL.Size = new System.Drawing.Size(244, 20);
            this.txtServidorMySQL.TabIndex = 5;
            this.txtServidorMySQL.Text = "localhost";
            // 
            // txtBancoMySQL
            // 
            this.txtBancoMySQL.Location = new System.Drawing.Point(106, 38);
            this.txtBancoMySQL.Name = "txtBancoMySQL";
            this.txtBancoMySQL.Size = new System.Drawing.Size(244, 20);
            this.txtBancoMySQL.TabIndex = 7;
            this.txtBancoMySQL.Text = "db_imperium";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Banco MySQL";
            // 
            // txtUsuarioMySQL
            // 
            this.txtUsuarioMySQL.Location = new System.Drawing.Point(106, 64);
            this.txtUsuarioMySQL.Name = "txtUsuarioMySQL";
            this.txtUsuarioMySQL.Size = new System.Drawing.Size(244, 20);
            this.txtUsuarioMySQL.TabIndex = 9;
            this.txtUsuarioMySQL.Text = "root";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Usuário MySQL";
            // 
            // txtSenhaMySQL
            // 
            this.txtSenhaMySQL.Location = new System.Drawing.Point(106, 90);
            this.txtSenhaMySQL.Name = "txtSenhaMySQL";
            this.txtSenhaMySQL.Size = new System.Drawing.Size(244, 20);
            this.txtSenhaMySQL.TabIndex = 11;
            this.txtSenhaMySQL.Text = "root";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Senha MySQL";
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnSalvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSalvar.Location = new System.Drawing.Point(534, 80);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(197, 38);
            this.btnSalvar.TabIndex = 12;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // txtNomeArquivoCliente
            // 
            this.txtNomeArquivoCliente.Location = new System.Drawing.Point(487, 41);
            this.txtNomeArquivoCliente.Name = "txtNomeArquivoCliente";
            this.txtNomeArquivoCliente.Size = new System.Drawing.Size(244, 20);
            this.txtNomeArquivoCliente.TabIndex = 16;
            this.txtNomeArquivoCliente.Text = "CLIENTE.CSV";
            this.toolTip.SetToolTip(this.txtNomeArquivoCliente, "Para o sistema não importa se o arquivo está maiúsculo e minúsculo");
            // 
            // txtNomeArquivoProduto
            // 
            this.txtNomeArquivoProduto.Location = new System.Drawing.Point(487, 12);
            this.txtNomeArquivoProduto.Name = "txtNomeArquivoProduto";
            this.txtNomeArquivoProduto.Size = new System.Drawing.Size(244, 20);
            this.txtNomeArquivoProduto.TabIndex = 14;
            this.txtNomeArquivoProduto.Text = "PRODUTO.CSV";
            this.toolTip.SetToolTip(this.txtNomeArquivoProduto, "Para o sistema não importa se o arquivo está maiúsculo e minúsculo");
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(368, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Nome arquivo Produto";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(368, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Nome arquivo Cliente";
            // 
            // FormParametros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 432);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtNomeArquivoCliente);
            this.Controls.Add(this.txtNomeArquivoProduto);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.txtSenhaMySQL);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtUsuarioMySQL);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBancoMySQL);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtServidorMySQL);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
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
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox ckbEanVazioInsereId;
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtServidorMySQL;
        private System.Windows.Forms.TextBox txtBancoMySQL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUsuarioMySQL;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSenhaMySQL;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.TextBox txtNomeArquivoCliente;
        private System.Windows.Forms.TextBox txtNomeArquivoProduto;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolTip toolTip;
    }
}