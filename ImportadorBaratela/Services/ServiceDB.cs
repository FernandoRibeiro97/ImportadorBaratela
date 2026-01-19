using ImportadorBaratela.Helpers;
using ImportadorBaratela.Models.Tabelas;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ImportadorBaratela.Services
{
    public class ServiceDB
    {
        MySqlConnection _conexao = null;

        public ServiceDB(MySqlConnection conexao)
        {
            _conexao = conexao;
        }

        public void InserirTabelaProduto(List<Produto> produtos)
        {
            ExecutarComando("TRUNCATE produto;", CommandType.Text, "TRUNCATE produto");

            string comando = @"INSERT INTO produto(idproduto, Descricao, DescrRed, EmbEntra, EmbSaida, UnidEntra, UnidSaida, Obs, Validade, idGrupo, idSubGrupo, idSubGrupo1, idSituacao, DtCadastro, PesoVariavel, Etiqueta, Ean, ClassFiscal, cest, Vasilhame, Tipo) 
              VALUES ";

            StringBuilder stringBuilder = new StringBuilder(comando);

            foreach (Produto p in produtos)
            {
                stringBuilder.AppendLine(HelperProduto.RetornarLinhaInserirProduto(p) + ",");
            }

            ExecutarComandoFinal(stringBuilder, "INSERT produto");
        }
        public void InserirTabelaPreco(List<ProdutoPreco> precos)
        {
            ExecutarComando("TRUNCATE produto_preco", CommandType.Text, "TRUNCATE produto_preco");

            string comando = @"INSERT INTO produto_preco(IDPRODUTO, ID_LOJA, CUSTO, CUSTO_MEDIO, VENDA1, VENDA2, DTINICIOPROMO, DTFINALPROMO, MARGEM, IDFAMILIA)
            VALUES ";

            StringBuilder stringBuilder = new StringBuilder(comando);

            foreach (ProdutoPreco p in precos)
            {
                stringBuilder.AppendLine(HelperProduto.RetornarLinhaInserirPreco(p) + ",");
            }

            ExecutarComandoFinal(stringBuilder, "INSERT produto_preco");
        }
        public void InserirTabelaEstoque(List<ProdutoEstoque> estoques)
        {
            ExecutarComando("TRUNCATE produto_estoque", CommandType.Text, "TRUNCATE produto_estoque");

            string comando = @"INSERT INTO produto_estoque(idproduto, id_loja, estoque_atual, estoque_minimo) 
            VALUES ";

            StringBuilder stringBuilder = new StringBuilder(comando);

            foreach (ProdutoEstoque e in estoques)
            {
                stringBuilder.AppendLine(HelperProduto.RetornarLinhaInserirEstoque(e) + ",");
            }

            ExecutarComandoFinal(stringBuilder, "INSERT produto_estoque");
        }
        public void InserirTabelaTributacao(List<ProdutoTributacao> tributacoes)
        {
            ExecutarComando("TRUNCATE produto_tributacao", CommandType.Text, "TRUNCATE produto_tributacao");

            string comando = @"INSERT INTO produto_tributacao(
                                idproduto, id_loja, origemprod, tipoprod, sittribcompra, icmscompra, redbase, tabicmsprodentrada, sittrib, icms, redbasevenda, tabicmsprod,
                                codtrib, ipi, iva, tipopiscofins, cst_pis, cst_pis_saida, ccs_apurada, cargaTributariaFederal, cargaTributaria, chaveNCM, cst_ipi_saida,
                                cst_ipi_entrada, tipoiva, calculaIvaAjustado, nat_receita, fecoep, pis, cofins, pisentrada, cofinsentrada
                                )
                                VALUES ";

            StringBuilder stringBuilder = new StringBuilder(comando);

            foreach (ProdutoTributacao t in tributacoes)
            {
                stringBuilder.AppendLine(HelperProduto.RetornarLinhaInserirTributacao(t) + ",");
            }

            ExecutarComandoFinal(stringBuilder, "INSERT produto_tributacao");
        }
        private int ExecutarComando(string strComando, CommandType type, string msgComando)
        {
            MySqlCommand cmd = new MySqlCommand(strComando, _conexao);
            cmd.CommandType = type;

            using (_conexao)
            {
                if (_conexao.State != ConnectionState.Open)
                {
                    _conexao.Open();
                }

                try
                {
                    return cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao executar comando {msgComando}\r\n\r\n{ex.Message}");
                    return 0;
                }
            }


        }
        private void ExecutarComandoFinal(StringBuilder stringBuilder, string msgComando)
        {
            string str = stringBuilder.ToString();

            string comandoFinal = str.Substring(0, str.Length - 3).ToString() + ";";

            ExecutarComando(comandoFinal, CommandType.Text, $"{msgComando}");
        }
    }
}
