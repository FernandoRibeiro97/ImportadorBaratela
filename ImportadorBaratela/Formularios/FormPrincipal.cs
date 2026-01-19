using ImportadorBaratela.Models.Config;
using ImportadorBaratela.Models.Tabelas;
using ImportadorBaratela.Services;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
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
                caminhoArquivo = RetornarArquivoCodificadoUTF8(caminhoArquivo);

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
                else if (!string.IsNullOrEmpty(campos[0]) && Convert.ToInt32(campos[0]) > 0)
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

        private void btnInserirBanco_Click(object sender, EventArgs e)
        {
            string strConexao = "Server=localhost;DataBase=db_imperium;UserId=root;Password=root";
            MySqlConnection connection = new MySqlConnection(strConexao);

            bool padraoCSV = true;

            if (dgProduto.Rows.Count > 0)
            {
                List<ProdutoCompleto> lstProdutos = new List<ProdutoCompleto>();

                foreach (DataGridViewRow r in dgProduto.Rows)
                {
                    if (padraoCSV)
                    {
                        lstProdutos.Add(RetornarProdutoPorRowPadrao(r));
                    }
                }

                ServiceDB serviceDB = new ServiceDB(connection);

                List<Produto> lstTabelaProduto = new List<Produto>();
                List<ProdutoPreco> lstTabelaPreco = new List<ProdutoPreco>();
                List<ProdutoEstoque> lstTabelaEstoque = new List<ProdutoEstoque>();
                List<ProdutoTributacao> lstTabelaTributacao = new List<ProdutoTributacao>();

                foreach (ProdutoCompleto p in lstProdutos)
                {
                    lstTabelaProduto.Add(p.TbProduto);
                    lstTabelaPreco.Add(p.TbPreco);
                    lstTabelaEstoque.Add(p.TbEstoque);
                    lstTabelaTributacao.Add(p.TbTributacao);
                }

                serviceDB.InserirTabelaProduto(lstTabelaProduto);
                serviceDB.InserirTabelaPreco(lstTabelaPreco);
                MessageBox.Show("Operação finalizada");
            }
        }

        ProdutoCompleto RetornarProdutoPorRowPadrao(DataGridViewRow r)
        {
            ProdutoCompleto produto = new ProdutoCompleto();
            produto.TbProduto.IdProduto = Convert.ToInt32(r.Cells[0].Value);
            produto.TbProduto.Descricao = RetornarDescricaoFormatada(r.Cells[2].Value.ToString());
            produto.TbProduto.DescricaoReduzida = produto.TbProduto.Descricao.Length > 24 ? produto.TbProduto.Descricao.Substring(0, 24) : produto.TbProduto.Descricao;
            produto.TbProduto.EmbEntrada = 1.000M;
            produto.TbProduto.EmbSaida = 1.000M;
            produto.TbProduto.UnidEntrada = r.Cells[3].Value.ToString();
            produto.TbProduto.UnidSaida = r.Cells[3].Value.ToString();
            produto.TbProduto.Validade = Convert.ToInt32(r.Cells[24].Value);
            produto.TbProduto.IdGrupo = 0; //TODO: RETORNAR IDGRUPO
            produto.TbProduto.IdSubGrupo = 0;
            produto.TbProduto.IdSubGrupo1 = 0;
            produto.TbProduto.PesoVariavel = r.Cells[23].Value.ToString() == "S" ? 1 : 0;
            produto.TbProduto.Ean = string.IsNullOrEmpty(r.Cells[1].Value.ToString()) ? produto.TbProduto.IdProduto.ToString() : r.Cells[1].Value.ToString();
            produto.TbProduto.ClassFiscal = string.IsNullOrEmpty(r.Cells[7].Value.ToString()) ? "12345678" : r.Cells[7].Value.ToString();
            produto.TbProduto.Cest = "";
            produto.TbProduto.Tipo = r.Cells[3].Value.ToString() == "KG" ? "P" : "U";

            produto.TbPreco.IdProduto = produto.TbProduto.IdProduto;
            produto.TbPreco.IdLoja = 1;
            produto.TbPreco.Custo = Convert.ToDecimal(r.Cells[4].Value);
            produto.TbPreco.Venda1 = Convert.ToDecimal(r.Cells[6].Value);

            return produto;
        }
        string RetornarDescricaoFormatada(string descricao)
        {
            descricao = descricao.Replace("Á", "A");
            descricao = descricao.Replace("À", "A");
            descricao = descricao.Replace("Â", "A");
            descricao = descricao.Replace("Ã", "A");

            descricao = descricao.Replace("É", "E");
            descricao = descricao.Replace("È", "E");
            descricao = descricao.Replace("Ê", "E");

            descricao = descricao.Replace("Í", "I");
            descricao = descricao.Replace("Ì", "I");

            descricao = descricao.Replace("Ó", "O");
            descricao = descricao.Replace("Ò", "O");
            descricao = descricao.Replace("Ô", "O");
            descricao = descricao.Replace("Õ", "O");

            descricao = descricao.Replace("Ú", "U");
            descricao = descricao.Replace("Ù", "U");

            descricao = descricao.Replace("Ç", "C");

            descricao = descricao.Replace("\\", "");
            descricao = descricao.Replace("'", "");

            return descricao;
        }
        string RetornarArquivoCodificadoUTF8(string arquivoOriginal)
        {
            string caminho = string.Empty;

            if (File.Exists(arquivoOriginal))
            {
                Encoding ansi = Encoding.GetEncoding(1252);

                string conteudoOriginal = File.ReadAllText(arquivoOriginal, ansi);

                caminho = Path.GetTempFileName();

                File.WriteAllText(caminho, conteudoOriginal, Encoding.UTF8);
            }


            return caminho;
        }
    }
}
