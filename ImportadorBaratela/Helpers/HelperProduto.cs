using ImportadorBaratela.Models.Tabelas;
using System.Text;

namespace ImportadorBaratela.Helpers
{
    public static class HelperProduto
    {
        public static string RetornaLinhaInserirProduto(Produto p)
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
            sb.Append($"'{p.Tipo}'");

            sb.Append(")");
            return sb.ToString();
        }
        static string FormatarCampoDecimal(string valor)
        {
            return valor.Replace(".", "#").Replace(",", ".").Replace("#", "");
        }
    }
}
