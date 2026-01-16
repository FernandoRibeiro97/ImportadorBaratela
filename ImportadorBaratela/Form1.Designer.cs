namespace ImportadorBaratela
{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnImportarArquivoCSV = new System.Windows.Forms.Button();
            this.dgProduto = new System.Windows.Forms.DataGridView();
            this.lblQtdLinhas = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgProduto)).BeginInit();
            this.SuspendLayout();
            // 
            // btnImportarArquivoCSV
            // 
            this.btnImportarArquivoCSV.BackColor = System.Drawing.Color.MediumSeaGreen;
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
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            this.dgProduto.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1344, 729);
            this.Controls.Add(this.lblQtdLinhas);
            this.Controls.Add(this.dgProduto);
            this.Controls.Add(this.btnImportarArquivoCSV);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgProduto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnImportarArquivoCSV;
        private System.Windows.Forms.DataGridView dgProduto;
        private System.Windows.Forms.Label lblQtdLinhas;
    }
}

