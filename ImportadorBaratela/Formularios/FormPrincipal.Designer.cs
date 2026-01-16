namespace ImportadorBaratela.Formularios
{
    partial class FormPrincipal
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnImportarArquivoCSV = new System.Windows.Forms.Button();
            this.dgProduto = new System.Windows.Forms.DataGridView();
            this.lblQtdLinhas = new System.Windows.Forms.Label();
            this.btnInserirBanco = new System.Windows.Forms.Button();
            this.btnParametros = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgProduto)).BeginInit();
            this.SuspendLayout();
            // 
            // btnImportarArquivoCSV
            // 
            this.btnImportarArquivoCSV.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnImportarArquivoCSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportarArquivoCSV.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnImportarArquivoCSV.Location = new System.Drawing.Point(12, 12);
            this.btnImportarArquivoCSV.Name = "btnImportarArquivoCSV";
            this.btnImportarArquivoCSV.Size = new System.Drawing.Size(197, 38);
            this.btnImportarArquivoCSV.TabIndex = 0;
            this.btnImportarArquivoCSV.Text = "Importar CSV";
            this.btnImportarArquivoCSV.UseVisualStyleBackColor = false;
            this.btnImportarArquivoCSV.Click += new System.EventHandler(this.btnImportarArquivoCSV_Click);
            // 
            // dgProduto
            // 
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.Silver;
            this.dgProduto.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgProduto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProduto.Location = new System.Drawing.Point(12, 103);
            this.dgProduto.Name = "dgProduto";
            this.dgProduto.RowHeadersVisible = false;
            this.dgProduto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgProduto.Size = new System.Drawing.Size(1320, 614);
            this.dgProduto.TabIndex = 1;
            // 
            // lblQtdLinhas
            // 
            this.lblQtdLinhas.AutoSize = true;
            this.lblQtdLinhas.Location = new System.Drawing.Point(1297, 87);
            this.lblQtdLinhas.Name = "lblQtdLinhas";
            this.lblQtdLinhas.Size = new System.Drawing.Size(16, 13);
            this.lblQtdLinhas.TabIndex = 2;
            this.lblQtdLinhas.Text = "---";
            // 
            // btnInserirBanco
            // 
            this.btnInserirBanco.BackColor = System.Drawing.Color.Indigo;
            this.btnInserirBanco.Enabled = false;
            this.btnInserirBanco.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInserirBanco.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnInserirBanco.Location = new System.Drawing.Point(215, 12);
            this.btnInserirBanco.Name = "btnInserirBanco";
            this.btnInserirBanco.Size = new System.Drawing.Size(197, 38);
            this.btnInserirBanco.TabIndex = 3;
            this.btnInserirBanco.Text = "Inserir Banco";
            this.btnInserirBanco.UseVisualStyleBackColor = false;
            // 
            // btnParametros
            // 
            this.btnParametros.BackColor = System.Drawing.Color.Orange;
            this.btnParametros.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnParametros.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnParametros.Location = new System.Drawing.Point(418, 12);
            this.btnParametros.Name = "btnParametros";
            this.btnParametros.Size = new System.Drawing.Size(197, 38);
            this.btnParametros.TabIndex = 4;
            this.btnParametros.Text = "Parâmetros";
            this.btnParametros.UseVisualStyleBackColor = false;
            this.btnParametros.Click += new System.EventHandler(this.btnParametros_Click);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1344, 729);
            this.Controls.Add(this.btnParametros);
            this.Controls.Add(this.btnInserirBanco);
            this.Controls.Add(this.lblQtdLinhas);
            this.Controls.Add(this.dgProduto);
            this.Controls.Add(this.btnImportarArquivoCSV);
            this.Name = "FormPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Importador";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgProduto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnImportarArquivoCSV;
        private System.Windows.Forms.DataGridView dgProduto;
        private System.Windows.Forms.Label lblQtdLinhas;
        private System.Windows.Forms.Button btnInserirBanco;
        private System.Windows.Forms.Button btnParametros;
    }
}

