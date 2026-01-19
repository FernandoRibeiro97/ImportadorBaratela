using ImportadorBaratela.Models.Tabelas;
using System.Text;

namespace ImportadorBaratela.Helpers
{
    public static class HelperArvoreMercadologica
    {
        public static string RetornarLinhaInserirGrupo(Grupo g)
        {
            StringBuilder sb = new StringBuilder("(");
            sb.Append($"{g.Id},");
            sb.Append($"'{g.Descricao}'");
            sb.Append(")");
            return sb.ToString();
        }
        public static string RetornarLinhaInserirSubGrupo(SubGrupo s)
        {
            StringBuilder sb = new StringBuilder("(");
            sb.Append($"{s.Id},");
            sb.Append($"{s.Id},");
            sb.Append($"'{s.Descricao}',");
            sb.Append($"{s.IdGrupo}");
            sb.Append(")");
            return sb.ToString();
        }
        public static string RetornarLinhaInserirSubGrupo1(SubGrupo1 s1)
        {
            StringBuilder sb = new StringBuilder("(");
            sb.Append($"{s1.Id},");
            sb.Append($"{s1.Id},");
            sb.Append($"'{s1.Descricao}',");
            sb.Append($"{s1.IdGrupo},");
            sb.Append($"{s1.IdSubGrupo}");
            sb.Append(")");
            return sb.ToString();
        }
    }
}
