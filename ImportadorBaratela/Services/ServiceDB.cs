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
            if (conexao.State != ConnectionState.Open)
            {
                conexao.Open();
            }

            _conexao = conexao;
        }

        public void InserirTabelaProduto(List<Produto> produtos)
        {
            ExecutarComando("TRUNCATE produto;", CommandType.Text, "TRUNCATE produto");

            string comando = @"INSERT INTO produto(idproduto, Descricao, DescrRed, EmbEntra, EmbSaida, UnidEntra, UnidSaida, Obs, Validade, idGrupo, idSubGrupo, idSubGrupo1, idSituacao, DtCadastro, PesoVariavel, Etiqueta, Ean, ClassFiscal, cest, Vasilhame, Tipo) 
              VALUES ";

            StringBuilder stringBuilder = new StringBuilder(comando);

            int contLote = 0;

            foreach (Produto p in produtos)
            {
                stringBuilder.AppendLine(HelperProduto.RetornarLinhaInserirProduto(p) + ",");
                contLote++;

                if (contLote == 1000)
                {
                    ExecutarComandoFinal(stringBuilder, "INSERT produto");
                    stringBuilder = new StringBuilder(comando);
                    contLote = 0;
                }
                else
                    continue;
            }

            if (contLote > 0)
            {
                ExecutarComandoFinal(stringBuilder, "INSERT produto");
            }
        }
        public void InserirTabelaPreco(List<ProdutoPreco> precos)
        {
            ExecutarComando("TRUNCATE produto_preco", CommandType.Text, "TRUNCATE produto_preco");

            string comando = @"INSERT INTO produto_preco(IDPRODUTO, ID_LOJA, CUSTO, CUSTO_MEDIO, VENDA1, VENDA2, DTINICIOPROMO, DTFINALPROMO, MARGEM, IDFAMILIA)
            VALUES ";

            StringBuilder stringBuilder = new StringBuilder(comando);

            int contLote = 0;

            foreach (ProdutoPreco p in precos)
            {
                stringBuilder.AppendLine(HelperProduto.RetornarLinhaInserirPreco(p) + ",");
                contLote++;

                if (contLote == 1000)
                {
                    ExecutarComandoFinal(stringBuilder, "INSERT produto_preco");
                    stringBuilder = new StringBuilder(comando);
                    contLote = 0;
                }
                else
                    continue;
            }

            if (contLote > 0)
            {
                ExecutarComandoFinal(stringBuilder, "INSERT produto_preco");
            }
        }
        public void InserirTabelaEstoque(List<ProdutoEstoque> estoques)
        {
            ExecutarComando("TRUNCATE produto_estoque", CommandType.Text, "TRUNCATE produto_estoque");

            string comando = @"INSERT INTO produto_estoque(idproduto, id_loja, estoque_atual, estoque_minimo) 
            VALUES ";

            StringBuilder stringBuilder = new StringBuilder(comando);

            int contLote = 0;

            foreach (ProdutoEstoque e in estoques)
            {
                stringBuilder.AppendLine(HelperProduto.RetornarLinhaInserirEstoque(e) + ",");
                contLote++;

                if (contLote == 1000)
                {
                    ExecutarComandoFinal(stringBuilder, "INSERT produto_estoque");
                    stringBuilder = new StringBuilder(comando);
                    contLote = 0;
                }
                else
                    continue;
            }

            if (contLote > 0)
            {
                ExecutarComandoFinal(stringBuilder, "INSERT produto_estoque");
            }
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

            int contLote = 0;

            foreach (ProdutoTributacao t in tributacoes)
            {
                stringBuilder.AppendLine(HelperProduto.RetornarLinhaInserirTributacao(t) + ",");
                contLote++;

                if (contLote == 1000)
                {
                    ExecutarComandoFinal(stringBuilder, "INSERT produto_tributacao");
                    stringBuilder = new StringBuilder(comando);
                    contLote = 0;
                }
                else
                    continue;
            }

            if (contLote > 0)
            {
                ExecutarComandoFinal(stringBuilder, "INSERT produto_tributacao");
            }
        }
        public void InserirTabelaGrupo(List<Grupo> grupos)
        {
            ExecutarComando("TRUNCATE grupo;", CommandType.Text, "TRUNCATE grupo");

            string comando = @"INSERT INTO grupo (IDGRUPO, NOME) 
            VALUES ";

            StringBuilder stringBuilder = new StringBuilder(comando);

            foreach (Grupo g in grupos)
            {
                stringBuilder.AppendLine(HelperArvoreMercadologica.RetornarLinhaInserirGrupo(g) + ",");
            }

            ExecutarComandoFinal(stringBuilder, "INSERT grupo");
        }
        public void InserirTabelaSubGrupo(List<SubGrupo> grupos)
        {
            ExecutarComando("TRUNCATE subgrupo;", CommandType.Text, "TRUNCATE subgrupo");

            string comando = @"INSERT INTO subgrupo (id, IdSubGrupo, Nome, IdGrupo) 
            VALUES ";

            StringBuilder stringBuilder = new StringBuilder(comando);

            foreach (SubGrupo s in grupos)
            {
                stringBuilder.AppendLine(HelperArvoreMercadologica.RetornarLinhaInserirSubGrupo(s) + ",");
            }

            ExecutarComandoFinal(stringBuilder, "INSERT subgrupo");
        }
        public void InserirTabelaSubGrupo1(List<SubGrupo1> grupos)
        {
            ExecutarComando("TRUNCATE subgrupo1;", CommandType.Text, "TRUNCATE subgrupo1");

            string comando = @"INSERT INTO subgrupo1 (id, idsubgrupo1, nome, idgrupo, idsubgrupo) 
            VALUES ";

            StringBuilder stringBuilder = new StringBuilder(comando);

            foreach (SubGrupo1 s1 in grupos)
            {
                stringBuilder.AppendLine(HelperArvoreMercadologica.RetornarLinhaInserirSubGrupo1(s1) + ",");
            }

            ExecutarComandoFinal(stringBuilder, "INSERT subgrupo1");
        }
        public void InserirTabelaCliente(List<Cliente> clientes)
        {
            ExecutarComando("TRUNCATE cliente;", CommandType.Text, "TRUNCATE cliente");

            string comando = @"INSERT INTO cliente(
                    idcliente, nome, fantasia, endereco, numero, bairro, cidade, codmunicipio, uf,
                    cep, cpf, rg, credito, limite, dt_nasc, usado, obs, empresa_convenio, loja, tipo, tipofidelidade, condicaoPagamento,
                    fone, celular, email
                    ) VALUES ";

            StringBuilder stringBuilder = new StringBuilder(comando);

            int contLote = 0;

            foreach (Cliente c in clientes)
            {
                stringBuilder.AppendLine(HelperCliente.RetornarLinhaInserirCliente(c) + ",");
                contLote++;

                if (contLote == 1000)
                {
                    ExecutarComandoFinal(stringBuilder, "INSERT cliente");
                    stringBuilder = new StringBuilder(comando);
                    contLote = 0;
                }
                else
                    continue;
            }

            if (contLote > 0)
            {
                ExecutarComandoFinal(stringBuilder, "INSERT produto");
            }
        }
        public List<Grupo> RetornarGrupos()
        {
            string comando = @"SELECT IDGRUPO, NOME FROM grupo;";
            List<Grupo> lstGrupos = new List<Grupo>();

            try
            {
                using (MySqlDataReader rdr = new MySqlCommand(comando, _conexao).ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        lstGrupos.Add(new Grupo() { Id = Convert.ToInt32(rdr["IDGRUPO"]), Descricao = rdr["NOME"].ToString() });
                    }
                }

                return lstGrupos;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível recuperar a lista de grupos inseridos");
                MessageBox.Show(ex.Message);
                return lstGrupos;
            }
        }
        public List<SubGrupo> RetornarSubGrupos()
        {
            string comando = @"SELECT Id, Nome, IdGrupo FROM subgrupo;";
            List<SubGrupo> lstSubGrupos = new List<SubGrupo>();

            try
            {
                using (MySqlDataReader rdr = new MySqlCommand(comando, _conexao).ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        lstSubGrupos.Add(new SubGrupo() { Id = Convert.ToInt32(rdr["Id"]), Descricao = rdr["Nome"].ToString(), IdGrupo = Convert.ToInt32(rdr["idGrupo"])  });
                    }
                }

                return lstSubGrupos;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível recuperar a lista de grupos inseridos");
                MessageBox.Show(ex.Message);
                return lstSubGrupos;
            }
        }
        public List<SubGrupo1> RetornarSubGrupos1()
        {
            string comando = @"SELECT id, nome, idgrupo, idsubgrupo FROM subgrupo1;";
            List<SubGrupo1> lstSubGrupos1 = new List<SubGrupo1>();

            try
            {
                using (MySqlDataReader rdr = new MySqlCommand(comando, _conexao).ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        lstSubGrupos1.Add(new SubGrupo1() { Id = Convert.ToInt32(rdr["id"]), Descricao = rdr["nome"].ToString(), IdGrupo = Convert.ToInt32(rdr["idgrupo"]), IdSubGrupo = Convert.ToInt32(rdr["idsubgrupo"]) });
                    }
                }

                return lstSubGrupos1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível recuperar a lista de grupos inseridos");
                MessageBox.Show(ex.Message);
                return lstSubGrupos1;
            }
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
