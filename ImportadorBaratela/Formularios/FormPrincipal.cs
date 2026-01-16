using ImportadorBaratela.Models.Config;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace ImportadorBaratela.Formularios
{
    public partial class FormPrincipal : Form
    {
        private Parametros _Parametros;
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void btnImportarArquivoCSV_Click(object sender, EventArgs e)
        {
            lblQtdLinhas.Text = "---";
            string caminhoArquivo = string.Empty;

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "arquivos csv (*.csv)|*.csv";

                if (ofd.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(ofd.FileName))
                    caminhoArquivo = ofd.FileName;
                else
                {
                    MessageBox.Show("Nenhum arquivo selecionado");
                    return;
                }
            }

            if (File.Exists(caminhoArquivo))
            {
                LerArquivoCSV(File.ReadAllLines(caminhoArquivo));
            }
            else
            {
                MessageBox.Show("Não foi possível ler o arquivo");
                return;
            }
        }

        bool LerArquivoCSV(string[] linhas)
        {
            if (linhas.Length == 0)
            {
                MessageBox.Show("O arquivo está vazio");
                return false;
            }

            DataTable dtProduto =  null;
            int contLinha = 0;

            foreach (string linha in linhas)
            {
                string[] campos = linha.Split(';');

                if (contLinha == 0)
                {
                    dtProduto = MontarColunasDataTableCSV(campos);
                }
                else
                {
                    AdicionarLinhaDataTable(dtProduto, campos);
                }

                contLinha++;
            }

            if (dtProduto.Rows.Count > 0)
            {
                dgProduto.DataSource = dtProduto;
                lblQtdLinhas.Text = dgProduto.Rows.Count.ToString();
                btnInserirBanco.Enabled = dgProduto.Rows.Count > 0;
                return true;
            }
            else
                return false;
        }

        DataTable MontarColunasDataTableCSV(string[] colunas)
        {
            DataTable dt = new DataTable();

            if (colunas.Length > 0)
            {
                foreach (string coluna in colunas)
                {
                    dt.Columns.Add(coluna.Trim());
                }
            }
            else
            {
                MessageBox.Show("Não foi possível ler as colunas do arquivo");
            }

            return dt;
        }
        bool AdicionarLinhaDataTable(DataTable dt, string[] campos)
        {
            if (campos.Length == dt.Columns.Count)
            {
                dt.Rows.Add(LimparEspacosCampos(campos));
                return true;
            }

            return false;
        }
        string[] LimparEspacosCampos(string[] campos)
        {
            string[] retorno = new string[campos.Length];

            for (int i = 0; i < campos.Length; i++)
            {
                retorno[i] = campos[i].Trim();
            }

            return retorno;
        }

        private void btnParametros_Click(object sender, EventArgs e)
        {
            using (FormParametros _form = new FormParametros())
            {
                _form.ShowDialog();
                _Parametros = _form.Parametros;
            }
        }
    }
}
