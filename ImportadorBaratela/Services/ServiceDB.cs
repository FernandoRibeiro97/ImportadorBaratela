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
                stringBuilder.AppendLine(HelperProduto.RetornaLinhaInserirProduto(p) + ",");
            }

            string str = stringBuilder.ToString();

            string comandoFinal = str.Substring(0, str.Length - 3).ToString() + ";";

            ExecutarComando(comandoFinal, CommandType.Text, "produto");
        }

        public void InserirTabelaPreco(List<ProdutoPreco> precos)
        {
            ExecutarComando("TRUNCATE produto_preco", CommandType.Text, "TRUNCATE produto_preco");

            string comando = @"INSERT INTO produto_preco(IDPRODUTO, ID_LOJA, CUSTO, CUSTO_MEDIO, VENDA1, VENDA2, DTINICIOPROMO, DTFINALPROMO, MARGEM, IDFAMILIA)
            VALUES ";

            StringBuilder stringBuilder = new StringBuilder(comando);

            foreach (ProdutoPreco p in precos)
            {
                stringBuilder.AppendLine(HelperProduto.RetornaLinhaInserirPreco(p) + ",");
            }

            string str = stringBuilder.ToString();

            string comandoFinal = str.Substring(0, str.Length - 3).ToString() + ";";

            ExecutarComando(comandoFinal, CommandType.Text, "insert produto_preco");
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
    }
}
