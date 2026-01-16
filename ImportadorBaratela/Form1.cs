using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImportadorBaratela
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void btnImportarArquivoCSV_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "arquivos csv (*.csv)|*.csv";
            ofd.ShowDialog();

            if (!string.IsNullOrEmpty(ofd.FileName))
            {

            }
            else
            {
                MessageBox.Show("Nenhum arquivo selecionado");
            }
        }
    }
}
