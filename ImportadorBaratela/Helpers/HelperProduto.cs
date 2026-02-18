using ImportadorBaratela.Models.Tabelas;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace ImportadorBaratela.Helpers
{
    public static class HelperProduto
    {
        public static string RetornarLinhaInserirProduto(Produto p)
        {
            StringBuilder sb = new StringBuilder("(");
            sb.Append($"{p.IdProduto},");
            sb.Append($"'{p.Descricao}',");
            sb.Append($"'{p.DescricaoReduzida}',");
            sb.Append($"{FormatarCampoDecimal(p.EmbEntrada.ToString())},");
            sb.Append($"{FormatarCampoDecimal(p.EmbSaida.ToString())},");
            sb.Append($"'{p.UnidEntrada}',");
            sb.Append($"'{p.UnidSaida}',");
            sb.Append($"'{p.Obs}',");
            sb.Append($"{p.Validade},");
            sb.Append($"{p.IdGrupo},");
            sb.Append($"{p.IdSubGrupo},");
            sb.Append($"{p.IdSubGrupo1},");
            sb.Append($"{p.IdSituacao},");
            sb.Append($"'{p.DtCadastro}',");
            sb.Append($"{p.PesoVariavel},");
            sb.Append($"{p.Etiqueta},");
            sb.Append($"'{p.Ean}',");
            sb.Append($"'{p.ClassFiscal}',");
            sb.Append($"'{p.Cest}',");
            sb.Append($"{p.Vasilhame},");
            sb.Append($"'{p.Tipo}',");
            sb.Append($"{p.IdFamilia}");

            sb.Append(")");
            return sb.ToString();
        }
        public static string RetornarLinhaInserirPreco(ProdutoPreco p)
        {
            StringBuilder sb = new StringBuilder("(");
            sb.Append($"{p.IdProduto},");
            sb.Append($"{p.IdLoja},");
            sb.Append($"{FormatarCampoDecimal(p.Custo.ToString())},");
            sb.Append($"{FormatarCampoDecimal(p.CustoMedio.ToString())},");
            sb.Append($"{FormatarCampoDecimal(p.Venda1.ToString())},");
            sb.Append($"{FormatarCampoDecimal(p.Venda2.ToString())},");
            sb.Append($"'{p.DtInicioPromo}',");
            sb.Append($"'{p.DtFinalPromo}',");
            sb.Append($"{FormatarCampoDecimal(p.Margem.ToString())},");
            sb.Append($"{p.IdFamilia}");

            sb.Append(")");
            return sb.ToString();
        }
        public static string RetornarLinhaInserirEstoque(ProdutoEstoque e)
        {
            StringBuilder sb = new StringBuilder("(");
            sb.Append($"{e.IdProduto},");
            sb.Append($"{e.IdLoja},");
            sb.Append($"{FormatarCampoDecimal(e.EstoqueAtual.ToString())},");
            sb.Append($"{FormatarCampoDecimal(e.EstoqueMinimo.ToString())}");
            sb.Append(")");
            return sb.ToString();
        }
        public static string RetornarLinhaInserirTributacao(ProdutoTributacao t)
        {
            StringBuilder sb = new StringBuilder("(");
            sb.Append($"{t.IdProduto},");
            sb.Append($"{t.IdLoja},");
            sb.Append($"'{t.OrigemProduto}',");
            sb.Append($"'{t.TipoProd}',");
            sb.Append($"{t.SitTribCompra},");
            sb.Append($"{FormatarCampoDecimal(t.IcmsCompra.ToString())},");
            sb.Append($"{FormatarCampoDecimal(t.RedBase.ToString())},");
            sb.Append($"'{t.TabIcmsProdEntrada}',");
            sb.Append($"{t.SitTrib},");
            sb.Append($"{FormatarCampoDecimal(t.Icms.ToString())},");
            sb.Append($"{FormatarCampoDecimal(t.RedBaseVenda.ToString())},");
            sb.Append($"'{t.TabIcmsProd}',");
            sb.Append($"'{t.CodTrib}',");
            sb.Append($"{t.Ipi},");
            sb.Append($"{t.Iva},");
            sb.Append($"'{t.TipoPisCofins}',");
            sb.Append($"'{t.CstPis}',");
            sb.Append($"'{t.CstPisSaida}',");
            sb.Append($"'{t.CcsApurada}',");
            sb.Append($"{t.CargaTributariaFederal},");
            sb.Append($"{t.CargaTributaria},");
            sb.Append($"'{t.ChaveNCM}',");
            sb.Append($"'{t.CstIpiSaida}',");
            sb.Append($"'{t.CstIpiEntrada}',");
            sb.Append($"'{t.TipoIva}',");
            sb.Append($"'{t.CalculaIvaAjustado}',");
            sb.Append($"'{t.NatReceita}',");
            sb.Append($"{t.Fecoep},");
            sb.Append($"{t.Pis},");
            sb.Append($"{t.Cofins},");
            sb.Append($"{t.PisEntrada},");
            sb.Append($"{t.CofinsEntrada}");

            sb.Append($")");
            return sb.ToString();
        }
        public static int RetornarSitTrib(string natFiscal)
        {
            switch (natFiscal)
            {
                case "T18":
                    return 1;
                case "T25":
                    return 2;
                case "T12":
                    return 3;
                case "T07":
                    return 4;
                case "I":
                    return 5;
                case "F18":
                default:
                    return 6;
            }
        }
        public static string RetornarTabIcms(decimal aliq, bool reducao = false)
        {
            if (reducao)
                return "20 - COM REDUÇÃO DE BASE DE CALCULO";

            switch (aliq)
            {
                case 18:
                case 25:
                case 12:
                case 7:
                    return "00 - TRIBUTADA INTEGRALMENTE";
                default:
                    return "60 - ICMS COBRADO ANT. POR SUBST. TRIB.";
            }
        }
        public static string RetornarCodTrib(decimal natReceita)
        {
            switch (natReceita)
            {
                case 18:
                    return "00";
                case 25:
                    return "07";
                case 12:
                    return "08";
                case 7:
                    return "09";
                case -1:
                    return "05";
                case 0:
                default:
                    return "04";
            }
        }
        public static decimal ValidarAliq(decimal aliq)
        {
            switch (aliq)
            {
                case 18:
                case 25:
                case 12:
                case 7:
                    return aliq;
                default:
                    return 0M;
            }
        }
        public static string RetornarCstPisEntrada(string pisCofins)
        {
            switch (pisCofins)
            {
                case "M":
                    return "70 - Operação de Aquisição sem Direito a Crédito";
                case "T":
                    return "50 - Operação com Direito a Crédito - Vinculada Exclusivamente a Receita Tributada no Mercado Interno";
                case "S":
                    return "75 - Operação de Aquisição por Substituição Tributária";
                case "N":
                    return "74 - Operação de Aquisição sem Incidência da Contribuição";
                case "I":
                    return "73 - Operação de Aquisição a Alíquota Zero";
                default:
                    return "98 - Outras Operações de Entrada";
            }
        }
        public static string RetornarCstPisSaida(string pisCofins)
        {
            switch (pisCofins)
            {
                case "M":
                    return "04 - Operação Tributável Monofásica - Revenda a Alíquota Zero";
                case "T":
                    return "01 - Operação Tributável com Alíquota Básica";
                case "S":
                    return "05 - Operação Tributável por Substituição Tributária";
                case "N":
                    return "08 - Operação sem Incidência da Contribuição";
                case "I":
                    return "06 - Operação Tributável a Alíquota Zero";
                default:
                    return "49 - Outras Operações de Saída";
            }
        }
        static string FormatarCampoDecimal(string valor)
        {
            return valor.Replace(".", "#").Replace(",", ".").Replace("#", "");
        }

    }
}
