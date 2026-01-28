using ImportadorBaratela.Models.Tabelas;
using System.Text;

namespace ImportadorBaratela.Helpers
{
    public static class HelperCliente
    {
        public static string RetornarLinhaInserirCliente(Cliente c)
        {
            StringBuilder sb = new StringBuilder("(");
            sb.Append($"{c.Id},");
            sb.Append($"'{c.Nome}',");
            sb.Append($"'{c.Fantasia}',");
            sb.Append($"'{c.Endereco}',");
            sb.Append($"'{c.Numero}',");
            sb.Append($"'{c.Bairro}',");
            sb.Append($"'{c.Cidade}',");
            sb.Append($"{c.CodMunicipio},");
            sb.Append($"'{c.UF}',");
            sb.Append($"'{c.CEP}',");
            sb.Append($"'{c.CPF}',");
            sb.Append($"'{c.RG}',");
            sb.Append($"{c.Credito},");
            sb.Append($"{c.Limite},");
            sb.Append($"'{c.DtNascimento}',");
            sb.Append($"{c.Usado},");
            sb.Append($"'{c.Obs}',");
            sb.Append($"{c.EmpresaConvenio},");
            sb.Append($"{c.Loja},");
            sb.Append($"'{c.Tipo}',");
            sb.Append($"{c.TipoFidelidade},");
            sb.Append($"'{c.CondicaoPagamento}',");
            sb.Append($"'{c.Fone}',");
            sb.Append($"'{c.Celular}',");
            sb.Append($"'{c.Email}'");

            sb.Append(")");
            return sb.ToString();
        }
    }
}
