using ImportadorBaratela.Enums;
using ImportadorBaratela.Helpers;
using ImportadorBaratela.Models.Config;
using ImportadorBaratela.Models.Tabelas;
using ImportadorBaratela.Services;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
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
        private MySqlConnection _Conexao;
        private Dictionary<string, int> _DicionarioColunas;
        private TipoArquivo _TipoArquivo = TipoArquivo.Nenhum;
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnParametros.PerformClick();
        }
        private void btnImportarArquivoCSV_Click(object sender, EventArgs e)
        {
            LimparTela();
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
                _TipoArquivo = caminhoArquivo.Contains("CLIENTE.CSV") ? TipoArquivo.Cliente : TipoArquivo.Produto;

                caminhoArquivo = RetornarArquivoCodificadoUTF8(caminhoArquivo);

                if (File.Exists(caminhoArquivo))
                {
                    LerArquivoCSV(File.ReadAllLines(caminhoArquivo));
                }
                else
                {
                    MessageBox.Show("Não foi possível converter o arquivo para UTF-8");
                    return;
                }
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

            DataTable dt =  null;
            int contLinha = 0;

            foreach (string linha in linhas)
            {
                string[] campos = linha.Split(';');

                int.TryParse(campos[0], out int result);

                if (contLinha == 0)
                {
                    dt = MontarColunasDataTableCSV(campos);
                }
                else if (!string.IsNullOrEmpty(campos[0]) && result > 0)
                {
                    AdicionarLinhaDataTable(dt, campos);
                }

                contLinha++;
            }

            if (dt.Rows.Count > 0)
            {
                if (_TipoArquivo == TipoArquivo.Produto)
                {
                    InserirArvoreMercadologica(dt, _Conexao);
                }
                
                dg.DataSource = dt;
                lblQtdLinhas.Text = dg.Rows.Count.ToString();
                btnInserirBanco.Enabled = dg.Rows.Count > 0;
                return true;
            }
            else
                return false;
        }

        DataTable MontarColunasDataTableCSV(string[] colunas)
        {
            DataTable dt = new DataTable();
            _DicionarioColunas = new Dictionary<string, int>();

            if (colunas.Length > 0)
            {
                foreach (string coluna in colunas)
                {
                    dt.Columns.Add(coluna.Trim().ToUpper());
                }

                foreach (DataColumn col in dt.Columns)
                {
                    _DicionarioColunas.Add(col.ColumnName, dt.Columns.IndexOf(col));
                }

                if (!ValidarColunasArquivo(dt.Columns, out string colunaNaoEncontrada) && _TipoArquivo == TipoArquivo.Produto)
                    throw new Exception($"NÃO FOI POSSÍVEL ENCONTRAR A COLUNA {colunaNaoEncontrada}");
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

                if (_form.Parametros is null)
                    return;

                _Conexao = new MySqlConnection($"Server={_Parametros.ServidorMySQL};Database={_Parametros.BancoMySQL};UserId={_Parametros.UsuarioMySQL};Password={_Parametros.SenhaMySQL};");

                try
                {
                    if (_Conexao.State != ConnectionState.Open)
                    {
                        _Conexao.Open();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possível se conectar com o banco de dados");
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnInserirBanco_Click(object sender, EventArgs e)
        {
            if (dg.Rows.Count > 0)
            {
                ServiceDB serviceDB = new ServiceDB(_Conexao);

                if (_TipoArquivo == TipoArquivo.Produto)
                {
                    List<ProdutoCompleto> lstProdutos = new List<ProdutoCompleto>();
                    HelperArvoreMercadologica helperArvoreMercadologica = new HelperArvoreMercadologica();
                    helperArvoreMercadologica.PreencherArvoreMercadologicaInserida(_Conexao);

                    foreach (DataGridViewRow r in dg.Rows)
                    {
                        if (RetornarTipoLeituraLinha(dg.Columns) == TipoLeituraLinha.Padrao)
                            lstProdutos.Add(RetornarProdutoPorRowPadrao(r, helperArvoreMercadologica));
                        else
                            lstProdutos.Add(RetornarProdutoPorNomeColuna(r, helperArvoreMercadologica));
                    }

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
                    serviceDB.InserirTabelaEstoque(lstTabelaEstoque);
                    serviceDB.InserirTabelaTributacao(lstTabelaTributacao);
                    MessageBox.Show("Operação finalizada");
                }
                else if (_TipoArquivo == TipoArquivo.Cliente)
                {
                    List<Cliente> lstCliente = new List<Cliente>();

                    foreach (DataGridViewRow r in dg.Rows)
                    {
                        lstCliente.Add(RetornarClientePorNomeColuna(r));
                    }

                    serviceDB.InserirTabelaCliente(lstCliente);
                    MessageBox.Show("Operação finalizada");
                }
            }
        }

        ProdutoCompleto RetornarProdutoPorRowPadrao(DataGridViewRow r, HelperArvoreMercadologica helperArvoreMercadologica)
        {
            int _loja = 1;

            ProdutoCompleto produto = new ProdutoCompleto();
            produto.TbProduto.IdProduto = Convert.ToInt32(r.Cells[0].Value);
            produto.TbProduto.Descricao = RetornarStringFormatada(r.Cells[2].Value.ToString());
            produto.TbProduto.DescricaoReduzida = produto.TbProduto.Descricao.Length > 24 ? produto.TbProduto.Descricao.Substring(0, 24) : produto.TbProduto.Descricao;
            produto.TbProduto.EmbEntrada = 1.000M;
            produto.TbProduto.EmbSaida = 1.000M;
            produto.TbProduto.UnidEntrada = r.Cells[3].Value.ToString();
            produto.TbProduto.UnidSaida = r.Cells[3].Value.ToString();
            produto.TbProduto.Validade = Convert.ToInt32(r.Cells[24].Value);
            produto.TbProduto.IdGrupo = helperArvoreMercadologica.GruposInseridos.FirstOrDefault(g => g.Descricao == r.Cells[20].Value.ToString()).Id;
            produto.TbProduto.IdSubGrupo = helperArvoreMercadologica.SubGruposInseridos.FirstOrDefault(sb => sb.Descricao == r.Cells[21].Value.ToString()).Id;
            produto.TbProduto.IdSubGrupo1 = helperArvoreMercadologica.SubGrupos1Inseridos.FirstOrDefault(sb1 => sb1.Descricao == r.Cells[22].Value.ToString()).Id;
            produto.TbProduto.PesoVariavel = r.Cells[23].Value.ToString() == "S" ? 1 : 0;
            produto.TbProduto.Ean = string.IsNullOrEmpty(r.Cells[1].Value.ToString()) ? produto.TbProduto.IdProduto.ToString() : r.Cells[1].Value.ToString();
            produto.TbProduto.ClassFiscal = string.IsNullOrEmpty(r.Cells[7].Value.ToString()) ? "12345678" : r.Cells[7].Value.ToString();
            produto.TbProduto.Cest = "";
            produto.TbProduto.Tipo = r.Cells[3].Value.ToString() == "KG" ? "P" : "U";

            produto.TbPreco.IdProduto = produto.TbProduto.IdProduto;
            produto.TbPreco.IdLoja = _loja;
            produto.TbPreco.Custo = Convert.ToDecimal(r.Cells[4].Value);
            produto.TbPreco.Venda1 = Convert.ToDecimal(r.Cells[6].Value);

            produto.TbEstoque.IdProduto = produto.TbProduto.IdProduto;
            produto.TbEstoque.IdLoja = _loja;
            produto.TbEstoque.EstoqueAtual = 0M;
            produto.TbEstoque.EstoqueMinimo = 0M;

            string natFiscal = r.Cells[13].Value.ToString();
            decimal.TryParse(r.Cells[8].Value.ToString(), out decimal aliqEntrada);
            decimal.TryParse(r.Cells[10].Value.ToString(), out decimal aliqSaida);
            
            bool temReducao = aliqSaida < aliqEntrada;
            decimal.TryParse(r.Cells[9].Value.ToString(), out decimal reducao);

            produto.TbTributacao.IdProduto = produto.TbProduto.IdProduto;
            produto.TbTributacao.IdLoja = _loja;
            produto.TbTributacao.OrigemProduto = "0 - NACIONAL";
            produto.TbTributacao.TipoProd = "00 - MERCADORIA PARA REVENDA";
            produto.TbTributacao.SitTribCompra = HelperProduto.RetornarSitTrib(natFiscal);
            produto.TbTributacao.IcmsCompra = HelperProduto.ValidarAliq(aliqEntrada);
            produto.TbTributacao.RedBase = 0M;
            produto.TbTributacao.TabIcmsProdEntrada = HelperProduto.RetornarTabIcms(aliqEntrada);
            produto.TbTributacao.SitTrib = HelperProduto.RetornarSitTrib(natFiscal);
            produto.TbTributacao.Icms = HelperProduto.ValidarAliq(aliqSaida);
            produto.TbTributacao.RedBaseVenda = temReducao ? reducao : 0M;
            produto.TbTributacao.TabIcmsProd = HelperProduto.RetornarTabIcms(aliqSaida, temReducao);
            produto.TbTributacao.CodTrib = HelperProduto.RetornarCodTrib(natFiscal == "I" ? -1 : aliqSaida);
            produto.TbTributacao.Ipi = 0M;
            produto.TbTributacao.Iva = 0M;

            string _pisCofins = r.Cells[14].Value.ToString();
            produto.TbTributacao.TipoPisCofins = _pisCofins == "A" ? "I" : _pisCofins;
            produto.TbTributacao.CstPis = HelperProduto.RetornarCstPisEntrada(_pisCofins);
            produto.TbTributacao.CstPisSaida = HelperProduto.RetornarCstPisSaida(_pisCofins);
            produto.TbTributacao.CcsApurada = "02 - Contribuição não-cumulativa apurada a alíquotas diferenciadas";
            produto.TbTributacao.CargaTributariaFederal = 0M;
            produto.TbTributacao.CargaTributaria = 0M;
            produto.TbTributacao.ChaveNCM = "M2L5P8";
            produto.TbTributacao.CstIpiSaida = "";
            produto.TbTributacao.CstIpiEntrada = "";
            produto.TbTributacao.TipoIva = "P";
            produto.TbTributacao.CalculaIvaAjustado = "N";
            produto.TbTributacao.NatReceita = "";
            produto.TbTributacao.Fecoep = 0M;
            produto.TbTributacao.Pis = 0M;
            produto.TbTributacao.Cofins = 0M;
            produto.TbTributacao.PisEntrada = 0M;
            produto.TbTributacao.CofinsEntrada = 0M;

            return produto;
        }
        ProdutoCompleto RetornarProdutoPorNomeColuna(DataGridViewRow r, HelperArvoreMercadologica helperArvoreMercadologica)
        {
            int _loja = 1;

            int idx_idproduto = RetornarIndexColunaPorDescricao("CODIGO");
            int idx_descricao = RetornarIndexColunaPorDescricao("DESCRICAO");
            int idx_unidade = RetornarIndexColunaPorDescricao("UNID.");
            int idx_validade = RetornarIndexColunaPorDescricao("VALIDADE");
            int idx_secao = RetornarIndexColunaPorDescricao("SECAO");
            int idx_grupo = RetornarIndexColunaPorDescricao("GRUPO");
            int idx_subgrupo = RetornarIndexColunaPorDescricao("SUBGRUPO");
            int idx_pesoVariavel = RetornarIndexColunaPorDescricao("BALANCA");
            int idx_ean = RetornarIndexColunaPorDescricao("COD.EAN");
            int idx_classFiscal = RetornarIndexColunaPorDescricao("NCM");
            int idx_idfamilia = RetornarIndexColunaPorDescricao("FAMILIA");

            int idx_custo = RetornarIndexColunaPorDescricao("C.FORN.");
            int idx_venda = RetornarIndexColunaPorDescricao("VENDA");

            int idx_estoque = RetornarIndexColunaPorDescricao("ESTOQUE");

            int idx_natFiscal = RetornarIndexColunaPorDescricao("NAT.FISCAL");
            int idx_aliqEntrada = RetornarIndexColunaPorDescricao("ICM COMPRA");
            int idx_aliqSaida = RetornarIndexColunaPorDescricao("ICM VENDA");
            int idx_reducao = RetornarIndexColunaPorDescricao("RED VENDA");
            int idx_pisCofins = RetornarIndexColunaPorDescricao("PIS/COFINS");

            ProdutoCompleto produto = new ProdutoCompleto();
            produto.TbProduto.IdProduto = Convert.ToInt32(r.Cells[idx_idproduto].Value);
            produto.TbProduto.Descricao = RetornarStringFormatada(r.Cells[idx_descricao].Value.ToString());
            produto.TbProduto.DescricaoReduzida = produto.TbProduto.Descricao.Length > 24 ? produto.TbProduto.Descricao.Substring(0, 24) : produto.TbProduto.Descricao;
            produto.TbProduto.EmbEntrada = 1.000M;
            produto.TbProduto.EmbSaida = 1.000M;
            produto.TbProduto.UnidEntrada = idx_unidade > 0 ? r.Cells[idx_unidade].Value.ToString() : "UN";
            produto.TbProduto.UnidSaida = idx_unidade > 0 ? r.Cells[idx_unidade].Value.ToString() : "UN";
            produto.TbProduto.Validade = idx_validade > 0 ? Convert.ToInt32(r.Cells[idx_validade].Value) : 0;
            produto.TbProduto.IdGrupo = helperArvoreMercadologica.GruposInseridos.FirstOrDefault(g => g.Descricao == r.Cells[idx_secao].Value.ToString()).Id;
            produto.TbProduto.IdSubGrupo = helperArvoreMercadologica.SubGruposInseridos.FirstOrDefault(sb => sb.Descricao == r.Cells[idx_grupo].Value.ToString()).Id;
            produto.TbProduto.IdSubGrupo1 = helperArvoreMercadologica.SubGrupos1Inseridos.FirstOrDefault(sb1 => sb1.Descricao == r.Cells[idx_subgrupo].Value.ToString()).Id;
            produto.TbProduto.PesoVariavel = idx_pesoVariavel > 0 ? (r.Cells[idx_pesoVariavel].Value.ToString() == "S" ? 1 : 0) : produto.TbProduto.UnidSaida == "KG" ? 1 : 0;
            produto.TbProduto.Ean = string.IsNullOrEmpty(r.Cells[idx_ean].Value.ToString()) ? produto.TbProduto.IdProduto.ToString() : r.Cells[idx_ean].Value.ToString();
            produto.TbProduto.ClassFiscal = string.IsNullOrEmpty(r.Cells[idx_classFiscal].Value.ToString()) ? "12345678" : r.Cells[idx_classFiscal].Value.ToString();
            produto.TbProduto.Cest = "";
            produto.TbProduto.Tipo = idx_unidade > 0 ? (r.Cells[idx_unidade].Value.ToString() == "KG" ? "P" : "U") : "U";
            produto.TbProduto.IdFamilia = idx_idfamilia > 0 ? Convert.ToInt32(r.Cells[idx_idfamilia].Value) : 0;

            produto.TbPreco.IdProduto = produto.TbProduto.IdProduto;
            produto.TbPreco.IdLoja = _loja;
            produto.TbPreco.IdFamilia = produto.TbProduto.IdFamilia;

            if (idx_custo > 0)
            {
                if (decimal.TryParse(r.Cells[idx_custo].Value.ToString(), out decimal _custo))
                    produto.TbPreco.Custo = _custo;
                else
                    produto.TbPreco.Custo = 0m;
            }

            if (idx_venda > 0)
            {
                if (decimal.TryParse(r.Cells[idx_venda].Value.ToString(), out decimal _venda1))
                    produto.TbPreco.Venda1 = _venda1;
                else
                    produto.TbPreco.Venda1 = 0m;
            }

            produto.TbEstoque.IdProduto = produto.TbProduto.IdProduto;
            produto.TbEstoque.IdLoja = _loja;

            if (idx_estoque > 0)
            {
                if (decimal.TryParse(r.Cells[idx_estoque].Value.ToString(), out decimal _estoque))
                    produto.TbEstoque.EstoqueAtual = _estoque;
                else
                    produto.TbEstoque.EstoqueAtual = 0;
            }

            produto.TbEstoque.EstoqueMinimo = 0M;

            string natFiscal = r.Cells[idx_natFiscal].Value.ToString();
            decimal.TryParse(r.Cells[idx_aliqEntrada].Value.ToString(), out decimal aliqEntrada);
            decimal.TryParse(r.Cells[idx_aliqSaida].Value.ToString(), out decimal aliqSaida);

            bool temReducao = aliqSaida < aliqEntrada;
            decimal.TryParse(r.Cells[idx_reducao].Value.ToString(), out decimal reducao);

            produto.TbTributacao.IdProduto = produto.TbProduto.IdProduto;
            produto.TbTributacao.IdLoja = _loja;
            produto.TbTributacao.OrigemProduto = "0 - NACIONAL";
            produto.TbTributacao.TipoProd = "00 - MERCADORIA PARA REVENDA";
            produto.TbTributacao.SitTribCompra = HelperProduto.RetornarSitTrib(natFiscal);
            produto.TbTributacao.IcmsCompra = HelperProduto.ValidarAliq(aliqEntrada);
            produto.TbTributacao.RedBase = 0M;
            produto.TbTributacao.TabIcmsProdEntrada = HelperProduto.RetornarTabIcms(aliqEntrada);
            produto.TbTributacao.SitTrib = HelperProduto.RetornarSitTrib(natFiscal);
            produto.TbTributacao.Icms = HelperProduto.ValidarAliq(aliqSaida);
            produto.TbTributacao.RedBaseVenda = temReducao ? reducao : 0M;
            produto.TbTributacao.TabIcmsProd = HelperProduto.RetornarTabIcms(aliqSaida, temReducao);
            produto.TbTributacao.CodTrib = HelperProduto.RetornarCodTrib(natFiscal == "I" ? -1 : aliqSaida);
            produto.TbTributacao.Ipi = 0M;
            produto.TbTributacao.Iva = 0M;

            string _pisCofins = r.Cells[idx_pisCofins].Value.ToString();
            produto.TbTributacao.TipoPisCofins = _pisCofins == "A" ? "I" : _pisCofins;
            produto.TbTributacao.CstPis = HelperProduto.RetornarCstPisEntrada(_pisCofins);
            produto.TbTributacao.CstPisSaida = HelperProduto.RetornarCstPisSaida(_pisCofins);
            produto.TbTributacao.CcsApurada = "02 - Contribuição não-cumulativa apurada a alíquotas diferenciadas";
            produto.TbTributacao.CargaTributariaFederal = 0M;
            produto.TbTributacao.CargaTributaria = 0M;
            produto.TbTributacao.ChaveNCM = "M2L5P8";
            produto.TbTributacao.CstIpiSaida = "";
            produto.TbTributacao.CstIpiEntrada = "";
            produto.TbTributacao.TipoIva = "P";
            produto.TbTributacao.CalculaIvaAjustado = "N";
            produto.TbTributacao.NatReceita = "";
            produto.TbTributacao.Fecoep = 0M;
            produto.TbTributacao.Pis = 0M;
            produto.TbTributacao.Cofins = 0M;
            produto.TbTributacao.PisEntrada = 0M;
            produto.TbTributacao.CofinsEntrada = 0M;

            return produto;
        }
        Cliente RetornarClientePorNomeColuna(DataGridViewRow r)
        {
            int idx_idcliente = RetornarIndexColunaPorDescricao("CODIGO");
            int idx_nome = RetornarIndexColunaPorDescricao("NOME");
            int idx_endereco = RetornarIndexColunaPorDescricao("ENDERECO");
            int idx_bairro = RetornarIndexColunaPorDescricao("BAIRRO");
            int idx_cidade = RetornarIndexColunaPorDescricao("CIDADE");
            int idx_cep = RetornarIndexColunaPorDescricao("CEP");
            int idx_uf = RetornarIndexColunaPorDescricao("UF");
            int idx_aniversario = RetornarIndexColunaPorDescricao("ANIVERSARIO");
            int idx_cpf = RetornarIndexColunaPorDescricao("CPF");
            int idx_rg = RetornarIndexColunaPorDescricao("RG");
            int idx_email = RetornarIndexColunaPorDescricao("EMAIL");
            int idx_celular = RetornarIndexColunaPorDescricao("CELULAR");
            
            Cliente cliente = new Cliente();
            cliente.Id = Convert.ToInt32(r.Cells[idx_idcliente].Value);
            cliente.Nome = RetornarStringFormatada(r.Cells[idx_nome].Value.ToString());
            cliente.Fantasia = cliente.Nome;
            cliente.Endereco = RetornarStringFormatada(r.Cells[idx_endereco].Value.ToString(), false).Replace("\\", "").Replace("'", "");
            cliente.Numero = RetornarNumeroEndereco(cliente.Endereco);
            cliente.Bairro = r.Cells[idx_bairro].Value.ToString();
            cliente.Cidade = RetornarStringFormatada(r.Cells[idx_cidade].Value.ToString());
            cliente.CodMunicipio = 0;
            cliente.UF = r.Cells[idx_uf].Value.ToString();
            cliente.CEP = r.Cells[idx_cep].Value.ToString();
            cliente.CPF = r.Cells[idx_cpf].Value.ToString();
            cliente.RG = r.Cells[idx_rg].Value.ToString();
            cliente.Credito = 0;
            cliente.Limite = 0;
            cliente.DtNascimento = "2000-01-01";
            cliente.Usado = 0;
            cliente.Obs = "IMPORTADO";
            cliente.EmpresaConvenio = 1;
            cliente.Loja = 1;
            cliente.Tipo = "TT";
            cliente.TipoFidelidade = 2;
            cliente.CondicaoPagamento = "";
            cliente.Fone = "";
            cliente.Celular = r.Cells[idx_celular].Value.ToString();
            cliente.Email = r.Cells[idx_email].Value.ToString();

            return cliente;
        }
        string RetornarStringFormatada(string str, bool removerCaracteresEspeciais = true)
        {
            str = str.Replace("Á", "A");
            str = str.Replace("À", "A");
            str = str.Replace("Â", "A");
            str = str.Replace("Ã", "A");

            str = str.Replace("É", "E");
            str = str.Replace("È", "E");
            str = str.Replace("Ê", "E");

            str = str.Replace("Í", "I");
            str = str.Replace("Ì", "I");

            str = str.Replace("Ó", "O");
            str = str.Replace("Ò", "O");
            str = str.Replace("Ô", "O");
            str = str.Replace("Õ", "O");

            str = str.Replace("Ú", "U");
            str = str.Replace("Ù", "U");

            str = str.Replace("Ç", "C");

            if (removerCaracteresEspeciais)
            {
                str = str.Replace("\\", "");
                str = str.Replace("'", "");
                str = str.Replace("~", "");
                str = str.Replace("*", "");
                str = str.Replace(".", "");
                str = str.Replace(",", "");
                str = str.Replace("=", "");
                str = str.Replace("(", "");
                str = str.Replace(")", "");
                str = str.Replace("-", "");
                str = str.Replace(";", "");
            }

            return str;
        }
        string RetornarArquivoCodificadoUTF8(string arquivoOriginal)
        {
            string caminho = string.Empty;

            try
            {
                if (File.Exists(arquivoOriginal))
                {
                    Encoding ansi = Encoding.GetEncoding(1252);

                    string conteudoOriginal = File.ReadAllText(arquivoOriginal, ansi);

                    caminho = Path.GetTempFileName();

                    File.WriteAllText(caminho, conteudoOriginal, Encoding.UTF8);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "";
            }

            return caminho;
        }
        bool InserirArvoreMercadologica(DataTable dtPrincipal, MySqlConnection connection)
        {
            List<Grupo> lstGrupo = new List<Grupo>();
            List<SubGrupo> lstSubGrupo = new List<SubGrupo>();
            List<SubGrupo1> lstSubGrupo1 = new List<SubGrupo1>();

            if (dtPrincipal.Rows.Count > 0)
            {
                if (dtPrincipal.Columns.Contains("SECAO"))
                {
                    int contGrupo = 1;
                    int contSubGrupo = 1;
                    int contSubGrupo1 = 1;
                    foreach (DataRow r in dtPrincipal.Rows)
                    {
                        Grupo grupo = new Grupo() { Descricao = r["SECAO"].ToString() };
                        SubGrupo subGrupo = new SubGrupo() { Descricao = r["GRUPO"].ToString() };
                        SubGrupo1 subGrupo1 = new SubGrupo1() { Descricao = r["SUBGRUPO"].ToString() };

                        if (!lstGrupo.Any(g => g.Descricao == grupo.Descricao))
                        {
                            grupo.Id = contGrupo;
                            contGrupo++;
                            lstGrupo.Add(grupo);
                        }
                        else
                            grupo.Id = lstGrupo.FirstOrDefault(g => g.Descricao == grupo.Descricao).Id;

                        if (!lstSubGrupo.Any(sb => sb.Descricao == subGrupo.Descricao))
                        {
                            subGrupo.Id = contSubGrupo;
                            subGrupo.IdGrupo = grupo.Id;
                            contSubGrupo++;
                            lstSubGrupo.Add(subGrupo);
                        }
                        else
                            subGrupo.Id = lstSubGrupo.FirstOrDefault(sb => sb.Descricao == subGrupo.Descricao).Id;

                        if (!lstSubGrupo1.Any(sb1 => sb1.Descricao == subGrupo1.Descricao))
                        {
                            subGrupo1.Id = contSubGrupo1;
                            subGrupo1.IdGrupo = grupo.Id;
                            subGrupo1.IdSubGrupo = subGrupo.Id;
                            contSubGrupo1++;
                            lstSubGrupo1.Add(subGrupo1);
                        }
                        
                    }
                }
            }

            ServiceDB service = new ServiceDB(connection);

            try
            {
                service.InserirTabelaGrupo(lstGrupo);
                service.InserirTabelaSubGrupo(lstSubGrupo);
                service.InserirTabelaSubGrupo1(lstSubGrupo1);

                return true;
            }
            catch
            {
                MessageBox.Show("Não foi possível inserir GRUPO/SUBGRUPO/SUBGRUPO1");
                return false;
            }
        }
        int RetornarIndexColunaPorDescricao(string coluna)
        {
            if (_DicionarioColunas.Count > 0)
            {
                _DicionarioColunas.TryGetValue(coluna, out int index);

                return index;
            }
            else
                return 0;
        }
        string RetornarNumeroEndereco(string endereco)
        {
            if (endereco == "N")
                return "SN";

            var x = 0;

            if (endereco.Contains(","))
            {
                string[] retorno = endereco.Split(',');

                if (retorno.Count() > 1)
                {
                    if (retorno[1].Contains(' '))
                    {
                        string[] novoRetorno = retorno[1].Split(' ');

                        for (int i = 0; i < novoRetorno.Length; i++)
                        {
                            int.TryParse(novoRetorno[i], out int result);

                            //RETORNA O PRIMEIRO QUE CONSEGUIR CONVERTER
                            if (result > 0)
                                return result.ToString();
                        }
                    }
                    else
                        return retorno[1].Trim();
                }
            }
            else if (endereco.Contains("N "))
            {
                int i = endereco.IndexOf("N ");

                var extrair = endereco.Substring(i);
                string[] retorno = extrair.Split(' ');

                if (retorno.Count() > 1)
                {
                    int.TryParse(retorno[1], out int result);

                    if (result > 0)
                        return retorno[1].Trim();
                }
            }
            else if (endereco.Contains("N."))
            {
                string[] retorno = endereco.Split('.');

                if (retorno.Count() > 1)
                {
                    int.TryParse(retorno[1], out int result);

                    if (result > 0)
                        return retorno[1].Trim();
                }
            }

            return "SN";
        }
        bool ValidarColunasArquivo(DataColumnCollection colunas, out string colunaNaoEncontrada)
        {
            if (!colunas.Contains("CODIGO"))
            {
                colunaNaoEncontrada = "CODIGO";
                return false;
            }

            if (!colunas.Contains("COD.EAN"))
            {
                colunaNaoEncontrada = "COD.EAN";
                return false;
            }

            if (!colunas.Contains("DESCRICAO"))
            {
                colunaNaoEncontrada = "DESCRICAO";
                return false;
            }

            colunaNaoEncontrada = "";
            return true;
        }
        TipoLeituraLinha RetornarTipoLeituraLinha(DataGridViewColumnCollection colunas)
        {
            string padraoEsperado = @"CODIGO;COD.EAN;DESCRICAO;UNID.;C.FORN.;C.REP.;VENDA;NCM;ICM COMPRA;RED COMPRA;ICM VENDA;CFOP;RED VENDA;NAT.FISCAL;PIS/COFINS;CST PIS ENT;CST PIS SAI;CST COF ENT;CST COF SAI;% ACRESC.PIS;SECAO;GRUPO;SUBGRUPO;BALANCA;VALIDADE;RECEITA;INF.NUTR;";

            string padraoArquivo = string.Empty;

            foreach (DataGridViewColumn coluna in colunas)
            {
                padraoArquivo += coluna.Name + ";";
            }

            if (padraoArquivo != padraoEsperado)
                return TipoLeituraLinha.NomeColuna;
            else
                return TipoLeituraLinha.Padrao;
        }
        void LimparTela()
        {
            _DicionarioColunas = new Dictionary<string, int>();
            _TipoArquivo = TipoArquivo.Nenhum;
            dg.DataSource = null;
            lblQtdLinhas.Text = "---";
        }
    }
}
